using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVSLibrary
{
    public class TimeStampModel
    {
        /// <summary>
        /// Represent the system that created this timestamp
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Represents the Timestamp for this entry (format: "yyyyMMddHHmmss")
        /// </summary>
        public string Timestamp { get; set; }
    }
}
