using System;
using System.Windows.Forms;

namespace Simi
{
    public partial class AddManutencao : Form
    {
        private string serial;
        public AddManutencao(string serialq)
        {
            InitializeComponent();
            serial = serialq;
            data_serial.Text = "Numero de Serie: " + serialq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.Conn conn = new DB.Conn();
            bool con = conn.AddManu(serial, problemare.Text);
            if (con == true)
            {
                //Manutencao m = new Manutencao();
                //m.Refreshing();
                MessageBox.Show("Adicionado a Fila de Manutenção com Sucesso! Recarregue a Fila de Manutenção para mostrar a fila atualizada.");

            }
            else
            {
                MessageBox.Show("Não foi possivel Adicionar, tente novamente mais tarde");
            }
            this.DialogResult=DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DB.Conn conn = new DB.Conn();
            //string[] Data = conn.select(serial);
            //Ficha ficha = new Ficha(Data);
            //ficha.Show();
            //this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void problemare_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DB.Conn conn = new DB.Conn();
                bool con = conn.AddManu(serial, problemare.Text);
                if (con == true)
                {

                    MessageBox.Show("Adicionado a Fila de Manutenção com Sucesso! Recarregue a Fila de Manutenção para mostrar a fila atualizada.");
                    //Ficha obj = (Ficha)Application.OpenForms["Ficha"];
                    //obj.Close();
                }
                else
                {
                    MessageBox.Show("Não foi possivel Adicionar, tente novamente mais tarde");
                }
                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
        }
    }
}
