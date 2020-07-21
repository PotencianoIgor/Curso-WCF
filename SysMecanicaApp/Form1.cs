using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysMecanicaApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_codigo.Clear();
                txt_descricao.Clear();
                txt_preco.Clear();

                lbl_codigo.BackColor = Color.Empty;
                lbl_descricao.BackColor = Color.Empty;
                lbl_preco.BackColor = Color.Empty;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.ProdutoServiceClient produtoServiceClient = new ServiceReference1.ProdutoServiceClient();
                int codigo = string.IsNullOrEmpty(txt_filtro.Text) ? 0 : Convert.ToInt32(txt_filtro.Text);

                ServiceReference1.Produto produto = produtoServiceClient.Buscar(codigo);
                if (produto != null)
                {
                    txt_codigo.Text = produto.Codigo.ToString();
                    txt_descricao.Text = produto.Descricao;
                    txt_preco.Text = produto.Preco.ToString();

                    MessageBox.Show("Produto encontrado com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Produto não encontrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            int codigo = string.IsNullOrEmpty(txt_codigo.Text) ? 0 : Convert.ToInt32(txt_codigo.Text);
            string descricao = txt_descricao.Text;
            double preco = string.IsNullOrEmpty(txt_preco.Text) ? 0 : Convert.ToInt32(txt_preco.Text);

            bool salvar = true;

            if (codigo == 0)
            {
                lbl_codigo.BackColor = Color.Red;
                salvar = false;
            }
            if (string.IsNullOrEmpty(descricao))
            {
                lbl_descricao.BackColor = Color.Red;
                salvar = false;
            }
            if (preco == 0)
            {
                lbl_preco.BackColor = Color.Red;
                salvar = false;
            }

            if (!salvar)
            {
                MessageBox.Show("Preencha os campos obrigatórios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            try
            {
                if (salvar)
                {
                    ServiceReference1.ProdutoServiceClient produtoServiceClient = new ServiceReference1.ProdutoServiceClient();
                    ServiceReference1.Produto produto = new ServiceReference1.Produto()
                    {
                        Codigo = codigo,
                        Descricao = descricao,
                        Preco = preco
                    };

                    produtoServiceClient.Add(produto);
                    MessageBox.Show("Produto salvo com sucesso!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
