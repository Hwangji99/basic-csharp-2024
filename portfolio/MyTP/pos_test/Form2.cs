using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos_test
{
    public partial class pos : Form
    {
        private ListView listViewCart;

        public pos()
        {

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // DataGridView 컨트롤의 열을 설정하는 메서드 호출
            setDataGridCloumn();

            // 파일에서 데이터를 읽어와 DataGridView에 추가하는 메서드 호출
            addDataGridRowFromFile();

            // 리스트 뷰 컨트롤 생성
            listViewCart = new ListView();

            // 리스트 뷰 컨트롤에 필요한 속성 설정
            listViewCart.Size = new Size(300, 200);
            listViewCart.Location = new Point(20, 20);
            listViewCart.View = View.Details;
            listViewCart.Columns.Add("Product ID", 100);
            listViewCart.Columns.Add("Product Name", 100);
            listViewCart.Columns.Add("Price", 100);
            listViewCart.Columns.Add("Quantity", 100);

            // 폼에 리스트 뷰 컨트롤 추가
            this.Controls.Add(listViewCart);
        }

        private void addDataGridRowFromFile()
        {
            StreamReader rd = new StreamReader("data.csv");

            string header_line = rd.ReadLine();
            //line is header

            while (!rd.EndOfStream)
            {
                string line = rd.ReadLine();
                string[] cols = line.Split(',');
                dataGridView1.Rows.Add(cols[0], cols[1], cols[2], cols[3]);
            }
            rd.Close();

        }


        private void setDataGridCloumn()
        {
            // 물품번호 컬럼 추가
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "물품번호";
            idColumn.ValueType = typeof(int); // 데이터 타입을 숫자로 설정하여 숫자로 정렬되도록 설정
            dataGridView1.Columns.Add(idColumn);

            // 나머지 컬럼 추가
            dataGridView1.Columns.Add("colName", "과일명");
            dataGridView1.Columns.Add("colPrice", "가격");
            dataGridView1.Columns.Add("colCount", "개수");
        }



        int selectedGridItemRowNum = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (row != null && row.Cells[0].Value != null)
            {
                selectedGridItemRowNum = e.RowIndex;
                TxtId.Text = row.Cells[0].Value.ToString();
                TxtName.Text = row.Cells[1].Value.ToString();
                TxtPrice.Text = row.Cells[2].Value.ToString();
                TxtCount.Text = row.Cells[3].Value.ToString();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[selectedGridItemRowNum];
            row.Cells[0].Value = TxtId.Text;
            row.Cells[1].Value = TxtName.Text;
            row.Cells[2].Value = TxtPrice.Text;
            row.Cells[3].Value = TxtCount.Text;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            int maxId = 0;

            // DataGridView에 행이 있는지 확인하고, 최대 id 값을 찾음
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id;
                if (row.Cells["id"].Value != null && int.TryParse(row.Cells["id"].Value.ToString(), out id))
                {
                    if (id > maxId)
                    {
                        maxId = id;
                    }
                }
            }

            // 최대 ID 값보다 1 큰 값을 사용하여 새로운 행 추가
            int newId = maxId + 1;

            // 입력된 값 가져오기
            string newName = TxtName.Text;
            string newPrice = TxtPrice.Text;
            string newCount = TxtCount.Text;

            // 새로운 행 추가
            dataGridView1.Rows.Add(newId, newName, newPrice, newCount);

            // 새로 추가된 행 선택
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            selectedGridItemRowNum = dataGridView1.Rows.Count - 1;

            // 새로 추가된 행의 값을 입력창에 표시
            TxtId.Text = newId.ToString();
            TxtName.Text = newName;
            TxtPrice.Text = newPrice;
            TxtCount.Text = newCount;
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (selectedGridItemRowNum != -1)
            {
                dataGridView1.Rows.RemoveAt(selectedGridItemRowNum);
                selectedGridItemRowNum = -1;
                TxtId.Text = "";
                TxtName.Text = "";
                TxtPrice.Text = "";
                TxtCount.Text = "";
            }
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

        private void BtnCartAdd_Click_1(object sender, EventArgs e)
        {
            // 선택된 행이 있는지 확인
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 선택된 행의 인덱스 가져오기
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // 선택된 행의 데이터 가져오기
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedIndex];
                string productId = selectedRow.Cells["Id"].Value.ToString();
                string productName = selectedRow.Cells["colName"].Value.ToString();
                int productPrice = int.Parse(selectedRow.Cells["colPrice"].Value.ToString());

                // 입력된 수량이 숫자인지 확인
                int selectedQuantity;
                if (!int.TryParse(TxtBuyCount.Text, out selectedQuantity))
                {
                    MessageBox.Show("수량을 숫자로 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 재고량 확인
                int stockQuantity = int.Parse(selectedRow.Cells["colCount"].Value.ToString());
                if (selectedQuantity > stockQuantity)
                {
                    MessageBox.Show("재고가 부족합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 장바구니에 아이템 추가
                string[] item = { productId, productName, productPrice.ToString(), selectedQuantity.ToString() };
                ListViewItem cartItem = new ListViewItem(item);
                listViewCart.Items.Add(cartItem);
            }
            else
            {
                MessageBox.Show("먼저 상품을 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCart.Items) // listViewCart를 사용하도록 수정
            {
                string productId = item.SubItems[0].Text;
                int selectedQuantity = int.Parse(item.SubItems[3].Text);

                // DataGridView에서 해당 제품 찾기
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Id"].Value.ToString() == productId) // 컬럼 이름 수정
                    {
                        int currentStock = int.Parse(row.Cells["colCount"].Value.ToString()); // 컬럼 이름 수정
                        row.Cells["colCount"].Value = (currentStock - selectedQuantity).ToString(); // 컬럼 이름 수정
                        break;
                    }
                }
            }

            // 장바구니 비우기
            listViewCart.Items.Clear(); // listViewCart를 사용하도록 수정
            MessageBox.Show("결제가 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "id") // 물품번호 컬럼인 경우
            {
                int num1, num2;
                bool isNum1 = int.TryParse(e.CellValue1.ToString(), out num1);
                bool isNum2 = int.TryParse(e.CellValue2.ToString(), out num2);

                if (isNum1 && isNum2)
                {
                    e.SortResult = num1.CompareTo(num2);
                    e.Handled = true;
                }
                else
                {
                    // 숫자로 변환할 수 없는 경우, 문자열로 정렬
                    e.SortResult = string.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                    e.Handled = true;
                }
            }
        }

        private void BtnNumAsc_Click(object sender, EventArgs e)
        {
            // "물품번호" 열을 숫자로 인식하도록 설정 
            dataGridView1.Columns["Id"].ValueType = typeof(int);

            // 현재 정렬 방식 확인
            if (dataGridView1.SortOrder == SortOrder.Ascending)
            {
                // 내림차순으로 변경
                dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Descending);
            }
            else
            {
                // 오름차순으로 정렬
                dataGridView1.Sort(dataGridView1.Columns["Id"], ListSortDirection.Ascending);
            }
        }

        private bool isCountDescending = true; // 재고별 내림차순 정렬 여부를 나타내는 변수
        private bool isPriceDescending = true; // 가격별 내림차순 정렬 여부를 나타내는 변수

        private void BtnCountDesc_Click(object sender, EventArgs e)
        {
            // 현재 정렬 방식에 따라 반대로 변경
            if (isCountDescending)
            {
                dataGridView1.Sort(dataGridView1.Columns["colCount"], ListSortDirection.Ascending);
            }
            else
            {
                dataGridView1.Sort(dataGridView1.Columns["colCount"], ListSortDirection.Descending);
            }

            // 정렬 방식 변경
            isCountDescending = !isCountDescending;
        }

        private void BtnPriceDesc_Click(object sender, EventArgs e)
        {
            // 현재 정렬 방식에 따라 반대로 변경
            if (isPriceDescending)
            {
                dataGridView1.Sort(dataGridView1.Columns["colPrice"], ListSortDirection.Ascending);
            }
            else
            {
                dataGridView1.Sort(dataGridView1.Columns["colPrice"], ListSortDirection.Descending);
            }

            // 정렬 방식 변경
            isPriceDescending = !isPriceDescending;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
