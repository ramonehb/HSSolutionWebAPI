using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSolution.Domain
{
    public class UsuarioViewModel
    {
        public int ID_Usuario { get; set; }
        public string Nome { get; set; }
        public string NR_CPF { get; set; }
        public string Email { get; set; }
        public string NR_Telefone { get; set; }
        public DateTime DT_Nascimento { get; set; }
        public DateTime DT_Cadastro { get; set; }

    }
}
