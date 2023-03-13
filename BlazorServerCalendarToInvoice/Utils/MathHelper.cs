namespace BlazorServerCalendarToInvoice.Utils
{
    public static class MathHelper
    {
        public static double RoundToNearestQuarter(this double x)
        {
            return Math.Round(x * 4, MidpointRounding.ToEven) / 4;
        }
    }
}
