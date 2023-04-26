using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenar
{
    internal class Sons
    {
        private byte[] myWaveData;
        private WBuf Buf;
        public int waveSize = 0;

        public WBuf MyBuf
        {
            get
            {
                return Buf;
            }
            set
            {
                Buf = value;
            }
        }

        public byte[] WaveData
        {
            get
            {
                return myWaveData;
            }
            set
            {
                myWaveData = value;
            }
        }
    }
}
