namespace 文本处理器
{
    partial class Option_Form
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.split_Text_Lab = new System.Windows.Forms.Label();
            this.col_Num_Lab = new System.Windows.Forms.Label();
            this.input_Files_TB = new System.Windows.Forms.TextBox();
            this.save_File_TB = new System.Windows.Forms.TextBox();
            this.split_Text_TB = new System.Windows.Forms.TextBox();
            this.col_Num_Numer = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.keyWords_TB = new System.Windows.Forms.TextBox();
            this.keyWord_Chebox = new System.Windows.Forms.CheckBox();
            this.len_Num_Numer = new System.Windows.Forms.NumericUpDown();
            this.len_Num_Lab = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.col_Num_Numer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.len_Num_Numer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(53, 12);
            label1.TabIndex = 0;
            label1.Text = "读取文件";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 55);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 12);
            label2.TabIndex = 1;
            label2.Text = "保存地址";
            // 
            // split_Text_Lab
            // 
            this.split_Text_Lab.AutoSize = true;
            this.split_Text_Lab.Location = new System.Drawing.Point(24, 90);
            this.split_Text_Lab.Name = "split_Text_Lab";
            this.split_Text_Lab.Size = new System.Drawing.Size(41, 12);
            this.split_Text_Lab.TabIndex = 2;
            this.split_Text_Lab.Text = "分隔符";
            this.split_Text_Lab.Visible = false;
            // 
            // col_Num_Lab
            // 
            this.col_Num_Lab.AutoSize = true;
            this.col_Num_Lab.Location = new System.Drawing.Point(12, 125);
            this.col_Num_Lab.Name = "col_Num_Lab";
            this.col_Num_Lab.Size = new System.Drawing.Size(53, 12);
            this.col_Num_Lab.TabIndex = 3;
            this.col_Num_Lab.Text = "选择列数";
            this.col_Num_Lab.Visible = false;
            // 
            // input_Files_TB
            // 
            this.input_Files_TB.Location = new System.Drawing.Point(72, 14);
            this.input_Files_TB.Name = "input_Files_TB";
            this.input_Files_TB.ReadOnly = true;
            this.input_Files_TB.Size = new System.Drawing.Size(197, 21);
            this.input_Files_TB.TabIndex = 4;
            // 
            // save_File_TB
            // 
            this.save_File_TB.Location = new System.Drawing.Point(72, 52);
            this.save_File_TB.Name = "save_File_TB";
            this.save_File_TB.ReadOnly = true;
            this.save_File_TB.Size = new System.Drawing.Size(197, 21);
            this.save_File_TB.TabIndex = 5;
            // 
            // split_Text_TB
            // 
            this.split_Text_TB.Location = new System.Drawing.Point(72, 87);
            this.split_Text_TB.Name = "split_Text_TB";
            this.split_Text_TB.Size = new System.Drawing.Size(72, 21);
            this.split_Text_TB.TabIndex = 6;
            this.split_Text_TB.Text = "----";
            this.split_Text_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.split_Text_TB.Visible = false;
            this.split_Text_TB.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // col_Num_Numer
            // 
            this.col_Num_Numer.Location = new System.Drawing.Point(72, 120);
            this.col_Num_Numer.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.col_Num_Numer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.col_Num_Numer.Name = "col_Num_Numer";
            this.col_Num_Numer.Size = new System.Drawing.Size(72, 21);
            this.col_Num_Numer.TabIndex = 7;
            this.col_Num_Numer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col_Num_Numer.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.col_Num_Numer.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 28);
            this.button3.TabIndex = 10;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(305, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 28);
            this.button4.TabIndex = 11;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // keyWords_TB
            // 
            this.keyWords_TB.Location = new System.Drawing.Point(72, 147);
            this.keyWords_TB.Multiline = true;
            this.keyWords_TB.Name = "keyWords_TB";
            this.keyWords_TB.ReadOnly = true;
            this.keyWords_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.keyWords_TB.Size = new System.Drawing.Size(261, 50);
            this.keyWords_TB.TabIndex = 13;
            this.keyWords_TB.Visible = false;
            this.keyWords_TB.WordWrap = false;
            // 
            // keyWord_Chebox
            // 
            this.keyWord_Chebox.Location = new System.Drawing.Point(12, 162);
            this.keyWord_Chebox.Margin = new System.Windows.Forms.Padding(0);
            this.keyWord_Chebox.Name = "keyWord_Chebox";
            this.keyWord_Chebox.Size = new System.Drawing.Size(60, 18);
            this.keyWord_Chebox.TabIndex = 14;
            this.keyWord_Chebox.Text = "关键字";
            this.keyWord_Chebox.UseVisualStyleBackColor = true;
            this.keyWord_Chebox.Visible = false;
            this.keyWord_Chebox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // len_Num_Numer
            // 
            this.len_Num_Numer.Location = new System.Drawing.Point(227, 120);
            this.len_Num_Numer.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.len_Num_Numer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.len_Num_Numer.Name = "len_Num_Numer";
            this.len_Num_Numer.Size = new System.Drawing.Size(72, 21);
            this.len_Num_Numer.TabIndex = 16;
            this.len_Num_Numer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.len_Num_Numer.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.len_Num_Numer.Visible = false;
            // 
            // len_Num_Lab
            // 
            this.len_Num_Lab.AutoSize = true;
            this.len_Num_Lab.Location = new System.Drawing.Point(168, 125);
            this.len_Num_Lab.Name = "len_Num_Lab";
            this.len_Num_Lab.Size = new System.Drawing.Size(53, 12);
            this.len_Num_Lab.TabIndex = 15;
            this.len_Num_Lab.Text = "指定长度";
            this.len_Num_Lab.Visible = false;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Image = global::文本处理器.Properties.Resources.文件夹;
            this.button2.Location = new System.Drawing.Point(274, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Image = global::文本处理器.Properties.Resources.文件夹;
            this.button1.Location = new System.Drawing.Point(274, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // Option_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 203);
            this.Controls.Add(this.len_Num_Numer);
            this.Controls.Add(this.len_Num_Lab);
            this.Controls.Add(this.keyWord_Chebox);
            this.Controls.Add(this.keyWords_TB);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.col_Num_Numer);
            this.Controls.Add(this.split_Text_TB);
            this.Controls.Add(this.save_File_TB);
            this.Controls.Add(this.input_Files_TB);
            this.Controls.Add(this.col_Num_Lab);
            this.Controls.Add(this.split_Text_Lab);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Option_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数填写";
            ((System.ComponentModel.ISupportInitialize)(this.col_Num_Numer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.len_Num_Numer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label split_Text_Lab;
        private System.Windows.Forms.Label col_Num_Lab;
        private System.Windows.Forms.TextBox input_Files_TB;
        private System.Windows.Forms.TextBox save_File_TB;
        private System.Windows.Forms.TextBox split_Text_TB;
        private System.Windows.Forms.NumericUpDown col_Num_Numer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox keyWords_TB;
        private System.Windows.Forms.CheckBox keyWord_Chebox;
        private System.Windows.Forms.NumericUpDown len_Num_Numer;
        private System.Windows.Forms.Label len_Num_Lab;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}