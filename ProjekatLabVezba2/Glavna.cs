using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MojButton;
using MinesweeperFunkcije;
using System.Diagnostics;
using System.Xml;

namespace ProjekatLabVezba2
{
    public partial class Glavna : Form
    {
        Stopwatch s = new Stopwatch();
        private double minVreme = 0;
        private double maxVreme = 0;
        private Form1 pomocnaForma;
        public Glavna()
        {
            InitializeComponent();
            Form1 form = new Form1();
            form.MdiParent = this;
         
            form.Dock = DockStyle.Fill;
            form.Show();
           
            timer1.Interval = (1000);
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Start();
            s.Start();
            Time.Visible = true;

           
        }
        public void podesiLabeluMinVreme(double vreme)
        {

            lblMinVreme.Text = "Min Vreme:"+ vreme.ToString()+"ms";

        }
        public void podesiLabeluMaxVreme(double vreme)
        {
            lblMaxVreme.Text = "Max Vreme:" + vreme.ToString()+"ms";
        }


        private void timer_Tick(Object sender,EventArgs e)
        {
            
               
            
            
            {
                Time.Text = s.Elapsed.ToString("hh\\:mm\\:ss");
            }
        }

        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form f in this.MdiChildren)
            {
                f.Dispose();
            }
            
            FormUpit upit = new FormUpit();
            int brojMina=0;
            int dimenzije=0;
           
            if(DialogResult.OK==upit.ShowDialog())
            {
                brojMina = int.Parse(upit.Mine);
                dimenzije = int.Parse(upit.Dimenzije);
                upit.Close();
            }
            Form1 form1 = new Form1(dimenzije, brojMina);
            form1.MdiParent = this;
            form1.Dock = DockStyle.Fill;
            form1.Show();
            


        }

        private void zavrsiIgruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Length == 0)
                return;
           
           Form1 f=this.MdiChildren.First<Form>() as Form1;
            f.PokaziSveMine();
            f.Enabled = false;
            s.Stop();
            timer1.Stop();
           
            
        }

        private void Glavna_MdiChildActivate(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            s.Restart();
           
        }

        private void Glavna_Leave(object sender, EventArgs e)
        {
            s.Stop();
            timer1.Stop();
            Time.Text = String.Empty;
            
        }

        private void ucitajIzXMLaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            duplaFora();
          //Ucitaj_Iz_XML();
        }
        private void duplaFora()
        {
            //Ucitaj_U_XML();
            Ucitaj_Iz_XML();
            Ucitaj_U_XML();
            Ucitaj_Iz_XML();
            Ucitaj_U_XML();
        }

        private void ucitajPodatkeUXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ucitaj_U_XML();
        }
        private void Ucitaj_U_XML()
        {
            if (MdiChildren.Length == 0)
                return;
            //if(pomocnaForma==null)
            pomocnaForma = this.MdiChildren.First<Form>() as Form1;
            XmlWriter writer = XmlWriter.Create("C://Users/Administrator/Desktop/Mine.xml");
            writer.WriteStartDocument();
            writer.WriteStartElement("mine");
            writer.WriteAttributeString("dimenzije",pomocnaForma.Dimenzije.ToString());
            writer.WriteAttributeString("brojMina",pomocnaForma.BrojMina.ToString());
            for (int i = 0; i <pomocnaForma.Dimenzije; i++)
                for (int j = 0; j <pomocnaForma.Dimenzije; j++)
                {
                    writer.WriteStartElement("polje");
                    writer.WriteAttributeString("isHidden", pomocnaForma[i,j].IsHidden.ToString());
                    writer.WriteAttributeString("hasMine", pomocnaForma[i,j].HasMine.ToString());
                    writer.WriteAttributeString("hasFlag", pomocnaForma[i,j].HasFlag.ToString());
                    writer.WriteAttributeString("brojOkolnihMina", pomocnaForma[i,j].BrojOkolnihMina.ToString());
                    writer.WriteAttributeString("kordinataI", pomocnaForma[i,j].KoordinataI.ToString());
                    writer.WriteAttributeString("kordinataJ", pomocnaForma[i,j].KoordinataJ.ToString());
                    writer.WriteAttributeString("visited", pomocnaForma[i,j].Visited.ToString());
                    writer.WriteString(i.ToString() + "," + j.ToString());
                    writer.WriteEndElement();
                }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        private void Ucitaj_Iz_XML()
        {
            
            foreach (Form f in this.MdiChildren)
            {
                f.Dispose();
            }
            XmlDocument document = new XmlDocument();
            document.Load("C://Users/Administrator/Desktop/Mine.xml");
            int dimenzije = int.Parse(document.DocumentElement.GetAttribute("dimenzije"));
            int brojMina = int.Parse(document.DocumentElement.GetAttribute("brojMina"));
            Form1 nova = new Form1(dimenzije, brojMina, document.DocumentElement.ChildNodes);
            nova.MdiParent = this;
            nova.Dock = DockStyle.Fill;
            nova.Show();
        }

        private void Glavna_Click(object sender, EventArgs e)
        {
            
        }

        private void Glavna_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("dbafjfkd", "hfdahdkjaf", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void Glavna_LocationChanged(object sender, EventArgs e)
        {

        }

        private void Glavna_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
