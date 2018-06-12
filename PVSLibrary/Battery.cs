namespace PVSLibrary
{
    public class Battery
    {
        /// <summary>
        /// Represents the unique id value of the battery
        /// </summary>
        public string BatteryID { get; set; }
        /// <summary>
        /// Represents the state of charge value in megawatt hour
        /// </summary>
        public decimal SOCMwH { get; set; }
        /// <summary>
        /// Represents the state of charge value in percentage
        /// </summary>
        public int SOCPer { get; set; }
        /// <summary>
        /// Represents the state of health value in percentage
        /// </summary>
        public int SOHPer { get; set; }
    }
}
