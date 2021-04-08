using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Compra
    {
        private int id;
        private Cliente cliente;
        private Excursion excursion;
        private double montoTotal;
        private int paxMayores;
        private int paxMenores;
        private DateTime fecha;
        private static int ultId = 1;

        public int Id
        {
            get { return this.id; }
        }
        public Cliente Cliente
        {
            get { return this.cliente; }
        }
        public Excursion Excursion
        {
            get { return this.excursion; }
        }
        public double MontoTotal
        {
            get { return this.montoTotal; }
        }
        public int PaxMayores
        {
            get { return this.paxMayores; }
        }
        public int PaxMenores
        {
            get { return this.paxMenores; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
        }

        public Compra(Cliente cliente, Excursion excursion, double montoTotal, int paxMayores, int paxMenores, DateTime fecha)
        {
            this.id = Compra.ultId;
            Compra.ultId += 1;
            this.cliente = cliente;
            this.excursion = excursion;
            this.montoTotal = montoTotal;
            this.paxMayores = paxMayores;
            this.paxMenores = paxMenores;
            this.fecha = fecha;
        }

        // sumo mayores y menores y calculo la cantidad de pasajeros total
        public int cantPax()
        {
            int cantidadPax = 0;
            cantidadPax = paxMayores + paxMenores;
            return cantidadPax;
        }

        // guardo el monto total de la compra original, y despues lo divido entre cantidad de pasajeros
        public double calcMontoPerPax()
        {
            double montoPerPax = 0;
            int cuantosPax = cantPax();
            montoPerPax = montoTotal / cuantosPax;
            return montoPerPax;
        }

        // calcula cuando descuento o comision total hubo en una compra
        public double calcMontoEspecifico()
        {
            double montoEspecifico = 0;
            double desc_com = excursion.montoEspecifico();
            int cuantosPax = cantPax();
            montoEspecifico = desc_com * cuantosPax;

            return montoEspecifico;
        }

    }
}
