using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simi
{
    public partial class LaudoView : Form
    {
        public LaudoView(DataRow rw)
        {
            InitializeComponent();
            seccia.Text = rw["seccia"].ToString();
            tec.Text = rw["tecnico"].ToString();
            inspecao.Text = rw["inspecao"].ToString();
            nficha.Text = rw["nficha"].ToString();
            npatrimonio.Text = rw["npatrimonio"].ToString();
            problema.Text = rw["problema"].ToString();
            solucao.Text = rw["solucao"].ToString();
        }
    }
}
