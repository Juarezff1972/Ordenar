using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ordenar
{
    internal class DataChunk
    {
        private const string CHUNK_ID = "data";

        public string ChunkId { get; private set; }
        public UInt32 ChunkSize { get; set; }
        public short[] WaveData;

        public DataChunk()
        {
            ChunkId = CHUNK_ID;
            ChunkSize = 0;  // Until we add some data
        }

        public UInt32 Length()
        {
            return (UInt32)GetBytes().Length;
        }

        public byte[] GetBytes()
        {
            List<Byte> chunkBytes = new List<Byte>();

            chunkBytes.AddRange(Encoding.ASCII.GetBytes(ChunkId));
            chunkBytes.AddRange(BitConverter.GetBytes(ChunkSize));
            byte[] bufferBytes = new byte[WaveData.Length * 2];
            Buffer.BlockCopy(WaveData, 0, bufferBytes, 0,
               bufferBytes.Length);
            chunkBytes.AddRange(bufferBytes.ToList());

            return chunkBytes.ToArray();
        }

        public void AddSampleData(short[] leftBuffer, short[] rightBuffer)
        {
            int oldsize = 0;
            if (WaveData == null)
            {
                WaveData = new short[leftBuffer.Length + rightBuffer.Length];
            }
            else
            {
                oldsize = WaveData.Length;
                Array.Resize<short>(ref WaveData, WaveData.Length + (leftBuffer.Length + rightBuffer.Length));
            }


            int bufferOffset = 0;
            for (int index = oldsize; index < WaveData.Length; index += 2)
            {
                WaveData[index] = leftBuffer[bufferOffset];
                WaveData[index + 1] = rightBuffer[bufferOffset];
                bufferOffset++;
            }
            ChunkSize = (UInt32)WaveData.Length * 2;
        }

        public override string ToString()
        {
            return $"{{{nameof(ChunkId)}={ChunkId}, {nameof(ChunkSize)}={ChunkSize.ToString()}}}";
        }
    }
}
