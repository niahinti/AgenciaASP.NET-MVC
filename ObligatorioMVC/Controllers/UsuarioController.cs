using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObligatorioP2_Dominio;

namespace ObligatorioMVC.Controllers
{
    public class UsuarioController : Controller
    {
        // Login, Logout y altaClientes
        // GET: Usuario
        public ActionResult Index()
        {
            return View("Home");
        }

        public ActionResult Logout()
        {
            if (Session["rol"] != null)
            {
                Session.Clear();
                return View("IndexLogin");
            }
            else
            {
                return RedirectToAction("../Usuario/IndexLogin");
            }
        }

        public ActionResult IndexLogin()
        {
            if (Session["rol"] == null)
            {
                return View("IndexLogin");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
        }

        public ActionResult Login(string username, string contrasenia)
        {
            if (Session["rol"] == null)
            {
                if (username != "" && contrasenia != "")
                {
                    Usuario usuarioLogin = Agencia.getInstancia.buscarUsuarioPorId(username);

                    if (usuarioLogin != null && usuarioLogin.Contrasenia == contrasenia)
                    {
                        Session["usuario"] = username;
                        Session["rol"] = usuarioLogin.Rol;
                        ViewBag.Mensaje = "Redireccionando al sitio...";
                        return RedirectToAction("../Excursion/IndexCatalogo");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Usuario o contraseña invalidos.";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ingrese usuario y contraseña.";
                }
                return View("IndexLogin");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
        }


        public ActionResult IndexAltaCliente()
        {
            if (Session["rol"] == null)
            {
                return View("IndexAltaCliente");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }
        }

        public ActionResult AltaCliente(string nombre, string apellido, string username, string contrasenia)
        {
            if (Session["rol"] == null)
            {
                if (username != null && nombre != null && apellido != null && contrasenia != null)
                {
                    if (nombre.Length >= 2 && apellido.Length >= 2 && username.Length >= 7 && username.Length <= 9 && username.All(char.IsDigit) && contrasenia.Length >= 6 && contrasenia.Any(char.IsUpper) && contrasenia.Any(char.IsLower) && contrasenia.Any(char.IsDigit))
                    {
                        ViewBag.MensajeAlta = Agencia.getInstancia.altaCliente(nombre, apellido, username, contrasenia);
                    }
                    else
                    {
                        ViewBag.Mensaje = "Formato incorrecto";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Me faltan datos";
                }
                return View("IndexAltaCliente");
            }
            else if (Session["rol"] != null && Session["rol"].ToString() == "Operador")
            {
                return RedirectToAction("../Reportes/IndexVerClientes");
            }
            else
            {
                return RedirectToAction("../Excursion/IndexCatalogo");
            }

        }
    }
}