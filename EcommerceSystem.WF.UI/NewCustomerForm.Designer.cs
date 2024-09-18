namespace EcommerceSystem.WF.UI
{
    partial class NewCustomerForm
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
            label1 = new Label();
            label2 = new Label();
            Namelabel = new Label();
            label4 = new Label();
            EmailLabel = new Label();
            btnSubmit = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(353, 40);
            label2.Name = "label2";
            label2.Size = new Size(160, 25);
            label2.TabIndex = 1;
            label2.Text = "NEW CUSTOMER";
            // 
            // Namelabel
            // 
            Namelabel.AutoSize = true;
            Namelabel.Location = new Point(224, 117);
            Namelabel.Name = "Namelabel";
            Namelabel.Size = new Size(59, 25);
            Namelabel.TabIndex = 2;
            Namelabel.Text = "Name";
            Namelabel.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 218);
            label4.Name = "label4";
            label4.Size = new Size(153, 25);
            label4.TabIndex = 3;
            label4.Text = "Shipping Address";
            label4.Click += label4_Click;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(224, 174);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(54, 25);
            EmailLabel.TabIndex = 4;
            EmailLabel.Text = "Email";
            EmailLabel.Click += label5_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(364, 287);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Location = new Point(376, 111);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(232, 31);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(376, 168);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(342, 31);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(376, 212);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(213, 31);
            textBox3.TabIndex = 8;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // NewCustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnSubmit);
            Controls.Add(EmailLabel);
            Controls.Add(label4);
            Controls.Add(Namelabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NewCustomerForm";
            Text = "NewCustomerForm";
            Load += NewCustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label Namelabel;
        private Label label4;
        private Label EmailLabel;
        private Button btnSubmit;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}