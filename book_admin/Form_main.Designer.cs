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
            this.기본설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel_list = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_page = new System.Windows.Forms.Panel();
            this.combo_type = new System.Windows.Forms.ComboBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.Btn_search = new System.Windows.Forms.Button();
            this.Btn_add = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(774, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.기본설정ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.파일ToolStripMenuItem.Text = "환경설정";
            // 
            // 기본설정ToolStripMenuItem
            // 
            this.기본설정ToolStripMenuItem.Name = "기본설정ToolStripMenuItem";
            this.기본설정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.기본설정ToolStripMenuItem.Text = "기본설정";
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // Panel_list
            // 
            this.Panel_list.AutoScroll = true;
            this.Panel_list.AutoScrollMargin = new System.Drawing.Size(0, 338);
            this.Panel_list.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_list.Location = new System.Drawing.Point(0, 24);
            this.Panel_list.Name = "Panel_list";
            this.Panel_list.Size = new System.Drawing.Size(774, 360);
            this.Panel_list.TabIndex = 1;
            this.Panel_list.WrapContents = false;
            this.Panel_list.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_list_Paint);
            // 
            // panel_page
            // 
            this.panel_page.AutoScroll = true;
            this.panel_page.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_page.Location = new System.Drawing.Point(0, 384);
            this.panel_page.Name = "panel_page";
            this.panel_page.Size = new System.Drawing.Size(774, 60);
            this.panel_page.TabIndex = 2;
            // 
            // combo_type
            // 
            this.combo_type.FormattingEnabled = true;
            this.combo_type.Items.AddRange(new object[] {
            "제목",
            "비고"});
            this.combo_type.Location = new System.Drawing.Point(16, 461);
            this.combo_type.Name = "combo_type";
            this.combo_type.Size = new System.Drawing.Size(121, 20);
            this.combo_type.TabIndex = 3;
            this.combo_type.Text = "검색타입";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(144, 461);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(208, 21);
            this.txt_search.TabIndex = 4;
            // 
            // Btn_search
            // 
            this.Btn_search.Location = new System.Drawing.Point(359, 461);
            this.Btn_search.Name = "Btn_search";
            this.Btn_search.Size = new System.Drawing.Size(75, 23);
            this.Btn_search.TabIndex = 5;
            this.Btn_search.Text = "검색";
            this.Btn_search.UseVisualStyleBackColor = true;
            this.Btn_search.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // Btn_add
            // 
            this.Btn_add.Location = new System.Drawing.Point(495, 461);
            this.Btn_add.Name = "Btn_add";
            this.Btn_add.Size = new System.Drawing.Size(69, 23);
            this.Btn_add.TabIndex = 8;
            this.Btn_add.Text = "등록";
            this.Btn_add.UseVisualStyleBackColor = true;
            this.Btn_add.Click += new System.EventHandler(this.Btn_add_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(774, 497);
            this.Controls.Add(this.Btn_add);
            this.Controls.Add(this.Btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.combo_type);
            this.Controls.Add(this.panel_page);
            this.Controls.Add(this.Panel_list);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_main";
            this.Text = "책정보";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 기본설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel Panel_list;
        private System.Windows.Forms.Panel panel_page;
        private System.Windows.Forms.ComboBox combo_type;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button Btn_search;
        private System.Windows.Forms.Button Btn_add;
    }
}

