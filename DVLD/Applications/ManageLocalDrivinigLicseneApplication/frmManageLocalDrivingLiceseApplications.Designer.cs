namespace DVLD.Applications.ManageLocalDrivinigLicseneApplication
{
    partial class frmManageLocalDrivingLiceseApplications
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLocalDrivingLiceseApplications));
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechedualVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualWritenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schedualStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(1217, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 10);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(630, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 168);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textBox1.Location = new System.Drawing.Point(412, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 30);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(93, 262);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(313, 30);
            this.comboBox1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filter By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(354, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(729, 44);
            this.label1.TabIndex = 20;
            this.label1.Text = "Manage Local Driving License Applications";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(1455, 343);
            this.dataGridView1.TabIndex = 26;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.schedualToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 84);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelToolStripMenuItem.Image")));
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // schedualToolStripMenuItem
            // 
            this.schedualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechedualVisionTestToolStripMenuItem,
            this.schedualWritenTestToolStripMenuItem,
            this.schedualStreetTestToolStripMenuItem});
            this.schedualToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("schedualToolStripMenuItem.Image")));
            this.schedualToolStripMenuItem.Name = "schedualToolStripMenuItem";
            this.schedualToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.schedualToolStripMenuItem.Text = "Schedual Tests";
            // 
            // sechedualVisionTestToolStripMenuItem
            // 
            this.sechedualVisionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sechedualVisionTestToolStripMenuItem.Image")));
            this.sechedualVisionTestToolStripMenuItem.Name = "sechedualVisionTestToolStripMenuItem";
            this.sechedualVisionTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.sechedualVisionTestToolStripMenuItem.Text = "Schedual Vision Test";
            this.sechedualVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechedualVisionTestToolStripMenuItem_Click);
            // 
            // schedualWritenTestToolStripMenuItem
            // 
            this.schedualWritenTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("schedualWritenTestToolStripMenuItem.Image")));
            this.schedualWritenTestToolStripMenuItem.Name = "schedualWritenTestToolStripMenuItem";
            this.schedualWritenTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.schedualWritenTestToolStripMenuItem.Text = "Schedual Written Test";
            this.schedualWritenTestToolStripMenuItem.Click += new System.EventHandler(this.schedualWritenTestToolStripMenuItem_Click);
            // 
            // schedualStreetTestToolStripMenuItem
            // 
            this.schedualStreetTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("schedualStreetTestToolStripMenuItem.Image")));
            this.schedualStreetTestToolStripMenuItem.Name = "schedualStreetTestToolStripMenuItem";
            this.schedualStreetTestToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.schedualStreetTestToolStripMenuItem.Text = "Schedual Street Test";
            // 
            // countOfRecords
            // 
            this.countOfRecords.AutoSize = true;
            this.countOfRecords.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countOfRecords.Location = new System.Drawing.Point(108, 644);
            this.countOfRecords.Name = "countOfRecords";
            this.countOfRecords.Size = new System.Drawing.Size(45, 25);
            this.countOfRecords.TabIndex = 29;
            this.countOfRecords.Text = "000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 644);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "#Recors:";
            // 
            // frmManageLocalDrivingLiceseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 675);
            this.Controls.Add(this.countOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmManageLocalDrivingLiceseApplications";
            this.Text = "frmManageLocalDrivingLiceseApplications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLiceseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Label countOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem schedualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechedualVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualWritenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schedualStreetTestToolStripMenuItem;
    }
}