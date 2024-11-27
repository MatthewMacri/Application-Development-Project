namespace Car_Reservation_System
{
    partial class ManageReservationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Define UI controls here
        private System.Windows.Forms.Label reservationLabel;
        private System.Windows.Forms.TextBox reservationTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

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
            this.reservationLabel = new System.Windows.Forms.Label();
            this.reservationTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();

            // 
            // reservationLabel
            // 
            this.reservationLabel.AutoSize = true;
            this.reservationLabel.Location = new System.Drawing.Point(20, 30);
            this.reservationLabel.Name = "reservationLabel";
            this.reservationLabel.Size = new System.Drawing.Size(120, 13);
            this.reservationLabel.TabIndex = 0;
            this.reservationLabel.Text = "Reservation Details:";

            // 
            // reservationTextBox
            // 
            this.reservationTextBox.Location = new System.Drawing.Point(150, 25);
            this.reservationTextBox.Multiline = true;
            this.reservationTextBox.Name = "reservationTextBox";
            this.reservationTextBox.Size = new System.Drawing.Size(200, 100);
            this.reservationTextBox.TabIndex = 1;

            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(100, 200);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(200, 200);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);

            // 
            // ManageReservationsForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.reservationLabel);
            this.Controls.Add(this.reservationTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "ManageReservationsForm";
            this.Text = "Manage Reservations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        #endregion
    }
}