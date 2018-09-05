using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winding.Cs
{
    public class VariableChangedEven
    {
        ~VariableChangedEven()
        { }
        Cs.InterfaceCheck interfaceCheck = new Cs.InterfaceCheck();
        Cs.XmlConverter xmlConverter = new XmlConverter();
        string lugResualt, lugResualt2, CCDResualt;
        string csvPath, csvName, csvTitle, csvValue;
        string csvPath1, csvName1, csvTitle1, csvValue1;
        string csvPath2, csvName2, csvTitle2, csvValue2;
        string csvPath3, csvName3, csvTitle3, csvValue3;
        string csvPath4, csvName4, csvTitle4, csvValue4;
        Cs.WriteToTxt writeToTxt = new WriteToTxt();
        string CCDTxtValue, tensionTxtValue, CCDPath, tensionPath, mesCCDPath, mesTensionPath,mesResultPath;
        string[] CCDValue = new string[500];
        string[] tensionValue = new string[1200];
        string[] mesKey = new string[] { "P001_MAX", "P001_MIN", "P002_MAX", "P002_MIN", "P003_MAX", "P003_MIN", "P004_MAX", "P004_MIN", "P005_MAX", "P005_MIN", "P006_MAX", "P006_MIN", "P007_MAX", "P007_MIN", "P008_MAX", "P008_MIN", "P009_MAX", "P009_MIN", "P010_MAX", "P010_MIN" };

        public void ClearMesOutFour()
        {
            // Cs.GlobalVariable.mesOut[4] = "0";
        }

        public void GMesInSeven()
        {
            Cs.Setting setting = new Setting();
            setting.MenuBar();
            csvPath = setting.Value(6) + DateTime.Now.ToString("yyyy-MM") + @"\";
            csvName = DateTime.Now.ToString("yyyyMMdd") + Cs.GlobalVariable.mesIn[56] + ".txt";
            csvTitle = string.Empty;
            csvValue = string.Empty;
            for (int i = 20; i < 30; i++)
            {
                csvValue += Cs.GlobalVariable.mesIn[i] + ",";
            }
            writeToTxt.WriteValueToTxt(csvPath, csvName, csvTitle, csvValue);
        }
        public void GMesInEight()
        {
            Cs.Setting setting = new Setting();
            setting.MenuBar();
            csvPath1 = setting.Value(7) + DateTime.Now.ToString("yyyy-MM") + @"\";
            csvName1 = DateTime.Now.ToString("yyyyMMdd") + Cs.GlobalVariable.mesIn[56] + ".txt";
            csvTitle1 = string.Empty;
            csvValue1 = string.Empty;
            for (int i = 1; i < 5; i++)
            {
                csvValue1 += Cs.GlobalVariable.mesIn[i] + ",";
            }
            for (int j = 6; j < 15; j++)
            {
                csvValue1 += Cs.GlobalVariable.mesIn[j] + ",";
            }
            writeToTxt.WriteValueToTxt(csvPath1, csvName1, csvTitle1, csvValue1);
        }

        public void MesInFive(string value)
        {
            Dictionary<string, object> productSate = new Dictionary<string, object>();
            string productValue = string.Empty;
            switch (value)
            {
                case "1":
                    productValue = "STANDBY";
                    break;
                case "2":
                    productValue = "RUN";
                    break;
                case "3":
                    productValue = "FAULT";
                    break;
                case "4":
                    productValue = "REPAIR";
                    break;
                case "5":
                    productValue = "MAINTAIN";
                    break;
                default:
                    break;
            }
            try
            {
                productSate.Add("MACHINE_IP", Cs.GlobalVariable.IPv4);
                productSate.Add("STATUS", productValue);
                productSate.Add("ERROR_DESC", productValue);
                productSate.Add("CREATE_USER", Cs.GlobalVariable.userName);
                Dictionary<string, object> proSate = interfaceCheck.CommonSaveMachineStatus(productSate);
                if (proSate["STATUS"].ToString() == "false")
                {
                    Cs.GlobalVariable.stateResult = proSate["STATUS"].ToString();
                    Cs.GlobalVariable.stateMessage = proSate["MESSAGE"].ToString();
                }
                else if (proSate["STATUS"].ToString() == "true")
                {
                    Cs.GlobalVariable.stateResult = proSate["STATUS"].ToString();
                }
                Cs.GlobalVariable.mesState1 = "1";
            }
            catch (Exception)
            {
                Cs.GlobalVariable.mesState1 = "2";
            }
        }

        public void ScanComplete()
        {
            Cs.Setting setting = new Setting();
            setting.MenuBar();
            if (Cs.GlobalVariable.codeStr.Substring(0, 1) == Cs.GlobalVariable.equipmentType && (Cs.GlobalVariable.codeStr.Length == Convert.ToInt32(Cs.GlobalVariable.codeLengthOne) || Cs.GlobalVariable.codeStr.Length == Convert.ToInt32(Cs.GlobalVariable.codeLengthTwo) || Cs.GlobalVariable.codeStr.Length == Convert.ToInt32(Cs.GlobalVariable.codeLengthThree)))
            {
                Cs.GlobalVariable.mesOut[1] = "1";
                Cs.GlobalVariable.scanState = false;
                Cs.GlobalVariable.scanToPlc = true;
                if (Cs.GlobalVariable.mesInTen)
                {
                    if (Cs.GlobalVariable.mesIn[53] == "1")
                    {
                        lugResualt = Cs.GlobalVariable.state.NG.ToString();
                    }
                    else
                    {
                        lugResualt = Cs.GlobalVariable.state.OK.ToString();
                    }
                    if (Cs.GlobalVariable.mesIn[54] == "1")
                    {
                        lugResualt2 = Cs.GlobalVariable.state.NG.ToString();
                    }
                    else
                    {
                        lugResualt2 = Cs.GlobalVariable.state.OK.ToString();
                    }
                    if (Cs.GlobalVariable.mesIn[55] == "1")
                    {
                        CCDResualt = Cs.GlobalVariable.state.NG.ToString();
                    }
                    else
                    {
                        CCDResualt = Cs.GlobalVariable.state.OK.ToString();
                    }
                    CheckResultData();
                    if (Cs.GlobalVariable.mesOut[5] == "1")
                    {
                        CCDProcessData(setting);
                        TensionProcessData(setting);
                        LocationResultData(setting);
                    }
                }
            }
            else
            {
                Cs.GlobalVariable.mesOut[1] = "2";
            }
        }
        private void CCDProcessData(Setting setting)
        {
            try
            {
                CCDPath = setting.Value(6) + DateTime.Now.ToString("yyyy-MM") + @"\" + DateTime.Now.ToString("yyyyMMdd") + Cs.GlobalVariable.mesIn[57] + ".txt";
                CCDTxtValue = writeToTxt.ReadTxt(CCDPath);
                CCDValue = CCDTxtValue.Split(',');
                csvPath2 = setting.Value(2) + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
                mesCCDPath = setting.Value(8) + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
                csvName2 = Cs.GlobalVariable.codeStr + ".csv";
                csvTitle2 = "蓝胶条码,虚拟码,生产时间,外侧隔膜到阳极,外侧隔膜到阴极,外侧阴极到阳极,外侧AT9到隔膜, 外侧AT9到阳极,外侧前阳到阴极,内侧隔膜到阳极,内侧隔膜到阴极,内侧阴极到阳极,内侧前阳到阴极\r\n";
                for (int i = 0; i < (int)((CCDValue.Length - 1) / 10); i++)
                {
                    csvValue2 = String.Empty;
                    csvValue2 = Cs.GlobalVariable.codeStr + "," + Cs.GlobalVariable.mesIn[57] + "," + DateTime.Now.ToString("HH:mm:ss") + ",";
                    for (int j = 0; j < 10; j++)
                    {
                        csvValue2 += CCDValue[j + 10 * i] + ",";
                    }
                    csvValue2 += "\r\n";
                    writeToTxt.WriteValueToTxt(csvPath2, csvName2, csvTitle2, csvValue2);                    
                    //writeToTxt.WriteValueToTxt(mesCCDPath, csvName2, csvTitle2, csvValue2);
                }
                writeToTxt.CopyFile(csvPath2 + csvName2, mesCCDPath + csvName2);
                File.Delete(CCDPath);
            }
            catch (Exception)
            {
            }
        }

        private void TensionProcessData(Setting setting)
        {
            try
            {
                tensionPath = setting.Value(7) + DateTime.Now.ToString("yyyy-MM") + @"\" + DateTime.Now.ToString("yyyyMMdd") + Cs.GlobalVariable.mesIn[57] + ".txt";
                tensionTxtValue = writeToTxt.ReadTxt(tensionPath);
                tensionValue = tensionTxtValue.Split(',');
                csvPath3 = setting.Value(4) + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
                mesTensionPath = setting.Value(9) + DateTime.Now.ToString("yyyy-MM-dd") + @"\";
                csvName3 = Cs.GlobalVariable.codeStr + ".csv";
                csvTitle3 = "蓝胶条码,虚拟码,生产时间,阴极张力,阳极张力,上隔膜张力,下隔膜张力, 阴极蛇形1纠偏,阴极放卷纠偏,阴极蛇形2纠偏,阴极入卷纠偏,阳极放卷纠偏,阳极蛇形纠偏,阳极入卷纠偏,上隔膜放卷纠偏,下隔膜放卷纠偏\r\n";
                for (int i = 0; i < (int)((tensionValue.Length - 1)) / 13; i++)
                {
                    csvValue3 = String.Empty;
                    csvValue3 = Cs.GlobalVariable.codeStr + "," + Cs.GlobalVariable.mesIn[57] + "," + DateTime.Now.ToString("HH:mm:ss") + ",";
                    for (int j = 0; j < 13; j++)
                    {
                        csvValue3 += tensionValue[j + 13 * i] + ",";
                    }
                    csvValue3 += "\r\n";
                    writeToTxt.WriteValueToTxt(csvPath3, csvName3, csvTitle3, csvValue3);
                    //writeToTxt.WriteValueToTxt(mesTensionPath, csvName3, csvTitle3, csvValue3);
                }
                writeToTxt.CopyFile(csvPath3 + csvName3, mesTensionPath + csvName3);
                File.Delete(tensionPath);
            }
            catch (Exception)
            {
            }
        }

        private void singleToText(string path, Dictionary<string, object> value)
        {
            Cs.GlobalVariable.productState = true;
            //Cs.WriteToTxt writeToTxt = new Cs.WriteToTxt();
            string str1 = path + DateTime.Now.ToString("yyyy-MM-dd");
            string str2 = str1 + @"\" + Cs.GlobalVariable.codeStr + ".txt";
            string cData = xmlConverter.DictionaryToXml(value);
            writeToTxt.WriteValueToTxt(str1, str2, string.Empty, cData);
        }

        private void CheckResultData()
        {
            Dictionary<string, object> productResualt = new Dictionary<string, object>();
            try
            {
                productResualt.Add("SITE", "NJTAFEL");
                productResualt.Add("SFC_NO", Cs.GlobalVariable.codeStr);
                productResualt.Add("SHOP_ORDER", Cs.GlobalVariable.workOrder);
                productResualt.Add("IP", Cs.GlobalVariable.IPv4);
                productResualt.Add("STATION_CODE", Cs.GlobalVariable.workStationNo);
                productResualt.Add("OPERATION_NO", Cs.GlobalVariable.procedureNo);
                for (int j = 1; j < 7; j++)
                {
                    productResualt.Add("MATERIAL" + j.ToString(), Cs.GlobalVariable.materielBatch[j - 1]);
                }
                productResualt.Add("WINDING_RATE", Cs.GlobalVariable.mesIn[30]);
                productResualt.Add("PREPARE_PRESS_PRESSURE", Cs.GlobalVariable.mesIn[31]);
                productResualt.Add("PREPARE_PRESS_TIME", Cs.GlobalVariable.mesIn[32]);
                productResualt.Add("Z_POLE_TENTION", Cs.GlobalVariable.mesIn[15]);
                productResualt.Add("F_POLE_TENTION", Cs.GlobalVariable.mesIn[16]);
                productResualt.Add("TOP_DIAPHRAGM_TENTION", Cs.GlobalVariable.mesIn[17]);
                productResualt.Add("BOTTOM_DIAPHRAGM_TENTION", Cs.GlobalVariable.mesIn[18]);
                for (int i = 0; i < 20; i++)
                {
                    productResualt.Add(mesKey[i], Cs.GlobalVariable.mesIn[i + 33]);
                }
                productResualt.Add("CLASS_NO", Cs.GlobalVariable.classes);
                productResualt.Add("CREATE_USER", Cs.GlobalVariable.userName);
                productResualt.Add("DC_TIME", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                productResualt.Add("RESULT1", lugResualt);
                productResualt.Add("RESULT2", lugResualt2);
                productResualt.Add("RESULT3", CCDResualt);
                if (Cs.GlobalVariable.netWorkState == "netWork")
                {
                    Dictionary<string, object> proSate = interfaceCheck.WindingSaveNew(productResualt);
                    if (proSate["STATUS"].ToString() == "false")
                    {
                        Cs.GlobalVariable.productResult = proSate["STATUS"].ToString();
                        Cs.GlobalVariable.productMessage = proSate["MESSAGE"].ToString();
                        Cs.GlobalVariable.mesOut[0] = "2";
                    }
                    else if (proSate["STATUS"].ToString() == "true")
                    {
                        Cs.GlobalVariable.productResult = proSate["STATUS"].ToString();
                        Cs.GlobalVariable.productMessage = string.Empty;
                        Cs.GlobalVariable.mesOut[0] = "1";
                    }
                    Cs.GlobalVariable.mesOut[5] = "1";
                    Cs.GlobalVariable.mesState2 = "1";
                    Cs.GlobalVariable.productState = true;
                }
                else
                {
                    Cs.GlobalVariable.productMessage = "采用离线模式开机生产";
                    Cs.GlobalVariable.productState = true;
                    Cs.GlobalVariable.mesOut[0] = "1";
                    Cs.GlobalVariable.mesOut[5] = "1";
                }
            }
            catch (Exception)
            {
                Cs.GlobalVariable.mesState2 = "2";
                Cs.GlobalVariable.mesOut[0] = "0";
                Cs.GlobalVariable.mesOut[5] = "2";
            }
        }

        private void LocationResultData(Setting setting)
        {
            try
            {
                csvPath4 = setting.Value(3) + DateTime.Now.ToString("yyyy-MM") + @"\";
                mesResultPath= setting.Value(5) + DateTime.Now.ToString("yyyy-MM") + @"\";
                csvName4 = DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                writeToTxt.CloseFile (csvName4);
                csvTitle4 = "站点,IPV4,工站,工序,工单,Tray条码,生产时间,物料1,物料2,物料3,物料4,上隔膜小批次,下隔膜小批次,卷绕速度,预压压力,预压时间,阳极张力,阴极张力,上隔膜张力,下隔膜张力,外侧隔膜到阳极MAX,外侧隔膜到阳极MIN,外侧隔膜到阴极MAX,外侧隔膜到阴极MIN,外侧阴极到阳极MAX,外侧阴极到阳极MIN,外侧AT9到隔膜MAX,外侧AT9到隔膜MIN,外侧AT9到阳极MAX,外侧AT9到阳极MIN,外侧前阳到阴极MAX,外侧前阳到阴极MIN,内侧隔膜到阳极MAX,内侧隔膜到阳极MIN,内侧隔膜到阴极MAX,内侧隔膜到阴极MIN,内侧阴极到阳极MAX,内侧阴极到阳极MIN,内侧前阳到阴极MAX,内侧前阳到阴极MIN,极耳打折结果,极耳翻折结果,CCD结果,操作员,班次,备注(MES结果)\r\n";
                csvValue4 = string.Empty;
                csvValue4 = "NJTAFEL" + "," + Cs.GlobalVariable.IPv4 + "," + Cs.GlobalVariable.workStationNo + "," + Cs.GlobalVariable.procedureNo + "," + Cs.GlobalVariable.workOrder + "," + Cs.GlobalVariable.codeStr + "," + DateTime.Now.ToString("HH:mm:ss") + ",";
                for (int l = 0; l < 6; l++)
                {
                    csvValue4 += Cs.GlobalVariable.materielBatch[l] + ",";
                }
                for (int i = 30; i < 33; i++)
                {
                    csvValue4 += Cs.GlobalVariable.mesIn[i] + ",";
                }
                for (int k = 15; k < 19; k++)
                {
                    csvValue4 += Cs.GlobalVariable.mesIn[k] + ",";
                }
                for (int j = 33; j < 53; j++)
                {
                    csvValue4 += Cs.GlobalVariable.mesIn[j] + ",";
                }
                csvValue4 += lugResualt + "," + lugResualt2 + "," + CCDResualt + "," + Cs.GlobalVariable.userName + "," + Cs.GlobalVariable.classes + "," + Cs.GlobalVariable.productMessage + "\r\n";
                writeToTxt.WriteValueToTxt(csvPath4, csvName4, csvTitle4, csvValue4);
                if (Cs.GlobalVariable.netWorkState == "single")
                { 
                    writeToTxt.CopyFile(csvPath4 + csvName4, mesResultPath + csvName4);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
