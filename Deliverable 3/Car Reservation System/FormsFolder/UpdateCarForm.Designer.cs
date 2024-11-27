namespace Car_Reservation_System
{
    partial class UpdateCarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Define UI controls here
        private System.Windows.Forms.TextBox carNameTextBox;
        private System.Windows.Forms.Label carNameLabel;
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
            this.carNameLabel = new System.Windows.Forms.Label();
            this.carNameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();

            // 
            // carNameLabel
            // 
            this.carNameLabel.AutoSize = true;
            this.carNameLabel.Location = new System.Drawing.Point(20, 30);
            this.carNameLabel.Name = "carNameLabel";
            this.carNameLabel.Size = new System.Drawing.Size(58, 13);
            this.carNameLabel.TabIndex = 0;
            this.carNameLabel.Text = "Car Name:";

            // 
            // carNameTextBox
            // 
            this.carNameTextBox.Location = new System.Drawing.Point(100, 25);
            this.carNameTextBox.Name = "carNameTextBox";
            this.carNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.carNameTextBox.TabIndex = 1;

            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(100, 100);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);

            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(200, 100);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);

            // 
            // UpdateCarForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.carNameLabel);
            this.Controls.Add(this.carNameTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "UpdateCarForm";
            this.Text = "Update Car";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        #endregion
    }
}