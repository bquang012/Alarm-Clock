namespace Q_HenGio
{
    partial class frmClocker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClocker));
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnTime = new System.Windows.Forms.FlowLayoutPanel();
            this.lbDay = new System.Windows.Forms.Label();
            this.btnChangeSound = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmenuClocker = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.itemExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.cmenuClocker.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(12, 34);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(401, 22);
            this.guna2Separator1.TabIndex = 0;
            // 
            // pnTime
            // 
            this.pnTime.AutoScroll = true;
            this.pnTime.Location = new System.Drawing.Point(33, 51);
            this.pnTime.Name = "pnTime";
            this.pnTime.Size = new System.Drawing.Size(390, 453);
            this.pnTime.TabIndex = 3;
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.Font = new System.Drawing.Font("Segoe UI Symbol", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDay.ForeColor = System.Drawing.Color.Teal;
            this.lbDay.Location = new System.Drawing.Point(163, 9);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(123, 28);
            this.lbDay.TabIndex = 4;
            this.lbDay.Text = "dayOfWeek";
            // 
            // btnChangeSound
            // 
            this.btnChangeSound.Image = global::Q_HenGio.Properties.Resources.sound;
            this.btnChangeSound.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChangeSound.Location = new System.Drawing.Point(48, 14);
            this.btnChangeSound.Name = "btnChangeSound";
            this.btnChangeSound.Size = new System.Drawing.Size(30, 25);
            this.btnChangeSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnChangeSound.TabIndex = 2;
            this.btnChangeSound.TabStop = false;
            this.btnChangeSound.Click += new System.EventHandler(this.btnChangeSound_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Q_HenGio.Properties.Resources.add_clock_2;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 25);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Ứng dụng được thu nhỏ";
            this.notifyIcon1.BalloonTipTitle = "Thông báo từ Clocker";
            this.notifyIcon1.ContextMenuStrip = this.cmenuClocker;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Clocker";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmenuClocker
            // 
            this.cmenuClocker.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemShow,
            this.itemExit});
            this.cmenuClocker.Name = "cmenuClocker";
            this.cmenuClocker.Size = new System.Drawing.Size(104, 48);
            // 
            // itemShow
            // 
            this.itemShow.Name = "itemShow";
            this.itemShow.Size = new System.Drawing.Size(103, 22);
            this.itemShow.Text = "Show";
            this.itemShow.Click += new System.EventHandler(this.itemShow_Click);
            // 
            // itemExit
            // 
            this.itemExit.Name = "itemExit";
            this.itemExit.Size = new System.Drawing.Size(103, 22);
            this.itemExit.Text = "Exit";
            this.itemExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // frmClocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 507);
            this.Controls.Add(this.lbDay);
            this.Controls.Add(this.pnTime);
            this.Controls.Add(this.btnChangeSound);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.guna2Separator1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(441, 545);
            this.MinimumSize = new System.Drawing.Size(441, 545);
            this.Name = "frmClocker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClocker_FormClosing);
            this.Load += new System.EventHandler(this.frmClocker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.cmenuClocker.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.PictureBox btnAdd;
        public System.Windows.Forms.FlowLayoutPanel pnTime;
        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.PictureBox btnChangeSound;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmenuClocker;
        private System.Windows.Forms.ToolStripMenuItem itemShow;
        private System.Windows.Forms.ToolStripMenuItem itemExit;
    }
}

