using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Ordenar
{
    public class Som
    {
        public class wave
        {
            public byte[] wavData;
            public int v;
            public double freq;
        }

        private List<wave> wavDataArray;
        public int MaxValue;


        public Som()
        {
            MaxValue = 20;
            wavDataArray = new List<wave> { };
        }

        public void AdicionaSom(int v)
        {
            byte[] wavData = GenerateSineWaveWav(440 * ((double)(v+1)/(MaxValue/2.0)), 0.01);
            wave wave = new wave();
            wave.v= v;
            wave.wavData = wavData;
            wave.freq = 440 * ((double)(v+1) / (MaxValue / 2.0));

            string filePath = "c:\\temp\\output["+v+"].wav";
            File.WriteAllBytes(filePath, wavData);

            if (!wavDataArray.Contains(wave))
            {
                wavDataArray.Add(wave);
            }
        }

        public void Gerar()
        {
            int i;
            for (i = 1; i <= MaxValue; i++)
            {
                AdicionaSom(i);
            }
        }

        public void Limpar()
        {
            wavDataArray.Clear();
        }

        /*private static async Task asyncPlay(wave wave)
        {
             await Task.Run(() =>
                    {
                        byte[] wavData = wave.wavData;
                        var memoryStream = new MemoryStream(wavData);
                        SoundPlayer player = new SoundPlayer(memoryStream);
                        player.Play();
                        //Console.Beep((int)wave.freq, 20);
                    });
        }*/

        public void play(int i, bool asinc)
        {
            int j = wavDataArray.FindIndex(w => w.v == i);
            // Console.WriteLine("som: " + i + " - Indice: " + j);
            /*if (asinc)
            {
                asyncPlay(wavDataArray[j]);
            }
            else
            {*/
                wave wave;
                wave = wavDataArray[j];
                byte[] wavData = wave.wavData;
                var memoryStream = new MemoryStream(wavData);
                SoundPlayer player = new SoundPlayer(memoryStream);
                //player.PlaySync();
                if (asinc)
                    player.Play();
                else
                    player.PlaySync();
                //Console.Beep((int)wave.freq, 30);
            //}

        }

        static byte[] GenerateSineWaveWav(double frequency, double duration)
        {
            // WAV format parameters
            int sampleRate = 44100; // 44.1 kHz
            short bitsPerSample = 16; // 16-bit audio
            short numChannels = 1; // Mono
            int numSamples = (int)(sampleRate * duration);
            int byteRate = sampleRate * numChannels * bitsPerSample / 8;
            int blockAlign = numChannels * bitsPerSample / 8;
            int dataSize = numSamples * numChannels * bitsPerSample / 8;

            // Create a memory stream to hold the WAV data
            using (var memoryStream = new MemoryStream())
            using (var writer = new BinaryWriter(memoryStream))
            {
                // Write the WAV header
                writer.Write(System.Text.Encoding.ASCII.GetBytes("RIFF")); // Chunk ID
                writer.Write(36 + dataSize); // Chunk size (file size - 8 bytes)
                writer.Write(System.Text.Encoding.ASCII.GetBytes("WAVE")); // Format
                writer.Write(System.Text.Encoding.ASCII.GetBytes("fmt ")); // Subchunk 1 ID
                writer.Write(16); // Subchunk 1 size (16 for PCM)
                writer.Write((short)1); // Audio format (1 for PCM)
                writer.Write(numChannels); // Number of channels
                writer.Write(sampleRate); // Sample rate
                writer.Write(byteRate); // Byte rate
                writer.Write((short)blockAlign); // Block align
                writer.Write(bitsPerSample); // Bits per sample
                writer.Write(System.Text.Encoding.ASCII.GetBytes("data")); // Subchunk 2 ID
                writer.Write(dataSize); // Subchunk 2 size (data size)

                // Generate and write the sine wave data
                double amplitude = 0.5 * short.MaxValue; // Max amplitude for 16-bit audio
                for (int i = 0; i < numSamples; i++)
                {
                    double time = (double)i / sampleRate;
                    short sample = (short)(amplitude * Math.Sin(2 * Math.PI * frequency * time));
                    writer.Write(sample);
                }

                // Return the WAV data as a byte array
                return memoryStream.ToArray();
            }
        }
    }
}
