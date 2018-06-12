using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVSLibrary
{
    public class ScheduleResponseModel
    {
        /// <summary>
        /// Represents the name of the model
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents a list of all the date/time value of when this model data was prepared (format: yyyyMMddHHmmss)
        /// </summary>
        public List<TimeStampModel> TimeStamps { get; set; } = new List<TimeStampModel>();
        /// <summary>
        /// Represents a list of all commands and their value for this plant
        /// </summary>
        public List<CommandEventModel> CommandEvents { get; set; } = new List<CommandEventModel>();
    }
}
