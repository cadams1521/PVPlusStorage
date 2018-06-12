namespace PVSLibrary
{
    public class CommandEvent
    {
        /// <summary>
        /// Order of the events. Does not have to correspond to order of execution
        /// </summary>
        public int EventID { get; set; }
        /// <summary>
        /// Enable this time entry
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Control function to be executed (1=Energy Shifting, 2=Real-Time)
        /// </summary>
        public int PVSFn { get; set; }
        /// <summary>
        /// Schedule start time hour
        /// </summary>
        public int StartHour { get; set; }
        /// <summary>
        /// Schedule start time hour
        /// </summary>
        public int StartMin { get; set; }
        /// <summary>
        /// Active power setpoint at POI
        /// </summary>
        public decimal PpoiMW { get; set; }
        /// <summary>
        /// (1=Voltage Control, 2=PF Control, 3=Reactive Power Control)
        /// </summary>
        public int AVRMode { get; set; }
        /// <summary>
        /// Reactive power setpoint at POI
        /// </summary>
        public decimal QpoiMvar { get; set; }
        /// <summary>
        /// Power factor setpoint at POI
        /// </summary>
        public decimal PFTrgt { get; set; }
        /// <summary>
        /// Voltage setpoint
        /// </summary>
        public decimal VTrgtkV { get; set; }
        /// <summary>
        /// Ramp rate for RR mode
        /// </summary>
        public decimal RmpRateMWmin { get; set; }
        /// <summary>
        /// PVS active power reference PV+BESS
        /// </summary>
        public decimal PpvsMW { get; set; }
        /// <summary>
        /// BESS charging active power reference
        /// </summary>
        public decimal PcMW { get; set; }
        /// <summary>
        /// BESS Charging priority
        /// </summary>
        public decimal ChgPr { get; set; }
        /// <summary>
        /// BESS discharging active power reference
        /// </summary>
        public bool PdMW { get; set; }
        /// <summary>
        /// Maximum SOC lImit
        /// </summary>
        public decimal SOCMaxPct { get; set; }
        /// <summary>
        /// Minimum SOC lImit
        /// </summary>
        public decimal SOCMinPct { get; set; }
        /// <summary>
        /// Grid charging allowed
        /// </summary>
        public bool GCen { get; set; }
    }
}
