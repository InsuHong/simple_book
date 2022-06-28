using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace book_admin
{
    public partial class Form_view : Form
    {
        private int local_B_index;
        SQLiteConnection conn;
        public int B_index
        {
            get { return this.local_B_index; }
            set { this.local_B_index = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        public Form_view()
        {
            InitializeComponent();
        }

        private void Form_view_Load(object sender, EventArgs e)
        {
            int now_idx = B_index;
            this.Location = new Point(100, 0);
        }
    }
}
