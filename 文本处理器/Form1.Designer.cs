namespace 文本处理器
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.repeat_btn = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(442, 87);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 42);
            this.button5.TabIndex = 2;
            this.button5.Text = "测试";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // repeat_btn
            // 
            this.repeat_btn.Location = new System.Drawing.Point(12, 12);
            this.repeat_btn.Name = "repeat_btn";
            this.repeat_btn.Size = new System.Drawing.Size(74, 38);
            this.repeat_btn.TabIndex = 3;
            this.repeat_btn.Text = "按行去重复";
            this.repeat_btn.UseVisualStyleBackColor = true;
            this.repeat_btn.Click += new System.EventHandler(this.Repeat_Btn_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(172, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(74, 38);
            this.button8.TabIndex = 4;
            this.button8.Text = "删除行";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(92, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 38);
            this.button3.TabIndex = 7;
            this.button3.Text = "按列去重复";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "删除列";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(332, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "删除包含关键词的列";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 287);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.repeat_btn);
            this.Controls.Add(this.button5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button repeat_btn;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

