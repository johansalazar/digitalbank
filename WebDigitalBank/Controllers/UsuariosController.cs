using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WcfServiceDigitalBank.Models;
using WebDigitalBank.ServiceRUsuario;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;



namespace WebDigitalBank.Controllers
{
    public class UsuariosController : Controller
    {
        //private WebDigitalBankContext db = new WebDigitalBankContext();

        private WcfServiceDigitalBank.UsuarioService usuarioService = new WcfServiceDigitalBank.UsuarioService();

        private const int TamañoPagina = 5; // Tamaño de página predeterminado
        private IFirebaseClient cliente;
        public UsuariosController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "jqKkY22viYYNuGUmTeyXC0juixlM8G4vmPDa81k2",
                BasePath = "https://digitalbanks-56a72-default-rtdb.firebaseio.com/"
            };
            cliente = new FirebaseClient(config);
        }


        // GET: Usuarios
        public ActionResult Index(int pagina = 1)
        {
            // Aquí debes implementar la lógica para obtener los datos paginados desde la base de datos utilizando ADO.NET.

            int totalRegistros = ObtenerTotalRegistros();
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / TamañoPagina);

            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPaginas;

            List<Usuarios> usuarios = new List<Usuarios>();
            usuarios = usuarioService.ListarUsuariosConPaginacion(pagina, totalPaginas);
            return View(usuarios);
        }

        private int ObtenerTotalRegistros()
        {
            int totalRegistros = usuarioService.ObtenerTotalRegistros();
            return totalRegistros;
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = usuarioService.LeerUsuarios(id);
            string idgenerado = usuarios.ID;
            FirebaseResponse response = cliente.Get("Usuarios/" + idgenerado);
            usuarioService.RegistrarActividad("LEER", "Usuarios", "Prueba", "Se realiza consulta de Usuario con ID: " + id + " DATE: " + DateTime.Now);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //    // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,FechaNacimiento,Sexo")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {

                string idgenerado = Guid.NewGuid().ToString("N");
                usuarios.ID = idgenerado;
                usuarioService.CrearUsuarios(usuarios);
                usuarioService.RegistrarActividad("CREAR", "Usuarios", "Prueba", "Se realiza CREACION de Usuario NOMBRE: " + usuarios.Nombre + " FECHA: " + usuarios.FechaNacimiento + " SEXO: " + usuarios.Sexo + " DATE: " + DateTime.Now);

                SetResponse response = cliente.Set("Usuarios/" + idgenerado, usuarios);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(usuarios);
        }

        //    // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = usuarioService.LeerUsuarios(id);
            string idgenerado = usuarios.ID;
            FirebaseResponse response = cliente.Get("Usuarios/" + idgenerado);
            usuarioService.RegistrarActividad("MODIFICAR", "Usuarios", "Prueba", "Se realiza consulta de Usuario con ID: " + id + " DATE: " + DateTime.Now);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,FechaNacimiento,Sexo")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                string idgenerado = usuarios.ID;

                usuarioService.ActualizarUsuarios(usuarios);
                FirebaseResponse response = cliente.Update("Usuarios/" + idgenerado, usuarios);
                usuarioService.RegistrarActividad("MODIFICAR", "Usuarios", "Prueba", "Se realiza MODIFICACIÓN de Usuario ID: " + usuarios.ID + " NOMBRE: " + usuarios.Nombre + " FECHA: " + usuarios.FechaNacimiento + " SEXO: " + usuarios.Sexo + " DATE: " + DateTime.Now);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = usuarioService.LeerUsuarios(id);
            string idgenerado = usuarios.ID;
            FirebaseResponse response = cliente.Get("Usuarios/" + idgenerado);
            usuarioService.RegistrarActividad("ELIMINAR", "Usuarios", "Prueba", "Se realiza consulta de Usuario con ID: " + id + " DATE: " + DateTime.Now);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuarios usuarios = usuarioService.LeerUsuarios(id);
            string idgenerado = usuarios.ID;
            FirebaseResponse response = null;
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            else
            {
                usuarioService.EliminarUsuarios(id);
                usuarioService.RegistrarActividad("ELIMINAR", "Usuarios", "Prueba", "Se realiza ELIMINACIÓN de Usuario con ID: " + id + " DATE: " + DateTime.Now);
                response = cliente.Delete("Usuarios/" + idgenerado);
               
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}
