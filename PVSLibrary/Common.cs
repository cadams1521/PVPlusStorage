using System;
using System.Collections.Generic;

namespace PVSLibrary
{
    public static class Common
    {
        public static ScheduleRequest SampleScheduleRequestCL()
        {
            var jsonObject = new ScheduleRequest();
            jsonObject.Name = "ScheduleRequestCL";
            List<TimeStamp> timeStamps = SampleTimeStamp("CL");
            jsonObject.TimeStamps = timeStamps;
            List<Battery> batteries = SampleBattery();
            jsonObject.Batteries = batteries;
            return jsonObject;
        }

        public static ScheduleRequest SampleScheduleRequestLM()
        {
            var jsonObject = new ScheduleRequest();
            jsonObject.Name = "ScheduleRequestLM";
            List<TimeStamp> timeStamps = SampleTimeStamp("LM");
            jsonObject.TimeStamps = timeStamps;
            List<Battery> batteries = SampleBattery();
            jsonObject.Batteries = batteries;
            return jsonObject;
        }

        public static ScheduleResponse SampleScheduleResponseLC()
        {
            var jsonObject = new ScheduleResponse();
            jsonObject.Name = "ScheduleResponseLC";
            List<TimeStamp> timeStamps = SampleTimeStamp("LC");
            jsonObject.TimeStamps = timeStamps;
            List<CommandEvent> commandEvent = SampleCommandEvent();
            jsonObject.CommandEvents = commandEvent;
            return jsonObject;
        }

        public static ScheduleResponse SampleScheduleResponseML()
        {
            var jsonObject = new ScheduleResponse();
            jsonObject.Name = "ScheduleResponseML";
            List<TimeStamp> timeStamps = SampleTimeStamp("ML");
            jsonObject.TimeStamps = timeStamps;
            List<CommandEvent> commandEvent = SampleCommandEvent();
            jsonObject.CommandEvents = commandEvent;
            return jsonObject;
        }

        static List<Battery> SampleBattery()
        {
            List<Battery> batteries = new List<Battery>();
            batteries.Add(new Battery { BatteryID = "A1", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "A2", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "B7", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "M10", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "P1", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "L17", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "T2", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            batteries.Add(new Battery() { BatteryID = "A28", SOCMwH = 68.123m, SOCPer = 97, SOHPer = 100 });
            return batteries;
        }

        static List<CommandEvent> SampleCommandEvent()
        {
            List<CommandEvent> commandEvent = new List<CommandEvent>();
            for (int i = 0; i <= 23; i++)
            {
                commandEvent.Add(new CommandEvent()
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
            return commandEvent;
        }

        static List<TimeStamp> SampleTimeStamp(string strModel)
        {
            List<TimeStamp> timeStamps = new List<TimeStamp>();
            switch (strModel)
            {
                case "CL":
                    timeStamps.Add(new TimeStamp { Source = "CL", Timestamp = SetTimestamp(0) });
                    break;
                case "LM":
                    timeStamps.Add(new TimeStamp { Source = "CL", Timestamp = SetTimestamp(-15) });
                    timeStamps.Add(new TimeStamp { Source = "LM", Timestamp = SetTimestamp(0) });
                    break;
                case "ML":
                    timeStamps.Add(new TimeStamp { Source = "CL", Timestamp = SetTimestamp(-30) });
                    timeStamps.Add(new TimeStamp { Source = "LM", Timestamp = SetTimestamp(-15) });
                    timeStamps.Add(new TimeStamp { Source = "ML", Timestamp = SetTimestamp(0) });
                    break;
                case "LC":
                    timeStamps.Add(new TimeStamp { Source = "CL", Timestamp = SetTimestamp(-45) });
                    timeStamps.Add(new TimeStamp { Source = "LM", Timestamp = SetTimestamp(-30) });
                    timeStamps.Add(new TimeStamp { Source = "ML", Timestamp = SetTimestamp(-15) });
                    timeStamps.Add(new TimeStamp { Source = "LC", Timestamp = SetTimestamp(0) });
                    break;
            }
            return timeStamps;
        }

        public static string SetTimestamp(short offsetSeconds)
        {
            DateTime currentTime = DateTime.Now;
            DateTime time = currentTime + new TimeSpan(0, 0, offsetSeconds);
            return time.ToString("yyyyMMddHHmmss");
        }
    }
}
