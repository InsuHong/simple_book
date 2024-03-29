﻿using System;
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
            this.pic_input = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.txt_memo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Btn_edit = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_now_book = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_plus = new System.Windows.Forms.Button();
            this.bun_minus = new System.Windows.Forms.Button();
            this.bun_minus_n = new System.Windows.Forms.Button();
            this.btn_plus_n = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_now_novel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tag = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_input)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_input
            // 
            this.pic_input.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pic_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_input.Location = new System.Drawing.Point(222, 2);
            this.pic_input.Name = "pic_input";
            this.pic_input.Size = new System.Drawing.Size(130, 174);
            this.pic_input.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_input.TabIndex = 0;
            this.pic_input.TabStop = false;
            this.pic_input.Click += new System.EventHandler(this.pic_input_Click);
            this.pic_input.DragDrop += new System.Windows.Forms.DragEventHandler(this.pic_input_DragDrop);
            this.pic_input.DragEnter += new System.Windows.Forms.DragEventHandler(this.pic_input_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "제목";
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(129, 207);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(415, 21);
            this.txt_title.TabIndex = 3;
            // 
            // txt_memo
            // 
            this.txt_memo.Location = new System.Drawing.Point(129, 346);
            this.txt_memo.Multiline = true;
            this.txt_memo.Name = "txt_memo";
            this.txt_memo.Size = new System.Drawing.Size(408, 94);
            this.txt_memo.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(12, 457);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(540, 2);
            this.label10.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 385);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "메모";
            // 
            // Btn_edit
            // 
            this.Btn_edit.Location = new System.Drawing.Point(258, 463);
            this.Btn_edit.Name = "Btn_edit";
            this.Btn_edit.Size = new System.Drawing.Size(76, 29);
            this.Btn_edit.TabIndex = 25;
            this.Btn_edit.Text = "수정";
            this.Btn_edit.UseVisualStyleBackColor = true;
            this.Btn_edit.Click += new System.EventHandler(this.Btn_edit_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(200, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "(이미지를 드래그해서 넣으세요)";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(540, 2);
            this.label2.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "현재만화책";
            // 
            // txt_now_book
            // 
            this.txt_now_book.Location = new System.Drawing.Point(130, 268);
            this.txt_now_book.Name = "txt_now_book";
            this.txt_now_book.Size = new System.Drawing.Size(84, 21);
            this.txt_now_book.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "권";
            // 
            // btn_plus
            // 
            this.btn_plus.Location = new System.Drawing.Point(246, 268);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(33, 23);
            this.btn_plus.TabIndex = 32;
            this.btn_plus.Text = "+";
            this.btn_plus.UseVisualStyleBackColor = true;
            this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
            // 
            // bun_minus
            // 
            this.bun_minus.Location = new System.Drawing.Point(285, 268);
            this.bun_minus.Name = "bun_minus";
            this.bun_minus.Size = new System.Drawing.Size(33, 23);
            this.bun_minus.TabIndex = 33;
            this.bun_minus.Text = "-";
            this.bun_minus.UseVisualStyleBackColor = true;
            this.bun_minus.Click += new System.EventHandler(this.bun_minus_Click);
            // 
            // bun_minus_n
            // 
            this.bun_minus_n.Location = new System.Drawing.Point(284, 303);
            this.bun_minus_n.Name = "bun_minus_n";
            this.bun_minus_n.Size = new System.Drawing.Size(33, 23);
            this.bun_minus_n.TabIndex = 38;
            this.bun_minus_n.Text = "-";
            this.bun_minus_n.UseVisualStyleBackColor = true;
            this.bun_minus_n.Click += new System.EventHandler(this.bun_minus_n_Click);
            // 
            // btn_plus_n
            // 
            this.btn_plus_n.Location = new System.Drawing.Point(245, 303);
            this.btn_plus_n.Name = "btn_plus_n";
            this.btn_plus_n.Size = new System.Drawing.Size(33, 23);
            this.btn_plus_n.TabIndex = 37;
            this.btn_plus_n.Text = "+";
            this.btn_plus_n.UseVisualStyleBackColor = true;
            this.btn_plus_n.Click += new System.EventHandler(this.btn_plus_n_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "권";
            // 
            // txt_now_novel
            // 
            this.txt_now_novel.Location = new System.Drawing.Point(129, 303);
            this.txt_now_novel.Name = "txt_now_novel";
            this.txt_now_novel.Size = new System.Drawing.Size(84, 21);
            this.txt_now_novel.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "현재소설";
            // 
            // txt_tag
            // 
            this.txt_tag.Location = new System.Drawing.Point(129, 237);
            this.txt_tag.Name = "txt_tag";
            this.txt_tag.Size = new System.Drawing.Size(415, 21);
            this.txt_tag.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "검색태그";
            // 
            // Form_edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 496);
            this.Controls.Add(this.txt_tag);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bun_minus_n);
            this.Controls.Add(this.btn_plus_n);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_now_novel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bun_minus);
            this.Controls.Add(this.btn_plus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_now_book);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Btn_edit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_memo);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_input);
            this.Location = new System.Drawing.Point(0, 1);
            this.Name = "Form_edit";
            this.Text = "수정";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}