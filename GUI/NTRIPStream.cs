using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    class NTRIPStream
    {
        private List<byte> dataStream = new List<byte>();

        private uint crc24(List<byte> buffer, int size)
        {
            uint crc = 0;
            for (int j = 0; j < size; ++j)
            {
                crc ^= (uint)buffer[j] << (16);
                for (int i = 0; i < 8; i++)
                {
                    crc <<= 1;
                    if ((crc & 0x1000000) != 0)
                        crc ^= 0x01864cfb;
                }
            }
            return crc;
        }


        /// <summary>
        /// Push data to the stream
        /// </summary>
        /// <param name="data"></param>
        public void push(byte [] data, int len)
        {
            if (data == null) return;
            if (len == 0) return;
            if (len > data.Length) return;

            for(int i = 0; i < len; ++i)
            {
                dataStream.Add(data[i]);
            }
        }

        /// <summary>
        /// Read a packet from the stream
        /// </summary>
        /// <returns></returns>
        public byte [] readRTCMPacket()
        {
            for(; ;)
            {
                if (dataStream.Count < RTCMPacket.RTCMFixedLen) break;

                // Preamble?
                if (dataStream[0] != RTCMPacket.PreambleValue)
                {
                    dataStream.RemoveAt(0);
                    continue;
                }

                // Reserved 6 bits to 0?
                if ((dataStream[1] & 0xFC) != 0)
                {
                    dataStream.RemoveRange(0, 2);
                    continue;
                }

                ushort len = (ushort)(((dataStream[1] & 3) << 8) | dataStream[2]);

                // Enough to be read?
                if (dataStream.Count < (RTCMPacket.RTCMFixedLen + len)) break;

                uint crc = crc24(dataStream, len + 3);

                uint crcIs = ((uint)dataStream[3 + len] << 16)
                                    | ((uint)dataStream[3 + len + 1] << 8)
                                    | ((uint)dataStream[3 + len + 2]);

                if (crc != crcIs)
                {
                    // Wrong CRC
                    dataStream.RemoveAt(0);
                    continue;
                }

                // CRC is ok, extract and return
                byte[] retval = new byte[RTCMPacket.RTCMFixedLen + len];
                for (int i = 0; i < retval.Length; ++i)
                    retval[i] = dataStream[i];

                dataStream.RemoveRange(0, retval.Length);
                return retval;
            }

            return null;
        }
    }
}
