using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObligatorioP2_Dominio;

namespace ObligatorioP2_Web
{
    class Program
    {
        // Patron singleton, creo instancia de referencia para acceder a metodos de clase administradora Agencia
        static Agencia agencia = Agencia.getInstancia();
        static void Main(string[] args)
        {
            // inicio menu
            int opcion = -1;

            while (opcion != 6)
            {
                Console.WriteLine(@" \----------------------------------\
  \                                  \        __
   \                                  \       | \
    >Bienvenid@s al sistema de Agencia >------|  \       ______
   /                                  /       --- \_____/**|_|_\____  |
  /                                  /          \_______ --------- __>-}
 /----------------------------------/              /  \_____|_____/   |
                                                  *         |
                                                           {O}");


                Console.WriteLine(@"|----------------------------------|");
                Console.WriteLine("|       Seleccione una opcion      |");
                Console.WriteLine(@"|----------------------------------|");
                MostrarMenu();
                Console.WriteLine(@"|----------------------------------|");

                int.TryParse(Console.ReadLine(), out opcion);
                MenuOpciones(opcion);

            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("    1 - Crear Destino");
            Console.WriteLine("    2 - Mostrar Destinos");
            Console.WriteLine("    3 - Cotizacion USD");
            Console.WriteLine("    4 - Listar Excursiones");
            Console.WriteLine("    5 - Buscar Excursiones por Fecha");
            Console.WriteLine("    6 - Salir");
        }

        // estructura switch case para opciones de menu segun input 
        static void MenuOpciones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    AltaDestino();
                    break;
                case 2:
                    MostrarDestino();
                    break;
                case 3:
                    CotizacionUSD();
                    break;
                case 4:
                    MostrarExcursiones();
                    break;
                case 5:
                    ListadoExcursionXFecha();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }


        // DESTINO: ALTA Y MOSTRAR
        #region Destino
        static void AltaDestino()
        {
            string msgDestino = "Error: Datos incorrectos";
            Console.WriteLine("Ingrese pais");
            string pais = Console.ReadLine();
            Console.WriteLine("Ingrese ciudad");
            string ciudad = Console.ReadLine();
            Console.WriteLine("Ingrese cantidad de dias de estadia");
            int cantDias;
            int.TryParse(Console.ReadLine(), out cantDias);
            Console.WriteLine("Ingrese el costo por dia");
            double costoXDia;
            double.TryParse(Console.ReadLine(), out costoXDia);

            // primera letra en mayuscula, ya que guardo todos los nombres en minuscula para procesar.
            string ciudadPais = ciudad.Substring(0, 1).ToUpper() + ciudad.Substring(1).ToLower() + ", " + pais.Substring(0, 1).ToUpper() + pais.Substring(1).ToLower();

            if (pais.Length >= 3 && ciudad.Length >= 3 && cantDias > 0 && costoXDia > 0)
            {
                Destino nuevoD = agencia.crearDestino(pais, ciudad, cantDias, costoXDia);
                if (nuevoD != null)
                {
                    msgDestino = "Destino " + ciudadPais + " fue creado con exito!";
                }
                else
                {
                    Console.WriteLine("");
                    msgDestino = "Error: Destino " + ciudadPais + " ya existe";
                }
            }            
                Console.WriteLine(msgDestino);
            
        }

        static void MostrarDestino()
        {
            // llamo al metodo de clase agencia
            Console.WriteLine(agencia.MostrarDestino());
        }

        #endregion Destino
        // FIN DESTINO


        // COTIZACION USD
        #region Cotizacion usd

        // ver cotizacion actual, y opcion para modificar

        public static void CotizacionUSD()
        {
            // lo muestro con fecha de hoy
            DateTime ahora = DateTime.Now;
            string hoy = ahora.ToShortDateString();

            // tiene un menu interno
            int opcionCotizar = -1;

            while (opcionCotizar != 2)
            {
                Console.WriteLine(" ______ Cotizacion USD ______ \n");
                Console.WriteLine(hoy + "  1 USD  =  " + agencia.Cotizacion + "\n"); // metodo get accesor
                Console.WriteLine(" Opciones de Cotizacion ");
                Console.WriteLine(" 1 - Modificar");
                Console.WriteLine(" 2 - Salir \n");

                int.TryParse(Console.ReadLine(), out opcionCotizar);

                if (opcionCotizar == 1)
                {
                    Console.WriteLine(" Ingrese nuevo valor de cotizacion");
                    double nuevoValorUYU;
                    double.TryParse(Console.ReadLine(), out nuevoValorUYU);

                    // validacion
                    if (nuevoValorUYU > 0)
                    {
                        // hago el set, metodo modificador. pero sin resolver logica del negocio en consola. asi que llamo al metodo de clase que lo haga
                        
                        agencia.cambiarCotizacion(nuevoValorUYU);
                    }
                    else
                    {
                        Console.WriteLine("Dato incorrecto. Debe ser un numero positivo.");
                    }
                }
            }
        }
        #endregion Cotizacion usd
        // FIN COTIZACION USD


        // EXCURSIONES:  MOSTRAR Y BUSCAR

        #region Excursiones
        static void MostrarExcursiones()
        {
            Console.WriteLine(agencia.MostrarExcursiones());
        }

        //Metodo para listado de excursiones por fecha 
        static void ListadoExcursionXFecha()
        {
            string pais;
            string ciudad;
            string msgError = "No se encontraron excursiones con esas caracteristicas";
            DateTime fechaInicial;
            DateTime fechaFinal;

            Console.WriteLine("Ingrese pais:");
            pais = Console.ReadLine();
            Console.WriteLine("Ingrese ciudad:");
            ciudad = Console.ReadLine();
            Console.WriteLine("Ingrese fecha inicial:");
            Console.WriteLine("Formato AAAA-MM-DD");
            DateTime.TryParse(Console.ReadLine(), out fechaInicial);
            Console.WriteLine("Ingrese fecha final:");
            Console.WriteLine("Formato AAAA-MM-DD");
            DateTime.TryParse(Console.ReadLine(), out fechaFinal);

            if (pais != "" && ciudad != "" && fechaInicial > DateTime.MinValue && fechaFinal < DateTime.MaxValue)
            {
                Console.WriteLine(agencia.listarXFechaDestino(pais, ciudad, fechaInicial, fechaFinal));
            }
            else
            {
                Console.WriteLine(msgError);
            }
        }
        #endregion Excursiones
        // FIN EXCURSIONES
    }
}

