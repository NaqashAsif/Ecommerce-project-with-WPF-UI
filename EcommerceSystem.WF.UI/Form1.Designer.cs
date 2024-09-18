namespace EcommerceSystem.WF.UI
{
    partial class Form1
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
            btnNewCustomer = new Button();
            btnExistingButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Location = new Point(304, 106);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(217, 50);
            btnNewCustomer.TabIndex = 0;
            btnNewCustomer.Text = "NEW CUSTOMER";
            btnNewCustomer.UseVisualStyleBackColor = true;
            btnNewCustomer.Click += button1_Click;
            // 
            // btnExistingButton
            // 
            btnExistingButton.Location = new Point(304, 193);
            btnExistingButton.Name = "btnExistingButton";
            btnExistingButton.Size = new Size(217, 50);
            btnExistingButton.TabIndex = 1;
            btnExistingButton.Text = "EXISTING CUSTOMER";
            btnExistingButton.UseVisualStyleBackColor = true;
            btnExistingButton.Click += btnExistingButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 47);
            label1.Name = "label1";
            label1.Size = new Size(329, 25);
            label1.TabIndex = 3;
            label1.Text = "WELCOME TO ECOMMERCE SYSTEM";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 450);
            Controls.Add(label1);
            Controls.Add(btnExistingButton);
            Controls.Add(btnNewCustomer);
            Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNewCustomer;
        private Button btnExistingButton;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
    }
}
