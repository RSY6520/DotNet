﻿using Microsoft.AspNetCore.Mvc;
using ModelValidations.Models;
using ModelValidationsExample.CustomModelBinders;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]

        //Example JSON: { "PersonName": "William", "Email": "william@example.com", "Phone": "123456", "Password": "william123", "ConfirmPassword": "william123" }
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index([FromBody] [ModelBinder(BinderType = typeof(PersonModelBinder))] Person person)
        {
            if(!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}