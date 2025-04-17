using Api.DataSource;
using Api.Template;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PdfController(ILogger<PdfController> logger) : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var model = InvoiceDocumentDataSource.GetInvoiceDetails();
            var document = new InvoiceDocument(model);
            var bytes = document.GeneratePdf();
            return File(bytes, "application/pdf", "arquivo-retornado.pdf");
        }
    }
}