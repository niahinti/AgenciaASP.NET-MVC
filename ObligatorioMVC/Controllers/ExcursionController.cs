using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioP2_Dominio;

namespace ObligatorioMVC.Controllers
{
    public class ExcursionController : Controller
    {
        // Comprar y cancelar Excursiones
        // GET: Excursion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexCatalogo()
        {
            //falta que no vea el admin, pero va luego
            if (Session["rol"] == null || Session["rol"].ToString() == "Cliente")
            {
                return View("IndexCatalogo");
            }
            else
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
        }

        public ActionResult IndexComprarExcursion()
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                return View("IndexComprarExcursion");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult ComprarExcursion(int? idExcursion)
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                if (idExcursion != null)
                {                    
                    Excursion miExcursion = Agencia.getInstancia.buscarExcursionPorId((int)idExcursion);
                    ViewBag.miExcursion = miExcursion;
                    ViewBag.PrecioUY = Agencia.getInstancia.cotizarExcursionUY(miExcursion);
                }
                else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
                {
                    return RedirectToAction("../Reportes/IndexVerClientes");
                }
                else
                {
                    ViewBag.Mensaje = "no me llego un id, no se si debo mostrar error o no";
                }
                return View("IndexComprarExcursion");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult AltaCompra(int? idExcursion, int? paxMayor, int? paxMenor)
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                ViewBag.Confirmacion = false;
                if (paxMenor == null || paxMenor < 0)
                {
                    paxMenor = 0;
                }
                if (idExcursion != null)
                {
                    Excursion miExcursion = Agencia.getInstancia.buscarExcursionPorId((int)idExcursion);
                    ViewBag.miExcursion = miExcursion;
                    ViewBag.PrecioUY = Agencia.getInstancia.cotizarExcursionUY(miExcursion);
                    
                    //agarrar cliente de la session.
                    //Cliente cliente, Excursion excursion, double montoPerPax, int paxMayores, int paxMenores)
                    if (paxMayor > 0 && paxMenor >= 0)
                    {
                        string clienteId = Session["usuario"].ToString();
                        string mensaje = Agencia.getInstancia.altaCompra(clienteId, (int)idExcursion, (int)paxMayor, (int)paxMenor);
                        ViewBag.Mensaje = mensaje;
                        if (mensaje == "Disfrute su excursion!")
                        {
                            ViewBag.Confirmacion = true;
                        }
                    }
                    else
                    {
                        ViewBag.Mensaje = "Debe viajar al menos un adulto";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Excursion invalida, haga otra seleccion.";
                }
                return View("IndexComprarExcursion");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult IndexCompras()
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                string clienteId = Session["usuario"].ToString();
                List<Compra> listaMisCompras = Agencia.getInstancia.comprasPorCliente(clienteId);
                ViewBag.ListaMisCompras = listaMisCompras;

                string mensaje = "aaaaaaaaaaaaaaaaaaaaaaaaa";
                return View("MisCompras", model: mensaje);
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult cancelarCompra(int? idCompra)
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                string mensaje = "Debe estar logeado para usar esta funcionalidad";
                if (Session["usuario"] != null)
                {
                    //agarrar cliente de la session.
                    string clienteId = Session["usuario"].ToString();

                    mensaje = "Compra incorrecta.";

                    if (idCompra != null && idCompra > 0)
                    {
                        Compra compra = Agencia.getInstancia.buscarCompraPorId((int)idCompra);
                        if (compra != null && compra.Cliente.Username == clienteId)
                        {
                            if (DateTime.Now <= (compra.Excursion.Fecha).AddDays(-10))
                            {
                                mensaje = Agencia.getInstancia.cancelarCompra(compra, clienteId);
                                List<Compra> listaMisCompras = Agencia.getInstancia.comprasPorCliente(clienteId);
                                ViewBag.ListaMisCompras = listaMisCompras;
                                ViewBag.Mensaje = mensaje;
                                return View("MisCompras");
                            }
                            else
                            {
                                mensaje = "No es posible cancelar menos de 10 dias antes de la fecha de partida.";
                            }
                        }
                        else
                        {
                            mensaje = "Cliente no autorizado para cancelar esta compra.";
                        }
                    }
                }
                ViewBag.Mensaje = mensaje;
                return View("MisCompras");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }








    }
}