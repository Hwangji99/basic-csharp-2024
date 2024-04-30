using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pos_test
{
    public partial class pos : Form
    {
        private bool isNew = false; // UPDATE(false), INSERT(true)

        private string ConnString = "Data Source = localhost;" +
                                    "Initial Catalog = Pos;" +
                                    "Persist Security Info = True;" +
                                    "User ID = sa; Encrypt = False;Password=mssql_p@ss";

        //private ListView listViewCart;

        public pos()
        {

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //// 리스트 뷰 컨트롤에 필요한 속성 설정
            //listViewCart.Size = new Size(300, 200);
            //listViewCart.Location = new Point(20, 20);
            //listViewCart.View = View.Details;
            //listViewCart.Columns.Add("Product ID", 100);
            //listViewCart.Columns.Add("Product Name", 100);
            //listViewCart.Columns.Add("Price", 100);
            //listViewCart.Columns.Add("Quantity", 100);

            // 폼에 리스트 뷰 컨트롤 추가
            //this.Controls.Add(listViewCart);

            // "물품번호" 열의 데이터 타입을 숫자로 지정
            //dataGridView1.Columns["Id"].ValueType = typeof(int);

            RefreshData();
        }



        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "종료하시겠습니까?", "종료여부", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true; // 종료 안되는 부분
            }
            else
            {
                Environment.Exit(0);
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            isNew = true;
            TxtId.Text = TxtName.Text = string.Empty;
            TxtPrice.Text = TxtCount.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();

                var query = "DELETE FROM [dbo].[Product] " +
                                "   WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter prmId = new SqlParameter("@Id", TxtId.Text);
                cmd.Parameters.Add(prmId);

                var result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(this, "삭제성공!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "삭제실패!", "삭제", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCartAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {

        }

        private void BtnNumAsc_Click(object sender, EventArgs e)
        {
            //// 현재 정렬 방식 확인
            //if (dataGridView1.SortOrder == SortOrder.Ascending)
            //{
            //    // 내림차순으로 변경
            //    dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Descending);
            //}
            //else
            //{
            //    // 오름차순으로 정렬
            //    dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Ascending);
            //}
        }

        //private bool isCountDescending = true; // 재고별 내림차순 정렬 여부를 나타내는 변수
        //private bool isPriceDescending = true; // 가격별 내림차순 정렬 여부를 나타내는 변수

        private void BtnCountDesc_Click(object sender, EventArgs e)
        {
            //// 현재 정렬 방식에 따라 반대로 변경
            //if (isCountDescending)
            //{
            //    dataGridView1.Sort(dataGridView1.Columns["colCount"], ListSortDirection.Ascending);
            //}
            //else
            //{
            //    dataGridView1.Sort(dataGridView1.Columns["colCount"], ListSortDirection.Descending);
            //}

            //// 정렬 방식 변경
            //isCountDescending = !isCountDescending;
        }

        private void BtnPriceDesc_Click(object sender, EventArgs e)
        {
            //// 현재 정렬 방식에 따라 반대로 변경
            //if (isPriceDescending)
            //{
            //    dataGridView1.Sort(dataGridView1.Columns["colPrice"], ListSortDirection.Ascending);
            //}
            //else
            //{
            //    dataGridView1.Sort(dataGridView1.Columns["colPrice"], ListSortDirection.Descending);
            //}

            //// 정렬 방식 변경
            //isPriceDescending = !isPriceDescending;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //int a = int.Parse(e.CellValue1.ToString()), b = int.Parse(e.CellValue2.ToString());

            //e.SortResult = a.CompareTo(b);
            //e.Handled = true;
        }

        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    var query = @"SELECT [Id]
                                   , [colName]
                                  , [colPrice]
                                  , [colCount]
                              FROM [dbo].[Product]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Product");

                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.ReadOnly = true; // 수정불가
                    dataGridView1.Columns[0].HeaderText = "물품번호";
                    dataGridView1.Columns[1].HeaderText = "과일명";
                    dataGridView1.Columns[2].HeaderText = "가격";
                    dataGridView1.Columns[3].HeaderText = "개수";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("과일명을 입력하세요.");
                return;
            }

            // 콤보박스는 SelectedIndex가 -1이 되면 안됨
            if (string.IsNullOrEmpty(TxtPrice.Text))
            {
                MessageBox.Show("가격을 입력하세요.");
                return;
            }

            if (string.IsNullOrEmpty(TxtCount.Text))
            {
                MessageBox.Show("수량을 입력하세요.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    var query = "";
                    if (isNew) // INSERT이면
                    {
                        query = @"INSERT INTO [dbo].[Product]
                                               ([colName]
                                               ,[colPrice]
                                               ,[colCount])
                                         VALUES
                                               (@colName
                                               ,@colPrice
                                               ,@colCount)";
                    }
                    else // UPDATE
                    {
                        query = @"UPDATE [dbo].[Product]
                                     SET [colName] = @colName
                                       ,[colPrice] = @colPrice
                                       ,[colCount] = @colCount
                                   WHERE Id = @Id;
";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmcolName = new SqlParameter("@colName", TxtName.Text);
                    cmd.Parameters.Add(prmcolName);
                    SqlParameter prmcolPrice = new SqlParameter("@colPrice", TxtPrice.Text);
                    cmd.Parameters.Add(prmcolPrice);
                    SqlParameter prmcolCount = new SqlParameter("@colCount", TxtCount.Text);
                    cmd.Parameters.Add(prmcolCount);
                    if (isNew != true)
                    {
                        SqlParameter prmId = new SqlParameter("@Id", TxtId.Text);
                        cmd.Parameters.Add(prmId);
                    }

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // this 메시지 박스의 부모창이 누구냐, FrmLoginUser
                        MessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // MessageBox.Show("저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // MessageBox.Show("저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"오류 : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TxtId.Text = TxtName.Text = string.Empty; // 입력, 수정, 삭제 이후에는 모든 입력값을 지워줘야 함
            TxtPrice.Text = TxtCount.Text = string.Empty;

            RefreshData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) // 아무것도 선택하지 않으면 -1
            {
                var selData = dataGridView1.Rows[e.RowIndex]; // 내가 선택한 인덱스값
                TxtId.Text = selData.Cells[0].Value.ToString();    // 책순번
                TxtName.Text = selData.Cells[1].Value.ToString();     // 저자명
                TxtPrice.Text = selData.Cells[2].Value.ToString();
                TxtCount.Text = selData.Cells[3].Value.ToString();

                isNew = false; // UPDATE
            }
        }
    }
}
