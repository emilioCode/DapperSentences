using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSentences.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public string comentario { get; set; }
        public byte[] foto { get; set; }
    }
}
