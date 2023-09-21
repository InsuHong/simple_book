using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_admin
{
    public partial class Form_main : Form
    {
        public static SQLiteConnection conn;
        int page_num = 10, now_page = 1, max_page = 0, layout_num = 0, page_btn_width = 40;  //한번에 10개씩보여줌
        int table_cell_width = 0, table_cell_height = 0, table_col_count = 5, table_row_count = 2;
        private ArrayList ITEM_list = new ArrayList();
        private ArrayList ITEM_view = new ArrayList();
        private String search_type = "", search_text = "";
        private int search_cat = 0;
        Global_Func GF1 = new Global_Func();  //공용클래스 사용
        Form_edit pop1;
        Form_view pop2;
        public static String connStr;
        string ftp_server;
        string ftp_path;
        string ftp_file = "/data/db/book_list.db";
        string ftp_user;
        string ftp_pwd;
        string start_db;

        int local_file_count = 0;
        int local_file_now = 0;

        int server_file_count = 0;
        int server_file_now = 0;

        BackgroundWorker download_thum = new BackgroundWorker();
        BackgroundWorker upload_thum = new BackgroundWorker();


        public Form_main()
        {
            InitializeComponent();
            //FTP로 접속해서 서버파일 가져오기
            try
            {
                label_state.Text = "FTP읽는중...";
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\data");
                if (di.Exists == false) di.Create();

                di = new DirectoryInfo(Application.StartupPath + @"\data/db");
                if (di.Exists == false) di.Create();

                di = new DirectoryInfo(Application.StartupPath + @"\data/thum");
                if (di.Exists == false) di.Create();




                read_ini();
                if (start_db == "원격파일")
                {
                    ftp_download();
                }
            }
            catch (Exception E)
            {
                //   Debug.WriteLine(E.ToString());
                label_state.Text = "FTP오류";
            }

            db_connect();

            //기본 테이블 없을경우 생성

            if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
            string sql_que = "SELECT COUNT(*) FROM sqlite_master WHERE name='book_list'";
            SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader[0].ToString() == "0")
            {
                sql_que = "CREATE TABLE 'book_list' (	'B_index'	INTEGER UNIQUE,	'B_title'	TEXT, 	'B_tag'	TEXT,	'B_now_book'	INTEGER, 'B_now_novel'	INTEGER,	'B_img1'	TEXT,	'B_memo'	TEXT,	'B_regdate'	TEXT,	'B_editdate'	TEXT,	PRIMARY KEY('B_index' AUTOINCREMENT))";
                cmd = new SQLiteCommand(sql_que, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                SQLiteConnection.ClearAllPools();
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //생성날짜 변경
                try
                {
                    String access_file = Application.StartupPath + @"\data\db\book_list.db";
                    DateTime mkd_time = new DateTime(2000, 1, 1);
                    File.SetLastWriteTime(access_file, mkd_time);
                    db_connect();  //DB재연결
                }
                catch (Exception E)
                {
                    Debug.WriteLine(E.ToString());
                    label_state.Text = "파일날자오류";
                }
            }


            pop1 = new Form_edit();
            pop1.FormSendEvent += new Form_edit.FormSendDataHandler(Page_reload);

            pop2 = new Form_view();
            combo_type.SelectedIndex = 0;
            Panel_list.VerticalScroll.Visible = false;
        }

        void db_connect()
        {
            read_ini();
            String access_file = Application.StartupPath + @"\data\db\book_list.db;";
            connStr = String.Format("Data Source={0}", access_file);
            conn = new SQLiteConnection(connStr);



        }

        private void make_ini()
        {
            List<string> outputList = new List<string>();
            File.WriteAllLines(Application.StartupPath + "\\setup.ini", outputList, Encoding.UTF8);

        }
        void read_ini()
        {
            FileInfo fi = new FileInfo(Application.StartupPath + "\\setup.ini");
            if (fi.Exists == false)
            {
                make_ini();
            }
            IniFile ini = new IniFile();
            ini.Load(Application.StartupPath + "\\setup.ini");

            ftp_server = ini["Simple Book Config"]["ftp_server"].ToString();
            ftp_path = ini["Simple Book Config"]["ftp_path"].ToString();
            ftp_user = ini["Simple Book Config"]["ftp_user"].ToString();
            ftp_pwd = ini["Simple Book Config"]["ftp_pwd"].ToString();
            start_db = ini["Simple Book Config"]["start_db"].ToString();

        }

        void Page_reload()
        {
            Serach_Start();
            Page_view(now_page);
        }



        void Page_num_click(object sender, EventArgs e, int pg)
        {
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#E95969");
            Page_view(pg);
        }



        private void set_page_btns(int page)
        {
            Button page_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point((page - 1) * (page_btn_width + 2), 10),
                Width = page_btn_width,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,

                Text = page.ToString()
            };
            if (now_page == page) page_btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#E95969");
            page_btn.Click += new EventHandler((sender, e) => Page_num_click(sender, e, page));
            panel_page.Controls.Add(page_btn);
        }

        void Page_Set()
        {

            double imscnt = ITEM_list.Count;
            double pg = Math.Ceiling(imscnt / page_num);
            int max_page = Int32.Parse(pg.ToString());
            int i, page;
            panel_page.Controls.Clear();
            for (i = 0; i < max_page; i++)
            {
                page = i + 1;
                set_page_btns(page);
            }

        }

        void Page_view(int page)
        {
            Panel_list.Controls.Clear();
            int start_num = (page - 1) * page_num;
            int end_num = (page * page_num) - 1;
            now_page = page;
            ITEM_view = new ArrayList();
            int j = 0, k;
            foreach (ITEMS obj in ITEM_list)
            {
                if (j >= start_num && j <= end_num)
                {
                    k = ITEM_list.Count - j;
                    obj.num = k;
                    ITEM_view.Add(obj);
                }
                j++;
            }

            Table_Clear();
            Reorder_Items();
            Page_Set();
            set_scoll_position(page);
        }
        private void set_scoll_position(int page)
        {
            panel_page.AutoScrollPosition = new Point((page - 10) * (page_btn_width + 2), 0);
        }


        void Table_Clear()
        {

            TableLayoutPanel table_panel = Panel_list;
            table_panel.Controls.Clear();
            table_panel.RowStyles.Clear();
            table_panel.ColumnStyles.Clear();
            table_panel.ColumnCount = table_col_count;
            table_panel.RowCount = table_row_count;
            table_panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            table_panel.Padding = new Padding(0);
            TableLayoutColumnStyleCollection styles1 = this.Panel_list.ColumnStyles;
            TableLayoutRowStyleCollection styles2 = this.Panel_list.RowStyles;

            if (table_col_count > 0 && table_row_count > 0)
            {
                table_panel.ColumnCount = table_col_count;
                table_panel.RowCount = table_row_count;
                int i, j;
                foreach (ColumnStyle style in styles1)
                {
                    style.SizeType = SizeType.Percent;
                    style.Width = (float)(100 / table_col_count);
                }
                foreach (RowStyle style in styles2)
                {
                    style.SizeType = SizeType.Percent;
                    style.Height = (float)(100 / table_row_count);
                }


                table_cell_width = (int)(table_panel.Width / table_col_count);
                table_cell_height = (int)(table_panel.Height / table_row_count);
            }

        }


        //검색결과 재정렬
        void Reorder_Items()
        {
            foreach (ITEMS obj in ITEM_view)
            {
                Add_items(obj);
            }

        }

        private void Add_items(ITEMS item)
        {
            int layout_width = table_cell_width, layout_height = table_cell_height;

            int item_idx = item.B_index;
            Button view_btn = null;
            PictureBox pic_thum = null;
            String img_path = Application.StartupPath + "\\data\\thum\\" + item.B_img1;

            pic_thum = new PictureBox()
            {
                Width = layout_width,
                Height = layout_height - 90,
                //Dock = DockStyle.Top,
                Dock = DockStyle.None,
                BorderStyle = BorderStyle.None,
                SizeMode = PictureBoxSizeMode.Zoom

            };
            FileInfo fi = new FileInfo(img_path);
            //FileInfo.Exists로 파일 존재유무 확인 "
            if (fi.Exists)
            {
                //                pic_thum.Load(img_path);  //파일 프로세스 점유하고있음
                System.IO.StreamReader pimg = new System.IO.StreamReader(img_path);
                pic_thum.Image = Image.FromStream(pimg.BaseStream);
                pimg.Dispose();
            }
            Label label_blank1 = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 8,
                BorderStyle = BorderStyle.None
            };
            Label label_blank2 = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 8,
                BorderStyle = BorderStyle.None
            };

            Label label_line1 = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 2,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.Fixed3D
            };
            Label label_line2 = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 2,
                Margin = new Padding(5),
                Padding = new Padding(5),
                BorderStyle = BorderStyle.Fixed3D
            };
            Label label_line3 = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 2,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.Fixed3D
            };



            TextBox label_title = new TextBox()
            {
                AutoSize = false,
                ReadOnly = true,
                BorderStyle = 0,
                BackColor = this.BackColor,
                TabStop = false,
                Dock = DockStyle.Bottom,
                Multiline = true,
                Width = layout_width,
                Height = 26,
                TextAlign = HorizontalAlignment.Center,
                //BorderStyle = BorderStyle.FixedSingle,
                Text = item.B_title
            };


            TextBox label_book = new TextBox()
            {
                AutoSize = false,
                ReadOnly = true,
                BorderStyle = 0,
                BackColor = this.BackColor,
                TabStop = false,
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 16,
                TextAlign = HorizontalAlignment.Center,
                //BorderStyle = BorderStyle.FixedSingle,
                Text = "만화 " + item.B_now_book + "권 / " + "소설 " + item.B_now_novel + "권"
            };



            Label label_num = new Label()
            {
                Dock = DockStyle.None,
                AutoSize = true,
                Height = 20,
                Location = new Point(1, 4),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "[" + item.num.ToString() + "]"
            };
            Button edit_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(50, 0),
                Width = 20,
                Height = 20,

                TextAlign = ContentAlignment.MiddleCenter,
                Text = "E"
            };
            edit_btn.Click += new EventHandler((sender, e) => Edit_items(sender, e, item_idx));

            Button del_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(70, 0),
                Width = 20,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "X"
            };
            del_btn.Click += new EventHandler((sender, e) => Del_items(sender, e, item_idx));

            Button copy_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(90, 0),
                Width = 20,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "C"
            };
            copy_btn.Click += new EventHandler((sender, e) => Copy_items(sender, e, item_idx));

            view_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(110, 0),
                Width = 20,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "V"
            };
            view_btn.Click += new EventHandler((sender, e) => View_items(sender, e, item_idx));


            Panel edit_panel = new Panel()
            {
                Dock = DockStyle.Bottom,
                Width = layout_width,
                Height = 22
            };
            edit_panel.Controls.Add(label_num);
            edit_panel.Controls.Add(edit_btn);
            edit_panel.Controls.Add(del_btn);
            edit_panel.Controls.Add(copy_btn);
            if (view_btn != null)
            {
                edit_panel.Controls.Add(view_btn);
            }





            Panel temp_panel = new Panel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0),
                Padding = new Padding(0),
                Width = layout_width,
                Height = layout_height
            };
            temp_panel.Controls.Add(pic_thum);
            temp_panel.Controls.Add(edit_panel);
            temp_panel.Controls.Add(label_line1);
            temp_panel.Controls.Add(label_blank1);
            temp_panel.Controls.Add(label_title);

            temp_panel.Controls.Add(label_line2);
            temp_panel.Controls.Add(label_blank2);
            temp_panel.Controls.Add(label_book);
            temp_panel.Controls.Add(label_line3);


            Panel_list.Controls.Add(temp_panel);
        }


        private void Serach_Start()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
                string sql_where = "where (1=1) ";
                if (search_type == "제목")
                {
                    sql_where = "where (B_title like '%" + search_text + "%') or  (B_tag like '%" + search_text + "%')";
                }
                if (search_type == "비고")
                {
                    sql_where = "where (B_memo like '%" + search_text + "%')";
                }
                if (search_type == "태그")
                {
                    sql_where = "where (B_tag like '%" + search_text + "%')";
                }

                string sql_que = "select * from book_list " + sql_where + " order by B_index desc";
                SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                ITEM_list = new ArrayList(); //초기화
                ITEMS itms;
                while (reader.Read())
                {
                    //Debug.WriteLine("title => " + reader["B_title"].ToString());
                    String now_novel = "0";
                    if (reader["B_now_novel"].ToString() != string.Empty) now_novel = GF1.StripSlashes(reader["B_now_novel"].ToString());
                    itms = new ITEMS
                    {

                        B_index = Int32.Parse(reader["B_index"].ToString()),
                        B_title = GF1.StripSlashes(reader["B_title"].ToString()),
                        B_now_book = GF1.StripSlashes(reader["B_now_book"].ToString()),
                        B_now_novel = now_novel,
                        B_img1 = reader["B_img1"].ToString(),
                    };

                    ITEM_list.Add(itms);

                }
                reader.Close();
                search_type = "";
                search_text = "";

            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR01:" + ex.Message);
            }
        }


        void View_items(object sender, EventArgs e, int item_idx)
        {
            pop2.B_index = item_idx;
            pop2.ShowDialog();



        }

        void Edit_items(object sender, EventArgs e, int item_idx)
        {
            pop1.B_index = item_idx;
            pop1.ShowDialog();
        }

        void Del_images(int item_idx)
        {

        }

        void Del_items(object sender, EventArgs e, int item_idx)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기

                    String sql_que = "select * from book_list where B_index=" + item_idx.ToString();

                    SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    String img_path = Application.StartupPath + "\\data\\thum\\" + reader["B_img1"].ToString();
                    FileInfo fi = new FileInfo(img_path);
                    if (fi.Exists) System.IO.File.Delete(img_path);
                    //이미지처리
                    Del_images(item_idx);

                    sql_que = "delete from book_list where  B_index = " + item_idx.ToString() + "";
                    cmd = new SQLiteCommand(sql_que, conn);
                    cmd.ExecuteNonQuery();
                    reader.Close();
                    /*
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();  //Sql연결 닫기
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    */
                    Serach_Start();
                    Page_view(1);
                }
                catch (Exception ex)
                {
                    /*
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();  //Sql연결 닫기
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                    */
                    // Debug.WriteLine(ex.Message);

                }

            }
        }

        void Copy_images(int source_idx, int target_idx)
        {

        }

        private void 상품등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_item();
        }

        private void New_item()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
                string sql_que = "select Max(B_index) from book_list ";
                SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                DateTime dateTime = DateTime.Now;
                string dateTime_str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                reader.Read();

                int Max_value = 0;
                //Debug.WriteLine(reader.GetValue(0).ToString());
                if (reader.GetValue(0).ToString() == "")
                {
                    sql_que = "insert into book_list (B_index, B_regdate) VALUES (1, '" + dateTime_str + "')";
                    Max_value = 1;
                }
                else
                {

                    Max_value = Int32.Parse(reader.GetValue(0).ToString());
                    Max_value++;
                    sql_que = "insert into book_list (B_index, B_regdate) VALUES (" + Max_value.ToString() + ", '" + dateTime_str + "')";

                }

                cmd = new SQLiteCommand(sql_que, conn);
                //Debug.WriteLine(sql_que);
                cmd.ExecuteNonQuery();
                reader.Close();

                /*
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();  //Sql연결 닫기
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                */
                if (Max_value > 0)
                {
                    pop1.B_index = Max_value;
                    pop1.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                /*
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();  //Sql연결 닫기
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                */
                // Debug.WriteLine(ex.Message);
            }

        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            New_item();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            Serach_Start();
            Page_view(1);

        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까??", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (start_db == "원격파일")
                {
                    ftp_upload();
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();  //Sql연결 닫기
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                Application.Exit();
            }
        }

        private void button_view1_Click(object sender, EventArgs e)
        {
            page_num = 1;
            table_col_count = 1;
            table_row_count = 1;
            Page_reload();
        }

        private void button_view2_Click(object sender, EventArgs e)
        {
            page_num = 2;
            table_col_count = 2;
            table_row_count = 1;
            Page_reload();
        }

        private void button_view4_Click(object sender, EventArgs e)
        {
            page_num = 6;
            table_col_count = 3;
            table_row_count = 2;
            Page_reload();
        }

        private void button_ftpup_Click(object sender, EventArgs e)
        {
            ftp_upload();
        }

        private void button_view10_Click(object sender, EventArgs e)
        {
            page_num = 10;
            table_col_count = 5;
            table_row_count = 2;
            Page_reload();
        }

        private void button_view24_Click(object sender, EventArgs e)
        {
            page_num = 24;
            table_col_count = 6;
            table_row_count = 4;
            Page_reload();
        }



        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (start_db == "원격파일")
            {
                ftp_upload();
            }
        }

        private void DB가져오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            read_ini();
            conn.Close();  //Sql연결 닫기
            GC.Collect();
            GC.WaitForPendingFinalizers();
            ftp_download();
        }

        private void 환경설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_config pop_config = new Form_config();
            pop_config.ShowDialog();
        }

        private void button_view32_Click(object sender, EventArgs e)
        {
            page_num = 32;
            table_col_count = 8;
            table_row_count = 4;
            Page_reload();
        }


        private void Panel_list_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            search_type = combo_type.Text;
            search_text = txt_search.Text;
            Serach_Start();
            Page_view(1);
        }




        // ##################  FTP처리 시작

        void ftp_download()
        {
            string file_path = "ftp://" + ftp_server + ftp_path + ftp_file;
            string local_path = Application.StartupPath + @"\data\db\book_list.db";
            try
            {
                //로컬 수정일
                DateTime local_modify = File.GetLastWriteTime(local_path);

                //원격파일 수정일
                DateTime ftp_modify = GetFTPFileTimestamp(file_path);

                int date_result = DateTime.Compare(ftp_modify, local_modify);

                //Debug.WriteLine("book_list.db / 로컬 : " + local_modify.ToString() + " / ftp : " + ftp_modify.ToString() + " / " + date_result.ToString());
                //FTP 최신파일만 다운로드
                if (date_result > 0)
                {
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                        client.DownloadFile(file_path, local_path);
                    }
                    //날짜를 FTP날짜와 같게만듦
                    File.SetLastWriteTime(local_path, ftp_modify);

                }
                label_state.Text = "다운로드 시작";

                download_thum.WorkerReportsProgress = true;
                download_thum.WorkerSupportsCancellation = true;
                download_thum.DoWork += new DoWorkEventHandler(Download_Thum_DoWork);
                download_thum.ProgressChanged += new ProgressChangedEventHandler(Download_Thum_ProgressChanged);
                download_thum.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Download_Thum_RunWorkerCompleted);
                download_thum.RunWorkerAsync("/data/thum");

                //DownloadFileList("/data/thum"); //이미지 파일도 다운로드
            }
            catch (Exception E)
            {
                //Debug.WriteLine(E.ToString());
                label_state.Text = "다운로드오류";
            }


        }

        private void Download_Thum_DoWork(object sender, DoWorkEventArgs e)
        {
            String thum_dir = e.Argument as String;
            DownloadFileList(thum_dir);
            //            e.Result = thum_dir;

        }

        // Progress 리포트 - UI Thread
        void Download_Thum_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int tmep = e.ProgressPercentage;

            label_state.Text = server_file_now.ToString() + "/" + server_file_count.ToString();
        }

        private void Download_Thum_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //            String thum_dir = e.Result.ToString();
            label_state.Text = "다운로드 완료";
            db_connect();
            Serach_Start();
            Page_view(1);
        }





        void ftp_upload()
        {
            conn.Close();  //Sql연결 닫기
            GC.Collect();
            GC.WaitForPendingFinalizers();

            string file_path = "ftp://" + ftp_server + ftp_path + ftp_file;
            string local_path = Application.StartupPath + @"\data\db\book_list.db";
            try
            {
                //로컬파일로 임시저장
                System.IO.File.Copy(Application.StartupPath + @"\data\db\book_list.db", Application.StartupPath + @"\data\db\book_list_temp.db", true);

                //로컬 수정일
                DateTime local_modify = File.GetLastWriteTime(local_path);

                //원격파일 수정일
                DateTime ftp_modify = GetFTPFileTimestamp(file_path);

                int date_result = DateTime.Compare(ftp_modify, local_modify);

                // Debug.WriteLine("book_list.db / 로컬 : " + local_modify.ToString() + " / ftp : " + ftp_modify.ToString() + " / " + date_result.ToString());

                //로컬 최신파일만 업로드
                if (date_result < 0)
                {
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                        client.UploadFile(file_path, Application.StartupPath + @"\data\db\book_list.db");

                    }
                    ftp_modify = GetFTPFileTimestamp(file_path);


                    //날짜를 FTP날짜와 같게만듦

                    conn.Close();
                    SQLiteConnection.ClearAllPools();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    try
                    {
                        File.SetLastWriteTime(local_path, ftp_modify);
                        db_connect();  //DB재연결
                    }
                    catch (Exception E)
                    {
                        //Debug.WriteLine(E.ToString());
                        label_state.Text = "파일날자오류";
                    }




                }

                label_state.Text = "업로드 시작";

                upload_thum.WorkerReportsProgress = true;
                upload_thum.WorkerSupportsCancellation = true;
                upload_thum.DoWork += new DoWorkEventHandler(Upload_Thum_DoWork);
                upload_thum.ProgressChanged += new ProgressChangedEventHandler(Upload_Thum_ProgressChanged);
                upload_thum.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Upload_Thum_RunWorkerCompleted);
                upload_thum.RunWorkerAsync("/data/thum");

                //                UploadFileList("/data/thum"); //이미지 파일도 업로드
            }
            catch (Exception E)
            {
                //Debug.WriteLine(E.ToString());
                label_state.Text = "업로드오류";
            }
            conn.Open();   //Sql연결 다시열기
        }



        private void Upload_Thum_DoWork(object sender, DoWorkEventArgs e)
        {
            String thum_dir = e.Argument as String;
            UploadFileList(thum_dir);
            //            e.Result = thum_dir;

        }

        // Progress 리포트 - UI Thread
        void Upload_Thum_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label_state.Text = local_file_now.ToString() + "/" + local_file_count.ToString();
        }

        private void Upload_Thum_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //            String thum_dir = e.Result.ToString();
            label_state.Text = "업로드 완료";
        }




        private void UploadFileList(string source)
        {
            // 업로드할 경로의 속성을 구한다.
            string url = "ftp://" + ftp_server + ftp_path + source;
            String file_path = Application.StartupPath + source;
            var attr = File.GetAttributes(file_path);
            String temp_file;
            // 만약 디렉토리라면..
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // 디렉토리 정보를 가져온다.
                DirectoryInfo dir = new DirectoryInfo(file_path);
                // 디렉토리 안의 파일 리스트를 가져온다.
                local_file_count = dir.GetFiles().Length;
                local_file_now = 0;
                foreach (var item in dir.GetFiles())
                {
                    // 파일을 업로드한다.
                    local_file_now++;
                    temp_file = source + @"\" + item.Name;
                    UploadFileList(temp_file);
                    upload_thum.ReportProgress(local_file_now);
                }
                // 디렉토리 안의 하위 디렉토리 리스트를 가져온다.
                foreach (var item in dir.GetDirectories())
                {
                    try
                    {

                        WebRequest request = WebRequest.Create(url);
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                        using (var resp = (FtpWebResponse)request.GetResponse())
                        {
                            Console.WriteLine(resp.StatusCode);
                        }

                    }
                    catch (WebException)
                    {
                        // 만약에 ftp에 디렉토리가 존재한다면 에러가 날 것이다.
                    }
                    // 디렉토리를 업로드한다.(재귀 함수 호출)
                    UploadFileList(item.FullName);
                }
            }
            else
            {
                // 디렉토리가 아닌 파일을 경우인데, 파일의 stream을 취득한다.
                String remote_path = "ftp://" + ftp_server + ftp_path + source.Replace(@"\", "/");
                //Debug.WriteLine(remote_path);
                //원격 파일사이즈
                /*
                long remote_filesize = 0;
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(remote_path);
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                ftpRequest.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                try
                {
                    using (FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse())
                    {
                        remote_filesize = response.ContentLength;
                    }
                }
                catch (Exception exception)
                {
                    if (exception.Message.Contains("File unavailable"))
                    {
                        remote_filesize = 0;
                    }

                }


                long local_filesize = 0;
                FileInfo info = new FileInfo(file_path);
                if (File.Exists(file_path))
                {
                    local_filesize = info.Length;
                }
                */
                //로컬 수정일
                DateTime local_modify = File.GetLastWriteTime(file_path);

                //원격파일 수정일
                DateTime ftp_modify = GetFTPFileTimestamp(remote_path);

                int date_result = DateTime.Compare(ftp_modify, local_modify);

                //   Debug.WriteLine(source + " / 로컬 : " + local_modify.ToString() + " / ftp : " + ftp_modify.ToString() + " / " + date_result.ToString());


                // if (remote_filesize != local_filesize || remote_filesize == -1 || remote_filesize == 0)
                if (date_result < 0)
                {
                    //Debug.WriteLine(source + " (업로드) / 로컬 : " + local_modify.ToString() + " / ftp : " + ftp_modify.ToString() + " / " + date_result.ToString());
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                        //Debug.WriteLine(file_path + "=>" + remote_path);
                        client.UploadFile(remote_path, file_path);
                    }
                    //날짜를 FTP날짜와 같게만듦
                    ftp_modify = GetFTPFileTimestamp(remote_path);
                    try
                    {
                        File.SetLastWriteTime(file_path, ftp_modify);
                    }
                    catch (Exception E)
                    {
                        //Debug.WriteLine(E.ToString());
                        label_state.Text = "파일날자오류";
                    }
                }

            }
        }



        private void DownloadFileList(string target)
        {
            string url = "ftp://" + ftp_server + ftp_path + target.Replace(@"\", "/");
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(url);
            ftpRequest.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            Boolean is_dir = false;
            String fname;
            while (!string.IsNullOrEmpty(line))
            {

                fname = System.IO.Path.GetFileName(line);
                directories.Add(fname);
                line = streamReader.ReadLine();
                is_dir = true;
            }
            streamReader.Close();
            server_file_count = directories.Count();
            // Debug.WriteLine("처리해야할 파일수 : " + server_file_count.ToString());
            // ftp 리스트를 돌린다.
            String remote_path, local_path;
            server_file_now = 0;
            if (is_dir == true)
            {
                foreach (var item in directories)
                {
                    try
                    {
                        // 파일을 다운로드한다.
                        //Debug.WriteLine(item);
                        server_file_now++;
                        remote_path = "ftp://" + ftp_server + ftp_path + target + @"/" + item;
                        local_path = Application.StartupPath + target + @"\" + item;
                        download_thum.ReportProgress(server_file_now);

                        /*
                        //원격 파일사이즈
                        ftpRequest = (FtpWebRequest) WebRequest.Create(remote_path);
                        ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                        ftpRequest.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                        long remote_filesize = 0;

                        try
                        {
                            using (response = (FtpWebResponse)ftpRequest.GetResponse())
                            {
                                remote_filesize = response.ContentLength;
                            }
                        }
                        catch (Exception exception)
                        {
                            if (exception.Message.Contains("File unavailable"))
                            {
                                remote_filesize = 0;
                            }

                        }
                        


                        long local_filesize = 0;
                        FileInfo info = new FileInfo(local_path);
                        if (File.Exists(local_path))
                        {
                            local_filesize = info.Length;
                        }
                        */

                        //로컬 수정일
                        DateTime local_modify = File.GetLastWriteTime(local_path);

                        //원격파일 수정일
                        DateTime ftp_modify = GetFTPFileTimestamp(remote_path);

                        int date_result = DateTime.Compare(ftp_modify, local_modify);
                        //Debug.WriteLine(item + " / 로컬 : " + local_modify.ToString() + " / ftp : " + ftp_modify.ToString() + " / " + date_result.ToString());


                        //if (remote_filesize != local_filesize || local_filesize == 0)
                        if (date_result > 0)
                        {
                            //Debug.WriteLine(remote_path + "(" + remote_filesize.ToString() + ") => " + local_path + "(" + local_filesize.ToString() + ")");
                            using (var client = new WebClient())
                            {
                                client.Credentials = new NetworkCredential(ftp_user, ftp_pwd);
                                client.DownloadFile(remote_path, local_path);
                                //수정날짜를 FPT날짜와 같게 만듬
                                File.SetLastWriteTime(local_path, ftp_modify);
                            }
                        }

                    }
                    catch (WebException)
                    {
                        // 그러나 파일이 아닌 디렉토리의 경우는 에러가 발생한다.
                        // 로컬 디렉토리를 만든다.
                        Directory.CreateDirectory(Application.StartupPath + target + "\\" + item);
                        // 디렉토리라면 재귀적 방법으로 다시 파일리스트를 탐색한다.
                        DownloadFileList(target + "\\" + item);
                    }
                }
            }

        }



        private DateTime GetFTPFileTimestamp(string ftpURL)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpURL);

            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            request.Credentials = new NetworkCredential(ftp_user, ftp_pwd);

            try
            {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.LastModified;
                }
            }
            catch (Exception exception)
            {
                return new DateTime(1970, 1, 1);
                Debug.WriteLine("에러메시지 : " + exception.ToString());
                /*
                if (exception.Message.Contains("File unavailable"))
                {
                    return new DateTime(1970, 1, 1);
                }
                */
                throw;
            }
        }

        // ##################  FTP처리 끝




        void Copy_items(object sender, EventArgs e, int item_idx)
        {
            try
            {

                if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
                string sql_que = "select Max(B_index) from em_list ";
                SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int Max_value = Int32.Parse(reader.GetValue(0).ToString());
                Max_value++;
                DateTime dateTime = DateTime.Now;
                string dateTime_str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sql_que = "insert into book_list (B_index, B_regdate) VALUES (" + Max_value.ToString() + ", '" + dateTime_str + "')";
                cmd = new SQLiteCommand(sql_que, conn);
                cmd.ExecuteNonQuery();
                sql_que = "select * from book_list where B_index=" + item_idx.ToString();
                cmd = new SQLiteCommand(sql_que, conn);
                reader = cmd.ExecuteReader();
                reader.Read();

                //이미지처리
                Copy_images(item_idx, Max_value);
                String B_img1 = "";

                sql_que = "update book_list set " +
                                                 "  B_title = '" + GF1.SQLite_AddSlashes(reader["B_title"].ToString()) + "', " +
                                                 "  B_now_book = '" + GF1.SQLite_AddSlashes(reader["B_now_book"].ToString()) + "', " +
                                                 "  B_now_novel = '" + GF1.SQLite_AddSlashes(reader["B_now_novel"].ToString()) + "', " +
                                                 "  B_img1 = '" + B_img1 + "', " +
                                                 "  B_memo = '" + GF1.SQLite_AddSlashes(reader["B_memo"].ToString()) + "' " +
                                                 " where B_index=" + Max_value.ToString();

                //Debug.WriteLine(sql_que);
                cmd = new SQLiteCommand(sql_que, conn);
                cmd.ExecuteNonQuery();
                /*
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();  //Sql연결 닫기
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                */
                reader.Close();
                Serach_Start();
                Page_view(1);
            }
            catch (Exception ex)
            {
                /*
                                if (conn.State == ConnectionState.Open)
                                {
                                    conn.Close();  //Sql연결 닫기
                                    GC.Collect();
                                    GC.WaitForPendingFinalizers();
                                }
                */
                // Debug.WriteLine(ex.Message);

            }
        }


        public class ITEMS
        {
            public ITEMS()
            {

            }
            public int num { get; set; }
            public int B_index { get; set; }
            public string B_title { get; set; }
            public string B_now_book { get; set; }
            public string B_now_novel { get; set; }
            public string B_img1 { get; set; }
            public int B_order { get; set; }
            public string B_regdate { get; set; }

        }


    }
}
