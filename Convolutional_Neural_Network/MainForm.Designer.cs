namespace Convolutional_Neural_Network
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_browseImage = new System.Windows.Forms.Button();
            this.textBox_imagePath = new System.Windows.Forms.TextBox();
            this.openFileDialog_BrowseImage = new System.Windows.Forms.OpenFileDialog();
            this.btn_analyze = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btn_browseImage
            // 
            this.btn_browseImage.Location = new System.Drawing.Point(256, 12);
            this.btn_browseImage.Name = "btn_browseImage";
            this.btn_browseImage.Size = new System.Drawing.Size(75, 20);
            this.btn_browseImage.TabIndex = 0;
            this.btn_browseImage.Text = "Browse...";
            this.btn_browseImage.UseVisualStyleBackColor = true;
            this.btn_browseImage.Click += new System.EventHandler(this.btn_browseImage_Click);
            // 
            // textBox_imagePath
            // 
            this.textBox_imagePath.Location = new System.Drawing.Point(12, 12);
            this.textBox_imagePath.Name = "textBox_imagePath";
            this.textBox_imagePath.Size = new System.Drawing.Size(238, 20);
            this.textBox_imagePath.TabIndex = 1;
            this.textBox_imagePath.TextChanged += new System.EventHandler(this.textBox_imagePath_TextChanged);
            // 
            // openFileDialog_BrowseImage
            // 
            this.openFileDialog_BrowseImage.Title = "Browse image";
            // 
            // btn_analyze
            // 
            this.btn_analyze.Enabled = false;
            this.btn_analyze.Location = new System.Drawing.Point(12, 38);
            this.btn_analyze.Name = "btn_analyze";
            this.btn_analyze.Size = new System.Drawing.Size(319, 62);
            this.btn_analyze.TabIndex = 2;
            this.btn_analyze.Text = "Analyze";
            this.btn_analyze.UseVisualStyleBackColor = true;
            this.btn_analyze.Click += new System.EventHandler(this.btn_analyze_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 310);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_analyze);
            this.Controls.Add(this.textBox_imagePath);
            this.Controls.Add(this.btn_browseImage);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convolution Neural Network v0.8";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browseImage;
        private System.Windows.Forms.TextBox textBox_imagePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog_BrowseImage;
        private System.Windows.Forms.Button btn_analyze;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

