using System.Data;
using System.Reflection;

namespace BlazorServerCalendarToInvoice.Utils
{
    public class DataTableHelper
    {
        internal static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
#pragma warning disable CS8601 // Possible null reference assignment.
                    values[i] = Props[i].GetValue(item, null);
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
