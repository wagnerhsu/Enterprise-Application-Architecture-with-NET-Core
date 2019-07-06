using HIJK.SOA.SOAServices;
using System;

namespace HIJK.SOA.Regulatory.DBMonitorService
{
    /// <summary>
    /// This provides the services related to monitoring the database for the validity of documents and notify the relevant service(s) to take required actions.
    /// Its a background always running service watching the dates of documents going to expire in a month.
    /// </summary>
    public class DBMonitor : IDisposable
    {
        private SOAContext soaContext;

        public DBMonitor()
        {
            soaContext = new SOAContext();
        }

        public void Initialize()
        {
            //Does the initialization, configuration, schedules, database, check ups..
            soaContext.Initialize();
        }

        public void Work()
        {
            //Perform all the mandated tasks as per schedule
            //Periodically watch DB tables for documents validity
            //Detect the change
            //Notify the change in respective document that it is expiring soon -- calls DocumentValidity notification service
        }

        #region IDisposable Interface
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (soaContext != null) soaContext.Close();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
