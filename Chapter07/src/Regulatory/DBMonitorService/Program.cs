namespace HIJK.SOA.Regulatory.DBMonitorService
{
    /// <summary>
    /// Service Host (container) for the background scheduled and always running tasks
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var monitor = new DBMonitor();

            monitor.Initialize();
            monitor.Work();
        }
    }
}
