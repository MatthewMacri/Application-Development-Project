namespace Car_Reservation_System
{
    partial class CustomerDashboard
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
            BrandTB = new TextBox();
            TypeTB = new TextBox();
            FilterButton = new Button();
            BrandLabel = new Label();
            TypeLabel = new Label();
            AvailabilityLabel = new Label();
            DisplayRichTB = new RichTextBox();
            AvailableFromDTP = new DateTimePicker();
            AvailableFromLabel = new Label();
            AvailableToLabel = new Label();
            AvaibleToDTP = new DateTimePicker();
            SuspendLayout();
            // 
            // BrandTB
            // 
            BrandTB.Location = new Point(61, 56);
            BrandTB.Name = "BrandTB";
            BrandTB.Size = new Size(100, 23);
            BrandTB.TabIndex = 0;
            BrandTB.TextChanged += textBox1_TextChanged;
            // 
            // TypeTB
            // 
            TypeTB.Location = new Point(210, 55);
            TypeTB.Name = "TypeTB";
            TypeTB.Size = new Size(100, 23);
            TypeTB.TabIndex = 1;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(642, 42);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(92, 37);
            FilterButton.TabIndex = 3;
            FilterButton.Text = "Filter\r\n";
            FilterButton.UseVisualStyleBackColor = true;
            // 
            // BrandLabel
            // 
            BrandLabel.AutoSize = true;
            BrandLabel.Location = new Point(17, 59);
            BrandLabel.Name = "BrandLabel";
            BrandLabel.Size = new Size(44, 15);
            BrandLabel.TabIndex = 4;
            BrandLabel.Text = "Brand: ";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(167, 59);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(37, 15);
            TypeLabel.TabIndex = 5;
            TypeLabel.Text = "Type: ";
            // 
            // AvailabilityLabel
            // 
            AvailabilityLabel.AutoSize = true;
            AvailabilityLabel.Location = new Point(446, 9);
            AvailabilityLabel.Name = "AvailabilityLabel";
            AvailabilityLabel.Size = new Size(68, 15);
            AvailabilityLabel.TabIndex = 6;
            AvailabilityLabel.Text = "Availability:";
            // 
            // DisplayRichTB
            // 
            DisplayRichTB.Location = new Point(12, 173);
            DisplayRichTB.Name = "DisplayRichTB";
            DisplayRichTB.Size = new Size(621, 348);
            DisplayRichTB.TabIndex = 7;
            DisplayRichTB.Text = "";
            // 
            // AvailableFromDTP
            // 
            AvailableFromDTP.Location = new Point(399, 27);
            AvailableFromDTP.Name = "AvailableFromDTP";
            AvailableFromDTP.Size = new Size(200, 23);
            AvailableFromDTP.TabIndex = 8;
            // 
            // AvailableFromLabel
            // 
            AvailableFromLabel.AutoSize = true;
            AvailableFromLabel.Location = new Point(352, 27);
            AvailableFromLabel.Name = "AvailableFromLabel";
            AvailableFromLabel.Size = new Size(41, 15);
            AvailableFromLabel.TabIndex = 9;
            AvailableFromLabel.Text = "From: ";
            // 
            // AvailableToLabel
            // 
            AvailableToLabel.AutoSize = true;
            AvailableToLabel.Location = new Point(352, 84);
            AvailableToLabel.Name = "AvailableToLabel";
            AvailableToLabel.Size = new Size(25, 15);
            AvailableToLabel.TabIndex = 10;
            AvailableToLabel.Text = "To: ";
            // 
            // AvaibleToDTP
            // 
            AvaibleToDTP.Location = new Point(399, 84);
            AvaibleToDTP.Name = "AvaibleToDTP";
            AvaibleToDTP.Size = new Size(200, 23);
            AvaibleToDTP.TabIndex = 11;
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 562);
            Controls.Add(AvaibleToDTP);
            Controls.Add(AvailableToLabel);
            Controls.Add(AvailableFromLabel);
            Controls.Add(AvailableFromDTP);
            Controls.Add(DisplayRichTB);
            Controls.Add(AvailabilityLabel);
            Controls.Add(TypeLabel);
            Controls.Add(BrandLabel);
            Controls.Add(FilterButton);
            Controls.Add(TypeTB);
            Controls.Add(BrandTB);
            Name = "CustomerDashboard";
            Text = "CustomerDashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox BrandTB;
        private TextBox TypeTB;
        private Button FilterButton;
        private Label BrandLabel;
        private Label TypeLabel;
        private Label AvailabilityLabel;
        private RichTextBox DisplayRichTB;
        private DateTimePicker AvailableFromDTP;
        private Label AvailableFromLabel;
        private Label AvailableToLabel;
        private DateTimePicker AvaibleToDTP;
    }
}