using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Nacional : Excursion
    {
        private bool interesNacional;
        private double descuento;

        public bool InteresNacional
        {
            get { return this.interesNacional; }
        }

        public double Descuento
        {
            get { return this.descuento; }
        }

        public Nacional(double descuento, string descripcion, DateTime fechaComienzo
                        , int diasDeTraslado, int stock, bool interesNacional, List<Destino> destinos) : base(descripcion, fechaComienzo, diasDeTraslado, stock, destinos)
        {
            this.interesNacional = interesNacional;
            this.descuento = descuento;
        }
        //Metodo toString para interes nacional
        public override string ToString()
        {
            string esinteres = "";

            if (InteresNacional)
            {
                esinteres += "SI \n";
            }
            else
            {
                esinteres = "NO \n";
            }

            return base.ToString() + " > Reconocida de Interes Nacional por el Ministerio de Turismo: " + esinteres + "\n";
        }

        public override double calcCostoTotalExcursion()
        {
            double precio = 0;

            foreach (Destino destino in this.Destinos)
            {
                precio = destino.calcCostoDestino();
                precio += (destino.CantDias * destino.CostoXDia);
            }
            if (Fecha.Month >= 5 && Fecha.Month <= 8)
            {
                precio -= ((descuento / 100) * precio);
            }
            return precio;
        }

        public override double montoEspecifico()
        {
            double montoDescuento = 0;
            double precio = 0;

            foreach (Destino destino in this.Destinos)
            {
                precio = destino.calcCostoDestino();
                precio += (destino.CantDias * destino.CostoXDia);
            }
            if (Fecha.Month >= 5 && Fecha.Month <= 8)
            {
                montoDescuento = ((descuento / 100) * precio);
            }
            return montoDescuento;
        }

        public override string datosEspecificos()
        {
            string datos = "";
            if (interesNacional)
            {
                datos = "Reconocida de Interes Nacional por el Ministerio de Turismo";
            }
            return datos;
        }

        public override string tipoExcursion()
        {
            string tipo = "Nacional";
            return tipo;
        }
    }
}
