using Microsoft.AspNetCore.Mvc;
using SistemaUniformes.Business;

namespace SistemaUniformes.Controllers
{
    public class OrdenesController : Controller
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

        public OrdenesController(IAccessInfo access, IUpdateInfo update, IDeleteInfo delete, IAddInfo add)
        {
            this.access = access;
            this.update = update;
            this.delete = delete;
            this.add = add;
        }

        public async Task<IActionResult> Listar()
        {
            ViewData["Empleados"] = await this.access.GetAllEmpleados();
            ViewData["Productos"] = await this.access.GetAllProductos();
            ViewData["OrdenesSalida"] = await this.access.GetAllOrdenesSalida();
            ViewData["OrdenesEntrada"] = await this.access.GetAllOrdenesEntrada();
            return View();
        }
    }
}
