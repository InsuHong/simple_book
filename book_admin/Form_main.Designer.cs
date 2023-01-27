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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DB가져오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combo_type = new System.Windows.Forms.ComboBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.Btn_search = new System.Windows.Forms.Button();
            this.Btn_add = new System.Windows.Forms.Button();
            this.button_view32 = new System.Windows.Forms.Button();
            this.button_view1 = new System.Windows.Forms.Button();
            this.button_view2 = new System.Windows.Forms.Button();
            this.button_view4 = new System.Windows.Forms.Button();
            this.button_view24 = new System.Windows.Forms.Button();
            this.button_view10 = new System.Windows.Forms.Button();
            this.Panel_list = new System.Windows.Forms.TableLayoutPanel();
            this.panel_page = new System.Windows.Forms.Panel();
            this.label_state = new System.Windows.Forms.Label();
            this.button_ftpup = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.환경설정ToolStripMenuItem,
            this.DB가져오기ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.파일ToolStripMenuItem.Text = "환경설정";
            // 
            // 환경설정ToolStripMenuItem
            // 
            this.환경설정ToolStripMenuItem.Name = "환경설정ToolStripMenuItem";
            this.환경설정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.환경설정ToolStripMenuItem.Text = "환경설정";
            this.환경설정ToolStripMenuItem.Click += new System.EventHandler(this.환경설정ToolStripMenuItem_Click);
            // 
            // DB가져오기ToolStripMenuItem
            // 
            this.DB가져오기ToolStripMenuItem.Name = "DB가져오기ToolStripMenuItem";
            this.DB가져오기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DB가져오기ToolStripMenuItem.Text = "DB가져오기";
            this.DB가져오기ToolStripMenuItem.Click += new System.EventHandler(this.DB가져오기ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // combo_type
            // 
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Items.AddRange(new object[] {
            "제목",
            "비고"});
            this.combo_type.Location = new System.Drawing.Point(16, 535);
            this.combo_type.Name = "combo_type";
            this.combo_type.Size = new System.Drawing.Size(121, 20);
            this.combo_type.TabIndex = 3;
            this.combo_type.Text = "검색타입";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(144, 535);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(208, 21);
            this.txt_search.TabIndex = 4;
            // 
            // Btn_search
            // 
            this.Btn_search.Location = new System.Drawing.Point(359, 535);
            this.Btn_search.Name = "Btn_search";
            this.Btn_search.Size = new System.Drawing.Size(75, 23);
            this.Btn_search.TabIndex = 5;
            this.Btn_search.Text = "검색";
            this.Btn_search.UseVisualStyleBackColor = true;
            this.Btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // Btn_add
            // 
            this.Btn_add.Location = new System.Drawing.Point(440, 535);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(69, 23);
            this.Btn_add.TabIndex = 8;
            this.Btn_add.Text = "등록";
            this.Btn_add.UseVisualStyleBackColor = true;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // button_view32
            // 
            this.button_view32.Location = new System.Drawing.Point(783, 532);
            this.button_view32.Name = "button_view32";
            this.button_view32.Size = new System.Drawing.Size(30, 28);
            this.button_view32.TabIndex = 81;
            this.button_view32.Text = "32";
            this.button_view32.UseVisualStyleBackColor = true;
            this.button_view32.Click += new System.EventHandler(this.button_view32_Click);
            // 
            // button_view1
            // 
            this.button_view1.Location = new System.Drawing.Point(638, 532);
            this.button_view1.Name = "button_view1";
            this.button_view1.Size = new System.Drawing.Size(30, 28);
            this.button_view1.TabIndex = 80;
            this.button_view1.Text = "1";
            this.button_view1.UseVisualStyleBackColor = true;
            this.button_view1.Click += new System.EventHandler(this.button_view1_Click);
            // 
            // button_view2
            // 
            this.button_view2.Location = new System.Drawing.Point(667, 532);
            this.button_view2.Name = "button_view2";
            this.button_view2.Size = new System.Drawing.Size(30, 28);
            this.button_view2.TabIndex = 79;
            this.button_view2.Text = "2";
            this.button_view2.UseVisualStyleBackColor = true;
            this.button_view2.Click += new System.EventHandler(this.button_view2_Click);
            // 
            // button_view4
            // 
            this.button_view4.Location = new System.Drawing.Point(696, 532);
            this.button_view4.Name = "button_view4";
            this.button_view4.Size = new System.Drawing.Size(30, 28);
            this.button_view4.TabIndex = 78;
            this.button_view4.Text = "4";
            this.button_view4.UseVisualStyleBackColor = true;
            this.button_view4.Click += new System.EventHandler(this.button_view4_Click);
            // 
            // button_view24
            // 
            this.button_view24.Location = new System.Drawing.Point(754, 532);
            this.button_view24.Name = "button_view24";
            this.button_view24.Size = new System.Drawing.Size(30, 28);
            this.button_view24.TabIndex = 77;
            this.button_view24.Text = "24";
            this.button_view24.UseVisualStyleBackColor = true;
            this.button_view24.Click += new System.EventHandler(this.button_view24_Click);
            // 
            // button_view10
            // 
            this.button_view10.Location = new System.Drawing.Point(725, 532);
            this.button_view10.Name = "button_view10";
            this.button_view10.Size = new System.Drawing.Size(30, 28);
            this.button_view10.TabIndex = 76;
            this.button_view10.Text = "10";
            this.button_view10.UseVisualStyleBackColor = true;
            this.button_view10.Click += new System.EventHandler(this.button_view10_Click);
            // 
            // Panel_list
            // 
            this.Panel_list.ColumnCount = 2;
            this.Panel_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel_list.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel_list.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_list.Location = new System.Drawing.Point(0, 24);
            this.Panel_list.Name = "Panel_list";
            this.Panel_list.RowCount = 2;
            this.Panel_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel_list.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel_list.Size = new System.Drawing.Size(952, 456);
            this.Panel_list.TabIndex = 82;
            // 
            // panel_page
            // 
            this.panel_page.AutoScroll = true;
            this.panel_page.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_page.Location = new System.Drawing.Point(0, 480);
            this.panel_page.Name = "panel_page";
            this.panel_page.Size = new System.Drawing.Size(952, 49);
            this.panel_page.TabIndex = 83;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(826, 536);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(17, 12);
            this.label_state.TabIndex = 84;
            this.label_state.Text = "...";
            // 
            // button_ftpup
            // 
            this.button_ftpup.Location = new System.Drawing.Point(515, 535);
            this.button_ftpup.Name = "button_ftpup";
            this.button_ftpup.Size = new System.Drawing.Size(79, 23);
            this.button_ftpup.TabIndex = 85;
            this.button_ftpup.Text = "DB내보내기";
            this.button_ftpup.UseVisualStyleBackColor = true;
            this.button_ftpup.Click += new System.EventHandler(this.button_ftpup_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(952, 562);
            this.Controls.Add(this.button_ftpup);
            this.Controls.Add(this.label_state);
            this.Controls.Add(this.panel_page);
            this.Controls.Add(this.Panel_list);
            this.Controls.Add(this.button_view32);
            this.Controls.Add(this.button_view1);
            this.Controls.Add(this.button_view2);
            this.Controls.Add(this.button_view4);
            this.Controls.Add(this.button_view24);
            this.Controls.Add(this.button_view10);
            this.Controls.Add(this.Btn_add);
            this.Controls.Add(this.Btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.combo_type);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_main";
            this.Text = "책정보";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

