namespace program
{
    partial class LoginForm
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            UsernameLabel = new Label();
            PassLabel = new Label();
            UsernameTxtBox = new TextBox();
            PassTxtBox = new TextBox();
            LangChangButton = new Button();
            LoginButton = new Button();
            FormNameLabel = new Label();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = Color.Wheat;
            UsernameLabel.Location = new Point(12, 50);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(130, 23);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "UsernameLabel";
            // 
            // PassLabel
            // 
            PassLabel.AutoSize = true;
            PassLabel.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PassLabel.ForeColor = Color.Wheat;
            PassLabel.Location = new Point(12, 83);
            PassLabel.Name = "PassLabel";
            PassLabel.Size = new Size(85, 23);
            PassLabel.TabIndex = 1;
            PassLabel.Text = "PassLebel";
            // 
            // UsernameTxtBox
            // 
            UsernameTxtBox.BackColor = Color.Wheat;
            UsernameTxtBox.ForeColor = SystemColors.WindowText;
            UsernameTxtBox.Location = new Point(129, 49);
            UsernameTxtBox.Name = "UsernameTxtBox";
            UsernameTxtBox.Size = new Size(336, 27);
            UsernameTxtBox.TabIndex = 3;
            // 
            // PassTxtBox
            // 
            PassTxtBox.BackColor = Color.Wheat;
            PassTxtBox.Location = new Point(129, 82);
            PassTxtBox.Name = "PassTxtBox";
            PassTxtBox.Size = new Size(336, 27);
            PassTxtBox.TabIndex = 4;
            PassTxtBox.UseSystemPasswordChar = true;
            // 
            // LangChangButton
            // 
            LangChangButton.FlatStyle = FlatStyle.Flat;
            LangChangButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            LangChangButton.ForeColor = Color.Wheat;
            LangChangButton.Location = new Point(12, 132);
            LangChangButton.Name = "LangChangButton";
            LangChangButton.Size = new Size(47, 29);
            LangChangButton.TabIndex = 5;
            LangChangButton.Text = "LNG";
            LangChangButton.UseVisualStyleBackColor = true;
            LangChangButton.Click += LangChangButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.BackColor = Color.Gray;
            LoginButton.FlatStyle = FlatStyle.Flat;
            LoginButton.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LoginButton.ForeColor = Color.Wheat;
            LoginButton.Location = new Point(371, 128);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 35);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "Увійти";
            LoginButton.UseVisualStyleBackColor = false;
            LoginButton.Click += LoginButton_Click;
            // 
            // FormNameLabel
            // 
            FormNameLabel.AutoEllipsis = true;
            FormNameLabel.AutoSize = true;
            FormNameLabel.BackColor = Color.Transparent;
            FormNameLabel.Font = new Font("Palatino Linotype", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormNameLabel.ForeColor = Color.Wheat;
            FormNameLabel.Location = new Point(12, 9);
            FormNameLabel.Name = "FormNameLabel";
            FormNameLabel.Size = new Size(193, 31);
            FormNameLabel.TabIndex = 7;
            FormNameLabel.Text = "FormNameLabel";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(477, 173);
            Controls.Add(FormNameLabel);
            Controls.Add(LoginButton);
            Controls.Add(LangChangButton);
            Controls.Add(PassTxtBox);
            Controls.Add(UsernameTxtBox);
            Controls.Add(PassLabel);
            Controls.Add(UsernameLabel);
            Name = "LoginForm";
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Label PassLabel;
        private TextBox UsernameTxtBox;
        private TextBox PassTxtBox;
        private Button LangChangButton;
        private Button LoginButton;
        private Label FormNameLabel;
    }
}
