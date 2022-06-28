using Microsoft.AspNetCore.Mvc;
using TesteCamposDealer.Models;

namespace TesteCamposDealer.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            var lista = ClienteModel.GetClienteModel();
            ViewBag.Lista = lista;

            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            var clientes = new ClienteModel();
            clientes.GetClientes(Id);
            ViewBag.Clientes = clientes;

            return View();
        }

        public IActionResult DeletarConfirmacao(int Id)
        {
            var clientes = new ClienteModel();
            clientes.GetClientes(Id);
            ViewBag.Clientes = clientes;

            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public IActionResult Carregar()
        {
            return View();
        }
        [HttpPost]
        public void Salvar()
        {
            var clientes = new ClienteModel();

            clientes.idCliente = Convert.ToInt32(Request.Form["idCliente"]);
            clientes.nmCliente = Request.Form["nmCliente"];
            clientes.nmCidade = Request.Form["nmCidade"];

            clientes.Criar();

            Response.Redirect("/Clientes");
        }

        [HttpPost]
        public void Deleta()
        {
            var clientes = new ClienteModel();

            clientes.idCliente = Convert.ToInt32(Request.Form["idCliente"]);
            clientes.nmCliente = Request.Form["nmCliente"];
            clientes.nmCidade = Request.Form["nmCidade"];

            clientes.Deletar();

            Response.Redirect("/Clientes");
        }
    }
}
