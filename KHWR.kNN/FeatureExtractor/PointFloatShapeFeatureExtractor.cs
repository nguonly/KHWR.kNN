using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KHWR.kNN.Common;

namespace KHWR.kNN.FeatureExtractor
{
  public class PointFloatShapeFeatureExtractor
  {
    private float _eps = 0.00001f;
    private float _preprocNormalizeSize = 10f;

     public IList<PointFloatShapeFeature> ExtractFeature(TraceGroup inTraceGroup)
     {
       var outVector = new List<PointFloatShapeFeature>();
       float x, y, deltaX;
       float sinTheta, cosTheta, sqSum;
       var numPoints = 0;

       foreach(var trace in inTraceGroup.Traces)
       {
         numPoints += trace.ChannelX.Count;
       }

       var xVec = new List<float>(numPoints);
       var yVec = new List<float>(numPoints);
       var penUpVec = new List<bool>();

       foreach(var trace in inTraceGroup.Traces)
       {
         var tempxVec = trace.ChannelX;
         var tempyVec = trace.ChannelY;
         var currentStrokeSize = tempxVec.Count;

         for(var point=0; point<currentStrokeSize;point++)
         {
           xVec.Add(tempxVec[point]);
           yVec.Add(tempyVec[point]);

           if(point == currentStrokeSize-1)
           {
             penUpVec.Add(true);
           }else
           {
             penUpVec.Add(false);
           }
         }
       }

       //Concatenating the strokes
       var theta = new List<float>(numPoints);
       var delta_x = new List<float>(numPoints);
       var delta_y = new List<float>(numPoints);

       for (var i = 0; i < numPoints - 1;i++ )
       {
         delta_x.Add( xVec[i + 1] - xVec[i]);
         delta_y.Add( yVec[i + 1] - yVec[i]);
       }

       //Add the control info here
       sqSum = (float)Math.Sqrt(Math.Pow(xVec[0], 2) + Math.Pow(yVec[0], 2)) + _eps;
       sinTheta = (1 + yVec[0]/sqSum)*_preprocNormalizeSize/2;
       cosTheta = (1 + xVec[0]/sqSum)*_preprocNormalizeSize/2;

       var feature = new PointFloatShapeFeature
                       {X = xVec[0], Y = yVec[0], SinTheta = sinTheta, CosTheta = cosTheta, IsPenUp = penUpVec[0]};

       outVector.Add(feature);

       for (var i = 1; i < numPoints; i++ )
       {
         sqSum = (float)Math.Sqrt(Math.Pow(delta_x[i-1], 2) + Math.Pow(delta_y[i-1], 2)) + _eps;
         sinTheta = (1 + delta_y[i-1] / sqSum) * _preprocNormalizeSize / 2;
         cosTheta = (1 + delta_x[i-1] / sqSum) * _preprocNormalizeSize / 2;

         feature = new PointFloatShapeFeature { X = xVec[i], Y = yVec[i], SinTheta = sinTheta, CosTheta = cosTheta, IsPenUp = penUpVec[i] };
         outVector.Add(feature);
       }

       return outVector;
     }

    public float ComputeEuclideanDistance(IList<PointFloatShapeFeature> firstFeatures, IList<PointFloatShapeFeature> secondFeathers)
    {
      var eucDistance = 0f;

      var firstVecSize = firstFeatures.Count;
      var secondVecSize = secondFeathers.Count;

      if(firstVecSize!=secondVecSize)
      {
        //Not yet sampling
      }

      for (var i = 0; i < firstVecSize; i++ )
      {
        var tempDistance = 0f;
        tempDistance = firstFeatures[i].GetDistance(secondFeathers[i]);
        eucDistance += tempDistance;
      }

      return eucDistance;
    }

    
  }
}
