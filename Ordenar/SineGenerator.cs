using System;

namespace Ordenar
{
    internal class SineGenerator
    {
        private readonly double _frequency;
        private readonly UInt32 _sampleRate;
        private readonly float _secondsInLength;
        private short[] _dataBuffer;

        public short[] Data { get { return _dataBuffer; } }

        public SineGenerator(double frequency, UInt32 sampleRate, float secondsInLength)
        {
            _frequency = frequency;
            _sampleRate = sampleRate;
            _secondsInLength = secondsInLength;
            GenerateDataFadeout();
        }

        private void GenerateData()
        {
            uint bufferSize = (uint)(_sampleRate * _secondsInLength);
            _dataBuffer = new short[bufferSize];

            int amplitude = 32760;

            double timePeriod = (Math.PI * 2 * _frequency) / (_sampleRate);

            for (uint index = 0; index < bufferSize - 1; index++)
            {
                _dataBuffer[index] = Convert.ToInt16(amplitude * Math.Sin(timePeriod * index));
            }
        }

        private void GenerateDataFadeout()
        {
            float s;
            s = _secondsInLength;
            if (s == 0) s = 0.001f;
            uint bufferSize = (uint)(_sampleRate * s);
            _dataBuffer = new short[bufferSize];

            uint amplitude = 32760;
            uint damped;
            float factor;

            double timePeriod = (Math.PI * 2 * _frequency) / (_sampleRate);

            for (uint index = 0; index < bufferSize - 1; index++)
            {
                factor = ((float)index / (float)(bufferSize - 1));
                damped = amplitude - (uint)(amplitude * factor);
                _dataBuffer[index] = Convert.ToInt16(damped * Math.Sin(timePeriod * index));
            }
        }

        public override string ToString()
        {
            return "Frequency: " + _frequency.ToString() + ", Sample Rate: " + _sampleRate.ToString() + ", Length: " + _secondsInLength.ToString() + "s";
        }
    }
}
