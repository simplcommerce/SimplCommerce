using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using SimplCommerce.Module.Contact.Models;

namespace SimplCommerce.Module.Contact.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository<Models.Contact> _contactRepository;

        public ContactController(IRepository<Models.Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [Route("contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
