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
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(372, 225);
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
            this.button1.Location = new System.Drawing.Point(332, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "删除列";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "删除包含关键词的列";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(332, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 38);
            this.button4.TabIndex = 10;
            this.button4.Text = "提取包含关键词的列";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(252, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 38);
            this.button6.TabIndex = 11;
            this.button6.Text = "提取行";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 56);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(74, 38);
            this.button7.TabIndex = 12;
            this.button7.Text = "提取指定长度的行";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(92, 56);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(74, 38);
            this.button9.TabIndex = 13;
            this.button9.Text = "提取指定列长度的行";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(172, 56);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(74, 38);
            this.button10.TabIndex = 14;
            this.button10.Text = "提取行";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(252, 56);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(74, 38);
            this.button11.TabIndex = 15;
            this.button11.Text = "提取含指定列数量的行";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button16);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Location = new System.Drawing.Point(12, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 157);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "集合操作_按行";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 108);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(74, 38);
            this.button16.TabIndex = 17;
            this.button16.Text = "对称差集";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(86, 20);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(74, 38);
            this.button15.TabIndex = 16;
            this.button15.Text = "并集";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(6, 64);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(74, 38);
            this.button14.TabIndex = 15;
            this.button14.Text = "补集";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(86, 64);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(74, 38);
            this.button13.TabIndex = 14;
            this.button13.Text = "差集";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 20);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(74, 38);
            this.button12.TabIndex = 13;
            this.button12.Text = "交集";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button18);
            this.groupBox2.Controls.Add(this.button19);
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Location = new System.Drawing.Point(192, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 157);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "集合操作_按列";
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(6, 108);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(74, 38);
            this.button17.TabIndex = 22;
            this.button17.Text = "对称差集";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(86, 20);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(74, 38);
            this.button18.TabIndex = 21;
            this.button18.Text = "并集";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(6, 64);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(74, 38);
            this.button19.TabIndex = 20;
            this.button19.Text = "补集";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(86, 64);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(74, 38);
            this.button20.TabIndex = 19;
            this.button20.Text = "差集";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(6, 20);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(74, 38);
            this.button21.TabIndex = 18;
            this.button21.Text = "交集";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.repeat_btn);
            this.Controls.Add(this.button5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button repeat_btn;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
    }
}

