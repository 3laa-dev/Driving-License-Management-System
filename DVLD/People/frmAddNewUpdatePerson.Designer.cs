namespace DVLD
{
    partial class frmAddNewUpdatePerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewUpdatePerson));
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlAddNewUpdatePerson1 = new DVLD.ctrlAddNewUpdatePerson();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(458, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New Person ";
            // 
            // ctrlAddNewUpdatePerson1
            // 
            this.ctrlAddNewUpdatePerson1.Address = "";
            this.ctrlAddNewUpdatePerson1.BirthOfDate = new System.DateTime(2026, 10, 22, 19, 38, 43, 891);
            this.ctrlAddNewUpdatePerson1.Email = "";
            this.ctrlAddNewUpdatePerson1.FirstName = "";
            this.ctrlAddNewUpdatePerson1.Gender = "Male";
            this.ctrlAddNewUpdatePerson1.LastName = "";
            this.ctrlAddNewUpdatePerson1.Location = new System.Drawing.Point(97, 99);
            this.ctrlAddNewUpdatePerson1.Name = "ctrlAddNewUpdatePerson1";
            this.ctrlAddNewUpdatePerson1.NationalNo = "";
            this.ctrlAddNewUpdatePerson1.Phone = "";
            this.ctrlAddNewUpdatePerson1.SecondName = "";
            this.ctrlAddNewUpdatePerson1.Size = new System.Drawing.Size(960, 476);
            this.ctrlAddNewUpdatePerson1.TabIndex = 0;
            this.ctrlAddNewUpdatePerson1.ThirdName = "";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(522, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 51);
            this.button2.TabIndex = 40;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(702, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 51);
            this.button1.TabIndex = 39;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmAddNewUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 609);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlAddNewUpdatePerson1);
            this.Name = "frmAddNewUpdatePerson";
            this.Text = "Add New Person";
            this.Load += new System.EventHandler(this.frmAddNewUpdatePerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAddNewUpdatePerson ctrlAddNewUpdatePerson1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}