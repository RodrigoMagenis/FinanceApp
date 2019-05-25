using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Classificador_com_Login
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        Gerenciador gerenciador = new Gerenciador();

        private void TelaLogin_Load(object sender, EventArgs e)
        {
            gerenciador.CarregarDadosUsuario();

            bool achou = false;

            foreach(Usuario usuario in gerenciador.ListadeUsuarios)
            {
                if(usuario.Nome == "admin")
                {
                    if (usuario.Senha == "admin123")
                    {
                        achou = true;
                    }
                }
            }

            if(achou == false)
            {
                Usuario usuario = new Usuario();
                usuario.Nome = "admin";
                usuario.Senha = "admin123";

                gerenciador.ListadeUsuarios.Add(usuario);
            }
            gerenciador.SalvarDadosUsuario();
        }

        private void BtLogar_Click(object sender, EventArgs e)
        {
            gerenciador.CarregarDadosUsuario();

            foreach (Usuario usuario in gerenciador.ListadeUsuarios)
            {
                if (CaixaNome.Text == usuario.Nome)
                {
                    if (CaixaSenha.Text == usuario.Senha)
                    {
                        TelaPrincipal telaprincipal = new TelaPrincipal();
                        telaprincipal.ShowDialog();
                    }
                    else // CaixaSenha.Text != usuario.Senha
                    {
                        System.Windows.Forms.MessageBox.Show("Nome e ou Senha Incorretos");
                    }
                }
                else // CaixaNome.Text != usuario.Nome
                {
                    System.Windows.Forms.MessageBox.Show("Nome e ou Senha Incorretos");
                }
            }
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
