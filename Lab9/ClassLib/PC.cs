using System;

namespace ClassLib
{
    [Serializable]
    public class PC
    {
        #region field
        private string _typePC;
        private string _serialNumber;
        private int _ram;
        private int _hd;
        public string _statePC { get; set; } = "Shutdown";
        #endregion region

        #region GeteersSetters
        public string GetTypePC
        {
            get
            {
                return _typePC;
            }
        }

        public string GetSerialNumber
        {
            get
            {
                return _serialNumber;
            }
        }

        public int Ram
        {
            get
            {
                return _ram;
            }
            set
            {
                _ram = (value > 0) ? value : 1;
            }
        }
        public int HD
        {
            get
            {
                return _hd;

            }

            set
            {
                _hd = (value > 0) ? value : 500;
            }
        }
        #endregion

        public PC()
        {
            _typePC = "HomePC";
            _serialNumber = "RB123-454IE";
            _ram = 1;
            _hd = 500;
        }

        public PC(string typePC, string serialNumber, int RAM, int HD)
        {
            _typePC = typePC;
            _serialNumber = serialNumber;
            _ram = RAM;
            _hd = HD;
        }

        public override string ToString()
        {
            return $"Type PC: {_typePC} serial number: {_serialNumber} ram: {_ram} hd: {_hd}";
        }

        public void TurningOn()
        {
            _statePC = "TurningOn";
        }

        public void Shutdown()
        {
            _statePC = "Shutdown";
        }

        public void Reboot()
        {
            _statePC = "Reboot";
        }

    }
}
