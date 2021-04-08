using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Internacional : Excursion
    {
        private CompaniaAerea companiaAerea;
        private static double comision = 10;

        public CompaniaAerea Compania
        {
            get { return this.companiaAerea; }
        }

        public static double Comision
        {
            get { return comision; }
        }

        //Constructor para Excursion Internacional. llamando a constructor clase padre, y pasandole los argumentos por parametro. 
        
        public Internacional(string descripcion, DateTime fechaComienzo
                        , int diasDeTraslado, int stock, List<Destino> destinos, CompaniaAerea companiaAerea) : base(descripcion, fechaComienzo, diasDeTraslado, stock, destinos)
        {
            this.companiaAerea = companiaAerea;
        }

        public override string ToString()
        {
            string codigoAereo = "";
           if (this.Compania != null)
            {
                //Guardo el codigo de la compania aerea en codigoAereo
                codigoAereo = this.Compania.Codigo;
            }
            return base.ToString() + " > Aerolinea: " + codigoAereo + "\n";
        }


        public override double calcCostoTotalExcursion()
        {
            double precio = 0;

            foreach (Destino destino in this.Destinos)
            {
                precio = destino.calcCostoDestino();
                precio += (destino.CantDias * destino.CostoXDia);
            }
            precio += ((comision / 100) * precio);
            return precio;
        }

        public override double montoEspecifico()
        {
            double montoComision = 0;
            double precio = 0;

            foreach (Destino destino in this.Destinos)
            {
                precio = destino.calcCostoDestino();
                precio += (destino.CantDias * destino.CostoXDia);
            }
            montoComision = ((comision / 100) * precio);
            return montoComision;
        }

        public override string datosEspecificos()
        {
            string datos = "";
            if (companiaAerea != null && companiaAerea.Codigo != null)
            {
                datos = "Aerolinea: " + companiaAerea.Codigo;
            }
            return datos;
        }

        public override string tipoExcursion()
        {
            string tipo = "Internacional";
            return tipo;
        }
    }

}
