using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Cliente : Usuario, IComparable<Cliente>
    {
        private string nombre;
        private string apellido;

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        public Cliente(string nombre, string apellido, string username, string contrasenia, string rol) : base(username, contrasenia, rol)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }       
        
        // sorting, cuando es igual hacer el otro tambien, ascendente
        public int CompareTo(Cliente other)
        {
            if (this.apellido.CompareTo(other.Apellido) == 0)
            {
                return this.nombre.
                    CompareTo(other.Nombre);
            }
            return apellido.CompareTo(other.Apellido);
        }
    }
}

