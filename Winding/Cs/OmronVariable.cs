using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMRON.Compolet.Variable;
using OMRON.Compolet.CIP;

namespace Winding.Cs
{
    public class OmronVariable
    {
        ~OmronVariable()
        { }
        VariableCompolet variableCompolet = new VariableCompolet();
        CIPPortCompolet cIPPortCompolet = new CIPPortCompolet();

        public void formatOmron()
        {
            if (!cIPPortCompolet.IsOpened(2))
            {
                cIPPortCompolet.Open(2);
            }
            if (!variableCompolet.Active)
            {
                variableCompolet.Active = true;
            }
        }
        public string[] fileReadSave(string name)
        {
            object omronObj = variableCompolet.ReadVariable(name);
            string getValue = this.getValueString(omronObj);
            return getValue.Split(',');
        }

        private string getValueString(object omronObj)
        {
            string getString = "";
            StringBuilder str = new StringBuilder();
            if (omronObj != null)
            {
                if (omronObj.GetType().IsArray)
                {
                    foreach (object obj in (Array)omronObj)
                    {
                        str.Append(string.Format("{0},", obj));
                    }
                    getString = str.ToString().TrimEnd(',');
                }
                else
                {
                    getString = omronObj.ToString();
                }
            }
            return getString;
        }

        public void WriteToPlc(string tagName, string[] strArray)
        {
            object value = strArray;
            if (variableCompolet.GetVariableInfo(tagName).Type == OMRON.Compolet.Variable.VariableType.STRUCT)
            {
                string[] arr = value as string[];
                Byte[] toArr = new Byte[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    toArr[i] = Byte.Parse(arr[i]);
                }
                value = toArr;
            }
            variableCompolet.WriteVariable(tagName, value);
        }

        public bool GetBitValue(int value, int index)
        {
            int val = 1;
            if (index != 0)
            { val = 1 << index; }
            int va = value & val;
            if (va == val)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
