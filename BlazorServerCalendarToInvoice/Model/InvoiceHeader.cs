namespace BlazorServerCalendarToInvoice.Model
{
    public class InvoiceHeader
    {
        public Guid Guid { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderPlanet { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPlanet { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime InvoiceDate { get; set; } = new DateTime();
        public List<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
        public InvoiceHeader()
        {
            Guid = Guid.NewGuid();
        }
        public decimal TotalNet() => InvoiceLines.Sum(l => l.TotalNet);
        public decimal TotalVAT() => InvoiceLines.Sum(l => l.VAT);
        public decimal TotalGross() => InvoiceLines.Sum(l => l.TotalGross);
        public decimal TotalQuantity() => InvoiceLines.Sum(l => l.Quantity);
    }
}
