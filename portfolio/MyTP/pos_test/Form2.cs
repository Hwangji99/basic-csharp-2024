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

        // 장바구니에 담긴 제품 정보를 저장할 리스트
        private List<CartItem> cartItems = new List<CartItem>();

        // 장바구니에 담긴 제품 정보 클래스
        private class CartItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Price { get; set; }
            public int Quantity { get; set; }
        }

        public pos()
        {

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshData();
            // BtnCartAdd 이벤트 핸들러를 연결합니다.
            BtnCartAdd.Click += BtnCartAdd_Click;

            // 초기 상태에서 장바구니가 비었으면 결제 버튼 비활성화
            UpdatePaymentButtonState();
        }

        private void UpdatePaymentButtonState()
        {
            BtnBuy.Enabled = !IsCartEmpty();
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
            if (string.IsNullOrEmpty(TxtName.Text))
            {
                MessageBox.Show("과일명을 입력하세요.");
                return;
            }

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

                    var query = @"INSERT INTO [dbo].[Product]
                                          ([Pname]
                                          ,[Pprice]
                                          ,[Pcount])
                                     VALUES
                                          (@Pname
                                          ,@Pprice
                                          ,@Pcount)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmPname = new SqlParameter("@Pname", TxtName.Text);
                    cmd.Parameters.Add(prmPname);
                    SqlParameter prmPprice = new SqlParameter("@Pprice", TxtPrice.Text);
                    cmd.Parameters.Add(prmPprice);
                    SqlParameter prmPcount = new SqlParameter("@Pcount", TxtCount.Text);
                    cmd.Parameters.Add(prmPcount);

                    var result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show(this, "저장성공!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "저장실패!", "저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            RefreshData();
        }

        private void BtnCartAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBuyCount.Text) || !int.TryParse(TxtBuyCount.Text, out int buyCount))
            {
                //MessageBox.Show("올바른 수량을 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int availableCount = int.Parse(TxtCount.Text);
            if (buyCount <= 0)
            {
                MessageBox.Show("수량은 양수만 입력하세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (buyCount > availableCount)
            {
                MessageBox.Show("구매 수량이 재고 수량보다 많습니다.", "재고 부족", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 제품 정보를 장바구니에 추가
            CartItem item = new CartItem
            {
                ProductId = int.Parse(TxtId.Text),
                ProductName = TxtName.Text,
                Price = int.Parse(TxtPrice.Text),
                Quantity = buyCount
            };

            cartItems.Add(item);

            // 제품 정보를 문자열로 구성하여 Cart 리스트 박스에 추가합니다.
            string productInfo = $"{TxtName.Text} {TxtPrice.Text}원  수량: {buyCount}개";
            Cart.Items.Add(productInfo);

            // 구매 수량을 입력한 후 재고 수량을 업데이트합니다.
            TxtCount.Text = (availableCount - buyCount).ToString();

            // 필요에 따라 구매 수량 텍스트 박스를 초기화합니다.
            TxtBuyCount.Text = string.Empty;

            // 성공적으로 추가되었다는 메시지를 표시합니다.
            MessageBox.Show("제품이 장바구니에 추가되었습니다.", "추가 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdatePaymentButtonState();
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                // 계산할 총합을 구합니다.
                int totalPrice = 0;
                foreach (var item in cartItems)
                {
                    totalPrice += item.Price * item.Quantity;
                }

                // 확인 대화상자를 표시하여 사용자에게 결제 여부를 묻습니다.
                DialogResult result = MessageBox.Show($"총 결제 금액은 {totalPrice}원 입니다. 결제를 진행하시겠습니까?",
                                                      "결제 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    // 데이터베이스 연결
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();

                        // 각 제품 정보에 대해 데이터베이스에서 재고 수량을 업데이트
                        foreach (var item in cartItems)
                        {
                            // SQL 쿼리 준비
                            string query = @"UPDATE [dbo].[Product]
                                     SET [Pcount] = [Pcount] - @BuyCount
                                     WHERE Id = @ProductId";

                            // 쿼리 실행을 위한 SqlCommand 객체 생성
                            SqlCommand cmd = new SqlCommand(query, conn);

                            // 매개변수 설정
                            cmd.Parameters.AddWithValue("@BuyCount", item.Quantity);
                            cmd.Parameters.AddWithValue("@ProductId", item.ProductId);

                            // 쿼리 실행
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected <= 0)
                            {
                                MessageBox.Show("데이터베이스 업데이트에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        // 모든 제품에 대한 재고 업데이트가 완료되면 장바구니 비우기
                        cartItems.Clear();
                        Cart.Items.Clear();

                        // 성공적으로 구매가 완료되었다는 메시지를 표시합니다.
                        MessageBox.Show("구매가 완료되었습니다.", "구매 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 데이터를 다시 불러와서 데이터그리드뷰를 업데이트합니다.
                        RefreshData();
                    }
                }
                else
                {
                    // 사용자가 결제를 취소한 경우
                    MessageBox.Show("결제가 취소되었습니다.", "결제 취소", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnNumAsc_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    var query = @"SELECT [Id]
                           , [Pname]
                          , [Pprice]
                          , [Pcount]
                      FROM [dbo].[Product]
                      ORDER BY [Id] ASC"; // 번호를 오름차순으로 정렬

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

        private void BtnCountDesc_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    var query = @"SELECT [Id]
                           , [Pname]
                          , [Pprice]
                          , [Pcount]
                      FROM [dbo].[Product]
                      ORDER BY [Pcount] DESC"; // 재고 수를 내림차순으로 정렬

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

        private void BtnPriceDesc_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    var query = @"SELECT [Id]
                           , [Pname]
                          , [Pprice]
                          , [Pcount]
                      FROM [dbo].[Product]
                      ORDER BY [Pprice] DESC"; // 가격을 내림차순으로 정렬

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

        private bool IsCartEmpty()
        {
            return cartItems.Count == 0;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Cart.Items.Clear();
            cartItems.Clear();
            UpdatePaymentButtonState();
        }
        private void Btnrm_Click(object sender, EventArgs e)
        {
            // 리스트 박스에서 선택된 아이템이 있는지 확인
            if (Cart.SelectedItem != null)
            {
                // 선택된 아이템을 문자열로 가져옴
                string selectedItem = Cart.SelectedItem.ToString();

                // 확인 대화상자를 통해 사용자에게 빼시겠습니까? 물어봅니다.
                DialogResult result = MessageBox.Show($"'{selectedItem}'을(를) 장바구니에서 제거하시겠습니까?",
                                                      "아이템 제거", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // 리스트 박스에서 해당 아이템 제거
                    Cart.Items.Remove(selectedItem);

                    // 그리드 뷰에서도 해당 아이템을 찾아 제거
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // DataGridView의 특정 열에서 아이템이 있는지 확인하고 제거
                        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == selectedItem)
                        {
                            dataGridView1.Rows.Remove(row);
                            break; // 한 번만 제거하므로 반복문 탈출
                        }
                    }

                    // 장바구니 리스트를 초기화합니다.
                    cartItems.Clear();

                    // 결제 버튼 상태를 업데이트합니다.
                    UpdatePaymentButtonState();

                    MessageBox.Show($"'{selectedItem}'이(가) 장바구니에서 제거되었습니다.",
                                    "제거 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("빼고자 하는 아이템을 선택하세요.", "선택 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    var query = @"SELECT [Id]
                                   , [Pname]
                                  , [Pprice]
                                  , [Pcount]
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
                                               ([Pname]
                                               ,[Pprice]
                                               ,[Pcount])
                                         VALUES
                                               (@Pname
                                               ,@Pprice
                                               ,@Pcount)";
                    }
                    else // UPDATE
                    {
                        query = @"UPDATE [dbo].[Product]
                                     SET [Pname] = @Pname
                                       ,[Pprice] = @Pprice
                                       ,[Pcount] = @Pcount
                                   WHERE Id = @Id;
";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlParameter prmPname = new SqlParameter("@Pname", TxtName.Text);
                    cmd.Parameters.Add(prmPname);
                    SqlParameter prmPprice = new SqlParameter("@Pprice", TxtPrice.Text);
                    cmd.Parameters.Add(prmPprice);
                    SqlParameter prmPcount = new SqlParameter("@Pcount", TxtCount.Text);
                    cmd.Parameters.Add(prmPcount);
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
