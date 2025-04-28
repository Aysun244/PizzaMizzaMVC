using Microsoft.AspNetCore.Mvc;
using PizzaMizzaMVC.Repositories;
using PizzaMizzaMVC.Model;

namespace PizzaMizzaMVC.Controllers
{
    public class PizzaController : Controller
    {
        private readonly PizzaRepository _repository = new PizzaRepository();

        public IActionResult Index()
        {
            var pizzas = _repository.GetAll();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            var pizza = _repository.GetById(id);
            var ingredients = _repository.GetIngredients(id);

            ViewBag.Pizza = pizza;
            ViewBag.Ingredients = ingredients;
            return View();
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}