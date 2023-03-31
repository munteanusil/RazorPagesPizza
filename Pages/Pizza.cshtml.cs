using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPIzza.Models;
using RazorPagesPIzza.Services;

namespace RazorPagesPIzza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza{get; set;} = new();
        public List<Pizza> pizzas = new();
        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }
        public string GlutenFreeText(Pizza pizza)
        {
            if(pizza.IsGlutenFree)           
                return "Gluten Free";
                return "Not GLuten Free";                     
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Deleted(id);
            return RedirectToAction("Get");
        }

       
    }
}
