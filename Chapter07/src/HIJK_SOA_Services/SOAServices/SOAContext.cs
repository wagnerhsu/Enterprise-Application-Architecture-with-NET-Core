// <copyright file="SOAContext.cs" company="HIJK">
//     Copyright (c) HIJK Ltd. All rights reserved.
// </copyright>
// <summary>
//     <project>HIJK SOA Services</project>
//     <description>
//         HIJK SOA wide basic services across the whole platform
//     </description>
// </summary>

namespace HIJK.SOA.SOAServices
{
    /// <summary>
    /// This object provides the basic SOA context to all the SOA services in the HIJK's SOA Platform
    /// </summary>
    public class SOAContext
    {
        public SOALogger soaLogger;
        //SOATracker soaTracker;

        private SOAServiceStructure soaServiceStructure;

        public SOAContext()
        {
            //Basic SOA Services, libraries, configuration initialization
            soaLogger = new SOALogger();
            soaServiceStructure = new SOAServiceStructure();
        }

        /// <summary>
        /// Initialize the SOA context
        /// </summary>
        public void Initialize()
        {
            //Initialize soaLogger & soaTracker
            //Read configuration or other meta-information mechanism to discover the SOA Service (which is using it) under the context
            //Create SOAServiceStructure: SOAMetaInfo & SOAPayload
            //Debug, SOA, Verbose logs
        }

        /// <summary>
        /// Close the SOA context successfully
        /// </summary>
        public void Close()
        {
            //Close the context
            //SOALogger.Log
            //SOATracker.Finish
        }

        /// <summary>
        /// Close the SOA context with error
        /// </summary>
        /// <param name="soaError"></param>
        public void Close(SOAError soaError)
        {
            //Close the context
            //SOALogger.LogError
            //SOATracker.Finish
        }
    }
}
