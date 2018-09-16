namespace FutebolDeRobosVSS
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageBoxHsv = new Emgu.CV.UI.ImageBox();
            this.imageBoxGray = new Emgu.CV.UI.ImageBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageBoxOriginal = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxHsv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Camera";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(216, 583);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Conectar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageBoxHsv
            // 
            this.imageBoxHsv.Location = new System.Drawing.Point(684, 12);
            this.imageBoxHsv.Name = "imageBoxHsv";
            this.imageBoxHsv.Size = new System.Drawing.Size(480, 270);
            this.imageBoxHsv.TabIndex = 4;
            this.imageBoxHsv.TabStop = false;
            // 
            // imageBoxGray
            // 
            this.imageBoxGray.Location = new System.Drawing.Point(684, 323);
            this.imageBoxGray.Name = "imageBoxGray";
            this.imageBoxGray.Size = new System.Drawing.Size(480, 270);
            this.imageBoxGray.TabIndex = 5;
            this.imageBoxGray.TabStop = false;
            this.imageBoxGray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grayImageBox_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 586);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onKeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // imageBoxOriginal
            // 
            this.imageBoxOriginal.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxOriginal.Location = new System.Drawing.Point(12, 12);
            this.imageBoxOriginal.Name = "imageBoxOriginal";
            this.imageBoxOriginal.Size = new System.Drawing.Size(480, 270);
            this.imageBoxOriginal.TabIndex = 1;
            this.imageBoxOriginal.TabStop = false;
            this.imageBoxOriginal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.originalImageBox_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1601, 1057);
            this.Controls.Add(this.imageBoxOriginal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.imageBoxGray);
            this.Controls.Add(this.imageBoxHsv);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxHsv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        //private Emgu.CV.UI.ImageBox imageBoxOriginal;
        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox imageBoxHsv;
        private Emgu.CV.UI.ImageBox imageBoxGray;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox imageBoxOriginal;
    }
}

