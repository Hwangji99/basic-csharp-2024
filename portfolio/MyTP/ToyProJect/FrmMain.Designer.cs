namespace ToyProJect
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            display = new Label();
            TxtStart = new TextBox();
            BtnInput = new Button();
            BtnStart = new Button();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // display
            // 
            display.Dock = DockStyle.Top;
            display.Font = new Font("굴림", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            display.Location = new Point(0, 0);
            display.Name = "display";
            display.Size = new Size(388, 23);
            display.TabIndex = 0;
            display.Text = "게임을 시작합니다";
            display.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtStart
            // 
            TxtStart.Location = new Point(40, 50);
            TxtStart.Name = "TxtStart";
            TxtStart.Size = new Size(142, 23);
            TxtStart.TabIndex = 1;
            // 
            // BtnInput
            // 
            BtnInput.Font = new Font("굴림", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            BtnInput.Location = new Point(214, 50);
            BtnInput.Name = "BtnInput";
            BtnInput.Size = new Size(142, 29);
            BtnInput.TabIndex = 2;
            BtnInput.Text = "입력";
            BtnInput.UseVisualStyleBackColor = true;
            // 
            // BtnStart
            // 
            BtnStart.Dock = DockStyle.Bottom;
            BtnStart.Font = new Font("굴림", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            BtnStart.Location = new Point(0, 105);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(388, 47);
            BtnStart.TabIndex = 3;
            BtnStart.Text = "게임 시작";
            BtnStart.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 152);
            Controls.Add(BtnStart);
            Controls.Add(BtnInput);
            Controls.Add(TxtStart);
            Controls.Add(display);
            Name = "FrmMain";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label display;
        private TextBox TxtStart;
        private Button BtnInput;
        private Button BtnStart;
        private BindingSource bindingSource1;
    }
}
