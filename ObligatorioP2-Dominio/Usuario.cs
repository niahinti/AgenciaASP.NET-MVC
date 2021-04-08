using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Usuario
    {
        private string username;
        private string contrasenia;
        private string rol;

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public string Contrasenia
        {
            get { return this.contrasenia; }
            set { this.contrasenia = value; }
        }

        public string Rol
        {
            get { return this.rol; }
            set { this.rol = value; }
        }


        public Usuario(string username, string contrasenia, string rol)
        {
            this.username = username;
            this.contrasenia = contrasenia;
            this.rol = rol;
        }
    }
}
