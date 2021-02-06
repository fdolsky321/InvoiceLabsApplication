using Domain.Interfaces.InvoiceContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using System;
using Domain.Invoices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Api.Controllers
{
    [Route("api/invoices")]
    [ApiController]
    [ApiKeyAuth]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceRepository invoiceRepository, IInvoiceService invoiceService)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceService = invoiceService;
        }

        //[Route("")]
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceRepository.ListAllAsync();
            return Json(invoices);
        }

        [HttpPost]
        public async Task<IActionResult> MakeInvoicePaid(Guid id) {

            var invoice = await _invoiceRepository.GetByIdAsync(id);
            await _invoiceService.InvoiceMakePaid(invoice);
            if (invoice != null) {
                return Ok(invoice);
            }
            return NotFound(invoice);
        }

        [HttpPatch]
        public async Task<IActionResult> EditInvoice(Guid id, [FromBody] JsonPatchDocument<Invoice> invoicePatch)
        {
            if (invoicePatch != null)
            {
                var invoice = await _invoiceRepository.GetByIdAsync(id);
                invoicePatch.ApplyTo(invoice, ModelState);
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(ModelState);
                }
                await _invoiceRepository.UpdateAsync(invoice);
                return Ok(invoice);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [Route("unpaid")]
        [HttpGet]
        public async Task<IActionResult> GetUnpaidInvoices()
        {
            var invoices = await _invoiceRepository.ListUnpaid();
            return Json(invoices);
        }
    }
}
