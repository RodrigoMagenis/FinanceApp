using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Classificador_com_Login
{
    public class Gerenciador
    {
        public List<Usuario> ListadeUsuarios;

        public Gerenciador()
        {
            ListadeUsuarios = new List<Usuario>();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            this.ListadeUsuarios.Add(usuario);
        }

        public List<Usuario> TodosOsUsuarios()
        {
            return this.ListadeUsuarios.ToList();
        }

        public void RemoverUsuario(Usuario usuario)
        {
            this.ListadeUsuarios.Remove(usuario);
        }

        public virtual void SalvarDadosUsuario()
        {
            StreamWriter streamwriter = new StreamWriter("Dados Usuario");
            XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Usuario>));
            xmlserializer.Serialize(streamwriter, ListadeUsuarios);

            streamwriter.Close();
        }

        public virtual void CarregarDadosUsuario()
        {
            if (File.Exists("Dados Usuario"))
            {
                FileStream filestream = System.IO.File.OpenRead("Dados Usuario");
                XmlSerializer xmlserializer = new XmlSerializer(typeof(List<Usuario>));
                ListadeUsuarios = xmlserializer.Deserialize(filestream) as List<Usuario>;

                filestream.Close();
            }
            else // File.!Exists
            {
                ListadeUsuarios = new List<Usuario>();
            }
        }

    }
}
