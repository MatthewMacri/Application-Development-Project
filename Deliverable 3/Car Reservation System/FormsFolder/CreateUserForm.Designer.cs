namespace Car_Reservation_System
{
    partial class CreateUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label creatingUserLabel;
        private Label firstNameLabel;
        private Label lastNameLabel;
        private TextBox firstNameTextBox;
        private TextBox lastNameTextBox;
        private Button submitButton;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private ComboBox roleComboBox;
        private Label roleLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private Button cancelButton; // New Cancel Button

        private void InitializeComponent()
        {
            creatingUserLabel = new Label();
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            submitButton = new Button();
            cancelButton = new Button(); // Initialize Cancel Button
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            roleComboBox = new ComboBox();
            roleLabel = new Label();

            SuspendLayout();

            // creatingUserLabel
            creatingUserLabel.AutoSize = true;
            creatingUserLabel.Location = new Point(354, 59);
            creatingUserLabel.Name = "creatingUserLabel";
            creatingUserLabel.Size = new Size(78, 15);
            creatingUserLabel.TabIndex = 0;
            creatingUserLabel.Text = "Creating User";
            creatingUserLabel.TextAlign = ContentAlignment.TopCenter;

            // firstNameLabel
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(280, 165);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(70, 15);
            firstNameLabel.TabIndex = 1;
            firstNameLabel.Text = "First Name :";

            // lastNameLabel
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(280, 197);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(69, 15);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name :"; // Default English text (fallback)

            // firstNameTextBox
            firstNameTextBox.Location = new Point(419, 157);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(100, 23);
            firstNameTextBox.TabIndex = 3;

            // lastNameTextBox
            lastNameTextBox.Location = new Point(419, 189);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(100, 23);
            lastNameTextBox.TabIndex = 4;

            // passwordLabel
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(280, 230);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(63, 15);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Password :";

            // passwordTextBox
            passwordTextBox.Location = new Point(419, 222);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 8;

            // roleLabel
            roleLabel.AutoSize = true;
            roleLabel.Location = new Point(280, 260);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(37, 15);
            roleLabel.TabIndex = 9;
            roleLabel.Text = "Role :";

            // roleComboBox
            roleComboBox.Location = new Point(419, 257);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(121, 23);
            roleComboBox.TabIndex = 10;

            // submitButton
            submitButton.Location = new Point(631, 379);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(108, 23);
            submitButton.TabIndex = 5;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += SubmitButton_Click;

            // cancelButton
            cancelButton.Location = new Point(510, 379);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(108, 23);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_Click;

            // CreateUserForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cancelButton);
            Controls.Add(roleComboBox);
            Controls.Add(roleLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(submitButton);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(creatingUserLabel);
            Name = "CreateUserForm";
            Text = "Create User Form";
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}