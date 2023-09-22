namespace book_admin
{
    partial class Form_main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            환경설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            DB가져오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            combo_type = new System.Windows.Forms.ComboBox();
            txt_search = new System.Windows.Forms.TextBox();
            Btn_search = new System.Windows.Forms.Button();
            Btn_add = new System.Windows.Forms.Button();
            button_view32 = new System.Windows.Forms.Button();
            button_view1 = new System.Windows.Forms.Button();
            button_view2 = new System.Windows.Forms.Button();
            button_view4 = new System.Windows.Forms.Button();
            button_view24 = new System.Windows.Forms.Button();
            button_view10 = new System.Windows.Forms.Button();
            Panel_list = new System.Windows.Forms.TableLayoutPanel();
            panel_page = new System.Windows.Forms.Panel();
            label_state = new System.Windows.Forms.Label();
            button_ftpup = new System.Windows.Forms.Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 파일ToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1305, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { 환경설정ToolStripMenuItem, DB가져오기ToolStripMenuItem, toolStripMenuItem1, 종료ToolStripMenuItem });
            파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            파일ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            파일ToolStripMenuItem.Text = "환경설정";
            // 
            // 환경설정ToolStripMenuItem
            // 
            환경설정ToolStripMenuItem.Name = "환경설정ToolStripMenuItem";
            환경설정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            환경설정ToolStripMenuItem.Text = "환경설정";
            환경설정ToolStripMenuItem.Click += 환경설정ToolStripMenuItem_Click;
            // 
            // DB가져오기ToolStripMenuItem
            // 
            DB가져오기ToolStripMenuItem.Name = "DB가져오기ToolStripMenuItem";
            DB가져오기ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            DB가져오기ToolStripMenuItem.Text = "DB가져오기";
            DB가져오기ToolStripMenuItem.Click += DB가져오기ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            종료ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            종료ToolStripMenuItem.Text = "종료";
            종료ToolStripMenuItem.Click += 종료ToolStripMenuItem_Click;
            // 
            // combo_type
            // 
            combo_type.FormattingEnabled = true;
            combo_type.Items.AddRange(new object[] { "제목", "비고", "태그" });
            combo_type.Location = new System.Drawing.Point(17, 755);
            combo_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            combo_type.Name = "combo_type";
            combo_type.Size = new System.Drawing.Size(121, 23);
            combo_type.TabIndex = 3;
            combo_type.Text = "검색타입";
            // 
            // txt_search
            // 
            txt_search.Location = new System.Drawing.Point(145, 753);
            txt_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txt_search.Name = "txt_search";
            txt_search.Size = new System.Drawing.Size(208, 23);
            txt_search.TabIndex = 4;
            // 
            // Btn_search
            // 
            Btn_search.Location = new System.Drawing.Point(360, 750);
            Btn_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Btn_search.Name = "Btn_search";
            Btn_search.Size = new System.Drawing.Size(75, 29);
            Btn_search.TabIndex = 5;
            Btn_search.Text = "검색";
            Btn_search.UseVisualStyleBackColor = true;
            Btn_search.Click += Btn_search_Click;
            // 
            // Btn_add
            // 
            Btn_add.Location = new System.Drawing.Point(441, 750);
            Btn_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Btn_add.Name = "Btn_add";
            Btn_add.Size = new System.Drawing.Size(69, 29);
            Btn_add.TabIndex = 8;
            Btn_add.Text = "등록";
            Btn_add.UseVisualStyleBackColor = true;
            Btn_add.Click += Btn_add_Click;
            // 
            // button_view32
            // 
            button_view32.Location = new System.Drawing.Point(784, 746);
            button_view32.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_view32.Name = "button_view32";
            button_view32.Size = new System.Drawing.Size(30, 35);
            button_view32.TabIndex = 81;
            button_view32.Text = "32";
            button_view32.UseVisualStyleBackColor = true;
            button_view32.Click += button_view32_Click;
            // 
            // button_view1
            // 
            button_view1.Location = new System.Drawing.Point(639, 746);
            button_view1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_view1.Name = "button_view1";
            button_view1.Size = new System.Drawing.Size(30, 35);
            button_view1.TabIndex = 80;
            button_view1.Text = "1";
            button_view1.UseVisualStyleBackColor = true;
            button_view1.Click += button_view1_Click;
            // 
            // button_view2
            // 
            button_view2.Location = new System.Drawing.Point(668, 746);
            button_view2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_view2.Name = "button_view2";
            button_view2.Size = new System.Drawing.Size(30, 35);
            button_view2.TabIndex = 79;
            button_view2.Text = "2";
            button_view2.UseVisualStyleBackColor = true;
            button_view2.Click += button_view2_Click;
            // 
            // button_view4
            // 
            button_view4.Location = new System.Drawing.Point(697, 746);
            button_view4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_view4.Name = "button_view4";
            button_view4.Size = new System.Drawing.Size(30, 35);
            button_view4.TabIndex = 78;
            button_view4.Text = "4";
            button_view4.UseVisualStyleBackColor = true;
            button_view4.Click += button_view4_Click;
            // 
            // button_view24
            // 
            button_view24.Location = new System.Drawing.Point(755, 746);
            button_view24.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_view24.Name = "button_view24";
            button_view24.Size = new System.Drawing.Size(30, 35);
            button_view24.TabIndex = 77;
            button_view24.Text = "24";
            button_view24.UseVisualStyleBackColor = true;
            button_view24.Click += button_view24_Click;
            // 
            // button_view10
            // 
            button_view10.Location = new System.Drawing.Point(726, 746);
            button_view10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_view10.Name = "button_view10";
            button_view10.Size = new System.Drawing.Size(30, 35);
            button_view10.TabIndex = 76;
            button_view10.Text = "10";
            button_view10.UseVisualStyleBackColor = true;
            button_view10.Click += button_view10_Click;
            // 
            // Panel_list
            // 
            Panel_list.ColumnCount = 2;
            Panel_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Panel_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Panel_list.Dock = System.Windows.Forms.DockStyle.Top;
            Panel_list.Location = new System.Drawing.Point(0, 24);
            Panel_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Panel_list.Name = "Panel_list";
            Panel_list.RowCount = 2;
            Panel_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Panel_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            Panel_list.Size = new System.Drawing.Size(1305, 661);
            Panel_list.TabIndex = 82;
            // 
            // panel_page
            // 
            panel_page.AutoScroll = true;
            panel_page.Dock = System.Windows.Forms.DockStyle.Top;
            panel_page.Location = new System.Drawing.Point(0, 685);
            panel_page.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel_page.Name = "panel_page";
            panel_page.Size = new System.Drawing.Size(1305, 59);
            panel_page.TabIndex = 83;
            // 
            // label_state
            // 
            label_state.Location = new System.Drawing.Point(827, 751);
            label_state.Name = "label_state";
            label_state.Size = new System.Drawing.Size(126, 21);
            label_state.TabIndex = 84;
            label_state.Text = "...";
            // 
            // button_ftpup
            // 
            button_ftpup.Location = new System.Drawing.Point(516, 750);
            button_ftpup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button_ftpup.Name = "button_ftpup";
            button_ftpup.Size = new System.Drawing.Size(79, 29);
            button_ftpup.TabIndex = 85;
            button_ftpup.Text = "DB내보내기";
            button_ftpup.UseVisualStyleBackColor = true;
            button_ftpup.Click += button_ftpup_Click;
            // 
            // Form_main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1305, 788);
            Controls.Add(button_ftpup);
            Controls.Add(label_state);
            Controls.Add(panel_page);
            Controls.Add(Panel_list);
            Controls.Add(button_view32);
            Controls.Add(button_view1);
            Controls.Add(button_view2);
            Controls.Add(button_view4);
            Controls.Add(button_view24);
            Controls.Add(button_view10);
            Controls.Add(Btn_add);
            Controls.Add(Btn_search);
            Controls.Add(txt_search);
            Controls.Add(combo_type);
            Controls.Add(menuStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_main";
            Text = "책정보";
            FormClosing += Form_main_FormClosing;
            Load += Form_main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DB가져오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ComboBox combo_type;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button Btn_search;
        private System.Windows.Forms.Button Btn_add;
        private System.Windows.Forms.Button button_view32;
        private System.Windows.Forms.Button button_view1;
        private System.Windows.Forms.Button button_view2;
        private System.Windows.Forms.Button button_view4;
        private System.Windows.Forms.Button button_view24;
        private System.Windows.Forms.Button button_view10;
        private System.Windows.Forms.TableLayoutPanel Panel_list;
        private System.Windows.Forms.Panel panel_page;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Button button_ftpup;
        private System.Windows.Forms.ToolStripMenuItem 환경설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

