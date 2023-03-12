namespace BlazorServerCalendarToInvoice.Utils
{
    public static class DateTimeHelper
    {
        public static DateTime GetStartOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0);
        }
        public static DateTime GetEndOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59);
        }
    }
}
