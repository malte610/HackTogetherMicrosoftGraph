using BlazorServerCalendarToInvoice.Model;
using System.Data;
using System.Text;
using BlazorServerCalendarToInvoice.Utils;
using AspNetCore.Reporting;

namespace BlazorServerCalendarToInvoice.Rdlc
{
    public static class ReportService
    {
        public static async Task<byte[]> CreateInvoice(InvoiceHeader invoice)
        {
            await Task.Delay(1);
            // prepare data

            var tempList = new List<InvoiceHeader> { invoice };
            DataTable dt_invoiceHeader = DataTableHelper.ToDataTable(tempList);
            dt_invoiceHeader.Columns.RemoveAt(
                dt_invoiceHeader.Columns.IndexOf("InvoiceLines"));
            DataTable dt_invoiceLines = DataTableHelper.ToDataTable(invoice.InvoiceLines);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Dictionary<string, string> parameters = new()
            {
                { "param", "Hi" }
            };

            // run report
            string mimetype = "application/pdf";
            int extension = 1;
            string path;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Rdlc", "Reports", "Invoice.rdlc"));
            else
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "rdlc", "Invoice.rdlc"));
            
            LocalReport localReport = new(path);
            localReport.AddDataSource("dsInvoiceHeader", dt_invoiceHeader);
            localReport.AddDataSource("dsInvoiceLines", dt_invoiceLines);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return result.MainStream;
        }
    }
}
