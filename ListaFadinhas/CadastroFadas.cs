using LuizFadinha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaFadinhas
{

    public partial class CadastroFadas : Form
    {
        bool editado = false;
        public void ChangeCursor()
        {
            this.Cursor = new Cursor(GetType(), "Magic Stick G.cur");
        }

        string nomeAntigo = string.Empty;
        List<Fada> fadas = new List<Fada>();

        public CadastroFadas()
        {
            InitializeComponent();
            ChangeCursor();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Fada fada = new Fada (txtNome.Text, txtFamilia.Text, cbCor.Text, cbCorAsa.Text, txtTamanhoAsa.Text, cbElemento.Text)
                {
                    Nome = txtNome.Text,
                    Familia = txtFamilia.Text,
                    Cor = cbCor.Text,
                    CorAsa = cbCorAsa.Text,
                    TamanhoAsa = Convert.ToDecimal(txtTamanhoAsa.Text),
                    AsaQuebrada = checkBox1.Checked,
                    EMulher = rbMan.Checked,
                    FazBarulho = rbNaoCb.Checked,
                    Elemento = cbElemento.Text

                };
                if (nomeAntigo == "")
                {
                    fadas.Add(fada);
                    AdicionarFada(fada);
                    MessageBox.Show("Fadinha Cadastrada com Sucesso");
                    LimparCampos();
                }
                else
                {
                    editado = true;
                    int linha = fadas.FindIndex(x => x.Nome == nomeAntigo);
                    fadas[linha] = fada;
                    EditarFada(fada, linha);
                    MessageBox.Show("Alterado com Sucesso");
                    nomeAntigo = string.Empty;
                    LimparCampos();
                }
            }
            catch (Exception El)
            {
                if (editado == false)
                {
                MessageBox.Show(El.Message);
                }
                else
                {
                 MessageBox.Show("Alterado com Sucesso");
                }
            }
        }

        private void AdicionarFada(Fada fada)
        {
            dataGridView1.Rows.Add(new Object[]
            {
                fada.Nome, fada.Cor, fada.Elemento, fada.Familia
            });
        }

        private void LimparCampos()
        {
            txtFamilia.Text = "";
            txtNome.Text = "";
            txtTamanhoAsa.Text = "";
            cbCor.Text = "";
            cbCorAsa.Text = "";
            cbElemento.Text = "";
            txtTamanhoAsa.Text = "";
        }

        private void EditarFada(Fada fada, int linha)
        {
            dataGridView1.Rows[linha].Cells[0].Value = fada.Nome;
            dataGridView1.Rows[linha].Cells[1].Value = fada.TamanhoAsa;
            dataGridView1.Rows[linha].Cells[2].Value = fada.Cor;
            dataGridView1.Rows[linha].Cells[3].Value = fada.CorAsa;
            dataGridView1.Rows[linha].Cells[4].Value = fada.AsaQuebrada;
            dataGridView1.Rows[linha].Cells[5].Value = fada.EMulher;
            dataGridView1.Rows[linha].Cells[6].Value = fada.FazBarulho;
            dataGridView1.Rows[linha].Cells[7].Value = fada.Elemento;

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Cadastre uma Fada");
                return;

            }
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma Linha");
                return;
            }

            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
            for (int i = 0; i < fadas.Count(); i++)
            {
                Fada fada = fadas[i];
                if (fada.Nome == nome)
                {
                    fadas.RemoveAt(i);
                }

                dataGridView1.Rows.RemoveAt(linhaSelecionada);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            nomeAntigo = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
          
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Cadastre uma Fada");
                    tabControl1.SelectedIndex = 1;
                    return;
                }
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um Arquivo");
                    tabControl1.SelectedIndex = 1;
                    return;
                }  

            foreach (Fada fada in fadas)
            {

                if (fada.Nome == nomeAntigo)
                {
                    txtNome.Text = Convert.ToString(fada.Nome);
                    txtFamilia.Text = Convert.ToString(fada.Familia);
                    cbCor.Text = Convert.ToString(fada.Cor);
                    txtTamanhoAsa.Text = Convert.ToString(fada.TamanhoAsa);
                    cbElemento.Text = Convert.ToString(fada.Elemento);
                    cbCorAsa.Text = Convert.ToString(fada.CorAsa);
                    nomeAntigo = fada.Nome;
                    tabControl1.SelectedIndex = 0;
                    break;
                }
          }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Fada fada = new Fada(txtName1.Text, txtFamilia1.Text, txtCor1.Text)
                  {
           
                     
                  };
                if (nomeAntigo == "")
                {
                    fadas.Add(fada);
                    AdicionarFada(fada);
                    MessageBox.Show("Fadinha Cadastrada com Sucesso");
                }
            }
            catch (Exception El)
            {
                MessageBox.Show(El.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            nomeAntigo = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
          
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Cadastre uma Fada");
                    tabControl1.SelectedIndex = 2;
                    return;
                }
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um Arquivo");
                    tabControl1.SelectedIndex = 2;
                    return;
                }
                foreach (Fada fada in fadas)
                {

                    if (fada.Nome == nomeAntigo)
                    {
                        txtName1.Text = Convert.ToString(fada.Nome);
                        txtFamilia1.Text = Convert.ToString(fada.Familia);
                        txtCor1.Text = Convert.ToString(fada.Cor);
                        tabControl1.SelectedIndex = 2;
                        break;
                    }
                }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void rbMan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}