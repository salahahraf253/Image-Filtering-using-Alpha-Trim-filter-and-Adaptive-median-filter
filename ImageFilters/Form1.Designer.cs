namespace ImageFilters
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.FilterBox = new System.Windows.Forms.ComboBox();
            this.window_size = new System.Windows.Forms.TextBox();
            this.Trim_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SortAlgoCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(13, 53);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 530);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnOpen.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.btnOpen.Location = new System.Drawing.Point(-1, 641);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(207, 76);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open Image";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(696, 53);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(630, 530);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // FilterBox
            // 
            this.FilterBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.FilterBox.FormattingEnabled = true;
            this.FilterBox.Items.AddRange(new object[] {"Alpha-Trim Filter", "Adaptive median filter "});
            this.FilterBox.Location = new System.Drawing.Point(535, 629);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(297, 33);
            this.FilterBox.TabIndex = 5;
            // 
            // window_size
            // 
            this.window_size.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.window_size.Location = new System.Drawing.Point(1089, 624);
            this.window_size.Name = "window_size";
            this.window_size.Size = new System.Drawing.Size(100, 34);
            this.window_size.TabIndex = 6;
            // 
            // Trim_value
            // 
            this.Trim_value.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Trim_value.Location = new System.Drawing.Point(1089, 682);
            this.Trim_value.Name = "Trim_value";
            this.Trim_value.Size = new System.Drawing.Size(100, 34);
            this.Trim_value.TabIndex = 7;
            this.Trim_value.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.label1.Location = new System.Drawing.Point(283, 630);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "choose filter ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.label2.Location = new System.Drawing.Point(244, 688);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "choose sort algorthim";
            // 
            // SortAlgoCombo
            // 
            this.SortAlgoCombo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.SortAlgoCombo.FormattingEnabled = true;
            this.SortAlgoCombo.Items.AddRange(new object[] {"Quick_Sort", "counting_Sort", "Select_the_Kth", "Min & Max Heap", "Modified Bubble Sort"});
            this.SortAlgoCombo.Location = new System.Drawing.Point(535, 690);
            this.SortAlgoCombo.Name = "SortAlgoCombo";
            this.SortAlgoCombo.Size = new System.Drawing.Size(302, 33);
            this.SortAlgoCombo.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.label3.Location = new System.Drawing.Point(873, 626);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Window Size ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.label4.Location = new System.Drawing.Point(884, 685);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Trim value";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (24)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.button1.Location = new System.Drawing.Point(1224, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 76);
            this.button1.TabIndex = 16;
            this.button1.Text = "Apply Filter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.applyFilterButton);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.label5.Location = new System.Drawing.Point(173, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(387, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Image before filter\r\n";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (50)))), ((int) (((byte) (226)))), ((int) (((byte) (178)))));
            this.label6.Location = new System.Drawing.Point(873, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(387, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Image after filter\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (24)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            this.ClientSize = new System.Drawing.Size(1458, 757);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SortAlgoCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Trim_value);
            this.Controls.Add(this.window_size);
            this.Controls.Add(this.FilterBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Image Filters...";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (64)))), ((int) (((byte) (64)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.TextBox Trim_value;

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox FilterBox;
        private System.Windows.Forms.TextBox window_size;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SortAlgoCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
    }
}

