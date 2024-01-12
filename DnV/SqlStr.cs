using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnV
{
    public class SqlStr
    {
        public static string GetHistory => "dnv.prcGetHistory";
        public static string GetRoom => "dnv.prcGetRoom";
        public static string GetEvent => "dnv.prcGetEvent";
        public static string GetNPC => "dnv.prcGetNPC";
        public static string GetHero => "dnv.prcGetHero";
        public static string GetBattlePerson => "dnv.prcGetBattlePerson";
        public static string GetStatus => "dnv.prcGetStatus";
        public static string GetNPCEditor => "dnv.prcGetNPCEditor";
        public static string GetNPCComboBox => "dnv.prcGetNPCComboBox";



        public static string SetHistory => "dnv.prcSetHistory";
        public static string SetHistorySave => "dnv.prcSetHistorySave";
        public static string SetRoomSaveEdit => "dnv.prcSetRoomSaveEdit";
        public static string SetEventSaveEdit => "dnv.prcSetEventSaveEdit";
        public static string SetPerson => "dnv.prcSetPerson";
        public static string SetNPCInRoom => "dnv.prcSetNPCInRoom";

    }
}
