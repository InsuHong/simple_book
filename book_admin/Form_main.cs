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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_admin
{
    public partial class Form_main : Form
    {
        public static SQLiteConnection conn;
        int page_num = 10, now_page = 1, max_page = 0, layout_num = 0;  //한번에 10개씩보여줌
        int table_cell_width = 0, table_cell_height = 0, table_col_count = 5, table_row_count = 2;
        private ArrayList ITEM_list = new ArrayList();
        private ArrayList ITEM_view = new ArrayList();
        private String search_type = "", search_text = "";
        private int search_cat = 0;
        Global_Func GF1 = new Global_Func();  //공용클래스 사용
        Form_edit pop1;
        Form_view pop2;
        public static String connStr;
        public Form_main()
        {
            InitializeComponent();
            String access_file = Application.StartupPath + @"\data\db\book_list.db;";
            connStr = String.Format("Data Source={0}", access_file);
            conn = new SQLiteConnection(connStr);
            pop1 = new Form_edit();
            pop1.FormSendEvent += new Form_edit.FormSendDataHandler(Page_reload);

            pop2 = new Form_view();
            combo_type.SelectedIndex = 0;
            Panel_list.VerticalScroll.Visible = false;
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
                Location = new Point((page - 1) * 32, 10),
                Width = 30,
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
                Height = layout_height - 80,
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
                Height = 16,
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
                Text = item.B_now_book + "권"
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
                Location = new Point(30, 0),
                Width = 20,
                Height = 20,

                TextAlign = ContentAlignment.MiddleCenter,
                Text = "E"
            };
            edit_btn.Click += new EventHandler((sender, e) => Edit_items(sender, e, item_idx));

            Button del_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(50, 0),
                Width = 20,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "X"
            };
            del_btn.Click += new EventHandler((sender, e) => Del_items(sender, e, item_idx));

            Button copy_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(70, 0),
                Width = 20,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "C"
            };
            copy_btn.Click += new EventHandler((sender, e) => Copy_items(sender, e, item_idx));

            view_btn = new Button()
            {
                Dock = DockStyle.None,
                Location = new Point(90, 0),
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
            Boolean search_ok = false;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
                string sql_que = "select * from book_list order by B_index desc";
                SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                ITEM_list = new ArrayList(); //초기화
                ITEMS itms;
                while (reader.Read())
                {
                    //Debug.WriteLine(reader["B_index"].ToString());
                    search_ok = false;


                    if (search_text == "" )
                    {
                       search_ok = true;
                    }
                    else
                    {
                        if (search_type == "제목" && reader["B_title"].ToString().Contains(search_text)) search_ok = true;
                        if (search_type == "비고" && reader["B_memo"].ToString().Contains(search_text)) search_ok = true;
                        
                    }
                    Debug.WriteLine(search_ok.ToString());
                    if (search_ok == true)
                    {
                        //Debug.WriteLine("title => " + reader["B_title"].ToString());
                        itms = new ITEMS
                      {
                          
                          B_index = Int32.Parse(reader["B_index"].ToString()),
                          B_title = GF1.StripSlashes(reader["B_title"].ToString()),
                          B_now_book = GF1.StripSlashes(reader["B_now_book"].ToString()),
                          B_img1 = reader["B_img1"].ToString(),
                      };

                      ITEM_list.Add(itms);
                    }

                }
                search_type = "";
                search_text = "";
                /*
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();  //Sql연결 닫기
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                */
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
                    Debug.WriteLine(ex.Message);

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
                Debug.WriteLine(reader.GetValue(0).ToString());
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
                Debug.WriteLine(sql_que);
                cmd.ExecuteNonQuery();
                
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
                Debug.WriteLine(ex.Message);
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
                Debug.WriteLine(ex.Message);

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
            public string B_img1 { get; set; }
            public int B_order { get; set; }
            public string B_regdate { get; set; }

        }


    }
}
