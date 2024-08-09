namespace QLThueNha
{
    partial class Form3
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
            this.btnQLNha = new System.Windows.Forms.Button();
            this.btnQLHD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQLNha
            // 
            this.btnQLNha.Location = new System.Drawing.Point(232, 225);
            this.btnQLNha.Name = "btnQLNha";
            this.btnQLNha.Size = new System.Drawing.Size(105, 83);
            this.btnQLNha.TabIndex = 0;
            this.btnQLNha.Text = "Quản lý nhà ";
            this.btnQLNha.UseVisualStyleBackColor = true;
            // 
            // btnQLHD
            // 
            this.btnQLHD.Location = new System.Drawing.Point(494, 225);
            this.btnQLHD.Name = "btnQLHD";
            this.btnQLHD.Size = new System.Drawing.Size(122, 83);
            this.btnQLHD.TabIndex = 1;
            this.btnQLHD.Text = "Quản lý hợp đồng";
            this.btnQLHD.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.btnQLHD);
            this.Controls.Add(this.btnQLNha);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQLNha;
        private System.Windows.Forms.Button btnQLHD;
    }
}