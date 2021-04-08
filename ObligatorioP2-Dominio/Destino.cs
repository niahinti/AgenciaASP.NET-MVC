using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Destino
    {
        private string pais;
        private string ciudad;
        private int cantDias;
        private double costoXDia;

        public string Pais
        {
            get { return this.pais; }
        }

        public string Ciudad
        {
            get { return this.ciudad; }
        }

        public int CantDias
        {
            get { return this.cantDias; }
        }

        public double CostoXDia
        {
            get { return this.costoXDia; }
        }

        public Destino(string pais, string ciudad, int cantDias, double costoXDia)
        {
            this.pais = pais;
            this.ciudad = ciudad;
            this.cantDias = cantDias;
            this.costoXDia = costoXDia;
        }
               
        //metodo calcula costo

        public double calcCostoDestino()
        {
            double precio = 0;

                if (CostoXDia > 0 && CantDias > 0)
                {
                    // al recorrer la lista de destinos, acumulo el valor total por dia por persona. y luego lo convierto a pesos UYU
                    precio += (CantDias * CostoXDia);
                }
            return precio;
        }


        public string MostrarDestinosbien(double unaCotizacion)
        {
            double precio = 0;
            double precioUYU = 0;

            precio = calcCostoDestino();
            precioUYU = precio * unaCotizacion;

            return this.ToString() +
                     " - Costo Total USD: $ " + precio + "\n" +
                     " - Costo Total UYU: $ " + precioUYU + "\n";
        }


        //excepcion al Metodo to string para mostrar los destinos en consola
        public override string ToString()
        {
            return
                "----------------------------------" + "\n" +
                " - Pais: " + this.Pais.Substring(0, 1).ToUpper() + Pais.Substring(1).ToLower() + "\n" +
                " - Ciudad: " + this.Ciudad.Substring(0, 1).ToUpper() + Ciudad.Substring(1).ToLower() + "\n" +
                " - Cantidad de dias: " + this.cantDias + "\n" +
                   " - Costo por dia: $ " + this.costoXDia + "\n";
        }
        

    }
}
