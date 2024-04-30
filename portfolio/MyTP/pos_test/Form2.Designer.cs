namespace pos_test
{
    partial class pos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pos));
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            GrbDataInput = new GroupBox();
            BtnSave = new Button();
            BtnDel = new Button();
            BtnAdd = new Button();
            TxtCount = new TextBox();
            TxtPrice = new TextBox();
            TxtName = new TextBox();
            TxtId = new TextBox();
            LbCount = new Label();
            LbPrice = new Label();
            LbName = new Label();
            LbId = new Label();
            GrbCartAdd = new GroupBox();
            LbBuyCount = new Label();
            BtnCartAdd = new Button();
            TxtBuyCount = new TextBox();
            GrbCart = new GroupBox();
            Cart = new ListBox();
            BtnClear = new Button();
            BtnBuy = new Button();
            splitContainer2 = new SplitContainer();
            dataGridView1 = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            BtnNumAsc = new Button();
            BtnCountDesc = new Button();
            BtnPriceDesc = new Button();
            LbEmpty = new Label();
            BtnFilter = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            GrbDataInput.SuspendLayout();
            GrbCartAdd.SuspendLayout();
            GrbCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1184, 761);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(GrbDataInput, 0, 0);
            tableLayoutPanel1.Controls.Add(GrbCartAdd, 1, 0);
            tableLayoutPanel1.Controls.Add(GrbCart, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1184, 400);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // GrbDataInput
            // 
            GrbDataInput.Controls.Add(BtnSave);
            GrbDataInput.Controls.Add(BtnDel);
            GrbDataInput.Controls.Add(BtnAdd);
            GrbDataInput.Controls.Add(TxtCount);
            GrbDataInput.Controls.Add(TxtPrice);
            GrbDataInput.Controls.Add(TxtName);
            GrbDataInput.Controls.Add(TxtId);
            GrbDataInput.Controls.Add(LbCount);
            GrbDataInput.Controls.Add(LbPrice);
            GrbDataInput.Controls.Add(LbName);
            GrbDataInput.Controls.Add(LbId);
            GrbDataInput.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrbDataInput.Location = new Point(3, 3);
            GrbDataInput.Name = "GrbDataInput";
            GrbDataInput.Size = new Size(388, 394);
            GrbDataInput.TabIndex = 0;
            GrbDataInput.TabStop = false;
            GrbDataInput.Text = "데이터 입력";
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(132, 321);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(88, 67);
            BtnSave.TabIndex = 8;
            BtnSave.Text = "저장";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnDel
            // 
            BtnDel.Location = new Point(266, 321);
            BtnDel.Name = "BtnDel";
            BtnDel.Size = new Size(88, 67);
            BtnDel.TabIndex = 7;
            BtnDel.Text = "삭제";
            BtnDel.UseVisualStyleBackColor = true;
            BtnDel.Click += BtnDel_Click;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(6, 321);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(88, 67);
            BtnAdd.TabIndex = 5;
            BtnAdd.Text = "추가";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // TxtCount
            // 
            TxtCount.Location = new Point(110, 205);
            TxtCount.Name = "TxtCount";
            TxtCount.Size = new Size(272, 33);
            TxtCount.TabIndex = 4;
            // 
            // TxtPrice
            // 
            TxtPrice.Location = new Point(110, 157);
            TxtPrice.Name = "TxtPrice";
            TxtPrice.Size = new Size(272, 33);
            TxtPrice.TabIndex = 3;
            // 
            // TxtName
            // 
            TxtName.Location = new Point(110, 109);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(272, 33);
            TxtName.TabIndex = 2;
            // 
            // TxtId
            // 
            TxtId.Enabled = false;
            TxtId.Location = new Point(110, 60);
            TxtId.Name = "TxtId";
            TxtId.ReadOnly = true;
            TxtId.Size = new Size(272, 33);
            TxtId.TabIndex = 1;
            // 
            // LbCount
            // 
            LbCount.AutoSize = true;
            LbCount.Location = new Point(17, 209);
            LbCount.Name = "LbCount";
            LbCount.Size = new Size(50, 25);
            LbCount.TabIndex = 0;
            LbCount.Text = "재고";
            // 
            // LbPrice
            // 
            LbPrice.AutoSize = true;
            LbPrice.Location = new Point(17, 157);
            LbPrice.Name = "LbPrice";
            LbPrice.Size = new Size(50, 25);
            LbPrice.TabIndex = 0;
            LbPrice.Text = "가격";
            // 
            // LbName
            // 
            LbName.AutoSize = true;
            LbName.Location = new Point(17, 109);
            LbName.Name = "LbName";
            LbName.Size = new Size(50, 25);
            LbName.TabIndex = 0;
            LbName.Text = "품명";
            // 
            // LbId
            // 
            LbId.AutoSize = true;
            LbId.Location = new Point(17, 60);
            LbId.Name = "LbId";
            LbId.Size = new Size(50, 25);
            LbId.TabIndex = 0;
            LbId.Text = "번호";
            // 
            // GrbCartAdd
            // 
            GrbCartAdd.Controls.Add(LbBuyCount);
            GrbCartAdd.Controls.Add(BtnCartAdd);
            GrbCartAdd.Controls.Add(TxtBuyCount);
            GrbCartAdd.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrbCartAdd.Location = new Point(397, 3);
            GrbCartAdd.Name = "GrbCartAdd";
            GrbCartAdd.Size = new Size(388, 394);
            GrbCartAdd.TabIndex = 1;
            GrbCartAdd.TabStop = false;
            GrbCartAdd.Text = "장바구니 담기";
            // 
            // LbBuyCount
            // 
            LbBuyCount.AutoSize = true;
            LbBuyCount.Location = new Point(73, 91);
            LbBuyCount.Name = "LbBuyCount";
            LbBuyCount.Size = new Size(50, 25);
            LbBuyCount.TabIndex = 1;
            LbBuyCount.Text = "수량";
            // 
            // BtnCartAdd
            // 
            BtnCartAdd.Location = new Point(162, 157);
            BtnCartAdd.Name = "BtnCartAdd";
            BtnCartAdd.Size = new Size(88, 49);
            BtnCartAdd.TabIndex = 9;
            BtnCartAdd.Text = "담기";
            BtnCartAdd.UseVisualStyleBackColor = true;
            BtnCartAdd.Click += BtnCartAdd_Click;
            // 
            // TxtBuyCount
            // 
            TxtBuyCount.Location = new Point(162, 91);
            TxtBuyCount.Name = "TxtBuyCount";
            TxtBuyCount.Size = new Size(209, 33);
            TxtBuyCount.TabIndex = 8;
            // 
            // GrbCart
            // 
            GrbCart.Controls.Add(Cart);
            GrbCart.Controls.Add(BtnClear);
            GrbCart.Controls.Add(BtnBuy);
            GrbCart.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            GrbCart.ImeMode = ImeMode.On;
            GrbCart.Location = new Point(791, 3);
            GrbCart.Name = "GrbCart";
            GrbCart.Size = new Size(390, 394);
            GrbCart.TabIndex = 2;
            GrbCart.TabStop = false;
            GrbCart.Text = "장바구니";
            // 
            // Cart
            // 
            Cart.FormattingEnabled = true;
            Cart.ItemHeight = 25;
            Cart.Location = new Point(6, 32);
            Cart.Name = "Cart";
            Cart.Size = new Size(320, 279);
            Cart.TabIndex = 1;
            // 
            // BtnClear
            // 
            BtnClear.Location = new Point(116, 335);
            BtnClear.Name = "BtnClear";
            BtnClear.Size = new Size(93, 39);
            BtnClear.TabIndex = 11;
            BtnClear.Text = "비우기";
            BtnClear.UseVisualStyleBackColor = true;
            BtnClear.Click += BtnClear_Click;
            // 
            // BtnBuy
            // 
            BtnBuy.Location = new Point(6, 335);
            BtnBuy.Name = "BtnBuy";
            BtnBuy.Size = new Size(93, 39);
            BtnBuy.TabIndex = 10;
            BtnBuy.Text = "결제";
            BtnBuy.UseVisualStyleBackColor = true;
            BtnBuy.Click += BtnBuy_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainer2.Size = new Size(1184, 357);
            splitContainer2.SplitterDistance = 900;
            splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(900, 357);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.SortCompare += dataGridView1_SortCompare;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(BtnNumAsc);
            flowLayoutPanel1.Controls.Add(BtnCountDesc);
            flowLayoutPanel1.Controls.Add(BtnPriceDesc);
            flowLayoutPanel1.Controls.Add(LbEmpty);
            flowLayoutPanel1.Controls.Add(BtnFilter);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(280, 357);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // BtnNumAsc
            // 
            BtnNumAsc.Location = new Point(3, 3);
            BtnNumAsc.Name = "BtnNumAsc";
            BtnNumAsc.Size = new Size(273, 40);
            BtnNumAsc.TabIndex = 0;
            BtnNumAsc.Text = "번호 오름차순";
            BtnNumAsc.UseVisualStyleBackColor = true;
            BtnNumAsc.Click += BtnNumAsc_Click;
            // 
            // BtnCountDesc
            // 
            BtnCountDesc.Location = new Point(3, 49);
            BtnCountDesc.Name = "BtnCountDesc";
            BtnCountDesc.Size = new Size(273, 40);
            BtnCountDesc.TabIndex = 1;
            BtnCountDesc.Text = "재고 내림차순";
            BtnCountDesc.UseVisualStyleBackColor = true;
            BtnCountDesc.Click += BtnCountDesc_Click;
            // 
            // BtnPriceDesc
            // 
            BtnPriceDesc.Location = new Point(3, 95);
            BtnPriceDesc.Name = "BtnPriceDesc";
            BtnPriceDesc.Size = new Size(273, 40);
            BtnPriceDesc.TabIndex = 0;
            BtnPriceDesc.Text = "가격 내림차순";
            BtnPriceDesc.UseVisualStyleBackColor = true;
            BtnPriceDesc.Click += BtnPriceDesc_Click;
            // 
            // LbEmpty
            // 
            LbEmpty.Location = new Point(3, 138);
            LbEmpty.Name = "LbEmpty";
            LbEmpty.Size = new Size(273, 40);
            LbEmpty.TabIndex = 2;
            LbEmpty.Text = "label1";
            // 
            // BtnFilter
            // 
            BtnFilter.Location = new Point(3, 181);
            BtnFilter.Name = "BtnFilter";
            BtnFilter.Size = new Size(273, 40);
            BtnFilter.TabIndex = 3;
            BtnFilter.Text = "필터";
            BtnFilter.UseVisualStyleBackColor = true;
            // 
            // pos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "pos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "재고 관리 시스템";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            GrbDataInput.ResumeLayout(false);
            GrbDataInput.PerformLayout();
            GrbCartAdd.ResumeLayout(false);
            GrbCartAdd.PerformLayout();
            GrbCart.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private DataGridView dataGridView1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BtnNumAsc;
        private Button BtnPriceDesc;
        private Button BtnCountDesc;
        private Label LbEmpty;
        private Button BtnFilter;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox GrbDataInput;
        private GroupBox GrbCartAdd;
        private GroupBox GrbCart;
        private Label LbCount;
        private Label LbPrice;
        private Label LbName;
        private Label LbId;
        private Button BtnDel;
        private Button BtnAdd;
        private TextBox TxtCount;
        private TextBox TxtPrice;
        private TextBox TxtName;
        private TextBox TxtId;
        private Label LbBuyCount;
        private Button BtnCartAdd;
        private Button BtnClear;
        private Button BtnBuy;
        private TextBox TxtBuyCount;
        private ListBox Cart;
        private Button BtnSave;
    }
}