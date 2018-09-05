using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winding.Cs
{
   public class InterfaceCheck
    {
        ~InterfaceCheck()
        { }
        WebReference.TafelWebService connectMes = new WebReference.TafelWebService();
        Cs.XmlConverter xmlConverter = new Cs.XmlConverter();
        public Dictionary<string,object>  MachineLogin(Dictionary<string,object > dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.machineLogin(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }
        public Dictionary<string, object> CommonSaveMachineStatus(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.commonSaveMachineStatus(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }
        public Dictionary<string, object> WindingSaveNew(string str)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.commonSaveMachineStatus(str));
            return returnMes;
        }
        public Dictionary<string, object> WindingSaveNew(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.WindingSaveNew(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }
        public Dictionary<string, object> LoadMaterial(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.loadMaterial(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }
        public Dictionary<string, object> UnLoadMaterial(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.unLoadMaterial(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }

        public Dictionary<string,object> loadFirstCheckItem(Dictionary<string,object >dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.loadFirstCheckItem(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }

        public Dictionary<string, object> firstCheck(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.firstCheck(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }

        public Dictionary<string, object> loadSpotCheckItem(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.loadSpotCheckItem(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }

        public Dictionary<string, object> spotCheck(Dictionary<string, object> dic)
        {
            Dictionary<string, object> returnMes = xmlConverter.XmlToDictionary(connectMes.spotCheck(xmlConverter.DictionaryToXml(dic)));
            return returnMes;
        }
    }
}
