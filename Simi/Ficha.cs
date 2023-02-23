using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simi
{
    public partial class Ficha : Form
    {
        public string[] Vs;
        public Ficha(string[] cod)
        {
            InitializeComponent();
            Vs = cod;
            if (Vs[15] != null)
            {
                button5.Text = "Retirar da Fila de Manutenção";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if(MessageBox.Show("Você realmente deseja excluir do Banco de Dados?", "AVISO IMPORTANTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DB.Conn conn = new DB.Conn();
                conn.Excluir(Vs[13]);
                this.Close();
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Laudo laudo = new Laudo(NSerie.Text);
            laudo.Show();
        }

     
        private void button6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Vs[15] != null)
            {
                DB.Conn c = new DB.Conn();
                bool t = c.RetirarManutencao(Vs[13]);
                if (t)
                {
                   // Manutencao m = new Manutencao();
                   // m.Refreshing();
                    MessageBox.Show("Retirado da fila de Manutenção com sucesso, Recarregue a Fila de Manutenção para atualizar a lista.");
                    button5.Text = "Adicionar da Fila de Manutenção";
                    Vs[15] = null;
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao tentar retirar da fila de manutenção");
                }
            }
            else
            {
                if(new AddManutencao(Vs[13]).ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                };
            }

        }

        private void Ficha_Load(object sender, EventArgs e)
        {

            textDesc.Text = "Ficha " + Vs[14] + " " + Vs[10];
            Resp.Text = Vs[1];
            SecD.Text = Vs[2];
            Proc.Text = Vs[3];
            Mem.Text = Vs[4];
            HD.Text = Vs[5];
            Sisop.Text = Vs[6];
            IP.Text = Vs[7];
            MAC.Text = Vs[8];
            Status.Text = Vs[9];
            Desc.Text = Vs[10];
            DataC.Text = Vs[11];
            UltimaE.Text = Vs[12];
            NSerie.Text = Vs[13];
            if (Vs[14] == "Desktop")
            {
                Image img = Properties.Resources.ManutencaoPC;
                tipoI.Image = img;
                tipoI.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (Vs[14] == "Notebook")
            {
                Image img = Properties.Resources.ManutencaoNot;
                tipoI.Image = img;
                tipoI.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else if (Vs[14] == "Impressora")
            {
                Image img = Properties.Resources.colorjet;
                tipoI.Image = img;
                tipoI.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Image img = Properties.Resources.Logo_SIMI;
                tipoI.Image = img;
                tipoI.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (Vs[15] != null)
            {
                probl.Text = Vs[15];
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerLaudo laudo = new VerLaudo(NSerie.Text);
            laudo.Show();
        }
    }
}
