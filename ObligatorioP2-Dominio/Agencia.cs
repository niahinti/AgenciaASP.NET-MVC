using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioP2_Dominio
{
    public class Agencia
    {
        private List<Excursion> listaExcursiones = new List<Excursion>();
        private double cotizacion;
        private List<Destino> listaDestinos = new List<Destino>();
        private List<CompaniaAerea> listaAerolineas = new List<CompaniaAerea>();
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private List<Compra> listaCompras = new List<Compra>();

        #region properties
        // patron Singleton
        // corro precarga al iniciar programa

        private static Agencia instancia = null;

        private Agencia()
        {
            PrecargaDatos();
        }

        public static Agencia getInstancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Agencia();
                }
                return instancia;
            }
        }

        // FIN SINGLETON


        public double Cotizacion
        {
            get { return this.cotizacion; }
            set { this.cotizacion = value; }
        }

        //Property de listadestinos
        public List<Destino> ListaDestinos
        {
            get { return this.listaDestinos; }
        }


        //Property de listaAerolineas
        public List<CompaniaAerea> GetListaAerolineas()
        {
            return listaAerolineas;
        }

        public List<Excursion> ListaExcursiones
        {
            get { return this.listaExcursiones; }
        }

        public List<Usuario> ListaUsuarios
        {
            get { return this.listaUsuarios; }
        }


        public List<Compra> ListaCompras
        {
            get { return this.listaCompras; }
        }

        #endregion properties

        // Precarga de Datos, y alta aero
        #region Precarga

        public void PrecargaDatos()
        {
            // precarga destinos
            Destino d01 = crearDestino("Grecia", "Atenas", 3, 60);
            Destino d02 = crearDestino("Grecia", "Santorini", 1, 80);
            Destino d03 = crearDestino("Italia", "Roma", 4, 70);
            Destino d04 = crearDestino("España", "Madrid", 2, 65);
            Destino d05 = crearDestino("España", "Ibiza", 2, 78);
            Destino d06 = crearDestino("USA", "Washington DC", 4, 50);
            Destino d07 = crearDestino("USA", "Los Angeles", 3, 67);
            Destino d08 = crearDestino("Uruguay", "Arequita", 1, 40);
            Destino d09 = crearDestino("Uruguay", "Cabo Polonio", 3, 55);
            Destino d10 = crearDestino("Uruguay", "Colonia del Sacramento", 2, 30);
            Destino d11 = crearDestino("Uruguay", "Montevideo", 4, 35);
            Destino d12 = crearDestino("Uruguay", "San Gregorio de Polanco", 1, 50);
            Destino d13 = crearDestino("Uruguay", "Piriapolis", 3, 60);

            // precarga Aerolineas
            CompaniaAerea IB = AltaAerolinea("IB", "España");
            CompaniaAerea AA = AltaAerolinea("AA", "EE.UU");
            CompaniaAerea LA = AltaAerolinea("LA", "Chile");

            // precarga listas destinos excursion.

            List<Destino> exc1 = new List<Destino>();
            exc1.Add(d01);
            exc1.Add(d02);
            List<Destino> exc2 = new List<Destino>();
            exc2.Add(d01);
            exc2.Add(d03);
            exc2.Add(d04);
            List<Destino> exc3 = new List<Destino>();
            exc3.Add(d06);
            exc3.Add(d07);
            List<Destino> exc4 = new List<Destino>();
            exc4.Add(d01);
            exc4.Add(d03);
            exc4.Add(d04);
            exc4.Add(d06);
            List<Destino> exc5 = new List<Destino>();
            exc5.Add(d09);
            exc5.Add(d11);
            exc5.Add(d13);
            List<Destino> exc6 = new List<Destino>();
            exc6.Add(d10);
            exc6.Add(d11);
            exc6.Add(d13);
            List<Destino> exc7 = new List<Destino>();
            exc7.Add(d08);
            exc7.Add(d13);
            List<Destino> exc8 = new List<Destino>();
            exc8.Add(d08);
            exc8.Add(d12);

            //Precarga Excursiones

            this.AgregarExcursionInternacional("Grecia", new DateTime(2021, 07, 15), 2, 23, exc1, "IB");
            this.AgregarExcursionInternacional("Europa", new DateTime(2022, 06, 04), 4, 26, exc2, "IB");
            this.AgregarExcursionInternacional("USA", new DateTime(2020, 12, 07), 2, 18, exc3, "AA");
            this.AgregarExcursionInternacional("Capitales del mundo", new DateTime(2021, 07, 15), 6, 3, exc4, "LA");
            this.AgregarExcursionNacional(10, "Playas del Uruguay", new DateTime(2021, 08, 15), 1, 3, true, exc5);
            this.AgregarExcursionNacional(15, "Tour Historico", new DateTime(2021, 04, 10), 2, 10, true, exc6);
            this.AgregarExcursionNacional(5, "Hiking en Cerros", new DateTime(2022, 06, 30), 1, 17, false, exc7);
            this.AgregarExcursionNacional(10, "Estancias Turisticas", new DateTime(2020, 12, 04), 2, 6, false, exc8);

            // precarga cotizacion
            this.cotizacion = 42.45;

            // precarga usuarios

            Cliente cliente1 = altaClienteObjeto("Astrid", "Madre de Dragones", "22222222", "Nueve09");
            Cliente cliente2 = altaClienteObjeto("Dahlia", "La Hechicera", "66666666", "Nubes09");            
            Cliente cliente4 = altaClienteObjeto("Sven", "El Guerrero", "44444444", "Noche09");
            Cliente cliente3 = altaClienteObjeto("Bjorn", "El Guerrero", "77777777", "Nords09");
            Cliente cliente5 = altaClienteObjeto("Olaf", "Hijo de Olaf", "55555555", "Nilium09");
            Cliente cliente6 = altaClienteObjeto("Erika", "La Gladiadora", "11111111", "Necar09");
            Cliente cliente7 = altaClienteObjeto("Helga", "La Gladiadora", "99999999", "Necro09");

            Usuario operador1 = altaUsuario("00000000", "Admin09", "Operador");
            Usuario operador2 = altaUsuario("33333333", "Jefa09", "Operador");

            // precarga Compras

            Compra compra = altaCompraObjeto("66666666", 1100, 2, 0, DateTime.Today.AddDays(-7));
            Compra compra2 = altaCompraObjeto("55555555", 1200, 3, 1, DateTime.Today.AddDays(-10));
            Compra compra3 = altaCompraObjeto("44444444", 1600, 5, 2, DateTime.Today.AddDays(-5));
            Compra compra4 = altaCompraObjeto("77777777", 1700, 1, 0, DateTime.Today.AddDays(-2));
            Compra compra5 = altaCompraObjeto("77777777", 1500, 3, 0, DateTime.Today);
        }

        // FIN PRECARGA

        // COTIZACION

        private void cambiarCotizacion(double nuevoValorUYU)
        {
            this.Cotizacion = nuevoValorUYU;
        }
        // FIN COTIZACION


        // Alta Aerolinea

        private CompaniaAerea AltaAerolinea(string codigo, string pais_origen)
        {
            CompaniaAerea aerolinea = null;
            //foreach (CompaniaAerea ca in listaAerolineas)
            //{
            bool existe = ValidarAerolinea(codigo);
            if (!existe)
            {
                aerolinea = new CompaniaAerea(codigo, pais_origen);
                this.listaAerolineas.Add(aerolinea);
            }
            //}    
            return aerolinea;
        }

        private bool ValidarAerolinea(string codigo)
        {
            bool existe = false;

            int i = 0;
            while (i < listaAerolineas.Count && existe == false)
            {
                if (listaAerolineas[i].Codigo == codigo)
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }
        #endregion Precarga
        // FIN Alta Aerolinea


        // ALTA DESTINO
        #region AltaDestino

        //Metodo alta destinos        

        private Destino crearDestino(string paisX, string ciudadX, int cantDias, double costoXDia)
        {
            Destino nuevoDestino = null; // inicio objeto en null
            string pais = paisX.ToLower(); // para validaciones paso texto a minuscula
            string ciudad = ciudadX.ToLower();

            bool existeDestino = ValidarDestino(pais, ciudad);
            // valido que nombre de pais y ciudad sea mayor a 3 caracteres. y costo y dias mayor a cero.
            // si cumplo condiciones creo la nueva instancia de objeto Destino. sino, retorno objeto null
            if (pais.Length >= 3 && ciudad.Length >= 3 && cantDias > 0 && costoXDia > 0 && !existeDestino)
            {
                nuevoDestino = new Destino(pais, ciudad, cantDias, costoXDia);
                //agrego a lista de destinos
                this.listaDestinos.Add(nuevoDestino);
            }

            return nuevoDestino;
        }

        // Metodo para recorrer lista destinos y verificar existencia
        private bool ValidarDestino(string pais, string ciudad)
        {
            bool existeDestino = false;

            int i = 0;
            while (i < listaDestinos.Count && existeDestino == false)
            {
                if (listaDestinos[i].Pais == pais && listaDestinos[i].Ciudad == ciudad)
                {
                    existeDestino = true;
                }
                i++;
            }
            return existeDestino;
        }


        //Metodo para mostrar destinos
        public string MostrarDestino()
        {//Variable para almacenar destinos
            string destinos = "";
            if (ListaDestinos.Count > 0)
            {
                //Para cada destino en la lista de destinos
                foreach (Destino destino in listaDestinos)
                {//concateno el toString de todos los objetos destino
                    destinos += destino.MostrarDestinosbien(cotizacion);
                }
            }
            else
            {
                destinos = "No hay destinos para mostrar";
            }
            //retorno string destinos
            return destinos;
        }


        public List<Destino> getDestinosMax()
        {
            List<Destino> destinosMax = new List<Destino>();

            int maxVeces = -1;
            foreach (Destino destino in ListaDestinos)
            {
                int veces = 0;
                foreach (Excursion excursion in listaExcursiones)
                {
                    if (excursion.Destinos.Contains(destino))
                    {
                        veces++;
                    }
                }
                if (veces > maxVeces)
                {
                    destinosMax.Clear();
                    destinosMax.Add(destino);
                    maxVeces = veces;
                }
                else if (veces == maxVeces)
                {
                    destinosMax.Add(destino);
                }
            }
            return destinosMax;
        }

        private Destino buscarDestinoPorId(string pais, string ciudad)
        {
            Destino destino = null;
            int i = 0;
            while (i < listaDestinos.Count() && destino == null)
            {
                if (listaDestinos[i].Pais == pais && listaDestinos[i].Ciudad == ciudad)
                {
                    destino = listaDestinos[i];
                }
                i++;
            }
            return destino;
        }


        #endregion AltaDestino
        // FIN ALTA DESTINO


        // EXCURSIONES
        #region Excursiones

        // ALTA

        //Metodo para agregar excursiones Nacionales
        private void AgregarExcursionNacional(double descuento, string descripcion, DateTime fechaComienzo, int diasDeTraslado, int stock, bool interesNacional, List<Destino> listdestinos)
        {
            //Validar datos, checkeo si lista destinos incluye destino internacional
            bool uruguay = ValidarDestinoUruguay(listdestinos);
            if (descripcion != "" && fechaComienzo >= DateTime.MinValue && diasDeTraslado > 0 && stock >= 0 && uruguay)
            {
                Nacional nuevaExcursion = new Nacional(descuento, descripcion, fechaComienzo, diasDeTraslado, stock, interesNacional, listdestinos);
                //Agrego a lista de excursiones
                this.listaExcursiones.Add(nuevaExcursion);
            }
        }
        //Metodo para agregar excursiones Internacionales
        private void AgregarExcursionInternacional(string descripcion, DateTime fechaComienzo
                        , int diasDeTraslado, int stock, List<Destino> destinos, string codigoCompaniaAerea)
        {
            //Validar datos         
            bool uruguay = ValidarDestinoUruguay(destinos);
            if (descripcion != "" && fechaComienzo >= DateTime.MinValue && diasDeTraslado > 0 && stock >= 0 && codigoCompaniaAerea != "" && !uruguay)
            {
                CompaniaAerea companiaAerea = BuscarCompaniaAerea(codigoCompaniaAerea);    // paso la string del codigo de aerolinea, y recibo el objeto para construir la nueva instancia excursion internacional
                Internacional nuevaExcursion = new Internacional(descripcion, fechaComienzo, diasDeTraslado, stock, destinos, companiaAerea);
                this.listaExcursiones.Add(nuevaExcursion);
            }
        }

        //Metodo para buscar el codigo de la compania aerea
        private CompaniaAerea BuscarCompaniaAerea(string codigo)
        {
            int i = 0;
            CompaniaAerea compania = null;

            while (i < listaAerolineas.Count && compania == null)
            {
                if (listaAerolineas[i].Codigo == codigo)
                {
                    compania = listaAerolineas[i];
                }
                i++;
            }
            return compania;
        }

        //FIN ALTA

        // LISTAR

        //Metodo para mostrar Excursiones
        public string MostrarExcursiones()
        {//Variable para almacenar excursiones en texto
            string listadoexcursiones = ""; if (listaExcursiones.Count > 0)
            {
                //Para cada excursion en la lista de excursiones
                foreach (Excursion excu in listaExcursiones)
                {// concateno en la string los objetos excursion pasados a texto friendly
                    listadoexcursiones += excu.MostrarExcursionesBien(Cotizacion);
                }
            }
            else
            {
                listadoexcursiones = "No hay Excursiones para mostrar.";
            }
            //muestro excursiones por pantalla
            return listadoexcursiones;
        }

        // BUSCAR 


        //Metodo para listar x fechas las excursiones
        public string listarXFechaDestino(string paisX, string ciudadX, DateTime fechaInicio, DateTime fechaFinal)
        {
            string resultado = "";
            string pais = paisX.ToLower();
            string ciudad = ciudadX.ToLower();
            bool encontrada = false;
            //Para cada excursion en mi lista de excursiones
            foreach (Excursion excursion in listaExcursiones)
            {
                //Valido que el destino coincida
                bool destinos = ValidarDestinoExcursion(pais, ciudad, excursion);
                //Comparo las fechas para mostrar las excursiones
                if (destinos && excursion.Fecha >= fechaInicio && excursion.Fecha <= fechaFinal && fechaInicio < fechaFinal)
                {
                    resultado += excursion.MostrarExcursionesBien(Cotizacion);
                    encontrada = true;
                }
            }
            // en caso de no encontrar retorno un mensaje
            if (!encontrada)
            {
                resultado = "No se encontraron excursiones con esas caracteristicas";
            }
            return resultado;
        }

        // metodo para verificar existencia de destino.
        private bool ValidarDestinoExcursion(string pais, string ciudad, Excursion excursion)
        {
            bool existeDestino = false;

            foreach (Destino destino in excursion.Destinos)
            {
                if (destino.Pais == pais && destino.Ciudad == ciudad)
                {
                    existeDestino = true;
                }
            }
            return existeDestino;
        }

        // metodo para verificar si las excursiones en una lista son internacionales o Nacionales (uruguay)
        private bool ValidarDestinoUruguay(List<Destino> listdestinos)
        {
            bool uruguay = false;

            int i = 0;
            while (i < listdestinos.Count && uruguay == false)
            {
                if (listdestinos[i].Pais == "uruguay")
                {
                    uruguay = true;
                }
                i++;
            }
            return uruguay;
        }


        //
        public Excursion buscarExcursionPorId(int idExcursion)
        {
            Excursion miExcursion = null;
            int i = 0;
            while (i < listaExcursiones.Count() && miExcursion == null)
            {
                if (listaExcursiones[i].Id == idExcursion)
                {
                    miExcursion = listaExcursiones[i];
                }
                i++;
            }
            return miExcursion;
        }


        // funciones que retornan el precio de la excursion
        public double cotizarExcursion(Excursion miExcursion)
        {
            double costoUy = 0;
            costoUy = miExcursion.calcCostoTotalExcursion();

            return costoUy;
        }
        public double cotizarExcursionUY(Excursion miExcursion)
        {
            double costoUy = 0;
            costoUy = miExcursion.convertirExcursionUY(cotizacion);

            return costoUy;
        }

        #endregion Excursiones


        //para operador, buscar excursiones que incluuenun destino, con contains
        public List<Excursion> buscarExcursionesPorDestino(string pais, string ciudad)
        {
            List<Excursion> excursionesPorDestino = new List<Excursion>();
            if (pais != "" && ciudad != "")
            {
                Destino destinoBuscado = buscarDestinoPorId(pais, ciudad);

                if (destinoBuscado != null)
                {
                    foreach (Excursion excursion in ListaExcursiones)
                    {
                        if (excursion.Destinos.Contains(destinoBuscado))
                        {
                            excursionesPorDestino.Add(excursion);
                        }
                    }
                }
            }
            excursionesPorDestino.Sort();
            return excursionesPorDestino;
        }






        // FIN EXCURSIONES


        // CLIENTE
        #region Cliente

        public string altaCliente(string nombre, string apellido, string username, string contrasenia)
        {
            string mensajeAlta = "No te pude agregar";
            if (nombre.Length >= 2 && apellido.Length >= 2 && username.Length >= 7 && username.Length <= 9
                && username.All(char.IsDigit) && contrasenia.Length >= 6 && contrasenia.Any(char.IsUpper)
                && contrasenia.Any(char.IsLower) && contrasenia.Any(char.IsDigit))
            {
                // verificar existencia cedula
                bool existe = ExisteUser(username);
                if (!existe)
                {
                    string rol = "Cliente";
                    Cliente newCliente = new Cliente(nombre, apellido, username, contrasenia, rol);
                    listaUsuarios.Add(newCliente);
                    mensajeAlta = "Cliente creado con exito.";
                }
                else
                {
                    mensajeAlta = "Cliente ya existe";
                }
            }
            return mensajeAlta;
        }

        // alta para precarga
        private Cliente altaClienteObjeto(string nombre, string apellido, string username, string contrasenia)
        {
            string rol = "Cliente";
            Cliente cliente = null;
            if (nombre.Length >= 2 && apellido.Length >= 2 && username.Length >= 7 && username.Length <= 9
                && username.All(char.IsDigit) && contrasenia.Length >= 6 && contrasenia.Any(char.IsUpper)
                && contrasenia.Any(char.IsLower) && contrasenia.Any(char.IsDigit))
            {
                // verificar existencia cedula
                bool existe = ExisteUser(username);
                if (!existe)
                {
                    cliente = new Cliente(nombre, apellido, username, contrasenia, rol);
                    listaUsuarios.Add(cliente);
                }
            }
            return cliente;
        }

        // para registrar un cliente
        private Usuario altaUsuario(string username, string contrasenia, string rol)
        {
            Usuario usuario = null;
            if (username.Length >= 7 && username.Length <= 9
                && username.All(char.IsDigit) && contrasenia.Length >= 6 && contrasenia.Any(char.IsUpper)
                && contrasenia.Any(char.IsLower) && contrasenia.Any(char.IsDigit))
            {
                // verificar existencia cedula
                bool existe = ExisteUser(username);
                if (!existe)
                {
                    usuario = new Usuario(username, contrasenia, rol);
                    listaUsuarios.Add(usuario);
                }
            }
            return usuario;
        }

        // para registrar un cliente, y verificar si ya existe
        private bool ExisteUser(string username)
        {
            bool existe = false;
            int i = 0;

            while (i < listaUsuarios.Count() && !existe)
            {
                if (listaUsuarios[i].Username == username)
                {
                    existe = true;
                }
                i++;
            }
            return existe;
        }


        // para el login
        public Usuario buscarUsuarioPorId(string userId)
        {
            Usuario miUser = null;
            int i = 0;
            while (i < listaUsuarios.Count() && miUser == null)
            {
                if (listaUsuarios[i].Username == userId)
                {
                    miUser = listaUsuarios[i];
                }
                i++;
            }
            return miUser;
        }

        //para dar de alta una compra
        private Cliente buscarClientePorId(string userId)
        {
            Cliente miCliente = null;
            int i = 0;
            while (i < listaUsuarios.Count() && miCliente == null)
            {
                if (listaUsuarios[i].Username == userId)
                {
                    miCliente = (Cliente)listaUsuarios[i];
                }
                i++;
            }
            return miCliente;
        }

        #endregion Cliente


        //para operador, ver Clientes
        public List<Cliente> verClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario is Cliente)
                {
                    listaClientes.Add((Cliente)usuario);
                }
            }
            listaClientes.Sort();
            return listaClientes;
        }

        // FIN CLIENTE


        // COMPRA
        #region Compra

        public string altaCompra(string clienteId, int idExcursion, int paxMayores, int paxMenores)
        {
            string msgCompra = "me faltan datos";
            if (clienteId != null)
            {
                Cliente cliente = buscarClientePorId(clienteId);
                Excursion excursion = buscarExcursionPorId(idExcursion);
                if (cliente != null)
                {
                    if (cliente != null && excursion != null && paxMayores > 0 && paxMenores >= 0)
                    {
                        int cantPax = paxMayores + paxMenores;
                        int stockDisponible = excursion.checkStock();
                        if (cantPax <= stockDisponible)
                        {
                            DateTime fecha = DateTime.Now;
                            double montoPerPax = cotizarExcursion(excursion);
                            double montoTotal = montoPerPax * cantPax;
                            Compra nuevaCompra = new Compra(cliente, excursion, montoTotal, paxMayores, paxMenores, fecha);
                            listaCompras.Add(nuevaCompra);
                            excursion.updateStock(cantPax);
                            msgCompra = "Disfrute su excursion!";
                        }
                        else
                        {
                            msgCompra = "Solo quedan "+excursion.Stock+" lugares disponibles.";
                        }
                    }
                }
                else
                {
                    msgCompra = "Usuario no habilidato para hacer esta compra";
                }
            }
            return msgCompra;
        }

        private Compra altaCompraObjeto(string clienteId, int idExcursion, int paxMayores, int paxMenores, DateTime fecha)
        {
            Compra nuevaCompra = null;
            if (clienteId != null)
            {
                Cliente cliente = buscarClientePorId(clienteId);
                Excursion excursion = buscarExcursionPorId(idExcursion);

                if (cliente != null)
                {
                    if (cliente != null && excursion != null && paxMayores > 0 && paxMenores >= 0)
                    {

                        int cantPax = paxMayores + paxMenores;
                        int stockDisponible = excursion.checkStock();
                        if (cantPax <= stockDisponible)
                        {                            
                            double montoTotal = cotizarExcursion(excursion);
                            montoTotal *= (paxMayores + paxMenores);

                            nuevaCompra = new Compra(cliente, excursion, montoTotal, paxMayores, paxMenores, fecha);
                            listaCompras.Add(nuevaCompra);
                            excursion.updateStock(cantPax);
                        }
                    }
                }
            }
            return nuevaCompra;
        }

        // para clientes, en mis compras, pueden cancelar una
        public string cancelarCompra(Compra compra, string clienteId)
        {
            string msgCancelar = "No pude encontrar esa compra.";
            if (compra != null && clienteId != null)
            {
                Cliente cliente = buscarClientePorId(clienteId);

                if (cliente != null && DateTime.Now <= (compra.Excursion.Fecha).AddDays(-9))
                {
                    if (compra.Cliente == cliente)
                    {
                        
                        int cantPax = (compra.PaxMayores + compra.PaxMenores) * -1;
                        compra.Excursion.updateStock(cantPax);
                        listaCompras.Remove(compra);
                        msgCancelar = "Hemos cancelado la compra a " + compra.Excursion.Descripcion + ".";
                    }
                    else
                    {
                        msgCancelar = "No se puede cancelar esta compra.";
                    }
                }
                else
                {
                    msgCancelar = "Compra o cliente incorrecto";
                }
            }
            return msgCancelar;
        }

        // para la funcion de cancelar compras en Excursion controler  
        public Compra buscarCompraPorId(int idCompra)
        {
            Compra compra = null;

            int i = 0;
            while (i < listaCompras.Count && compra == null)
            {
                if (listaCompras[i].Id == idCompra)
                {
                    compra = listaCompras[i];
                }
                i++;
            }
            return compra;
        }

        // para la funcionalidad de mostrar mis compras, tomando el cliente loggeado
        public List<Compra> comprasPorCliente(string clienteId)
        {
            List<Compra> listaComprasCliente = new List<Compra>();
            foreach (Compra compra in listaCompras)
            {
                if (compra.Cliente.Username == clienteId)
                {
                    listaComprasCliente.Add(compra);
                }
            }
            return listaComprasCliente;
        }


        // para operador, reporte de compras por fecha
        public List<Compra> buscarComprasPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Compra> comprasPorFecha = new List<Compra>();
            foreach (Compra compra in listaCompras)
            {
                if (compra.Fecha >= fechaDesde && compra.Fecha <= fechaHasta)
                {
                    comprasPorFecha.Add(compra);
                }
            }
            return comprasPorFecha;
        }                                    
        
        #endregion Compra
        // FIN COMPRA

    }
}
