namespace Car_Reservation_System
{
    partial class Login
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
            newUserButton = new Button();
            label1 = new Label();
            label2 = new Label();
            idTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label3 = new Label();
            SubmitButton = new Button();
            SuspendLayout();
            // 
            // newUserButton
            // 
            newUserButton.Location = new Point(229, 350);
            newUserButton.Name = "newUserButton";
            newUserButton.Size = new Size(75, 23);
            newUserButton.TabIndex = 0;
            newUserButton.Text = "New User";
            newUserButton.UseVisualStyleBackColor = true;
            newUserButton.Click += newUserButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(373, 36);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Login Screen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(334, 135);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 2;
            label2.Text = "Id : ";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(384, 127);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(100, 23);
            idTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(384, 167);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(297, 175);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 5;
            label3.Text = "Password :";
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(562, 350);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(92, 23);
            SubmitButton.TabIndex = 6;
            SubmitButton.Text = "Submit";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SubmitButton);
            Controls.Add(label3);
            Controls.Add(passwordTextBox);
            Controls.Add(idTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(newUserButton);
            Name = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newUserButton;
        private Label label1;
        private Label label2;
        private TextBox idTextBox;
        private TextBox passwordTextBox;
        private Label label3;
        private Button SubmitButton;
    }
}