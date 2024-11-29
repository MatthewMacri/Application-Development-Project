namespace Car_Reservation_System
{
    partial class AdminFormDashboard
    {
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

        private void InitializeComponent()
        {
            carListBox = new ListBox();
            addCarButton = new Button();
            updateCarButton = new Button();
            removeCarButton = new Button();
            manageReservationsButton = new Button();
            SuspendLayout();

            // 
            // carListBox
            // 
            carListBox.FormattingEnabled = true;
            carListBox.ItemHeight = 15;
            carListBox.Location = new Point(12, 12);
            carListBox.Name = "carListBox";
            carListBox.Size = new Size(400, 400);
            carListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            carListBox.TabIndex = 0;

            // 
            // addCarButton
            // 
            addCarButton.Location = new Point(430, 20);
            addCarButton.Name = "addCarButton";
            addCarButton.Size = new Size(120, 30);
            addCarButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addCarButton.TabIndex = 1;
            addCarButton.Text = "Add Car";
            addCarButton.UseVisualStyleBackColor = true;
            addCarButton.Click += AddCarButton_Click;

            // 
            // updateCarButton
            // 
            updateCarButton.Location = new Point(430, 60);
            updateCarButton.Name = "updateCarButton";
            updateCarButton.Size = new Size(120, 30);
            updateCarButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateCarButton.TabIndex = 2;
            updateCarButton.Text = "Update Car";
            updateCarButton.UseVisualStyleBackColor = true;
            updateCarButton.Click += UpdateCarButton_Click;

            // 
            // removeCarButton
            // 
            removeCarButton.Location = new Point(430, 100);
            removeCarButton.Name = "removeCarButton";
            removeCarButton.Size = new Size(120, 30);
            removeCarButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            removeCarButton.TabIndex = 3;
            removeCarButton.Text = "Remove Car";
            removeCarButton.UseVisualStyleBackColor = true;
            removeCarButton.Click += RemoveCarButton_Click;

            // 
            // manageReservationsButton
            // 
            manageReservationsButton.Location = new Point(430, 140);
            manageReservationsButton.Name = "manageReservationsButton";
            manageReservationsButton.Size = new Size(120, 30);
            manageReservationsButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            manageReservationsButton.TabIndex = 4;
            manageReservationsButton.Text = "Manage Reservations";
            manageReservationsButton.UseVisualStyleBackColor = true;
            manageReservationsButton.Click += ManageReservationsButton_Click;

            // 
            // AdminFormDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(carListBox);
            Controls.Add(addCarButton);
            Controls.Add(updateCarButton);
            Controls.Add(removeCarButton);
            Controls.Add(manageReservationsButton);
            Name = "AdminFormDashboard";
            Text = "Admin Dashboard";
            ResumeLayout(false);
        }

        #endregion

        private ListBox carListBox;
        private Button addCarButton;
        private Button updateCarButton;
        private Button removeCarButton;
        private Button manageReservationsButton;
    }
}