using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificador_com_Login
{
    public class Usuario
    {
        public String Nome { get; set; }
        public String Senha { get; set; }

        public Usuario(String nome, String senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public Usuario()
        {

        }
    }
}
