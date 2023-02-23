using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Simi
{
    public partial class Manutencao : Form
    {
        public Manutencao()
        {

            InitializeComponent();
            Refreshing();

        }
        /*
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        */
        private void Manutencao_Load(object sender, EventArgs e)
        {
            //  if(data != null)
            //   {

            //  }
            //  ImageList imageList1 = new ImageList();
            //  imageList1.Images.Add(Image.FromFile(@"C:\Users\sti\Downloads\TestePic\ManutencaoPC.png"));
            //  imageList1.Images.Add(Image.FromFile(@"C:\Users\sti\Downloads\TestePic\kisspng-multi-function-printer-samsung-proxpress-m4070fr-s-multifunction-5af271b2f2af08.596915451525838258994.png"));
            //  imageList1.Images.Add(Image.FromFile(@"C:\Users\sti\Downloads\TestePic\colorjet.png"));

            //  this.listView1.View = View.LargeIcon;
            //  imageList1.ImageSize = new Size(32, 32);
            //  this.listView1.LargeImageList = imageList1;
            //  this.listView1.Items.Add("Computador Secretaria", 0);
            //   this.listView1.Items.Add("Impressora NPOR", 1);
            //   this.listView1.Items.Add("Impressora CCAP", 2);


        }

        public void Refreshing()
        {
            this.listView1.Clear();
            DB.Conn conn = new DB.Conn();
            DataTable data = conn.selectManutencao();
            int i = 0;
            ImageList imageList1 = new ImageList();
            foreach (DataRow row in data.Rows)
            {
                string[] tipo = conn.selectManutencao(row["serial_key"].ToString());
                if (tipo != null)
                {

                    if (tipo[1] == "Desktop")
                    {
                        imageList1.Images.Add(Properties.Resources.ManutencaoPC);


                    }
                    else if (tipo[1] == "Notebook")
                    {
                        imageList1.Images.Add(Properties.Resources.ManutencaoNot);

                    }
                    else if (tipo[1] == "Impressora")
                    {
                        imageList1.Images.Add(Properties.Resources.colorjet);

                    }
                    this.listView1.View = View.LargeIcon;
                    imageList1.ImageSize = new Size(32, 32);
                    this.listView1.LargeImageList = imageList1;
                    this.listView1.Items.Add(tipo[1] + " " + tipo[0] + "-" + row["serial_key"].ToString(), i);
                    i++;
                }

            }
        }
        private void MyList_Click(object sender, EventArgs e)
        {

        }


        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var item = listView1.SelectedItems[0];
            string[] words = item.Text.Split('-');
            DB.Conn conn = new DB.Conn();
            string[] Data = conn.select(words[1]);
            Ficha ficha = new Ficha(Data);
            if(ficha.ShowDialog() == DialogResult.OK)
            {
                Refreshing();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Localizador loca = new Localizador();
            //loca.Show();
            if(loca.ShowDialog() == DialogResult.OK)
            {
                Ficha fch = new Ficha(loca.data);
                if(fch.ShowDialog() == DialogResult.OK)
                {
                    Refreshing();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Refreshing();
        }

        #region Teste
        /// <summary>
        /// Usado para Selecionar a opção do meu
        /// </summary>
        /// <param name="Id">Id da Tela</param>
        void OpcoesMenu(string Id)
        {
            try
            {
                switch (Id)
                {
                    case "Atualizar":
                        Refreshing();
                        break;
                    default:
                        throw new Exception("Nenhuma opção foi selecionada.");
                }
            }
            catch (Exception Problema)
            {
                throw Problema;
            }
        }
        void Menu_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = string.Empty;
                if (sender is Button btn)
                    Id = btn.Tag.ToString();
                OpcoesMenu(Id);
            }
            catch (Exception Problema)
            {
                MessageBox.Show(Problema.Message);
            }
        }
        #endregion
    }
}
