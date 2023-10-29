using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    class RTCMPacket
    {
        public const byte PreambleValue = 0xD3;
        public const byte RTCMFixedLen = 6;

        private byte[] data;

        public RTCMPacket(byte [] data)
        {
            if (data == null) throw new Exception("data is null");

            this.data = new byte[data.Length];
            for (int i = 0; i < data.Length; ++i) this.data[i] = data[i];
        }

        public ushort GetType()
        {
            if ((data == null) || (data.Length < 5)) throw new Exception("data is unvalid");

            return (ushort)(((data[3]) << 4) | ((data[4] & 0xF0) >> 4));
        }
    }
}
