using ProyectoAula3EmanuelGallego_SaraPineda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoAula3EmanuelGallego_SaraPineda.Controllers
{
    public class HomeController : Controller
    {
        Verificacion verificacion = new Verificacion();
        Modificacion modificacion = new Modificacion();
        Epm epm = new Epm();
        public ActionResult Epm()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            return View();
        }

        public ActionResult MostrarClienteNoRegistrado()
        {
            ViewBag.Notificacion = TempData["ClientesNoRegistrados"];
            return View();
        }

        public ActionResult MostrarEnergia()
        {
            if (epm.DatosDeUsuarios.Count > 0)
            {
                return View(epm);
            }
            if (epm.DatosDeUsuarios.Count == 0)
            {
                TempData["ClientesNoRegistrados"] = "No hay clientes registrados.";
                return RedirectToAction("MostrarClienteNoRegistrado");
            }
            return View();
        }

        public ActionResult MostrarAgua()
        {
            if (epm.DatosDeUsuarios.Count > 0)
            {
                return View(epm);
            }
            if (epm.DatosDeUsuarios.Count == 0)
            {
                TempData["ClientesNoRegistrados"] = "No hay clientes registrados.";
                return RedirectToAction("MostrarClienteNoRegistrado");
            }
            return View();
        }
        public ActionResult Facturacion()
        {
            ViewBag.Notificacion = TempData["NotificacionNoExistenciaId"];
            return View();
        }

        public ActionResult MostrarFactura()
        {
            string cedula;

            cedula = Convert.ToString(Request.Form["cedula"]);

            Factura factura = new Factura(cedula);

            if (verificacion.verificarExistenciaId(cedula) == false)
            {
                TempData["NotificacionNoExistenciaId"] = "El cliente identificado con el número " + cedula + " no se encuentra en el sistema";
                return RedirectToAction("Facturacion");
            }
            if (verificacion.verificarExistenciaId(cedula) == true)
            {
                return View(factura);
            }

            return View();
        }

        public ActionResult AgregarCliente()
        {
            ViewBag.Notificacion = TempData["ClienteYaRegistrado"];
            return View();
        }
        public ActionResult MostrarRegistro()
        {
            string cedula;
            string nombre;
            string apellido;
            int periodoConsumo;
            int estrato;
            int MetaAhorroEnergia;
            int ConsumoEnergia;
            int PromedioConsumoAgua;
            int ConsumoAgua;

            cedula = Convert.ToString(Request.Form["cedula"]);
            nombre = Convert.ToString(Request.Form["nombre"]);
            apellido = Convert.ToString(Request.Form["apellidos"]);
            periodoConsumo = Convert.ToInt32(Request.Form["periodoConsumo"]);
            estrato = Convert.ToInt32(Request.Form["estrato"]);
            MetaAhorroEnergia = Convert.ToInt32(Request.Form["metaAhorroEnergia"]);
            ConsumoEnergia = Convert.ToInt32(Request.Form["consumoActualEnergia"]);
            PromedioConsumoAgua = Convert.ToInt32(Request.Form["promedioConsumoAgua"]);
            ConsumoAgua = Convert.ToInt32(Request.Form["consumoActualAgua"]);

            if (verificacion.verificarExistenciaId(cedula))
            {
                TempData["ClienteYaRegistrado"] = "El cliente identificado con el número " + cedula + " ya se encuentra en el sistema.";
                return RedirectToAction("AgregarCliente");
            }

            Usuario usuario = new Usuario(cedula, nombre, apellido, periodoConsumo, estrato, MetaAhorroEnergia, ConsumoEnergia, PromedioConsumoAgua, ConsumoAgua);

            epm.AgregarCliente(usuario);
            return View(usuario);
        }
        public ActionResult EliminarCliente()
        {
            ViewBag.Notificacion = TempData["NotificacionNoExistenciaId"];
            return View();
        }
        public ActionResult MostrarClienteEliminado()
        {
            string cedula;

            cedula = Convert.ToString(Request.Form["cedula"]);

            if (verificacion.verificarExistenciaId(cedula) == false)
            {
                TempData["NotificacionNoExistenciaId"] = "El cliente identificado con el número " + cedula + " no se encuentra en el sistema";
                return RedirectToAction("EliminarCliente");
            }

            if (verificacion.verificarExistenciaId(cedula) == true)
            {
                foreach (Usuario usuario in epm.DatosDeUsuarios)
                {
                    if (usuario.Cedula == cedula)
                    {
                        Usuario clienteElimindo = epm.EliminarCliente(usuario);
                        return View(clienteElimindo);
                    }

                }
            }

            return View();
        }


        public ActionResult Modificacion()
        {
            ViewBag.Notificacion = TempData["NotificacionExistenciaId"];
            return View();
        }
        public ActionResult MostrarModificacion()
        {
            string cedula;
            string nombre;
            string apellido;
            string opcionModificar;
            int periodoConsumo;
            int estrato;
            int MetaAhorroEnergia;
            int ConsumoEnergia;
            int PromedioConsumoAgua;
            int ConsumoAgua;


            cedula = Convert.ToString(Request.Form["cedula"]);
            nombre = Convert.ToString(Request.Form["nombre"]);
            opcionModificar = Convert.ToString(Request.Form["opcionModificar"]);
            apellido = Convert.ToString(Request.Form["apellidos"]);
            periodoConsumo = Convert.ToInt32(Request.Form["periodoConsumo"]);
            estrato = Convert.ToInt32(Request.Form["estrato"]);
            MetaAhorroEnergia = Convert.ToInt32(Request.Form["metaAhorroEnergia"]);
            ConsumoEnergia = Convert.ToInt32(Request.Form["consumoActualEnergia"]);
            PromedioConsumoAgua = Convert.ToInt32(Request.Form["promedioConsumoAgua"]);
            ConsumoAgua = Convert.ToInt32(Request.Form["consumoActualAgua"]);
            if (verificacion.verificarExistenciaId(cedula) == false)
            {
                TempData["NotificacionExistenciaId"] = "El cliente identificado con el número " + cedula + " no se encuentra en el sistema";
                return RedirectToAction("Modificacion");
            }

            if (opcionModificar == "1")
            {
                string nuevoValor = Convert.ToString(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarNombre(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "2")
            {
                string nuevoValor = Convert.ToString(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarApellido(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "3")
            {
                int nuevoValor = Convert.ToInt32(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarPeriodoConsumo(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "4")
            {
                int nuevoValor = Convert.ToInt32(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarEstrato(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "5")
            {
                int nuevoValor = Convert.ToInt32(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarMetaAhorroEnergia(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "6")
            {
                int nuevoValor = Convert.ToInt32(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarConsumoEnergia(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "7")
            {
                int nuevoValor = Convert.ToInt32(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarPromedioConsumoAgua(cedula, nuevoValor);
                return View(resultadoModificacion);
            }

            else if (opcionModificar == "8")
            {
                int nuevoValor = Convert.ToInt32(Request.Form["valorNuevo"]);

                Usuario resultadoModificacion = modificacion.modificarConsumoAgua(cedula, nuevoValor);
                return View(resultadoModificacion);
            }
            return View();
        }
    }
}
