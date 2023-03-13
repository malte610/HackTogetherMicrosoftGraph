using BlazorServerCalendarToInvoice.Utils;
using Microsoft.Graph;

namespace BlazorServerCalendarToInvoice.Model
{
    public class InvoiceLine
    {
        public int InvoiceHeaderId { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; } = default!;
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalNet { get; set; }
        public decimal VATRate { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalGross { get; set; }
        public InvoiceLine() { }
        public InvoiceLine(InvoiceHeader header, Event ev, decimal hourlyRate, decimal vatRate)
        {
            InvoiceHeader = header;
            Date = DateTime.Parse(ev.Start.DateTime);
            Description = ev.Subject;
            HourlyRate = hourlyRate;
            Quantity = (decimal)MathHelper.RoundToNearestQuarter(
                (DateTime.Parse(ev.End.DateTime) - DateTime.Parse(ev.Start.DateTime)).TotalHours);
            TotalNet = HourlyRate * Quantity;
            VATRate = vatRate / 100;
            VAT = Math.Round(TotalNet * VATRate, 2);
            TotalGross = TotalNet + VAT;
        }
    }
}
