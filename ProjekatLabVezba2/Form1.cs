using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MojButton;


namespace ProjekatLabVezba2
{
    public partial class Form1 : Form
    {
        private int dimenzije = 9;
        private int brojMina = 10;
        private int brojZastavica;
        private MyButton[,] buttons;
        private int otkrivenoI=0;
        private int otkrivenoJ=0;
        private double minVreme=10000;
        private double maxVreme = 0;
        Stopwatch s1 = new Stopwatch();
        Stopwatch s2 = new Stopwatch();
        private bool prviKlik = false;

        XmlNodeList list;
        //Promenjen kod
        public MyButton this[int i,int j]
        {
            get => buttons[j, i];
            set => buttons[j, i] = value;
        }
        public int Dimenzije { get => dimenzije; set => dimenzije = value; }
        public int BrojMina { get => brojMina; set => brojMina = value; }
        public MyButton[,] Buttons { get => buttons; set => buttons = value; }
        public int OtkrivenoI { get => otkrivenoI; set => otkrivenoI = value; }
        public int OtkrivenoJ { get => otkrivenoJ; set => otkrivenoJ = value; }

        // Panel panel = new Panel();
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            s1.Start();
            this.Shown += FillFormWithButtons;
            brojZastavica = brojMina;
        }
        public Form1(int dimenzije, int brojMina)
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.dimenzije = dimenzije;
            this.brojMina = brojMina;
            brojZastavica = brojMina;

            NacrtajNovuTabelu();
            this.Shown += FillFormWithButtons;
            
        }
        public Form1(int dimenzije,int brojMina,XmlNodeList list)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.dimenzije = dimenzije;
            this.brojMina = brojMina;
            brojZastavica = brojMina;
            NacrtajNovuTabelu();
            buttons = new MyButton[dimenzije, dimenzije];

            
                    DodeliButtonVrednosti(list);
            

        }
       private void DodeliButtonVrednosti(XmlNodeList list)
        {
           
            int i = 0, j = 0;
            if (list == null)
                return;
            else
                //Lose izparsuje komandu zato ne radi
            foreach(XmlNode node in list)
            {
                   
                //int m = int.Parse(node.Attributes["kordinataI"].Value);
                //int n= int.Parse(node.Attributes["kordinataJ"].Value);
                    buttons[i, j] = new MyButton();
                    NamestiDugme(buttons[i, j]);
                    buttons[i,j].KoordinataI = int.Parse(node.Attributes["kordinataI"].Value); 
                buttons[i,j].KoordinataJ = int.Parse(node.Attributes["kordinataJ"].Value); 
                    table.Controls.Add(buttons[i,j]);
                    buttons[i,j].Visited = bool.Parse(node.Attributes["visited"].Value);
                buttons[i,j].BrojOkolnihMina = int.Parse(node.Attributes["brojOkolnihMina"].Value);
                buttons[i,j].HasFlag = bool.Parse(node.Attributes["hasFlag"].Value);
                buttons[i,j].HasMine = bool.Parse(node.Attributes["hasMine"].Value);
                buttons[i,j].IsHidden = bool.Parse(node.Attributes["isHidden"].Value);

                    if (buttons[i, j].IsHidden || buttons[i, j].HasMine)
                    {
                        i++;
                        if (i == dimenzije)
                        {
                            i = 0;
                            j++;
                        }
                        continue;
                    }
                    else
                    {
                        if (buttons[i, j].HasFlag)
                            buttons[i, j].ShowImageFlag();
                        else
                        {
                            buttons[i, j].ObojiBrojMina();
                            buttons[i, j].PostaviNoviBackGround();

                        }
                    }
                    i++;
                    if (i == dimenzije)
                    {
                        i = 0;
                        j++;
                    }


                }
        }
        private void NacrtajNovuTabelu()
        {




            table.ColumnStyles.Clear();
            table.RowStyles.Clear();
            float procenat = 100.0f / dimenzije;
            table.ColumnCount = dimenzije;
            table.RowCount = dimenzije;
            for (int i = 0; i < dimenzije; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, procenat));
                table.RowStyles.Add(new RowStyle(SizeType.Percent, procenat));
            }
            
            table.Location = new Point(0, 33);
            this.table.Size = new System.Drawing.Size(564, 571);

        }
        private void FillFormWithButtons(object sender, EventArgs e)
        {
            InstanicirajButtons();
            PopuniPoljeMinama();
            popuniOkolneMine();

        }
        private void InstanicirajButtons()

        {
            buttons = new MyButton[dimenzije, dimenzije];

            for (int i = 0; i < dimenzije; i++)
                for (int j = 0; j < dimenzije; j++)
                {
                    buttons[i, j] = new MyButton();
                    NamestiDugme(buttons[i, j]);
                    buttons[i, j].KoordinataI = i;
                    buttons[i, j].KoordinataJ = j;
                  
                   table.Controls.Add(buttons[i, j], i, j);
                }
        }
        private void PopuniPoljeMinama()
        {
            Random random = new Random();
            int mine = brojMina;
            while (mine != 0)
            {
                int i = random.Next(dimenzije);
                int j = random.Next(dimenzije);
                if (buttons[i, j].HasMine)
                    continue;
                buttons[i, j].HasMine = true;
                mine--;

            }

        }
        public void PokaziSveMine()
        {
            for (int i = 0; i < dimenzije; i++)
                for (int j = 0; j < dimenzije; j++)
                    if (buttons[i, j].HasMine)
                        buttons[i, j].ShowImageMina();
        }
        private void PritisnutoDugme(object sender, MouseEventArgs e)
        {
            MouseEventArgs evt = e as MouseEventArgs;
            MyButton button = sender as MyButton;
            if (evt != null)
            {
                if (evt.Button == MouseButtons.Right)
                {
                    DesniKlik(sender,button);
                }
                else if (evt.Button == MouseButtons.Left)
                {
                    LeviKlik(sender,button);
                }
                else
                    return;
            }

        }
        private void RekurzivnoOtvoriSusednaPolja(MyButton button)
        {
            if(!button.HasMine && button.BrojOkolnihMina==0)
            {

                for(int i=0;i<3;i++)
                    for(int j=0;j<3; j++)
                    {
                        int vrstaI = button.KoordinataI - 1 + i;
                        int vrstaJ = button.KoordinataJ - 1 + j;
                        if (!pripadaLiOpsegu(vrstaI, vrstaJ))
                            continue;
                        if (buttons[vrstaI, vrstaJ].Visited)
                            continue;
                        if (i == 1 && j == 1)
                            continue;
                        buttons[vrstaI, vrstaJ].IsHidden = false;
                        buttons[vrstaI, vrstaJ].Visited = true;
                        buttons[vrstaI, vrstaJ].PostaviNoviBackGround();
                        buttons[vrstaI, vrstaJ].ObojiBrojMina();
                        RekurzivnoOtvoriSusednaPolja(buttons[vrstaI, vrstaJ]);

                    }

            }
        }
      private void LeviKlik(object sender,MyButton button)
        {
            
            if (!prviKlik)
            {
                s1.Restart();
                prviKlik = true;

            }
            else
            {
                double mili = s1.ElapsedMilliseconds;
                if (mili < minVreme)
                {
                    minVreme = mili;
                    posaljiMinVreme(minVreme);
                }
                if (mili > maxVreme)
                {
                    maxVreme = mili;
                    posaljiMaxVreme(maxVreme);
                }
                
                prviKlik = false;
            }

            

            if (button.HasFlag)
                return;
            button.IsHidden = false;
            button.Visited = true;
            button.PostaviNoviBackGround();
            button.ObojiBrojMina();
            pritusnutaMina(button);
            RekurzivnoOtvoriSusednaPolja(button);
        }
        public void posaljiMinVreme(double vreme)
        {
            Glavna glavna = this.MdiParent as Glavna;
            if(glavna!=null)
            {
                glavna.podesiLabeluMinVreme(vreme);
            }
           
        }
        private void posaljiMaxVreme(double vreme)
        {
            Glavna glavna = this.MdiParent as Glavna;
            if (glavna != null)
            {
                glavna.podesiLabeluMaxVreme(vreme);
            }
            
        }
        private void DesniKlik(object sender,MyButton button)
        {
            
            if(brojMina==0)
            {
                int k = 0;
                for (int i = 0; i < dimenzije; i++)
                    for (int j = 0; j < dimenzije; j++)
                        if (buttons[i, j].HasFlag && buttons[i, j].HasMine)
                            k++;
                if (brojZastavica == k)
                    MessageBox.Show("Pobedili ste cestitamo", "Obavestenje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          else  if (button.HasFlag)
            {
                button.HasFlag = false;
                button.RemoveImageMina();
                brojMina++;

            }
            else if (brojMina == 0 || button.Visited==true)
                return;
            else
            {
                button.HasFlag = true;
                button.ShowImageFlag();
                brojMina--;
            }
        }
        private void NamestiDugme(MyButton button)
        {
            
            button.Dock = DockStyle.Fill;
            button.Margin = new Padding(0, 0, 0, 0);
            button.BackColor = Color.LightGray;
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.MouseClick += new MouseEventHandler(PritisnutoDugme);
          //  button.MouseDown += new MouseEventHandler(PritisnutoDugme);
           
            
            
        }

        
        private void pritusnutaMina(MyButton button)
        {
            if (!button.HasMine)
                return;
            else {
                MessageBox.Show("Pritisnuli ste minu i izgubli ste igru", "Pritisnuta Mina",
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                this.Dispose();
                
       
                }
            
        }
        private void popuniOkolneMine()
        {
            for (int i = 0; i < dimenzije; i++)
                for (int j = 0; j < dimenzije; j++)
                    IzracunajBrojOkolnihMina(buttons[i, j],i,j);
        }
        private void IzracunajBrojOkolnihMina(MyButton button,int i,int j)
        {
            if(button.HasMine)
            {
                button.BrojOkolnihMina = 0;
                
                return;
            }
            int okolneMine = 0;
            for (int n = 0; n < 3; n++)
                for (int m = 0; m <3; m++)
                {

                    if (n == 1 && m == 1)
                        continue;
                    if (pripadaLiOpsegu(i - 1 + n, j - 1 + m) && buttons[i-1+n,j-1+m].HasMine)
                        okolneMine++;
                }
            button.BrojOkolnihMina = okolneMine;
         
          
        }
        private bool pripadaLiOpsegu(int i,int j)
        {
            return (0 <= i && i < dimenzije) && (0 <= j && j < dimenzije);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

       
    }
}
