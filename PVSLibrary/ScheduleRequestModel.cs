using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVSLibrary
{
    public class ScheduleRequestModel
    {
        /// <summary>
        /// Represents the name of the model
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents the date/time value of when this model data was prepared (format: yyyyMMddHHmmss)
        /// </summary>
        public List<TimeStampModel> TimeStamps { get; set; }
        /// <summary>
        /// Represents a list of all batteries and their conditions for this plant
        /// </summary>
        public List<BatteryModel> Batteries { get; set; }
    }
}
