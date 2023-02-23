using System;
using System.Windows.Forms;

namespace Simi
{
    public partial class Localizador : Form
    {
        public string[] data { get; set; }
        public Localizador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.Conn conn = new DB.Conn();
            string[] Data = conn.select(textLoca.Text);
            if (Data != null)
            {
                this.data = Data;
                this.DialogResult = DialogResult.OK;
                //Ficha ficha = new Ficha(Data);
                //ficha.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Nº de Serie não identificado.");
                textLoca.Focus();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Manutencao m = new Manutencao();
            //m.Show();
            //this.Close();
            this.DialogResult=DialogResult.OK;
        }

        private void textLoca_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DB.Conn conn = new DB.Conn();
                string[] Data = conn.select(textLoca.Text);
                if (Data != null)
                {
                    //Ficha ficha = new Ficha(Data);
                    //ficha.Show();
                    //this.Close();
                    this.data= Data;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Nº de Serie não identificado.");
                    textLoca.Focus();
                }
            }
        }
    }
}
