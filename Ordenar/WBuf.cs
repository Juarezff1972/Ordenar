using MultiMedia;
using System;
using System.Runtime.InteropServices;
using WindowsMediaLib.Defs;

namespace Ordenar
{
    public class WBuf
    {
        private WAVEHDR m_Head;
        private int m_MaxLen;
        private GCHandle m_Handle;

        public WBuf(IntPtr waveHandle, int iMaxBuf)
        {
            m_MaxLen = iMaxBuf;
            m_Head = new WAVEHDR(iMaxBuf);
            m_Head.dwBytesRecorded = 0;

            // Since waveOutWrite will continue to the buffer after the call
            // returns, the buffer must be fixed in place.
            m_Handle = GCHandle.Alloc(m_Head, GCHandleType.Pinned);

            int mmr = waveOut.PrepareHeader(waveHandle, m_Head, Marshal.SizeOf(typeof(WAVEHDR)));
            waveOut.ThrowExceptionForError(mmr);

            // Make it easier for IsBufferFree() to determine when buffers are free
            m_Head.dwFlags |= WAVEHDR.WHDR.Done;
        }
        public void Release(IntPtr waveHandle)
        {
            int mmr;

            mmr = waveOut.UnprepareHeader(waveHandle, m_Head, Marshal.SizeOf(typeof(WAVEHDR)));
            waveOut.ThrowExceptionForError(mmr);

            m_Head.Dispose();
            m_Handle.Free();
        }
        public bool IsBufferFree()
        {
            return (m_Head.dwFlags & WAVEHDR.WHDR.Done) != 0;
        }
        public IntPtr GetPtr()
        {
            return m_Handle.AddrOfPinnedObject();
        }

        public static int GenerateLaSize(WaveFormatEx wfx, int iDuration, out int iSamples)
        {
            iSamples = (int)Math.Ceiling((wfx.nSamplesPerSec * iDuration) / 10.0);
            return iSamples * wfx.nBlockAlign;
        }
        public int GenerateLa(WaveFormatEx wfx, int iDuration, double freq)
        {
            int iSamples;
            int vol = 20;
            int iSize = GenerateLaSize(wfx, iDuration, out iSamples);
            if (iSize > m_MaxLen)
            {
                throw new Exception("Requested duration greater than buffer's max size");
            }
            m_Head.dwBufferLength = iSize;

            int iOffset = 0;
            IntPtr pBuff = m_Head.lpData;

            for (int i = 0; i < iSamples; i++)
            {
                double damp = ((double)iSamples - (double)i) / (double)iSamples;
                double y = (damp * Math.Sin((freq * 2 * Math.PI * i) / wfx.nSamplesPerSec))/vol; // tone
                if (wfx.wBitsPerSample == 8)
                {
                    byte sample = (byte)(127.5 * (y + 1.0));
                    Marshal.WriteByte(pBuff, iOffset, sample); // Note: This would perform better using pointers in unsafe mode
                    iOffset++;
                    if (wfx.nChannels == 2)
                    {
                        Marshal.WriteByte(pBuff, iOffset, sample); // Note: This would perform better using pointers in unsafe mode
                        iOffset++;
                    }
                }
                else
                {
                    short sample = (short)((32767.5 * y) - 0.5);
                    Marshal.WriteInt16(pBuff, iOffset, sample); // Note: This would perform better using pointers in unsafe mode
                    iOffset += 2;
                    if (wfx.nChannels == 2)
                    {
                        Marshal.WriteInt16(pBuff, iOffset, sample); // Note: This would perform better using pointers in unsafe mode
                        iOffset += 2;
                    }
                }
            }

            return iSize;
        }
    }
}
