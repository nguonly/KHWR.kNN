namespace KHWR.kNN.View
{
  partial class PreProcessForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.grbDrawing = new System.Windows.Forms.GroupBox();
      this.btnDrawingClear = new System.Windows.Forms.Button();
      this.pnlDrawing = new System.Windows.Forms.Panel();
      this.btnSmooth = new System.Windows.Forms.Button();
      this.btnReSampling = new System.Windows.Forms.Button();
      this.grbResult = new System.Windows.Forms.GroupBox();
      this.pnlResult = new System.Windows.Forms.Panel();
      this.txtDrawingRaw = new System.Windows.Forms.TextBox();
      this.txtDrawingResult = new System.Windows.Forms.TextBox();
      this.txtFeature = new System.Windows.Forms.TextBox();
      this.btnFeature = new System.Windows.Forms.Button();
      this.btnLoadRecognizerForm = new System.Windows.Forms.Button();
      this.btnEuclidean = new System.Windows.Forms.Button();
      this.chkIsNormalized = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.btnTest = new System.Windows.Forms.Button();
      this.grbDrawing.SuspendLayout();
      this.grbResult.SuspendLayout();
      this.SuspendLayout();
      // 
      // grbDrawing
      // 
      this.grbDrawing.Controls.Add(this.btnDrawingClear);
      this.grbDrawing.Controls.Add(this.pnlDrawing);
      this.grbDrawing.Location = new System.Drawing.Point(12, 12);
      this.grbDrawing.Name = "grbDrawing";
      this.grbDrawing.Size = new System.Drawing.Size(272, 281);
      this.grbDrawing.TabIndex = 0;
      this.grbDrawing.TabStop = false;
      this.grbDrawing.Text = "Drawing Area";
      // 
      // btnDrawingClear
      // 
      this.btnDrawingClear.Location = new System.Drawing.Point(21, 242);
      this.btnDrawingClear.Name = "btnDrawingClear";
      this.btnDrawingClear.Size = new System.Drawing.Size(75, 23);
      this.btnDrawingClear.TabIndex = 1;
      this.btnDrawingClear.Text = "Clear";
      this.btnDrawingClear.UseVisualStyleBackColor = true;
      this.btnDrawingClear.Click += new System.EventHandler(this.btnDrawingClear_Click);
      // 
      // pnlDrawing
      // 
      this.pnlDrawing.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pnlDrawing.Location = new System.Drawing.Point(21, 36);
      this.pnlDrawing.Name = "pnlDrawing";
      this.pnlDrawing.Size = new System.Drawing.Size(200, 200);
      this.pnlDrawing.TabIndex = 0;
      // 
      // btnSmooth
      // 
      this.btnSmooth.Location = new System.Drawing.Point(305, 62);
      this.btnSmooth.Name = "btnSmooth";
      this.btnSmooth.Size = new System.Drawing.Size(75, 23);
      this.btnSmooth.TabIndex = 1;
      this.btnSmooth.Text = "Smooth";
      this.btnSmooth.UseVisualStyleBackColor = true;
      this.btnSmooth.Click += new System.EventHandler(this.btnSmooth_Click);
      // 
      // btnReSampling
      // 
      this.btnReSampling.Location = new System.Drawing.Point(305, 91);
      this.btnReSampling.Name = "btnReSampling";
      this.btnReSampling.Size = new System.Drawing.Size(75, 23);
      this.btnReSampling.TabIndex = 2;
      this.btnReSampling.Text = "ReSampling";
      this.btnReSampling.UseVisualStyleBackColor = true;
      this.btnReSampling.Click += new System.EventHandler(this.btnReSampling_Click);
      // 
      // grbResult
      // 
      this.grbResult.Controls.Add(this.pnlResult);
      this.grbResult.Location = new System.Drawing.Point(402, 12);
      this.grbResult.Name = "grbResult";
      this.grbResult.Size = new System.Drawing.Size(272, 281);
      this.grbResult.TabIndex = 1;
      this.grbResult.TabStop = false;
      this.grbResult.Text = "Result";
      // 
      // pnlResult
      // 
      this.pnlResult.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.pnlResult.Location = new System.Drawing.Point(21, 36);
      this.pnlResult.Name = "pnlResult";
      this.pnlResult.Size = new System.Drawing.Size(200, 200);
      this.pnlResult.TabIndex = 0;
      // 
      // txtDrawingRaw
      // 
      this.txtDrawingRaw.Location = new System.Drawing.Point(33, 319);
      this.txtDrawingRaw.Multiline = true;
      this.txtDrawingRaw.Name = "txtDrawingRaw";
      this.txtDrawingRaw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtDrawingRaw.Size = new System.Drawing.Size(200, 312);
      this.txtDrawingRaw.TabIndex = 3;
      // 
      // txtDrawingResult
      // 
      this.txtDrawingResult.Location = new System.Drawing.Point(423, 319);
      this.txtDrawingResult.Multiline = true;
      this.txtDrawingResult.Name = "txtDrawingResult";
      this.txtDrawingResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtDrawingResult.Size = new System.Drawing.Size(200, 312);
      this.txtDrawingResult.TabIndex = 4;
      // 
      // txtFeature
      // 
      this.txtFeature.Location = new System.Drawing.Point(721, 319);
      this.txtFeature.Multiline = true;
      this.txtFeature.Name = "txtFeature";
      this.txtFeature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtFeature.Size = new System.Drawing.Size(272, 312);
      this.txtFeature.TabIndex = 5;
      // 
      // btnFeature
      // 
      this.btnFeature.Location = new System.Drawing.Point(629, 373);
      this.btnFeature.Name = "btnFeature";
      this.btnFeature.Size = new System.Drawing.Size(75, 23);
      this.btnFeature.TabIndex = 6;
      this.btnFeature.Text = "Feature";
      this.btnFeature.UseVisualStyleBackColor = true;
      this.btnFeature.Click += new System.EventHandler(this.btnFeature_Click);
      // 
      // btnLoadRecognizerForm
      // 
      this.btnLoadRecognizerForm.Location = new System.Drawing.Point(762, 62);
      this.btnLoadRecognizerForm.Name = "btnLoadRecognizerForm";
      this.btnLoadRecognizerForm.Size = new System.Drawing.Size(150, 23);
      this.btnLoadRecognizerForm.TabIndex = 7;
      this.btnLoadRecognizerForm.Text = "Load Recognizer Form";
      this.btnLoadRecognizerForm.UseVisualStyleBackColor = true;
      this.btnLoadRecognizerForm.Click += new System.EventHandler(this.btnLoadRecognizerForm_Click);
      // 
      // btnEuclidean
      // 
      this.btnEuclidean.Location = new System.Drawing.Point(762, 166);
      this.btnEuclidean.Name = "btnEuclidean";
      this.btnEuclidean.Size = new System.Drawing.Size(75, 23);
      this.btnEuclidean.TabIndex = 8;
      this.btnEuclidean.Text = "Euclidean";
      this.btnEuclidean.UseVisualStyleBackColor = true;
      this.btnEuclidean.Click += new System.EventHandler(this.btnEuclidean_Click);
      // 
      // chkIsNormalized
      // 
      this.chkIsNormalized.AutoSize = true;
      this.chkIsNormalized.Location = new System.Drawing.Point(853, 172);
      this.chkIsNormalized.Name = "chkIsNormalized";
      this.chkIsNormalized.Size = new System.Drawing.Size(89, 17);
      this.chkIsNormalized.TabIndex = 9;
      this.chkIsNormalized.Text = "Is Normalized";
      this.chkIsNormalized.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 300);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(101, 13);
      this.label1.TabIndex = 10;
      this.label1.Text = "Raw Unipen Format";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(423, 300);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(175, 13);
      this.label2.TabIndex = 11;
      this.label2.Text = "Unipen Format After Pre-Processing";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(721, 300);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(93, 13);
      this.label3.TabIndex = 12;
      this.label3.Text = "Feature Extraction";
      // 
      // btnTest
      // 
      this.btnTest.Location = new System.Drawing.Point(762, 225);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(150, 23);
      this.btnTest.TabIndex = 14;
      this.btnTest.Text = "Test Recognizer";
      this.btnTest.UseVisualStyleBackColor = true;
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // PreProcessForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1005, 649);
      this.Controls.Add(this.btnTest);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.chkIsNormalized);
      this.Controls.Add(this.btnEuclidean);
      this.Controls.Add(this.btnLoadRecognizerForm);
      this.Controls.Add(this.btnFeature);
      this.Controls.Add(this.txtFeature);
      this.Controls.Add(this.txtDrawingResult);
      this.Controls.Add(this.txtDrawingRaw);
      this.Controls.Add(this.grbResult);
      this.Controls.Add(this.btnReSampling);
      this.Controls.Add(this.btnSmooth);
      this.Controls.Add(this.grbDrawing);
      this.Name = "PreProcessForm";
      this.Text = "PreProcessForm";
      this.grbDrawing.ResumeLayout(false);
      this.grbResult.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox grbDrawing;
    private System.Windows.Forms.Panel pnlDrawing;
    private System.Windows.Forms.Button btnSmooth;
    private System.Windows.Forms.Button btnReSampling;
    private System.Windows.Forms.GroupBox grbResult;
    private System.Windows.Forms.Panel pnlResult;
    private System.Windows.Forms.Button btnDrawingClear;
    private System.Windows.Forms.TextBox txtDrawingRaw;
    private System.Windows.Forms.TextBox txtDrawingResult;
    private System.Windows.Forms.TextBox txtFeature;
    private System.Windows.Forms.Button btnFeature;
    private System.Windows.Forms.Button btnLoadRecognizerForm;
    private System.Windows.Forms.Button btnEuclidean;
    private System.Windows.Forms.CheckBox chkIsNormalized;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnTest;
  }
}