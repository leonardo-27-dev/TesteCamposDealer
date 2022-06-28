using Microsoft.AspNetCore.Mvc;
using TesteCamposDealer.Models;

namespace TesteCamposDealer.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            var lista = ProdutoModel.GetProdutoModel();
            ViewBag.Lista = lista;

            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            var produto = new ProdutoModel();
            produto.GetProdutoModel(Id);
            ViewBag.produtos = produto;

            return View();
        }

        public IActionResult DeletarConfirmacao(int Id)
        {
            var produto = new ProdutoModel();
            produto.GetProdutoModel(Id);
            ViewBag.produtos = produto;

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
            var produto = new ProdutoModel();

            produto.idProduto = Convert.ToInt32(Request.Form["idProduto"]);
            produto.dscProduto = Request.Form["dscProduto"];
            produto.vlrUnitario = Convert.ToSingle(Request.Form["vlrUnitario"]);

            produto.Criar();

            Response.Redirect("/Produtos");
        }

        [HttpPost]
        public void Deleta()
        {
            var produto = new ProdutoModel();

            produto.idProduto = Convert.ToInt32(Request.Form["idProduto"]);
            produto.dscProduto = Request.Form["dscProduto"];
            produto.vlrUnitario = Convert.ToSingle(Request.Form["vlrUnitario"]);

            produto.Deletar();

            Response.Redirect("/Produtos");
        }
    }
}
