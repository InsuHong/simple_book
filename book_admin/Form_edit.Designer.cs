using System;
using System.Windows.Forms;

namespace book_admin
{
    partial class Form_edit
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
            pic_input = new PictureBox();
            label1 = new Label();
            txt_title = new TextBox();
            txt_memo = new TextBox();
            label10 = new Label();
            label11 = new Label();
            Btn_edit = new Button();
            label15 = new Label();
            label2 = new Label();
            label4 = new Label();
            txt_now_book = new TextBox();
            label3 = new Label();
            btn_plus = new Button();
            bun_minus = new Button();
            bun_minus_n = new Button();
            btn_plus_n = new Button();
            label5 = new Label();
            txt_now_novel = new TextBox();
            label6 = new Label();
            txt_tag = new TextBox();
            label7 = new Label();
            button_resize = new Button();
            textBox_imgfile = new TextBox();
            label_filesize = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_input).BeginInit();
            SuspendLayout();
            // 
            // pic_input
            // 
            pic_input.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            pic_input.BorderStyle = BorderStyle.FixedSingle;
            pic_input.Location = new System.Drawing.Point(222, 2);
            pic_input.Margin = new Padding(3, 4, 3, 4);
            pic_input.Name = "pic_input";
            pic_input.Size = new System.Drawing.Size(130, 217);
            pic_input.SizeMode = PictureBoxSizeMode.Zoom;
            pic_input.TabIndex = 0;
            pic_input.TabStop = false;
            pic_input.Click += pic_input_Click;
            pic_input.DragDrop += pic_input_DragDrop;
            pic_input.DragEnter += pic_input_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(49, 265);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "제목";
            // 
            // txt_title
            // 
            txt_title.Location = new System.Drawing.Point(129, 259);
            txt_title.Margin = new Padding(3, 4, 3, 4);
            txt_title.Name = "txt_title";
            txt_title.Size = new System.Drawing.Size(415, 23);
            txt_title.TabIndex = 3;
            // 
            // txt_memo
            // 
            txt_memo.Location = new System.Drawing.Point(129, 432);
            txt_memo.Margin = new Padding(3, 4, 3, 4);
            txt_memo.Multiline = true;
            txt_memo.Name = "txt_memo";
            txt_memo.Size = new System.Drawing.Size(408, 116);
            txt_memo.TabIndex = 16;
            // 
            // label10
            // 
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Location = new System.Drawing.Point(12, 571);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(540, 2);
            label10.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(50, 481);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(31, 15);
            label11.TabIndex = 20;
            label11.Text = "메모";
            // 
            // Btn_edit
            // 
            Btn_edit.Location = new System.Drawing.Point(258, 579);
            Btn_edit.Margin = new Padding(3, 4, 3, 4);
            Btn_edit.Name = "Btn_edit";
            Btn_edit.Size = new System.Drawing.Size(76, 36);
            Btn_edit.TabIndex = 25;
            Btn_edit.Text = "수정";
            Btn_edit.UseVisualStyleBackColor = true;
            Btn_edit.Click += Btn_edit_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(200, 240);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(179, 15);
            label15.TabIndex = 27;
            label15.Text = "(이미지를 드래그해서 넣으세요)";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new System.Drawing.Point(12, 412);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(540, 2);
            label2.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(51, 341);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(67, 15);
            label4.TabIndex = 28;
            label4.Text = "현재만화책";
            // 
            // txt_now_book
            // 
            txt_now_book.Location = new System.Drawing.Point(130, 335);
            txt_now_book.Margin = new Padding(3, 4, 3, 4);
            txt_now_book.Name = "txt_now_book";
            txt_now_book.Size = new System.Drawing.Size(84, 23);
            txt_now_book.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(223, 341);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(19, 15);
            label3.TabIndex = 31;
            label3.Text = "권";
            // 
            // btn_plus
            // 
            btn_plus.Location = new System.Drawing.Point(246, 335);
            btn_plus.Margin = new Padding(3, 4, 3, 4);
            btn_plus.Name = "btn_plus";
            btn_plus.Size = new System.Drawing.Size(33, 29);
            btn_plus.TabIndex = 32;
            btn_plus.Text = "+";
            btn_plus.UseVisualStyleBackColor = true;
            btn_plus.Click += btn_plus_Click;
            // 
            // bun_minus
            // 
            bun_minus.Location = new System.Drawing.Point(285, 335);
            bun_minus.Margin = new Padding(3, 4, 3, 4);
            bun_minus.Name = "bun_minus";
            bun_minus.Size = new System.Drawing.Size(33, 29);
            bun_minus.TabIndex = 33;
            bun_minus.Text = "-";
            bun_minus.UseVisualStyleBackColor = true;
            bun_minus.Click += bun_minus_Click;
            // 
            // bun_minus_n
            // 
            bun_minus_n.Location = new System.Drawing.Point(284, 379);
            bun_minus_n.Margin = new Padding(3, 4, 3, 4);
            bun_minus_n.Name = "bun_minus_n";
            bun_minus_n.Size = new System.Drawing.Size(33, 29);
            bun_minus_n.TabIndex = 38;
            bun_minus_n.Text = "-";
            bun_minus_n.UseVisualStyleBackColor = true;
            bun_minus_n.Click += bun_minus_n_Click;
            // 
            // btn_plus_n
            // 
            btn_plus_n.Location = new System.Drawing.Point(245, 379);
            btn_plus_n.Margin = new Padding(3, 4, 3, 4);
            btn_plus_n.Name = "btn_plus_n";
            btn_plus_n.Size = new System.Drawing.Size(33, 29);
            btn_plus_n.TabIndex = 37;
            btn_plus_n.Text = "+";
            btn_plus_n.UseVisualStyleBackColor = true;
            btn_plus_n.Click += btn_plus_n_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(222, 385);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(19, 15);
            label5.TabIndex = 36;
            label5.Text = "권";
            // 
            // txt_now_novel
            // 
            txt_now_novel.Location = new System.Drawing.Point(129, 379);
            txt_now_novel.Margin = new Padding(3, 4, 3, 4);
            txt_now_novel.Name = "txt_now_novel";
            txt_now_novel.Size = new System.Drawing.Size(84, 23);
            txt_now_novel.TabIndex = 35;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(50, 385);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(55, 15);
            label6.TabIndex = 34;
            label6.Text = "현재소설";
            // 
            // txt_tag
            // 
            txt_tag.Location = new System.Drawing.Point(129, 296);
            txt_tag.Margin = new Padding(3, 4, 3, 4);
            txt_tag.Name = "txt_tag";
            txt_tag.Size = new System.Drawing.Size(415, 23);
            txt_tag.TabIndex = 40;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(49, 302);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(55, 15);
            label7.TabIndex = 39;
            label7.Text = "검색태그";
            // 
            // button_resize
            // 
            button_resize.Location = new System.Drawing.Point(401, 149);
            button_resize.Name = "button_resize";
            button_resize.Size = new System.Drawing.Size(75, 23);
            button_resize.TabIndex = 41;
            button_resize.Text = "크기줄이기";
            button_resize.UseVisualStyleBackColor = true;
            button_resize.Click += button_resize_Click;
            // 
            // textBox_imgfile
            // 
            textBox_imgfile.Location = new System.Drawing.Point(376, 85);
            textBox_imgfile.Name = "textBox_imgfile";
            textBox_imgfile.Size = new System.Drawing.Size(124, 23);
            textBox_imgfile.TabIndex = 42;
            // 
            // label_filesize
            // 
            label_filesize.AutoSize = true;
            label_filesize.Location = new System.Drawing.Point(428, 126);
            label_filesize.Name = "label_filesize";
            label_filesize.Size = new System.Drawing.Size(14, 15);
            label_filesize.TabIndex = 43;
            label_filesize.Text = "0";
            label_filesize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form_edit
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(572, 620);
            Controls.Add(label_filesize);
            Controls.Add(textBox_imgfile);
            Controls.Add(button_resize);
            Controls.Add(txt_tag);
            Controls.Add(label7);
            Controls.Add(bun_minus_n);
            Controls.Add(btn_plus_n);
            Controls.Add(label5);
            Controls.Add(txt_now_novel);
            Controls.Add(label6);
            Controls.Add(bun_minus);
            Controls.Add(btn_plus);
            Controls.Add(label3);
            Controls.Add(txt_now_book);
            Controls.Add(label4);
            Controls.Add(label15);
            Controls.Add(Btn_edit);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label2);
            Controls.Add(txt_memo);
            Controls.Add(txt_title);
            Controls.Add(label1);
            Controls.Add(pic_input);
            Location = new System.Drawing.Point(0, 1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_edit";
            Text = "수정";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pic_input).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }



        #endregion

        private System.Windows.Forms.PictureBox pic_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.TextBox txt_memo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Btn_edit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_now_book;
        private Label label3;
        private Button btn_plus;
        private Button bun_minus;
        private Button bun_minus_n;
        private Button btn_plus_n;
        private Label label5;
        private TextBox txt_now_novel;
        private Label label6;
        private TextBox txt_tag;
        private Label label7;
        private Button button_resize;
        private TextBox textBox_imgfile;
        private Label label_filesize;
    }
}