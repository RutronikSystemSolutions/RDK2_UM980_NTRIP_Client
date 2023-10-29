using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM980PositioningGUI
{
    public class UM980Stream
    {
        private List<byte> dataStream = new List<byte>();

        public void push(byte [] data, int len)
        {
            if (data == null) return;
            if (len == 0) return;
            if (len > data.Length) return;

            for (int i = 0; i < len; ++i)
            {
                dataStream.Add(data[i]);
            }
        }

        public byte [] readNMEAPacket()
        {
            for(; ;)
            {
                if (dataStream.Count < 3) break;

                if (dataStream[0] != '$')
                {
                    dataStream.RemoveAt(0);
                    continue;
                }

                // Search for CR LF now
                for(int i = 1; i < dataStream.Count; ++i)
                {
                    // Find $ again -> not possible, clear
                    if (dataStream[i] == '$')
                    {
                        dataStream.RemoveRange(0, i);
                        return null;
                    }

                    if ((dataStream[i-1] == '\r') && (dataStream[i] == '\n'))
                    {
                        // Good
                        byte[] retval = new byte[i + 1];
                        for (int j = 0; j < retval.Length; ++j)
                            retval[j] = dataStream[j];

                        dataStream.RemoveRange(0, retval.Length);
                        return retval;
                    }
                }

                break;
            }
            return null;
        }
    }
}
