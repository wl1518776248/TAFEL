using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsUI.Docking;

namespace Winding.Cs
{
    public class Tree
    {
        ~Tree()
        { }
        Dictionary<int, string> dic = new Dictionary<int, string>();
        public void TreeView()
        {
            dic.Add(101, "设备设置"); dic.Add(102, "IPv4地址"); dic.Add(103, "接口管理"); dic.Add(104, "EXCEL设置"); dic.Add(105, "密码修改");
            dic.Add(106, "系统登录");
            dic.Add(201, "车间维护"); dic.Add(202, "部门维护"); dic.Add(203, "班组维护"); dic.Add(204, "班次维护"); dic.Add(205, "人员维护");
            dic.Add(206, "物料维护"); dic.Add(207, "工艺参数维护"); dic.Add(208, "设备工位维护"); dic.Add(209, "工序维护"); dic.Add(210, "易损件维护");
            dic.Add(211, "易损件更换记录"); dic.Add(212, "设备点检项目维护"); dic.Add(213, "设备点检计划维护"); dic.Add(214, "原料在库统计");
            dic.Add(301, "配方名称"); dic.Add(302, "配方结构"); dic.Add(303, "工艺参数"); dic.Add(304, "工艺标准");
            dic.Add(401, "工单管理"); dic.Add(402, "生产监控"); dic.Add(403, "生产报表"); dic.Add(404, "条码防误"); dic.Add(405, "原料消耗/统计");
            dic.Add(406, "班组产量统计"); dic.Add(407, "离线数据统计"); dic.Add(408, "物料首检"); dic.Add(409, "物料校验"); dic.Add(410, "手动条码");
            dic.Add(411, "文件关闭");
            dic.Add(501, "设备静态参数"); dic.Add(502, "报警信息"); dic.Add(503, "维修信息"); dic.Add(504, "点检信息"); dic.Add(505, "OEE分析");
            dic.Add(506, "设备稼动率");
            dic.Add(601, "质量明细"); dic.Add(602, "班组合格率统计"); dic.Add(603, "SPC分析"); dic.Add(604, "CPK分析"); dic.Add(605, "异常信息统计分析");
            dic.Add(606, "设备停机报表");
        }

        public string Value(int key)
        {
            return dic[key];
        }

        public DockContent TreeOpen(string frmName)
        {
            DockContent form = new DockContent();
            switch (frmName)
            {
                case "设备设置":
                    Sys.EquipmentNumber frm101 = new Sys.EquipmentNumber();
                    form = frm101;
                    break;
                case "IPv4地址":
                    Sys.IPv4Address frm102 = new Sys.IPv4Address();
                    form = frm102;
                    break;
                case "接口管理":
                    Sys.PortManage frm103 = new Sys.PortManage();
                    form = frm103;
                    break;
                case "EXCEL设置":
                    Sys.SingleNetwork frm104 = new Sys.SingleNetwork();
                    form = frm104;
                    break;
                case "密码修改":
                    ChangePassword frm105 = new ChangePassword();
                    form = frm105;
                    break;
                case "系统登录":
                    Sys.frmInLogin frm106 = new Sys.frmInLogin();
                    form = frm106;
                    break;
                case "车间维护":
                    Bas.Workshop frm201 = new Bas.Workshop();
                    form = frm201;
                    break;
                case "部门维护":
                    Bas.Department frm202 = new Bas.Department();
                    form = frm202;
                    break;
                case "班组维护":
                    Bas.TeamGroup frm203 = new Bas.TeamGroup();
                    form = frm203;
                    break;
                case "班次维护":
                    Bas.Classes frm204 = new Bas.Classes();
                    form = frm204;
                    break;
                case "人员维护":
                    Bas.Personnel frm205 = new Bas.Personnel();
                    form = frm205;
                    break;
                case "物料维护":
                    Bas.Material frm206 = new Bas.Material();
                    form = frm206;
                    break;
                case "工艺参数维护":
                    Bas.Parameter frm207 = new Bas.Parameter();
                    form = frm207;
                    break;
                case "设备工位维护":
                    Bas.Equipment frm208 = new Bas.Equipment();
                    form = frm208;
                    break;
                case "工序维护":
                    Bas.Process frm209 = new Bas.Process();
                    form = frm209;
                    break;
                case "易损件维护":
                    Bas.VulnerablePart frm210 = new Bas.VulnerablePart();
                    form = frm210;
                    break;
                case "易损件更换记录":
                    Bas.ReplaceRecord frm211 = new Bas.ReplaceRecord();
                    form = frm211;
                    break;
                case "设备点检项目维护":
                    Bas.CheckProject frm212 = new Bas.CheckProject();
                    form = frm212;
                    break;
                case "设备点检计划维护":
                    Bas.CheckPlan frm213 = new Bas.CheckPlan();
                    form = frm213;
                    break;
                case "原料在库统计":
                    Bas.MaterialsWarehouse frm214 = new Bas.MaterialsWarehouse();
                    form = frm214;
                    break;
                case "配方名称":
                    Rec.RecipeName frm301 = new Rec.RecipeName();
                    form = frm301;
                    break;
                case "配方结构":
                    Rec.RecipeStructure frm302 = new Rec.RecipeStructure();
                    form = frm302;
                    break;
                case "工艺参数":
                    Rec.TechnologicalParameter frm303 = new Rec.TechnologicalParameter();
                    form = frm303;
                    break;
                case "工艺标准":
                    Rec.TechnologicalStandard frm304 = new Rec.TechnologicalStandard();
                    form = frm304;
                    break;
                case "工单管理":
                    Pro.WorksheetManagement frm401 = new Pro.WorksheetManagement();
                    form = frm401;
                    break;
                case "生产监控":
                    Pro.ProductionMonitoring frm402 = new Pro.ProductionMonitoring();
                    form = frm402;
                    break;
                case "生产报表":
                    Pro.ProductionReport frm403 = new Pro.ProductionReport();
                    form = frm403;
                    break;
                case "条码防误":
                    Pro.CodeProtected frm404 = new Pro.CodeProtected();
                    form = frm404;
                    break;
                case "原料消耗/统计":
                    Pro.MaterialConsumption frm405 = new Pro.MaterialConsumption();
                    form = frm405;
                    break;
                case "班组产量统计":
                    Pro.ShiftProduction frm406 = new Pro.ShiftProduction();
                    form = frm406;
                    break;
                case "离线数据统计":
                    Pro.OffLineData frm407 = new Pro.OffLineData();
                    form = frm407;
                    break;
                case "物料首检":
                    Pro.FirstArticleInspection frm408 = new Pro.FirstArticleInspection();
                    form = frm408;
                    break;
                case "物料校验":
                    Pro.MaterielCheck frm409 = new Pro.MaterielCheck();
                    form = frm409;
                    break;
                case "手动条码":
                    Pro.ArtificialCode frm410 = new Pro.ArtificialCode();
                    form = frm410;
                    break;
                case "文件关闭":
                    Pro.LocalFileClosed  frm411 = new Pro.LocalFileClosed();
                    form = frm411;
                    break;
                case "设备静态参数":
                    Equ.StaticParameter frm501 = new Equ.StaticParameter();
                    form = frm501;
                    break;
                case "报警信息":
                    Equ.AlarmMessage frm502 = new Equ.AlarmMessage();
                    form = frm502;
                    break;
                case "维修信息":
                    Equ.MaintainMessage frm503 = new Equ.MaintainMessage();
                    form = frm503;
                    break;
                case "点检信息":
                    Equ.PointInspection frm504 = new Equ.PointInspection();
                    form = frm504;
                    break;
                case "OEE分析":
                    Equ.OEEAnalyze frm505 = new Equ.OEEAnalyze();
                    form = frm505;
                    break;
                case "设备稼动率":
                    Equ.EquipmentActivation frm506 = new Equ.EquipmentActivation();
                    form = frm506;
                    break;
                case "质量明细":
                    Rep.QualityDetails frm601 = new Rep.QualityDetails();
                    form = frm601;
                    break;
                case "班组合格率统计":
                    Rep.PercentPass frm602 = new Rep.PercentPass();
                    form = frm602;
                    break;
                case "SPC分析":
                    Rep.SPCAnalyze frm603 = new Rep.SPCAnalyze();
                    form = frm603;
                    break;
                case "CPK分析":
                    Rep.CPKAnalyze frm604 = new Rep.CPKAnalyze();
                    form = frm604;
                    break;
                case "异常信息统计分析":
                    Rep.AbnormalMessage frm605 = new Rep.AbnormalMessage();
                    form = frm605;
                    break;
                case "设备停机报表":
                    Rep.EquipmentHalt frm606 = new Rep.EquipmentHalt();
                    form = frm606;
                    break;
                default:
                    break;
            }
            return form;
        }
    }
}
