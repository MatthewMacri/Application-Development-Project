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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            FilterButton = new Button();
            BrandLabel = new Label();
            TypeLabel = new Label();
            label3 = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(169, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(319, 28);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(479, 28);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            // 
            // FilterButton
            // 
            FilterButton.Location = new Point(12, 27);
            FilterButton.Name = "FilterButton";
            FilterButton.Size = new Size(75, 23);
            FilterButton.TabIndex = 3;
            FilterButton.Text = "Filter\r\n";
            FilterButton.UseVisualStyleBackColor = true;
            // 
            // BrandLabel
            // 
            BrandLabel.AutoSize = true;
            BrandLabel.Location = new Point(125, 31);
            BrandLabel.Name = "BrandLabel";
            BrandLabel.Size = new Size(44, 15);
            BrandLabel.TabIndex = 4;
            BrandLabel.Text = "Brand: ";
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(275, 31);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(37, 15);
            TypeLabel.TabIndex = 5;
            TypeLabel.Text = "Type: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(435, 31);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 137);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(437, 277);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(label3);
            Controls.Add(TypeLabel);
            Controls.Add(BrandLabel);
            Controls.Add(FilterButton);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "CustomerDashboard";
            Text = "CustomerDashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button FilterButton;
        private Label BrandLabel;
        private Label TypeLabel;
        private Label label3;
        private RichTextBox richTextBox1;
    }
}