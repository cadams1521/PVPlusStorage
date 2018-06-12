using System;
using System.Collections.Generic;

namespace PVSLibrary
{
    public static class Common
    {
        public static ScheduleRequestModel SampleScheduleRequestCL()
        {
            var jsonObject = new ScheduleRequestModel();
            jsonObject.Name = "ScheduleRequestCL";
            List<TimeStampModel> timestamps = SampleTimeStampModel("CL");
            jsonObject.TimeStamps = timestamps;
            List<BatteryModel> batteries = SampleBatteryModel();
            jsonObject.Batteries = batteries;
            return jsonObject;
        }

        public static ScheduleRequestModel SampleScheduleRequestLM()
        {
            var jsonObject = new ScheduleRequestModel();
            jsonObject.Name = "ScheduleRequestLM";
            List<TimeStampModel> timestamps = SampleTimeStampModel("LM");
            jsonObject.TimeStamps = timestamps;
            List<BatteryModel> batteries = SampleBatteryModel();
            jsonObject.Batteries = batteries;
            return jsonObject;
        }

        public static ScheduleResponseModel SampleScheduleResponseLC()
        {
            var jsonObject = new ScheduleResponseModel();
            jsonObject.Name = "ScheduleResponseLC";
            List<TimeStampModel> timestamps = SampleTimeStampModel("LC");
            jsonObject.TimeStamps = timestamps;
            List<CommandEventModel> commandevent = SampleCommandEventModel();
            jsonObject.CommandEvents = commandevent;
            return jsonObject;
        }

        public static ScheduleResponseModel SampleScheduleResponseML()
        {
            var jsonObject = new ScheduleResponseModel();
            jsonObject.Name = "ScheduleResponseML";
            List<TimeStampModel> timestamps = SampleTimeStampModel("ML");
            jsonObject.TimeStamps = timestamps;
            List<CommandEventModel> commandevent = SampleCommandEventModel();
            jsonObject.CommandEvents = commandevent;
            return jsonObject;
        }

        static List<BatteryModel> SampleBatteryModel()
        {
            List<BatteryModel> batteries = new List<BatteryModel>();
            batteries.Add(new BatteryModel { BatteryID = "A1", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "A2", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "B7", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "M10", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "P1", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "L17", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "T2", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new BatteryModel() { BatteryID = "A28", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            return batteries;
        }

        static List<CommandEventModel> SampleCommandEventModel()
        {
            List<CommandEventModel> commandevent = new List<CommandEventModel>();
            for (int i = 0; i <= 23; i++)
            {
                commandevent.Add(new CommandEventModel()
                {
                    EventID = i + 1,
                    Enable = true,
                    PVSFn = 1,
                    StartHour = i,
                    StartMin = 10,
                    PpoiMW = 20,
                    AVRMode = 1,
                    QpoiMvar = 10,
                    PFTrgt = .99m,
                    VTrgtkV = 36.5m,
                    RmpRateMWmin = 10,
                    PpvsMW = 20,
                    PcMW = 10,
                    ChgPr = 1,
                    PdMW = false,
                    SOCMaxPct = 98.1m,
                    SOCMinPct = 5.25m,
                    GCen = false
                });
            }
            return commandevent;
        }

        static List<TimeStampModel> SampleTimeStampModel(string strModel)
        {
            List<TimeStampModel> timestamps = new List<TimeStampModel>();
            switch (strModel)
            {
                case "CL":
                    timestamps.Add(new TimeStampModel { Source = "CL", Timestamp = SetTimestamp(0) });
                    break;
                case "LM":
                    timestamps.Add(new TimeStampModel { Source = "CL", Timestamp = SetTimestamp(-15) });
                    timestamps.Add(new TimeStampModel { Source = "LM", Timestamp = SetTimestamp(0) });
                    break;
                case "ML":
                    timestamps.Add(new TimeStampModel { Source = "CL", Timestamp = SetTimestamp(-30) });
                    timestamps.Add(new TimeStampModel { Source = "LM", Timestamp = SetTimestamp(-15) });
                    timestamps.Add(new TimeStampModel { Source = "ML", Timestamp = SetTimestamp(0) });
                    break;
                case "LC":
                    timestamps.Add(new TimeStampModel { Source = "CL", Timestamp = SetTimestamp(-45) });
                    timestamps.Add(new TimeStampModel { Source = "LM", Timestamp = SetTimestamp(-30) });
                    timestamps.Add(new TimeStampModel { Source = "ML", Timestamp = SetTimestamp(-15) });
                    timestamps.Add(new TimeStampModel { Source = "LC", Timestamp = SetTimestamp(0) });
                    break;
            }
            return timestamps;
        }

        public static string SetTimestamp(short offsetSec)
        {
            DateTime temp = DateTime.Now;
            DateTime time = temp + new TimeSpan(0, 0, offsetSec);
            return time.ToString("yyyyMMddHHmmss");
        }
    }
}
