using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class CompaniaAerea
    {
        private string codigo;
        private string paisDeOrigen;

        public string Codigo
        {
            get { return this.codigo; }
        }

        public string PaisOrigen
        {
            get { return this.paisDeOrigen; }
        }
        public CompaniaAerea(string codigo, string paisDeOrigen)
        {
            this.codigo = codigo;
            this.paisDeOrigen = paisDeOrigen;

        }
    }
}
