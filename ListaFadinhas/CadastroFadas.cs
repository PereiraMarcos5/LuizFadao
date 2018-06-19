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
        public void ChangeCursor()
        {
            this.Cursor = new Cursor(GetType(), "Magic Wand.cur");
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
                Fada fada = new Fada()
                {
                    Nome = txtNome.Text,
                    Familia = txtFamilia.Text,
                    Cor = cbCor.Text,
                    CorAsa = cbCorAsa.Text,
                    TamanhoAsa = Convert.ToDecimal(txtTamanhoAsa.Text),
                    AsaQuebrada = checkBox1.Checked,
                    EMulher = rbSimGen.Checked,
                    FazBarulho = rbNaoCb.Checked,
                    Elemento = cbElemento.Text

                };
                if (nomeAntigo == "")
                {
                    fadas.Add(fada);
                    AdicionarFada(fada);
                }
                MessageBox.Show("Fadinha Cadastrada com Sucesso");
                tabControl1.SelectedIndex = 0;
                LimparCampos();
            }
            catch (Exception El)
            {
                MessageBox.Show(El.Message);
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
            dataGridView1.Rows[linha].Cells[0].Value = fada.TamanhoAsa;
            dataGridView1.Rows[linha].Cells[0].Value = fada.Cor;
            dataGridView1.Rows[linha].Cells[0].Value = fada.CorAsa;
            dataGridView1.Rows[linha].Cells[0].Value = fada.AsaQuebrada;
            dataGridView1.Rows[linha].Cells[0].Value = fada.EMulher;
            dataGridView1.Rows[linha].Cells[0].Value = fada.FazBarulho;
            dataGridView1.Rows[linha].Cells[0].Value = fada.Elemento;

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Cadastre um Carro");
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
            string nome = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
            foreach (Fada fada in fadas)
            {
                txtNome.Text = fada.Nome;
                txtFamilia.Text = Convert.ToString(fada.Familia);
                cbCor.Text = Convert.ToString(fada.Cor);
                cbCorAsa.Text = Convert.ToString(fada.CorAsa);

                nomeAntigo = fada.Nome;
                tabControl1.SelectedIndex = 1;
                break;
                int linha = fadas.FindIndex(x => x.Nome == nomeAntigo);
                fadas[linha] = fada;
                EditarFada(fada, linha);
                MessageBox.Show("Alterado com Sucesso");
                nomeAntigo = string.Empty;
            }
        }
    }
}