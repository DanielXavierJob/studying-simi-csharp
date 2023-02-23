using System;
using System.Windows.Forms;

namespace Simi
{
    public partial class Laudo : Form
    {
        public Laudo(string nf)
        {
            InitializeComponent();
            nficha.Text = nf;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(seccia.Text) || string.IsNullOrEmpty(seccia.Text))
            {
                MessageBox.Show("O campo Seção ou Cia está em branco");
                seccia.Focus();
            }
            else if (string.IsNullOrWhiteSpace(tec.Text) || string.IsNullOrEmpty(tec.Text))
            {
                MessageBox.Show("O campo Tecnico Responsavel está em branco");
                tec.Focus();
            }
            else if (string.IsNullOrWhiteSpace(inspecao.Text) || string.IsNullOrEmpty(inspecao.Text))
            {
                MessageBox.Show("O campo Inspeção está em branco");
                inspecao.Focus();
            }
            else if (string.IsNullOrWhiteSpace(npatrimonio.Text) || string.IsNullOrEmpty(npatrimonio.Text))
            {
                MessageBox.Show("O campo Nº de Patrimonio está em branco");
                npatrimonio.Focus();
            }
            else if (string.IsNullOrWhiteSpace(problema.Text) || string.IsNullOrEmpty(problema.Text))
            {
                MessageBox.Show("O campo Problema Encontrado está em branco");
                problema.Focus();
            }
            else if (string.IsNullOrWhiteSpace(solucao.Text) || string.IsNullOrEmpty(solucao.Text))
            {
                MessageBox.Show("O campo Solução está em branco");
                solucao.Focus();
            }
            else
            {
                string[] Vs =
                {
                    nficha.Text,
                    seccia.Text,
                    tec.Text,
                    inspecao.Text,
                    nficha.Text,
                    npatrimonio.Text,
                    problema.Text,
                    solucao.Text,
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                };

                DB.Conn conn = new DB.Conn();
                bool data = conn.insertlaudo(Vs);
                if (data == true)
                {
                    MessageBox.Show("O Laudo foi adicionado com sucesso!");
                    nficha.Text = string.Empty;
                    seccia.Text = string.Empty;
                    tec.Text = string.Empty;
                    inspecao.Text = string.Empty;
                    nficha.Text = string.Empty;
                    npatrimonio.Text = string.Empty;
                    problema.Text = string.Empty;
                    solucao.Text = string.Empty;
                    nficha.Focus();
                }
                else
                {
                    MessageBox.Show("Não foi possivel adicionar o Laudo, contate o suporte");
                }
            }

        }
    }
}
