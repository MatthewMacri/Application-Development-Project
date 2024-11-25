namespace Car_Reservation_System
{
    partial class AdminFormDashboard
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
            this.carListBox = new System.Windows.Forms.ListBox();
            this.addCarButton = new System.Windows.Forms.Button();
            this.updateCarButton = new System.Windows.Forms.Button();
            this.removeCarButton = new System.Windows.Forms.Button();
            this.manageReservationsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // carListBox
            // 
            this.carListBox.FormattingEnabled = true;
            this.carListBox.Location = new System.Drawing.Point(12, 12);
            this.carListBox.Name = "carListBox";
            this.carListBox.Size = new System.Drawing.Size(350, 259);
            this.carListBox.TabIndex = 0;
            // 
            // addCarButton
            // 
            this.addCarButton.Location = new System.Drawing.Point(390, 12);
            this.addCarButton.Name = "addCarButton";
            this.addCarButton.Size = new System.Drawing.Size(120, 23);
            this.addCarButton.TabIndex = 1;
            this.addCarButton.Text = "Add Car";
            this.addCarButton.UseVisualStyleBackColor = true;
            // 
            // updateCarButton
            // 
            this.updateCarButton.Location = new System.Drawing.Point(390, 51);
            this.updateCarButton.Name = "updateCarButton";
            this.updateCarButton.Size = new System.Drawing.Size(120, 23);
            this.updateCarButton.TabIndex = 2;
            this.updateCarButton.Text = "Update Car";
            this.updateCarButton.UseVisualStyleBackColor = true;
            // 
            // removeCarButton
            // 
            this.removeCarButton.Location = new System.Drawing.Point(390, 90);
            this.removeCarButton.Name = "removeCarButton";
            this.removeCarButton.Size = new System.Drawing.Size(120, 23);
            this.removeCarButton.TabIndex = 3;
            this.removeCarButton.Text = "Remove Car";
            this.removeCarButton.UseVisualStyleBackColor = true;
            // 
            // manageReservationsButton
            // 
            this.manageReservationsButton.Location = new System.Drawing.Point(390, 139);
            this.manageReservationsButton.Name = "manageReservationsButton";
            this.manageReservationsButton.Size = new System.Drawing.Size(120, 23);
            this.manageReservationsButton.TabIndex = 4;
            this.manageReservationsButton.Text = "Manage Reservations";
            this.manageReservationsButton.UseVisualStyleBackColor = true;
            // 
            // AdminFormDashboard
            // 
            this.ClientSize = new System.Drawing.Size(534, 291);
            this.Controls.Add(this.manageReservationsButton);
            this.Controls.Add(this.removeCarButton);
            this.Controls.Add(this.updateCarButton);
            this.Controls.Add(this.addCarButton);
            this.Controls.Add(this.carListBox);
            this.Name = "AdminFormDashboard";
            this.Text = "Admin Dashboard";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox carListBox;
        private System.Windows.Forms.Button addCarButton;
        private System.Windows.Forms.Button updateCarButton;
        private System.Windows.Forms.Button removeCarButton;
        private System.Windows.Forms.Button manageReservationsButton;
    }
}