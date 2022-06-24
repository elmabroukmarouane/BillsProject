using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillProject.Models;
using BillProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        public IActionResult Post(Basket basket)
        {
            var dummyBill = new Bill()
            {
                // C'est le test pour le null car Total n'est pas nullable (double?) donc on doit envoyer une valeur double
                Total = _billService.GetBill(basket) ?? 0
            };
            return Ok(new
            {
                Message = "Here your bill",
                dummyBill.Total
            });
        }
    }
}
