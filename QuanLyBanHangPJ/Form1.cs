using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHangPJ
{
    public partial class QuanLyDmTp : Form
    {

        string strConnectionString = "Data Source=HJ;" + "Initial Catalog=QuanLyBanHang;" + "Integrated Security=True";

        SqlConnection conn = null;
        SqlDataAdapter daThanhPho = null;
        DataTable dtThanhPho = null;
        bool Them = false;

        void LoadData()
        {
            tpInput.ResetText();
            tenTpInput.ResetText();

            luuBtn.Enabled = false;
            huyBtn.Enabled = false;
            panel1.Enabled = false;

            themBtn.Enabled = true;
            suaBtn.Enabled = true;
            xoaBtn.Enabled = true;
            thoatBtn.Enabled = true;

            try
            {
                conn = new SqlConnection(strConnectionString);
                daThanhPho = new SqlDataAdapter("SELECT * FROM THANHPHO", conn);
                dtThanhPho = new DataTable();
                daThanhPho.Fill(dtThanhPho);
                dataGVTpho.DataSource = dtThanhPho;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO! Lỗi rồi!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Kiemtra()
        {
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
                conn.Open();
            // Thêm dữ liệu
            try
            {
                // Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lệnh kiem tra thanh pho ton tai ?
                cmd.CommandText = "Select Count(*) From THANHPHO Where THANHPHO='" +
                tpInput.Text.Trim() + "'";
                int k = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (k > 0)
                {
                    MessageBox.Show("Thành Phố tồn tại. Nhập Thành Phố khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tpInput.ResetText();
                    tpInput.Focus();
                }
                else
                {
                    tenTpInput.Focus();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public QuanLyDmTp()
        {
            InitializeComponent();
        }

        private void QuanLyDmTp_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void themBtn_Click(object sender, EventArgs e)
        {
            Them = true;
            tpInput.Enabled = true;
            tpInput.ResetText();
            tenTpInput.ResetText();

            luuBtn.Enabled = true;
            huyBtn.Enabled = true;
            panel1.Enabled = true;

            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            xoaBtn.Enabled = false;
            thoatBtn.Enabled = false;
            tpInput.Focus();
        }

        private void luuBtn_Click(object sender, EventArgs e)
        {
            if (!tpInput.Text.Trim().Equals(""))
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                }

                if (Them)
                {
                    try
                    {
                        // Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        // Lệnh Insert InTo
                        cmd.CommandText = "Insert Into THANHPHO Values('" +
                        tpInput.Text.Trim() + "',N'" +
                        tenTpInput.Text + "')";
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        // Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        // Thứ tự dòng hiện hành
                        int r = dataGVTpho.CurrentCell.RowIndex;
                        // MaKH hiện hành
                        string strThanhPho =
                        dataGVTpho.Rows[r].Cells[0].Value.ToString();
                        // Câu lệnh SQL
                        cmd.CommandText = "Update THANHPHO Set TenThanhPho=N'" +
                        tenTpInput.Text.Trim() + "' Where MaThanhPho='" +
                        strThanhPho.Trim() + "'";
                        // Cập nhật
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không sửa được. Lỗi rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Đóng kết nối
                conn.Close();
            } else {
                MessageBox.Show("Thành phố chưa có. Lỗi rồi!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tpInput.Focus();
            }
        }

        private void xoaBtn_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc chắn xóa?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK)
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                    conn.Open();
                try
                {
                    // Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lấy thứ tự record hiện hành
                    int r = dataGVTpho.CurrentCell.RowIndex;
                    // Lấy MaKH của record hiện hành
                    string strThanhPho =
                    dataGVTpho.Rows[r].Cells[0].Value.ToString();
                    // Viết câu lệnh SQL
                    cmd.CommandText = "Delete From THANHPHO Where MaThanhPho='" + strThanhPho.Trim() + "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện câu lệnh SQL
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được. Lỗi rồi!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Đóng kết nối
                    conn.Close();
                }
            }
        }

        private void huyBtn_Click(object sender, EventArgs e)
        {
            tpInput.ResetText();
            tenTpInput.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            themBtn.Enabled = true;
            suaBtn.Enabled = true;
            xoaBtn.Enabled = true;
            thoatBtn.Enabled = true;
            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            luuBtn.Enabled = false;
            huyBtn.Enabled = false;
            panel1.Enabled = false;
        }

        private void suaBtn_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            //dgvTHANHPHO_CellClick(null, null);
            // Cho phép thao tác trên Panel
            panel1.Enabled = true;
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            luuBtn.Enabled = true;
            huyBtn.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            themBtn.Enabled = false;
            suaBtn.Enabled = false;
            xoaBtn.Enabled = false;
            thoatBtn.Enabled = false;
            // Đưa con trỏ đến TextField txtTenCty
            tpInput.Enabled = false;
            tenTpInput.Focus();
        }


        private void tpInput_Leave(object sender, EventArgs e)
        {
            Kiemtra();
        }

        private void tpInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) Kiemtra();
        }

        private void dataGVTpho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGVTpho.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            tpInput.Text =
            dataGVTpho.Rows[r].Cells[0].Value.ToString();
            tenTpInput.Text = dataGVTpho.Rows[r].Cells[1].Value.ToString();
        }

        private void dataGVTpho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thoatBtn_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc chắn thoát?", "Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }
    }
}