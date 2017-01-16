namespace MMFair
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.sourceFileChooseButton = new System.Windows.Forms.Button();
			this.sourceFileNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.outputFileChooseButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.outputFileNameTextBox = new System.Windows.Forms.TextBox();
			this.calcButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.sourceFileChooseButton);
			this.groupBox1.Controls.Add(this.sourceFileNameTextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(11, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(465, 86);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input File";
			// 
			// sourceFileChooseButton
			// 
			this.sourceFileChooseButton.Location = new System.Drawing.Point(373, 35);
			this.sourceFileChooseButton.Name = "sourceFileChooseButton";
			this.sourceFileChooseButton.Size = new System.Drawing.Size(75, 26);
			this.sourceFileChooseButton.TabIndex = 1;
			this.sourceFileChooseButton.Text = "...";
			this.sourceFileChooseButton.UseVisualStyleBackColor = true;
			// 
			// sourceFileNameTextBox
			// 
			this.sourceFileNameTextBox.Location = new System.Drawing.Point(91, 36);
			this.sourceFileNameTextBox.Name = "sourceFileNameTextBox";
			this.sourceFileNameTextBox.Size = new System.Drawing.Size(276, 26);
			this.sourceFileNameTextBox.TabIndex = 0;
			this.sourceFileNameTextBox.Text = "Sample.txt";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "File name";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.outputFileChooseButton);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.outputFileNameTextBox);
			this.groupBox2.Location = new System.Drawing.Point(11, 106);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(465, 86);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Output File";
			// 
			// outputFileChooseButton
			// 
			this.outputFileChooseButton.Location = new System.Drawing.Point(373, 39);
			this.outputFileChooseButton.Name = "outputFileChooseButton";
			this.outputFileChooseButton.Size = new System.Drawing.Size(75, 26);
			this.outputFileChooseButton.TabIndex = 1;
			this.outputFileChooseButton.Text = "...";
			this.outputFileChooseButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "File name";
			// 
			// outputFileNameTextBox
			// 
			this.outputFileNameTextBox.Location = new System.Drawing.Point(91, 40);
			this.outputFileNameTextBox.Name = "outputFileNameTextBox";
			this.outputFileNameTextBox.Size = new System.Drawing.Size(276, 26);
			this.outputFileNameTextBox.TabIndex = 0;
			this.outputFileNameTextBox.Text = "Output.txt";
			// 
			// calcButton
			// 
			this.calcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.calcButton.Location = new System.Drawing.Point(358, 212);
			this.calcButton.Name = "calcButton";
			this.calcButton.Size = new System.Drawing.Size(118, 26);
			this.calcButton.TabIndex = 2;
			this.calcButton.Text = "Calculate";
			this.calcButton.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 250);
			this.Controls.Add(this.calcButton);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Tahoma", 9F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MMF";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button sourceFileChooseButton;
		private System.Windows.Forms.TextBox sourceFileNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button outputFileChooseButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox outputFileNameTextBox;
		private System.Windows.Forms.Button calcButton;
	}
}

