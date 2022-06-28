using Microsoft.AspNetCore.Mvc;
using TesteCamposDealer.Data;
using TesteCamposDealer.Models;
using System.Collections.Generic;
using System.Linq;

namespace TesteCamposDealer.Controllers
{
    public class VendasController : Controller
    {
        public IActionResult Index()
        {
            var lista = VendaModel.GetVendaModel();
            ViewBag.Lista = lista;

            return View();
        }

        public JsonResult GetCliente(string name)
        {
            DataContext dc = new DataContext();
            var emp = (from x in dc.Clientes where x.nmCliente.StartsWith(name) select new { label = x.nmCliente }).ToList();
            return Json(emp);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            var venda = new VendaModel();
            venda.GetVendaModel(Id);
            ViewBag.Vendas = venda;

            return View();
        }

        public IActionResult DeletarConfirmacao(int Id)
        {
            var venda = new VendaModel();
            venda.GetVendaModel(Id);
            ViewBag.vendas = venda;

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
            var venda = new VendaModel();

            venda.idVenda = Convert.ToInt32(Request.Form["idVenda"]);
            venda.idCliente = Convert.ToInt32(Request.Form["idCliente"]);
            venda.idProduto = Convert.ToInt32(Request.Form["idProduto"]);
            venda.qtdVenda = Convert.ToInt32(Request.Form["qtdVenda"]);
            venda.vlrUnitarioVenda = Convert.ToSingle(Request.Form["vlrUnitarioVenda"]);

            venda.Criar();

            Response.Redirect("/Vendas");
        }

        [HttpPost]
        public void Deleta()
        {
            var venda = new VendaModel();

            venda.idVenda = Convert.ToInt32(Request.Form["idVenda"]);

            venda.Deletar();

            Response.Redirect("/Vendas");
        }
    }
}
