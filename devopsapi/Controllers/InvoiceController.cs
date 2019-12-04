using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devopsapi.Models;
using devopsapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace devopsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET api/invoices
        [HttpGet]
        public IActionResult Get()
        {
            List<Invoice> invoices = _invoiceService.Read();
            return new JsonResult(invoices);
        }

        // GET api/invoices/(id)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Invoice invoice = _invoiceService.Read(id);
            return new JsonResult(invoice);
        }

        // POST api/invoices
        [HttpPost]
        public IActionResult Create([FromBody] Invoice invoice)
        {
            Invoice createdInvoice = _invoiceService.Create(invoice);
            return new JsonResult(createdInvoice);
        }

        // PUT api/invoice/(id)
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Invoice invoice)
        {
            Invoice updatedInvoice = _invoiceService.Update(id, invoice);
            return new JsonResult(updatedInvoice);
        }

        // DELETE api/invoice/(id)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _invoiceService.Delete(id);
            return new OkResult();
        }
    }
}
