namespace KHWR.kNN.View
{
  partial class RecognizerForm
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
      this.chkAutoRecognize = new System.Windows.Forms.CheckBox();
      this.btnRecognizer = new System.Windows.Forms.Button();
      this.btnDrawingClear = new System.Windows.Forms.Button();
      this.pnlDrawing = new System.Windows.Forms.Panel();
      this.btnTrain = new System.Windows.Forms.Button();
      this.grbResult = new System.Windows.Forms.GroupBox();
      this.lblGuessChar = new System.Windows.Forms.Label();
      this.lblResult = new System.Windows.Forms.Label();
      this.grbDrawing.SuspendLayout();
      this.grbResult.SuspendLayout();
      this.SuspendLayout();
      // 
      // grbDrawing
      // 
      this.grbDrawing.Controls.Add(this.chkAutoRecognize);
      this.grbDrawing.Controls.Add(this.btnRecognizer);
      this.grbDrawing.Controls.Add(this.btnDrawingClear);
      this.grbDrawing.Controls.Add(this.pnlDrawing);
      this.grbDrawing.Location = new System.Drawing.Point(12, 64);
      this.grbDrawing.Name = "grbDrawing";
      this.grbDrawing.Size = new System.Drawing.Size(260, 306);
      this.grbDrawing.TabIndex = 1;
      this.grbDrawing.TabStop = false;
      this.grbDrawing.Text = "Drawing Area";
      // 
      // chkAutoRecognize
      // 
      this.chkAutoRecognize.AutoSize = true;
      this.chkAutoRecognize.Location = new System.Drawing.Point(146, 271);
      this.chkAutoRecognize.Name = "chkAutoRecognize";
      this.chkAutoRecognize.Size = new System.Drawing.Size(102, 17);
      this.chkAutoRecognize.TabIndex = 3;
      this.chkAutoRecognize.Text = "Auto Recognize";
      this.chkAutoRecognize.UseVisualStyleBackColor = true;
      // 
      // btnRecognizer
      // 
      this.btnRecognizer.Location = new System.Drawing.Point(146, 242);
      this.btnRecognizer.Name = "btnRecognizer";
      this.btnRecognizer.Size = new System.Drawing.Size(75, 23);
      this.btnRecognizer.TabIndex = 2;
      this.btnRecognizer.Text = "Recognize";
      this.btnRecognizer.UseVisualStyleBackColor = true;
      this.btnRecognizer.Click += new System.EventHandler(this.btnRecognizer_Click);
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
      // btnTrain
      // 
      this.btnTrain.Location = new System.Drawing.Point(33, 12);
      this.btnTrain.Name = "btnTrain";
      this.btnTrain.Size = new System.Drawing.Size(75, 23);
      this.btnTrain.TabIndex = 2;
      this.btnTrain.Text = "Train";
      this.btnTrain.UseVisualStyleBackColor = true;
      this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
      // 
      // grbResult
      // 
      this.grbResult.Controls.Add(this.lblGuessChar);
      this.grbResult.Controls.Add(this.lblResult);
      this.grbResult.Location = new System.Drawing.Point(288, 12);
      this.grbResult.Name = "grbResult";
      this.grbResult.Size = new System.Drawing.Size(236, 358);
      this.grbResult.TabIndex = 3;
      this.grbResult.TabStop = false;
      this.grbResult.Text = "Result";
      // 
      // lblGuessChar
      // 
      this.lblGuessChar.AutoSize = true;
      this.lblGuessChar.Font = new System.Drawing.Font("Khmer OS Battambang", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGuessChar.ForeColor = System.Drawing.SystemColors.HotTrack;
      this.lblGuessChar.Location = new System.Drawing.Point(79, 16);
      this.lblGuessChar.Name = "lblGuessChar";
      this.lblGuessChar.Size = new System.Drawing.Size(90, 52);
      this.lblGuessChar.TabIndex = 1;
      this.lblGuessChar.Text = "Char";
      // 
      // lblResult
      // 
      this.lblResult.AutoSize = true;
      this.lblResult.Font = new System.Drawing.Font("Khmer OS Battambang", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblResult.Location = new System.Drawing.Point(6, 101);
      this.lblResult.Name = "lblResult";
      this.lblResult.Size = new System.Drawing.Size(77, 38);
      this.lblResult.TabIndex = 0;
      this.lblResult.Text = "Result";
      // 
      // RecognizerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(543, 393);
      this.Controls.Add(this.grbResult);
      this.Controls.Add(this.btnTrain);
      this.Controls.Add(this.grbDrawing);
      this.Name = "RecognizerForm";
      this.Text = "RecognizerForm";
      this.grbDrawing.ResumeLayout(false);
      this.grbDrawing.PerformLayout();
      this.grbResult.ResumeLayout(false);
      this.grbResult.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grbDrawing;
    private System.Windows.Forms.Button btnDrawingClear;
    private System.Windows.Forms.Panel pnlDrawing;
    private System.Windows.Forms.Button btnRecognizer;
    private System.Windows.Forms.Button btnTrain;
    private System.Windows.Forms.GroupBox grbResult;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.Label lblGuessChar;
    private System.Windows.Forms.CheckBox chkAutoRecognize;
  }
}