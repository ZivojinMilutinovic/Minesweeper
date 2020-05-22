namespace ProjekatLabVezba2
{
    partial class Glavna
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.konfigurisiIgruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaIgraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zavrsiIgruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucitajIzXMLaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucitajPodatkeUXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Time = new System.Windows.Forms.Label();
            this.lblMinVreme = new System.Windows.Forms.Label();
            this.lblMaxVreme = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konfigurisiIgruToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(565, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // konfigurisiIgruToolStripMenuItem
            // 
            this.konfigurisiIgruToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaIgraToolStripMenuItem,
            this.zavrsiIgruToolStripMenuItem,
            this.ucitajIzXMLaToolStripMenuItem,
            this.ucitajPodatkeUXMLToolStripMenuItem});
            this.konfigurisiIgruToolStripMenuItem.Name = "konfigurisiIgruToolStripMenuItem";
            this.konfigurisiIgruToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.konfigurisiIgruToolStripMenuItem.Text = "Konfigurisi igru";
            // 
            // novaIgraToolStripMenuItem
            // 
            this.novaIgraToolStripMenuItem.Name = "novaIgraToolStripMenuItem";
            this.novaIgraToolStripMenuItem.Size = new System.Drawing.Size(283, 34);
            this.novaIgraToolStripMenuItem.Text = "Nova Igra";
            this.novaIgraToolStripMenuItem.Click += new System.EventHandler(this.novaIgraToolStripMenuItem_Click);
            // 
            // zavrsiIgruToolStripMenuItem
            // 
            this.zavrsiIgruToolStripMenuItem.Name = "zavrsiIgruToolStripMenuItem";
            this.zavrsiIgruToolStripMenuItem.Size = new System.Drawing.Size(283, 34);
            this.zavrsiIgruToolStripMenuItem.Text = "Zavrsi Igru";
            this.zavrsiIgruToolStripMenuItem.Click += new System.EventHandler(this.zavrsiIgruToolStripMenuItem_Click);
            // 
            // ucitajIzXMLaToolStripMenuItem
            // 
            this.ucitajIzXMLaToolStripMenuItem.Name = "ucitajIzXMLaToolStripMenuItem";
            this.ucitajIzXMLaToolStripMenuItem.Size = new System.Drawing.Size(283, 34);
            this.ucitajIzXMLaToolStripMenuItem.Text = "Ucitaj iz XML-a";
            this.ucitajIzXMLaToolStripMenuItem.Click += new System.EventHandler(this.ucitajIzXMLaToolStripMenuItem_Click);
            // 
            // ucitajPodatkeUXMLToolStripMenuItem
            // 
            this.ucitajPodatkeUXMLToolStripMenuItem.Name = "ucitajPodatkeUXMLToolStripMenuItem";
            this.ucitajPodatkeUXMLToolStripMenuItem.Size = new System.Drawing.Size(283, 34);
            this.ucitajPodatkeUXMLToolStripMenuItem.Text = "Ucitaj podatke u XML";
            this.ucitajPodatkeUXMLToolStripMenuItem.Click += new System.EventHandler(this.ucitajPodatkeUXMLToolStripMenuItem_Click);
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(180, 9);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(43, 20);
            this.Time.TabIndex = 3;
            this.Time.Text = "Time";
            this.Time.Visible = false;
            // 
            // lblMinVreme
            // 
            this.lblMinVreme.AutoSize = true;
            this.lblMinVreme.Location = new System.Drawing.Point(264, 9);
            this.lblMinVreme.Name = "lblMinVreme";
            this.lblMinVreme.Size = new System.Drawing.Size(89, 20);
            this.lblMinVreme.TabIndex = 5;
            this.lblMinVreme.Text = "Min Vreme:";
            // 
            // lblMaxVreme
            // 
            this.lblMaxVreme.AutoSize = true;
            this.lblMaxVreme.Location = new System.Drawing.Point(410, 9);
            this.lblMaxVreme.Name = "lblMaxVreme";
            this.lblMaxVreme.Size = new System.Drawing.Size(93, 20);
            this.lblMaxVreme.TabIndex = 6;
            this.lblMaxVreme.Text = "Max Vreme:";
            // 
            // Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 562);
            this.Controls.Add(this.lblMaxVreme);
            this.Controls.Add(this.lblMinVreme);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Glavna";
            this.Text = "Minesweeper";
            this.LocationChanged += new System.EventHandler(this.Glavna_LocationChanged);
            this.Click += new System.EventHandler(this.Glavna_Click);
            this.Leave += new System.EventHandler(this.Glavna_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Glavna_MouseDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem konfigurisiIgruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaIgraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zavrsiIgruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ucitajIzXMLaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ucitajPodatkeUXMLToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label lblMinVreme;
        private System.Windows.Forms.Label lblMaxVreme;
    }
}