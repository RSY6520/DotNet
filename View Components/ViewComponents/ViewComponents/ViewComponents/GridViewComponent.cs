﻿using Microsoft.AspNetCore.Mvc;
using ViewComponents.Models;

namespace ViewComponents.ViewComponents
{
    public class GridViewComponent: ViewComponent
    {
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    PersonGridModel personGridModel = new PersonGridModel()
        //    {
        //        GridTitle = "Persons List",
        //        Persons = new List<Person>() {
        //          new Person() { PersonName = "John", JobTitle = "Manager" },
        //          new Person() { PersonName = "Jones", JobTitle = "Asst. Manager" },
        //          new Person() { PersonName = "William", JobTitle = "Clerk" },
        //        }
        //    };
        //    //ViewData["Grid"] = model;
        //    return View("Sample", personGridModel);
        //}
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel grid)
        {
            
            return View("Sample", grid);
        }
    }
}
