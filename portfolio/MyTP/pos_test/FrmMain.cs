namespace pos_test
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtId.Text == "admin" && TxtPassword.Text == "1234")
            {
                this.Hide();
                pos main_form = new pos();
                main_form.Show();
            }
            else
            {
                MessageBox.Show("로그인 실패");
            }
        }
    }
}
