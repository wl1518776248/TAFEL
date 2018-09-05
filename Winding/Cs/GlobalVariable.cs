using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winding.Cs
{
    public class GlobalVariable
    {
        public static int dockPanelHeight;
        public static int dockPanelWidth;
        public static string codeStr;
        public static bool[] variable;
        public static string IPv4;
        public static string userName;
        public static string classes;
        public static string procedureNo;
        public static string workStationNo;
        public static string stateResult;
        public static string stateMessage;
        public static string productResult;
        public static string productMessage;
        public static bool productState;
        public static string[] mesOut = new string[10];
        public static string[] codeMesOut = new string[20];
        public static string codeLengthOne;
        public static string codeLengthTwo;
        public static string codeLengthThree;
        public static string equipmentType;
        public static string[] mesIn = new string[70];
        public static string workOrder;
        public static string[] materielBatch = new string[6];
        public static string[] materielCheckQuantity = new string[6];
        public static string[] batchNo = new string[7];
        public static string meterielStatus;
        public static bool mesInZero;
        public static bool mesInTen;
        public static bool scanState;
        public static bool scanToPlc;
        public static int firstCheckCount;
        public static int spotCheckCount;
        public static bool settingEnable;
        public static string netWorkState;
        public static bool PLCState;
        public static string processName;
        public static string mesState1 = string.Empty ;
        public static string mesState2 = string.Empty;
        public enum state
        {
            NG,
            OK
        }
    }
}
