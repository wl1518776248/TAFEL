using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winding.Cs
{
    public class Setting
    {
        ~Setting()
        { }
        Dictionary<int, string> dic = new Dictionary<int  , string>();
        public void MenuBar()
        {
            dic.Add(1, @"F:\LEADUpperComputer\Setting\Setting.xml");
            dic.Add(2, @"F:\LEADUpperComputer\CCDData\");
            dic.Add(3, @"F:\LEADUpperComputer\ResualtData\");
            dic.Add(4, @"F:\LEADUpperComputer\TensionData\");
            dic.Add(5, @"F:\LEADUpperComputer\MesResualtData\");
            dic.Add(6, @"F:\LEADUpperComputer\CCDTemp\");
            dic.Add(7, @"F:\LEADUpperComputer\TensionTemp\");
            dic.Add(8, @"F:\LEADUpperComputer\MesCCDData\");
            dic.Add(9, @"F:\LEADUpperComputer\MesTensionData\");
            dic.Add(101, "equipmentEncoding"); dic.Add(102, "equipmentName"); dic.Add(103, "equipmentIPv4"); dic.Add(104, "PLCIPv4");
            dic.Add(105, "MesPort"); dic.Add(106, "ConfigPort"); dic.Add(107, "DataPort"); dic.Add(108, "PLCIPv4"); dic.Add(109, "equipmentType");
            dic.Add(110, "MainWindowsTitle");
            dic.Add(201, "WorkOrder1"); dic.Add(202, "MaterielBatch1"); dic.Add(203, "materielCheckQuantity1"); dic.Add(204, "materielCheckUserName1"); dic.Add(205, "materielCheckDate1"); dic.Add(206, "batchNo1");
            dic.Add(211, "WorkOrder2"); dic.Add(212, "MaterielBatch2"); dic.Add(213, "materielCheckQuantity2"); dic.Add(214, "materielCheckUserName2"); dic.Add(215, "materielCheckDate2"); dic.Add(216, "batchNo2");
            dic.Add(221, "WorkOrder3"); dic.Add(222, "MaterielBatch3"); dic.Add(223, "materielCheckQuantity3"); dic.Add(224, "materielCheckUserName3"); dic.Add(225, "materielCheckDate3"); dic.Add(226, "batchNo3");
            dic.Add(231, "WorkOrder4"); dic.Add(232, "MaterielBatch4"); dic.Add(233, "materielCheckQuantity4"); dic.Add(234, "materielCheckUserName4"); dic.Add(235, "materielCheckDate4"); dic.Add(236, "batchNo4");
            dic.Add(241, "WorkOrder5"); dic.Add(242, "MaterielBatch5"); dic.Add(243, "materielCheckQuantity5"); dic.Add(244, "materielCheckUserName5"); dic.Add(245, "materielCheckDate5"); dic.Add(246, "batchNo5");
            dic.Add(251, "WorkOrder6"); dic.Add(252, "MaterielBatch6"); dic.Add(253, "materielCheckQuantity6"); dic.Add(254, "materielCheckUserName6"); dic.Add(255, "materielCheckDate6"); dic.Add(256, "batchNo6");
            dic.Add(401, "codeLengthOne"); dic.Add(402, "codeLengthTwo"); dic.Add(403, "codeLengthThree");
            dic.Add(501, "passWord");dic.Add(502, "shortMold");
        }

        public string Value(int key)
        {
            return dic[key];
        }
    }
}
