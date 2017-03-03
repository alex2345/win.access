using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win_access
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 '資料庫1DataSet.grade' 資料表。您可以視需要進行移動或移除。
            this.gradeTableAdapter.Fill(this.資料庫1DataSet.grade);
            // TODO:  這行程式碼會將資料載入 '資料庫1DataSet.student' 資料表。您可以視需要進行移動或移除。
            this.studentTableAdapter.Fill(this.資料庫1DataSet.student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // [C#][WinForm] GridView 中 CheckBox 全選
            //https://dotblogs.com.tw/shunnien/2013/07/22/111941
            //step1. 先建立 CheckBox 欄
            DataGridViewCheckBoxColumn cbCol = new DataGridViewCheckBoxColumn();
            cbCol.Name = "chkbox_0";     //給定名稱
            cbCol.Width = 50;                      //設定寬度
            cbCol.HeaderText = "　全選"; //標題文字
            cbCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;   //置中
            dataGridView2.Columns.Insert(0, cbCol);
            //
            //step2. 建立矩形，等下
            Rectangle rect = dataGridView2.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + rect.Width / 4 - 9;     //CheckBox 嵌入 GridView 的位置 (X軸)
            rect.Y = rect.Location.Y + (rect.Height / 2 - 14); //CheckBox 嵌入 GridView 的位置 (Y軸)
            CheckBox cbHeader = new CheckBox();
            cbHeader.Name = "checkboxHeader";
            cbHeader.Size = new Size(18, 18);
            cbHeader.Location = rect.Location;    
            //委派 delegate 全選要設定的事件
            cbHeader.CheckedChanged += new EventHandler(cbHeader_CheckedChanged);
            //將 CheckBox 加入到 dataGridView
            dataGridView2.Controls.Add(cbHeader);
            
        }
        private void cbHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView2.Rows)
                dr.Cells[0].Value = ((CheckBox)dataGridView2.Controls.
                    Find("checkboxHeader", true)[0]).Checked;
            // dr.Cells[0] = 設定 DataGridView 第0欄的值
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Remove("chkbox_0");
        }
    }
}
