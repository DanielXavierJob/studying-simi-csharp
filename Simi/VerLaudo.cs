using System;
using System.Data;
using System.Windows.Forms;

namespace Simi
{
    public partial class VerLaudo : Form
    {

        public VerLaudo(string serial)
        {
            InitializeComponent();
            DB.Conn conn = new DB.Conn();
            dataGridView1.DataSource = conn.npg(serial);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex.ToString() != "-1")
            {
                DataRow rw = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;

                LaudoView v = new LaudoView(rw);
                v.Show();
            }
            else
            {
                MessageBox.Show("opa me clicou");

            }

        }
    }
}
