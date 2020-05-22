using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MojButton
{
    public partial class FormUpit : Form
    {
        public FormUpit()
        {
            InitializeComponent();
        }
        public string Mine
        {
          get { return txtMine.Text; }
        }
        public string Dimenzije
        {
            get { return txtDimenzije.Text; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMine.Text == String.Empty || txtDimenzije.Text == String.Empty)
            {
                MessageBox.Show("Morate uneti sve vednosti", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
           
        }

        private void txtDimenzije_TextChanged(object sender, EventArgs e)
        {
            if (txtDimenzije.Text == String.Empty)
                return;
            if (int.Parse(txtDimenzije.Text) < 9)
            {
                errorProvider1.SetError(txtDimenzije, "Dimenzija ne moze biti manja od 9");
                button1.Enabled = false;
                return;
            }
            if (int.Parse(txtDimenzije.Text) > 37)
            {
                errorProvider1.SetError(txtDimenzije, "Dimenzija su prevelike");
                button1.Enabled = false;
                return;
            }
            errorProvider1.Clear();
            button1.Enabled = true;
        }

        private void txtMine_TextChanged(object sender, EventArgs e)
        {
            if (txtDimenzije.Text == String.Empty || txtMine.Text==String.Empty)
                return;
            if (int.Parse(txtMine.Text) > int.Parse(txtDimenzije.Text) * int.Parse(txtDimenzije.Text) )
            {
                errorProvider1.SetError(txtDimenzije, "Broj mina ne moze biti veci od dimenzija");
                button1.Enabled = false;
                return;
            }
            button1.Enabled = true;
        }
        private void PritisnutTaster(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                return;
          if (!int.TryParse(e.KeyChar.ToString(), out int result)) 
            e.Handled = true;
        }
        private void txtDimenzije_KeyPress(object sender, KeyPressEventArgs e)
        {
            PritisnutTaster(e);
        }

        private void txtMine_KeyPress(object sender, KeyPressEventArgs e)
        {
            PritisnutTaster(e);
        }

        private void txtDimenzije_Leave(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void txtMine_Leave(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
