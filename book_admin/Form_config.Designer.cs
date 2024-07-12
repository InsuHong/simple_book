namespace book_admin
{
    partial class Form_config
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
            label1 = new System.Windows.Forms.Label();
            text_sever = new System.Windows.Forms.TextBox();
            text_Path = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            text_Id = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            text_Pass = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            button_save = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            radio2 = new System.Windows.Forms.RadioButton();
            radio1 = new System.Windows.Forms.RadioButton();
            text_port = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 36);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "FTP서버주소";
            // 
            // text_sever
            // 
            text_sever.Location = new System.Drawing.Point(129, 30);
            text_sever.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            text_sever.Name = "text_sever";
            text_sever.Size = new System.Drawing.Size(267, 23);
            text_sever.TabIndex = 1;
            // 
            // text_Path
            // 
            text_Path.Location = new System.Drawing.Point(127, 100);
            text_Path.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            text_Path.Name = "text_Path";
            text_Path.Size = new System.Drawing.Size(267, 23);
            text_Path.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 107);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "FTP서버경로";
            // 
            // text_Id
            // 
            text_Id.Location = new System.Drawing.Point(127, 140);
            text_Id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            text_Id.Name = "text_Id";
            text_Id.Size = new System.Drawing.Size(166, 23);
            text_Id.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(26, 147);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 15);
            label3.TabIndex = 4;
            label3.Text = "FTP아이디";
            // 
            // text_Pass
            // 
            text_Pass.Location = new System.Drawing.Point(127, 179);
            text_Pass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            text_Pass.Name = "text_Pass";
            text_Pass.Size = new System.Drawing.Size(166, 23);
            text_Pass.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(26, 185);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(74, 15);
            label4.TabIndex = 6;
            label4.Text = "FTP패스워드";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(26, 224);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(71, 15);
            label5.TabIndex = 8;
            label5.Text = "실행시 동작";
            // 
            // button_save
            // 
            button_save.Location = new System.Drawing.Point(166, 282);
            button_save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_save.Name = "button_save";
            button_save.Size = new System.Drawing.Size(75, 29);
            button_save.TabIndex = 11;
            button_save.Text = "저장";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radio2);
            groupBox1.Controls.Add(radio1);
            groupBox1.Location = new System.Drawing.Point(125, 209);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(269, 48);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // radio2
            // 
            radio2.AutoSize = true;
            radio2.Location = new System.Drawing.Point(140, 20);
            radio2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radio2.Name = "radio2";
            radio2.Size = new System.Drawing.Size(125, 19);
            radio2.TabIndex = 12;
            radio2.TabStop = true;
            radio2.Text = "로컬파일로만 사용";
            radio2.UseVisualStyleBackColor = true;
            // 
            // radio1
            // 
            radio1.AutoSize = true;
            radio1.Location = new System.Drawing.Point(11, 20);
            radio1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radio1.Name = "radio1";
            radio1.Size = new System.Drawing.Size(125, 19);
            radio1.TabIndex = 11;
            radio1.TabStop = true;
            radio1.Text = "원격파일 업데이트";
            radio1.UseVisualStyleBackColor = true;
            // 
            // text_port
            // 
            text_port.Location = new System.Drawing.Point(128, 64);
            text_port.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            text_port.Name = "text_port";
            text_port.Size = new System.Drawing.Size(70, 23);
            text_port.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(27, 70);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(52, 15);
            label6.TabIndex = 13;
            label6.Text = "FTP Port";
            // 
            // Form_config
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(421, 356);
            Controls.Add(text_port);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            Controls.Add(button_save);
            Controls.Add(label5);
            Controls.Add(text_Pass);
            Controls.Add(label4);
            Controls.Add(text_Id);
            Controls.Add(label3);
            Controls.Add(text_Path);
            Controls.Add(label2);
            Controls.Add(text_sever);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form_config";
            Text = "환경설정";
            Load += Form_config_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_sever;
        private System.Windows.Forms.TextBox text_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_Id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_Pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.Label label6;
    }
}