using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public abstract class Excursion : IComparable<Excursion>
    {
        private int id;
        private string descripcion;
        private DateTime fechaComienzo;
        private int diasDeTraslado;
        private int stock;
        private List<Destino> destinos = new List<Destino>();
        private static int ultId = 1000;

        #region properties
        public string Descripcion
        {
            get { return this.descripcion; }
        }
        public DateTime Fecha
        {
            get { return this.fechaComienzo; }
        }

        public int DiasTraslado
        {
            get { return this.diasDeTraslado; }
        }

        public int Stock
        {
            get { return this.stock; }
        }

        public int Id
        {
            get { return this.id; }
        }

        public List<Destino> Destinos
        {
            get { return this.destinos; }
        }
        #endregion


        // Metodo Constructor de clase padre
        public Excursion(string descripcion, DateTime fechaComienzo, int diasDeTraslado, int stock, List<Destino> destinos)
        {

            // id autoincremental. guardo el ultimo id, asigno a la instancia actual y lo aumento para la proxima
            this.id = Excursion.ultId;
            Excursion.ultId += 100;
            this.descripcion = descripcion;
            this.fechaComienzo = fechaComienzo;
            this.diasDeTraslado = diasDeTraslado;
            this.stock = stock;
            this.destinos = destinos;
        }

        //metodos abstractos

        public abstract double calcCostoTotalExcursion();
        public abstract double montoEspecifico();
        public abstract string tipoExcursion();
        public abstract string datosEspecificos(); // aero / interes

        // cotizar excursion
        public double convertirExcursionUY(double cotizacion)
        {
            double precioUY = calcCostoTotalExcursion();
            precioUY *= cotizacion;

            return precioUY;
        }

        // checkea si hay stock para comprar
        public int checkStock()
        {
            return this.stock;
        }

        //cambia el stock si hay disponible (para cancelar le paso un valor negativo)
        public void updateStock(int cantPax)
        {
            if (stock >= cantPax)
            {
                stock -= cantPax;
            }
        }

        // sorting
        public int CompareTo(Excursion other)
        {
            //fechas descendente
            return this.fechaComienzo.CompareTo(other.fechaComienzo) * -1;
        }

        // to string destinos
        public string mostrarDestinos()
        {
            string mostrardestinos = "";

            foreach (Destino destino in Destinos)
            {
                string ciudadPais = destino.Ciudad.Substring(0, 1).ToUpper() + destino.Ciudad.Substring(1).ToLower() + ", " + destino.Pais.Substring(0, 1).ToUpper() + destino.Pais.Substring(1).ToLower();
                mostrardestinos += " - " + ciudadPais + ".";
            }
            return mostrardestinos;
        }

        // to string precios
        public string MostrarExcursionesBien(double cotizacion)
        {
            double precio = 0;
            double precioUYU = 0;

            precio = calcCostoTotalExcursion();
            precioUYU = precio * cotizacion;

            return this.ToString() +
                     " > Precio Total USD: $ " + precio + "\n" +
                     " > Precio Total UYU: $ " + precioUYU + "\n";
        }


        // excepcion al metodo toString para esta clase
        public override string ToString()
        {
            string mostrardestinos = "";

            foreach (Destino destino in Destinos)
            {
                string ciudadPais = destino.Ciudad.Substring(0, 1).ToUpper() + destino.Ciudad.Substring(1).ToLower() + ", " + destino.Pais.Substring(0, 1).ToUpper() + destino.Pais.Substring(1).ToLower();
                mostrardestinos += " - " + ciudadPais + ". \n";
            }

            //muestro para cada excursion toda la info por pantalla
            return
                     " - ID: " + this.Id + "\n" +
                     " > Descripcion: " + this.Descripcion + "\n" +
                     " > Fecha del viaje: " + this.Fecha.ToShortDateString() + "\n" +
                     " > Cantidad de dias de Traslado: " + this.DiasTraslado + "\n" +
                     " > Stock disponible: " + this.Stock + "\n" +
                     " > Destinos: \n" + mostrardestinos + "\n";
        }
        
    }
}
