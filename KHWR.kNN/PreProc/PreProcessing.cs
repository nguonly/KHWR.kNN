using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KHWR.kNN.Common;
using KHWR.kNN.Enum;

namespace KHWR.kNN.PreProc
{
  public class PreProcessing
  {
    private bool _preserveAspectRatio;
    private float _eps = 0.00001f;
    private float _aspectRatioThreshold = 3.0f;
    private bool _preserveRelativeYPosition = false;
    private float _preprocNormalizeSize = 10f;
    private float _dotThreshold = 0.01f;
    private float _sizeThreshold = 0.01f;

    private int _traceDimension = 100;

    private int _quantizationStep = 5;

    private CaptureDevice _captureDevice;

    public PreProcessing()
    {
      _captureDevice = new CaptureDevice();
      _captureDevice.XDpi = 2000;
      _captureDevice.YDpi = 2000;
      _captureDevice.Latency = 0.0f;
      _captureDevice.SamplingRate = 100;

      _preserveAspectRatio = true;
    }

    public TraceGroup SmoothenTraceGroup(TraceGroup traceGroup)
    {
      var filterLength = 5;
      var newTraceGroup = new TraceGroup();
      var sumX = 0f;
      var sumY = 0f;
      var actualIndex = 0;
      foreach (var trace in traceGroup.Traces)
      {
        var newTrace = new Trace();
        var numPoints = trace.Points.Count;
        var channelX = trace.ChannelX;
        var channelY = trace.ChannelY;
        for(var pointIndex=0; pointIndex<numPoints; pointIndex++)
        {
          sumX = sumY = 0f;

          for(var loopIdex=0;loopIdex<filterLength;loopIdex++)
          {
            actualIndex = (pointIndex - loopIdex);
            if(actualIndex<0)
            {
              actualIndex = 0;
            }else if(actualIndex>=numPoints)
            {
              actualIndex = numPoints - 1;
            }

            //accumulate sum
            sumX += channelX[actualIndex];
            sumY += channelY[actualIndex];
          }

          sumX /= filterLength;
          sumY /= filterLength;

          
          newTrace.Points.Add(new PenPoint{X=sumX, Y=sumY});
        }
        newTraceGroup.Traces.Add(newTrace);
      }

      return newTraceGroup;
    }

    public Trace ResampleTrace(Trace inTrace, int resamplePoints)
    {
      var outTrace = new Trace();
      var xSum = 0f;
      var ySum = 0f;
      var x = 0f;
      var y = 0f;
      var numTracePoints = inTrace.Points.Count;

      var xDiff = 0f;
      var yDiff = 0f;
      var pointDistance = 0f;
      var unitLength = 0f;
      var distanceVec = new List<float>();
      var balanceDistance = 0f;  //	distance between the last resampled point and
                                //	the next raw sample point
      var measuredDistance = 0f;

      var m1 = 0f;
      var m2 = 0f;
      var ptIndex = 0;
      var currentPointIndex = 0;

      var xVec = inTrace.ChannelX;
      var yVec = inTrace.ChannelY;

      var xTemp = 0f;
      var yTemp = 0f;

      if(resamplePoints==1)
      {
        xSum = inTrace.GetSumX();
        ySum = inTrace.GetSumY();

        x = xSum/numTracePoints;
        y = ySum/numTracePoints;
        var penPoint = new PenPoint {X = x, Y = y};
        outTrace.Points.Add(penPoint);
      }else
      {
        for(var i=0;i<(numTracePoints-1);++i)
        {
          xDiff = inTrace.ChannelX[i] - inTrace.ChannelX[i + 1];
          yDiff = inTrace.ChannelY[i] - inTrace.ChannelY[i + 1];
          pointDistance = (float) Math.Sqrt(xDiff*xDiff + yDiff*yDiff);
          unitLength += pointDistance;
          distanceVec.Add(pointDistance);
        }

        unitLength /= (resamplePoints - 1);

        x = inTrace.ChannelX[0];
        y = inTrace.ChannelY[0];

        outTrace.Points.Add(new PenPoint{X=x, Y=y});

        for(var i=1; i<(resamplePoints-1); ++i)
        {
          measuredDistance = balanceDistance;

          while(measuredDistance<unitLength)
          {
            measuredDistance += distanceVec[ptIndex++];

            if (ptIndex == 1) currentPointIndex = 1;
            else currentPointIndex++;

          }

          if (ptIndex < 1) ptIndex = 1;

          m2 = measuredDistance - unitLength;
          m1 = distanceVec[ptIndex - 1] - m2;

          if(Math.Abs(m1+m2)>_eps)
          {
            xTemp = (m1*xVec[currentPointIndex] + m2*xVec[currentPointIndex - 1])/(m1 + m2);
            yTemp = (m1*yVec[currentPointIndex] + m2*yVec[currentPointIndex - 1])/(m1 + m2);
          }else
          {
            xTemp = xVec[currentPointIndex];
            yTemp = yVec[currentPointIndex];
          }

          outTrace.Points.Add(new PenPoint{X=xTemp, Y=yTemp});

          balanceDistance = m2;
        }

        x = xVec[xVec.Count - 1]; //adding x of last point
        y = yVec[yVec.Count - 1]; //adding y of last point

        outTrace.Points.Add(new PenPoint{X=x, Y=y});
      }

      return outTrace;
    }

    //public TraceGroup ResampleTraceGroup(TraceGroup inTraceGroup)
    //{
    //  var outTraceGroup = new TraceGroup();
    //  foreach(var trace in inTraceGroup.Traces)
    //  {
    //    var outTrace = ResampleTrace(trace, 60);
    //    outTraceGroup.Traces.Add(outTrace);
    //  }
    //  return outTraceGroup;
    //}

    public TraceGroup ResampleTraceGroup(TraceGroup inTraceGroup)
    {
      var total = 0;
      var totalLength = 0f;
      var totalPoints = 0;

      var numOfTraces = inTraceGroup.Traces.Count;

      //Implement length base scheme
      var maxIndex = 0;
      float maxLength = 0f;
      var lengthsVec = new List<float>();

      for(var j=0; j<numOfTraces; j++)
      {
        var trace = inTraceGroup.Traces[j];
        var length = ComputeTraceLength(trace, 0, trace.Points.Count-1);

        lengthsVec.Add(length);
        if (Math.Abs(lengthsVec[j]) < _eps) lengthsVec[j] = _eps;

        totalLength += lengthsVec[j];
        if(lengthsVec[j] > maxLength)
        {
          maxLength = lengthsVec[j];
          maxIndex = j;
        }
      }

      var pointsPerTrace = new List<int>();
      
      for(int i=0; i<numOfTraces; i++)
      {
        pointsPerTrace.Add(0);
        if(i!=maxIndex)
        {
          var tempPoints = _quantizationStep*
                              (int) (Math.Floor(_traceDimension*lengthsVec[i]/(_quantizationStep*totalLength)) + 0.5f);

          pointsPerTrace[i] = tempPoints;
          if (pointsPerTrace[i] <= 0) pointsPerTrace[i] = 1;

          total += pointsPerTrace[i];

        }
      }
      pointsPerTrace[maxIndex] = _traceDimension - total;

      int sum = 0;
      for(int temp = 0; temp<pointsPerTrace.Count; temp++)
      {
        sum += pointsPerTrace[temp];
      }

      var outTraceGroup = new TraceGroup();
      for(int i=0;i<numOfTraces;i++)
      {
        var trace = inTraceGroup.Traces[i];
        var newTrace = ResampleTrace(trace, pointsPerTrace[i]);
        outTraceGroup.Traces.Add(newTrace);
      }
      outTraceGroup.XScaleFactor = inTraceGroup.XScaleFactor;
      outTraceGroup.YScaleFactor = inTraceGroup.YScaleFactor;

      return outTraceGroup;
    }

    public float ComputeTraceLength(Trace trace, int fromPoint, int toPoint)
    {
      var noOfPoints = trace.Points.Count;
      
      if((fromPoint<0 || fromPoint>(noOfPoints-1))
        || (toPoint<0 ||toPoint>(noOfPoints-1)) )
      {
        //error
      }

      float xDiff, yDiff, pointDistance;
      IList<float> xVec, yVec;
      var outLength = 0f;

      xVec = trace.ChannelX;
      yVec = trace.ChannelY;
      
      for(var i=fromPoint;i<toPoint;i++)
      {
        xDiff = xVec[i] - xVec[i + 1];
        yDiff = yVec[i] - yVec[i + 1];

        //distance between 2 points
        pointDistance = (float)Math.Sqrt(xDiff*xDiff + yDiff*yDiff);

        outLength += pointDistance;
      }

      return outLength;
    }

    public TraceGroup NormalizeSize(TraceGroup inTraceGroup)
    {
      var outTraceGroup = new TraceGroup();
      var xScale = 0f;
      var yScale = 0f;
      var aspectRatio = 0f;
      float scaleX, scaleY, offsetX, offsetY;

      var box = inTraceGroup.GetBoundingBox();

      outTraceGroup = inTraceGroup;

      xScale = Math.Abs(box.XMax - box.XMin)/outTraceGroup.XScaleFactor;
      yScale = Math.Abs(box.YMax - box.YMin)/outTraceGroup.YScaleFactor;

      if(_preserveAspectRatio)
      {
        if(yScale>xScale)
        {
          aspectRatio = (xScale > _eps) ? (yScale/xScale): _aspectRatioThreshold+_eps;
        }else
        {
          aspectRatio = (yScale > _eps) ? (xScale/yScale) : _aspectRatioThreshold + _eps;
        }

        if(aspectRatio>_aspectRatioThreshold)
        {
          if (yScale > xScale) xScale = yScale;
          else yScale = xScale;
        }
      }

      offsetY = 0.0f;
      if (_preserveRelativeYPosition) offsetY = (box.YMin + box.YMax)/2.0f;

      if(xScale <= (_dotThreshold*_captureDevice.XDpi) && yScale<=(_dotThreshold*_captureDevice.YDpi))
      {
        offsetX = _preprocNormalizeSize/2;
        offsetY += _preprocNormalizeSize/2;

        outTraceGroup.Traces.Clear();

        foreach(var trace in inTraceGroup.Traces)
        {
          var normalizedTrace = new Trace();
          foreach(var point in trace.Points)
          {
            normalizedTrace.Points.Add(new PenPoint{X=offsetX, Y=offsetY});
          }
          outTraceGroup.Traces.Add(normalizedTrace);
        }
      }

      //finding the final scale and offset values for the x channel
      if((!_preserveAspectRatio) && (xScale<(_sizeThreshold*_captureDevice.XDpi)))
      {
        scaleX = 1.0f;
        offsetX = (float)(_preprocNormalizeSize/2.0);
      }else
      {
        scaleX = (float)(_preprocNormalizeSize / xScale);
        offsetX = 0.0f;
      }

      // finding the final scale and offset values for the y channel
      if((!_preserveAspectRatio) && (yScale<_sizeThreshold*_captureDevice.YDpi))
      {
        offsetY += _preprocNormalizeSize/2;
        scaleY = 1.0f;
      }else
      {
        scaleY = (float)(_preprocNormalizeSize/yScale);
      }

      outTraceGroup.AffineTransform(scaleX, scaleY, offsetX, offsetY, TraceGroupCornerEnum.XMin_YMin);

      return outTraceGroup;
    }

    public TraceGroup PreProcess(TraceGroup inTraceGroup)
    {
      var norm = NormalizeSize(inTraceGroup);
      var sampling = ResampleTraceGroup(norm);

      return sampling;
    }
  }
}
