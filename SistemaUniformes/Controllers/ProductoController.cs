using Microsoft.AspNetCore.Mvc;
using SistemaUniformes.Business;
using SistemaUniformes.Models;
using System.Globalization;

namespace SistemaUniformes.Controllers
{
    public class ProductoController : Controller
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="access"></param>
        /// <param name="update"></param>
        /// <param name="delete"></param>
        /// <param name="add"></param>
        public ProductoController(IAccessInfo access, IUpdateInfo update, IDeleteInfo delete, IAddInfo add)
        {
            this.access = access;
            this.update = update;
            this.delete = delete;
            this.add = add;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Listar()
        {
            ViewData["Productos"] = await this.access.GetAllProductos();
            ViewData["Tipos"] = await this.access.GetAllTipos();
            return View();
        }

        // GET: EmpleadoController/Create
        public async Task<IActionResult> Guardar()
        {
            ViewData["Tipos"] = await this.access.GetAllTipos();
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guardar(Productos producto)
        {
            try
            {
                producto.Cantidad = Convert.ToInt32(producto.Cantidad);
                producto.Costo = Convert.ToDouble(producto.Costo);
                var result = await this.add.AgregarProducto(producto);
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
            ViewData["Producto"] = await this.access.GetByIdProducto(id);
            ViewData["Tipos"] = await this.access.GetAllTipos();
            return View();
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Productos producto)
        {
            try
            {

                var result = await this.update.UpdateProducto(producto);
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
            ViewData["Producto"] = await this.access.GetByIdProducto(id);
            return View();
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string prueba)
        {
            try
            {
                var result = await this.delete.EliminarProducto(id);
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
            for(int i= 0; i < values.Count(); i++)
            {
                if (values[i] == "0" || values[i] == "__RequestVerificationToken")
                {
                    values.RemoveAt(i);
                    ids.RemoveAt(i);
                    i = -1;
                }
            }
            var result = await this.add.AgregarOrdenEntrada(ids, values);
            return RedirectToAction("Listar");
        }
    }
}
