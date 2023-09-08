using Microsoft.AspNetCore.Mvc;
using SistemaUniformes.Business;
using SistemaUniformes.Models;

namespace SistemaUniformes.Controllers
{
    public class EmpleadoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IAccessInfo access;
        /// <summary>
        /// 
        /// </summary>
        private readonly IUpdateInfo update;
        /// <summary>
        /// 
        /// </summary>
        private readonly IDeleteInfo delete;
        /// <summary>
        /// 
        /// </summary>
        private readonly IAddInfo add;

        public EmpleadoController(IAccessInfo access, IUpdateInfo update, IDeleteInfo delete, IAddInfo add)
        {
            this.access = access;
            this.update = update;
            this.delete = delete;
            this.add = add;
        }

        // GET: EmpleadoController
        public async Task<IActionResult> Listar()
        {
            ViewData["Empleados"] = await this.access.GetAllEmpleados();
            ViewData["Grupos"] = await this.access.GetAllGrupos();
            return View();
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoController/Create
        public async Task<IActionResult> Guardar()
        {
            ViewData["Grupos"] = await this.access.GetAllGrupos();
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guardar(Empleados empleado)
        {
            try
            {
                empleado.Activo = true;
                if (empleado.SegundoNombre == null)
                {
                    empleado.SegundoNombre = "";
                }
                var result = await this.add.AgregarEmpleado(empleado);
                if (result)
                    return RedirectToAction("Listar");
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<IActionResult> Editar(int id)
        {
            ViewData["Empleado"] = await this.access.GetByIdEmpleado(id);
            ViewData["Grupos"] = await this.access.GetAllGrupos();
            return View();
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Empleados empleado)
        {
            try
            {
                var result = await this.update.UpdateEmpleado(empleado);
                if (result)
                    return RedirectToAction("Listar");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            ViewData["Empleado"] = await this.access.GetByIdEmpleado(id);
            return View();
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string prueba)
        {
            try
            {
                var result = await this.delete.EliminarEmpleado(id);
                if (result)
                    return RedirectToAction("Listar");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> OtorgarProductos()
        {
            ViewData["Productos"] = await this.access.GetAllProductos();
            ViewData["Tipos"] = await this.access.GetAllTipos();
            return View();
        }

        public async Task<IActionResult> RecibeInfo(int id)
        {
            TablaPivote tablaPivote = new TablaPivote();
            tablaPivote.IdEmpleado = id;
            tablaPivote.Estatus = 1;
            var result = await this.add.AgregarPivote(tablaPivote);
            return RedirectToAction("OtorgarProductos");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecibeInfo(IFormCollection IdParameter)
        {
            List<string> values = new List<string>();
            List<string> ids = new List<string>();
            foreach (var param in IdParameter)
            {
                values.Add(param.Value);
                ids.Add(param.Key);
            }
            for (int i = 0; i < values.Count(); i++)
            {
                if (values[i] == "0" || values[i] == "__RequestVerificationToken")
                {
                    values.RemoveAt(i);
                    ids.RemoveAt(i);
                    i = -1;
                }
            }
            var result = await this.add.AgregarOrdenSalida(ids, values);
            return RedirectToAction("Listar");
        }
    }
}
