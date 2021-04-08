using ObligatorioP2_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObligatorioMVC.Controllers
{
    public class ReportesController : Controller
    {
        //Funciones Administrador, Ver clientes
        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexVerClientes()
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                List<Cliente> listaClientes = ObligatorioP2_Dominio.Agencia.getInstancia.verClientes();
                ViewBag.Listaclientes = listaClientes;
                return View("IndexVerClientes");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }


        public ActionResult IndexBuscarCompras()
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return View("IndexBuscarCompras");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult BuscarCompras(DateTime? fechaDesde,
            DateTime? fechaHasta)
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                List<Compra> comprasPorFecha = new List<Compra>();
                if (fechaDesde != null && fechaHasta != null)
                {
                    comprasPorFecha = Agencia.getInstancia.buscarComprasPorFecha(
                        (DateTime)fechaDesde, (DateTime)fechaHasta);

                    double sumaCompras = 0;
                    foreach (Compra compra in comprasPorFecha)
                    {
                        sumaCompras += compra.MontoTotal;
                    }
                    ViewBag.TotalCompras = sumaCompras;
                }
                else
                {
                    ViewBag.FechaDesde = "Ingresar dos fechas (mm/dd/yyy)";
                }

                return View("IndexBuscarCompras", comprasPorFecha);
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult IndexEstadisticas()
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                List<Destino> destinosMax = Agencia.getInstancia.getDestinosMax();
                ViewBag.DestinosMax = destinosMax;

                return View("IndexEstadisticas");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }


        public ActionResult ReporteExcursionesPorDestino(string paisDestino, string ciudadDestino)
        {
            if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                if (ciudadDestino != null  && paisDestino != null && ciudadDestino != "" && paisDestino != "")
                {
                    List<Destino> destinosMax = Agencia.getInstancia.getDestinosMax();
                    ViewBag.DestinosMax = destinosMax;

                    List<Excursion> excursionesPorDestino = Agencia.getInstancia.buscarExcursionesPorDestino(paisDestino, ciudadDestino);

                    return View("IndexEstadisticas", excursionesPorDestino);
                }
                else
                {
                    return View("IndexEstadisticas");
                }
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Cliente")
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }


        }

        public ActionResult Mostrar()
        {
            string mensaje = "Prueba N2B" ;
            ViewBag.Mensaje = mensaje;
            return View();
        }





    }
}