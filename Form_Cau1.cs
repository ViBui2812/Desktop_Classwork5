using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Desktop_Classwork5
{
    public partial class Form_Cau1 : Form
    {
        DataTable Sinh_Vien = new DataTable("Sinhvien");
        DataTable San_pham = new DataTable("Sanpham");
        public Form_Cau1()
        {
            
            InitializeComponent();
        }

        private void Form_Cau1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Sinh_Vien.TableName = "Sinh Vien";   
            //Creat columns
            Sinh_Vien.Columns.Add(new DataColumn("MaSV", typeof(string)));
            Sinh_Vien.Columns.Add(new DataColumn("Hoten", typeof(string)));
            Sinh_Vien.Columns.Add(new DataColumn("DTB", typeof(float)));
            //Creat Primary Key
            Sinh_Vien.PrimaryKey = new DataColumn[] { Sinh_Vien.Columns["MaSV"] };
            //Add 2 Rows
            Sinh_Vien.Rows.Add("31211", "Bùi Xuân Vĩ", 4.5);
            Sinh_Vien.Rows.Add("31212", "Bùi Xuân Vĩnh", 5);
            DataRow dr = Sinh_Vien.NewRow();
            dr["MaSV"] = "31213";
            dr[1] = "Bùi Xuân Viễn";
            dr["DTB"] = 6.5;
            Sinh_Vien.Rows.Add(dr);
            //Show to DataGr1idView
            dataGridView1.DataSource = Sinh_Vien;

        }
        private void btnWrite_Click(object sender, EventArgs e)
        {
            Sinh_Vien.WriteXml("D:\\TÀI LIỆU\\Phát Triển Ứng Dụng Desktop\\Buổi 5 - Kết nối CSDL\\SINH_VIEN.xml");
        }

        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            San_pham.Columns.Add(new DataColumn("MaSP"));
            San_pham.Columns.Add(new DataColumn("TenSP"));
            San_pham.Columns.Add(new DataColumn("MaDMSP"));
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=VIS-LAPTOP;Initial Catalog=QLBH_TestDesktop;Integrated Security=True";
            cnn.Open();
            SqlCommand sqlcmd = new SqlCommand("Select * from San_pham", cnn);
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                San_pham.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
            }
            cnn.Close();
            dataGridView1.DataSource = San_pham;
        }
    }
}
