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
            this.label1 = new System.Windows.Forms.Label();
            this.text_sever = new System.Windows.Forms.TextBox();
            this.text_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_Pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP서버주소";
            // 
            // text_sever
            // 
            this.text_sever.Location = new System.Drawing.Point(129, 24);
            this.text_sever.Name = "text_sever";
            this.text_sever.Size = new System.Drawing.Size(267, 21);
            this.text_sever.TabIndex = 1;
            // 
            // text_Path
            // 
            this.text_Path.Location = new System.Drawing.Point(127, 57);
            this.text_Path.Name = "text_Path";
            this.text_Path.Size = new System.Drawing.Size(267, 21);
            this.text_Path.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "FTP서버경로";
            // 
            // text_Id
            // 
            this.text_Id.Location = new System.Drawing.Point(127, 89);
            this.text_Id.Name = "text_Id";
            this.text_Id.Size = new System.Drawing.Size(166, 21);
            this.text_Id.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "FTP아이디";
            // 
            // text_Pass
            // 
            this.text_Pass.Location = new System.Drawing.Point(127, 120);
            this.text_Pass.Name = "text_Pass";
            this.text_Pass.Size = new System.Drawing.Size(166, 21);
            this.text_Pass.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "FTP패스워드";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "실행시 동작";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(166, 226);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 11;
            this.button_save.Text = "저장";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radio2);
            this.groupBox1.Controls.Add(this.radio1);
            this.groupBox1.Location = new System.Drawing.Point(125, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 38);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Location = new System.Drawing.Point(140, 16);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(123, 16);
            this.radio2.TabIndex = 12;
            this.radio2.TabStop = true;
            this.radio2.Text = "로컬파일로만 사용";
            this.radio2.UseVisualStyleBackColor = true;
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Location = new System.Drawing.Point(11, 16);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(123, 16);
            this.radio1.TabIndex = 11;
            this.radio1.TabStop = true;
            this.radio1.Text = "원격파일 업데이트";
            this.radio1.UseVisualStyleBackColor = true;
            // 
            // Form_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 285);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.text_Pass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_Id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_sever);
            this.Controls.Add(this.label1);
            this.Name = "Form_config";
            this.Text = "환경설정";
            this.Load += new System.EventHandler(this.Form_config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}