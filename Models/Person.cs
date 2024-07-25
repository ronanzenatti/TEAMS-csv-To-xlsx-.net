using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAMS_csv_To_xlsx.Models
{
    internal class Person
    {
        public int RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<string> Presencas { get; set; }
        public string Tipo { get; set; }

        public Person(int rM, string nome, string email, string tipo)
        {
            RM = rM;
            Nome = nome;
            Email = email;
            Tipo = tipo;
            Presencas = new List<string>();
        }
    }


}
