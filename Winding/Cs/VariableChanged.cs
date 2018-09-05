using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Winding.Cs
{
    public class VariableChanged
    {
        ~VariableChanged()
        { }
        Cs.VariableChangedEven variableChangedEven = new VariableChangedEven();

        private bool _gMesIn2;
        public bool GMesIn2
        {
            get
            {
                return _gMesIn2;
            }
            set
            {
                if (value && value != GMesIn2)
                {
                    variableChangedEven.ClearMesOutFour();
                }
                _gMesIn2 = value;
            }
        }

        private bool _gMesIn3;
        public bool GMesIn3
        {
            get
            {
                return _gMesIn3;
            }
            set
            {
                if (value && value != GMesIn3)
                {
                    variableChangedEven.ClearMesOutFour();
                }
                _gMesIn3 = value;
            }
        }

        private bool _gMesIn4;
        public bool GMesIn4
        {
            get
            {
                return _gMesIn4;
            }
            set
            {
                if (value && value != GMesIn4)
                {
                    variableChangedEven.ClearMesOutFour();
                }
                _gMesIn4 = value;
            }
        }

        private bool _gMesIn5;
        public bool GMesIn5
        {
            get
            {
                return _gMesIn5;
            }
            set
            {
                if (value && value != GMesIn5)
                {
                    variableChangedEven.ClearMesOutFour();
                }
                _gMesIn5 = value;
            }
        }

        private bool _gMesIn7;
        public bool GMesIn7
        {
            get
            {
                return _gMesIn7;
            }
            set
            {
                if (value && value != GMesIn7)
                {
                    variableChangedEven.GMesInSeven();
                }
                _gMesIn7 = value;
            }
        }

        private bool _gMesIn8;
        public bool GMesIn8
        {
            get
            {
                return _gMesIn8;
            }
            set
            {
                if (value && value != GMesIn8)
                {
                    variableChangedEven.GMesInEight();
                }
                _gMesIn8 = value;
            }
        }

        private string _mesIn5;
        public string MesIn5
        {
            get
            {
                return _mesIn5;
            }
            set
            {
                if (value != MesIn5)
                {
                    variableChangedEven.MesInFive(value);
                }
                _mesIn5 = value;
            }
        }

        private bool _scanComplete;
        public bool ScanComplete
        {
            get
            {
                return _scanComplete;
            }
            set
            {
                if (value && ScanComplete != value)
                {
                    variableChangedEven.ScanComplete();

                }
                _scanComplete = value;
            }
        }

        public bool ResendToMES
        {
            get
            {
                return _resendToMES;
            }

            set
            {
                if (value && ResendToMES != value)
                {
                    variableChangedEven.ScanComplete();

                }
                _resendToMES = value;
            }
        }

        private bool _resendToMES;
    }
}
