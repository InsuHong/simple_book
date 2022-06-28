using System;
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
    public partial class Form_edit : Form
    {
        private int local_B_index;
        SQLiteConnection conn;
        public delegate void FormSendDataHandler();
        public event FormSendDataHandler FormSendEvent;
        private String thum_file;
        private String connStr = Form_main.connStr;


        Global_Func GF1 = new Global_Func();  //공용클래스 사용
        public int B_index
        {
            get { return this.local_B_index; }
            set { this.local_B_index = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }


        public Form_edit()
        {
            InitializeComponent();
            pic_input.AllowDrop = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int now_idx = B_index;
            this.Location = new Point(100, 0);
            conn = Form_main.conn;
            try
            {

                if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
                string sql_que = "select * from book_list where B_index=" + now_idx.ToString();
                SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                reader.Read();

                txt_title.Text = GF1.StripSlashes(reader["B_title"].ToString());
                txt_now_book.Text = GF1.StripSlashes(reader["B_now_book"].ToString());
                txt_memo.Text = GF1.StripSlashes(reader["B_memo"].ToString());


                //FileInfo.Exists로 파일 존재유무 확인
                thum_file = reader["B_img1"].ToString();
                String img1    = Application.StartupPath + @"\data\thum\" + thum_file;
                FileInfo fi1 = new FileInfo(img1);
                if (fi1.Exists)
                {
                    pic_input.Image = Image.FromFile(img1);
                }
                else
                {
                    pic_input.Image = null;
                }

                if (conn.State == ConnectionState.Open)
                {
                  //  conn.Close();
                   // GC.Collect();
                   // GC.WaitForPendingFinalizers();
                }


            }
            catch (Exception ex)
            {
              //  if (conn.State == ConnectionState.Open) conn.Close();  //Sql연결 닫기
                Debug.WriteLine("EX03" + ex.Message);

            }
        }






  

        private void pic_input_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Btn_edit_Click(object sender, EventArgs e)
        {
            int now_idx = B_index;
            //conn = new SQLiteConnection(connStr);
            //Debug.WriteLine(conn.State.ToString() + "=>" + ConnectionState.Open.ToString());
            try
            {

                if (conn.State != ConnectionState.Open) conn.Open();   //Sql연결 열기
                //Debug.WriteLine(conn.State.ToString() + "=>" + ConnectionState.Open.ToString());
                DateTime dateTime = DateTime.Now;
                string dateTime_str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                String sql_que = "update book_list set " +
                                  "  B_title = '" + GF1.SQLite_AddSlashes(txt_title.Text) + "', " +
                                  "  B_now_book = '" + GF1.SQLite_AddSlashes(txt_now_book.Text) + "', " +
                                  "  B_img1 = '" + thum_file + "', " +
                                  "  B_memo = '" + GF1.SQLite_AddSlashes(txt_memo.Text) + "', " +
                                  "  B_editdate = '" + dateTime_str + "' " +
                                  " where B_index=" + now_idx.ToString();

                SQLiteCommand cmd = new SQLiteCommand(sql_que, conn);
                Debug.WriteLine(sql_que);
                
                cmd.ExecuteNonQuery();
                /*
                if (conn.State == ConnectionState.Open) 
                {
                    conn.Close();
                    GC.Collect();  
                    GC.WaitForPendingFinalizers();
                }
                */
                //cmd.Dispose();
                //Debug.WriteLine(sql_que);
               // Debug.WriteLine(conn.State.ToString() + "=>"+ ConnectionState.Open.ToString());
            }
            catch (Exception ex)
            {
                //if (conn.State == ConnectionState.Open) conn.Close();  //Sql연결 닫기
                Debug.WriteLine( "EX02"+ ex.Message);

            }

            try
            {
                this.FormSendEvent();
                this.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EX04" + ex.Message);

            }
        }

        private void pic_input_Click(object sender, EventArgs e)
        {

        }

        private void pic_input_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            System.IO.StreamReader pimg = new System.IO.StreamReader(files[0]);
            pic_input.Image = Image.FromStream(pimg.BaseStream);
            pimg.Dispose();

            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            long time_sc = (long)timeSpan.TotalSeconds;
            String out_file = time_sc.ToString() + ".woi";
            String old_file = Application.StartupPath + "\\data\\thum\\" + thum_file;
            //txt_thum_name.Text = out_file;

            string targetPath = Application.StartupPath + "\\data\\thum\\" + out_file;
            FileInfo fi1 = new FileInfo(files[0]);
            FileInfo old_fi = new FileInfo(old_file);
            //FileInfo.Exists로 파일 존재유무 확인
            //Debug.WriteLine(files[0].ToString());
            if (fi1.Exists)
            {
                try
                {
                    String dir_name = System.IO.Path.GetDirectoryName(files[0]);
                    System.IO.File.Copy(files[0], targetPath, true);
                    Size reSize; ;
                    Bitmap si = new Bitmap(files[0]);
                    reSize = new Size(150, 200);
                    Bitmap reSizeImg = new Bitmap(si, reSize);
                    reSizeImg.Save(targetPath);
                    thum_file = out_file;
                }
                catch (Exception ex)
                {
                    
                    Debug.WriteLine("EX06" + ex.Message);
                }
            }
            if (old_fi.Exists)
            {
                try
                {
                    System.IO.File.Delete(old_file);
                }
                catch (Exception ex)
                {
                    
                    Debug.WriteLine("EX05" + ex.Message);
                }


            }
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            int nn = 0;
            if (txt_now_book.Text != "")
            {
                nn = Int32.Parse(txt_now_book.Text);
            }
            nn++;
            txt_now_book.Text = nn.ToString();
        }

        private void bun_minus_Click(object sender, EventArgs e)
        {
            int nn = 0;
            if (txt_now_book.Text != "")
            {
                nn = Int32.Parse(txt_now_book.Text);
            }
            nn--;
            if (nn < 0) nn = 0;
            txt_now_book.Text = nn.ToString();
        }
    }
}
