using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EON_Uppgift
{
    public class CycleCalculator
    {

        private int _cycle = 0;
        private int _x = 1;
        private int _sum = 0;
        private string _CRT = "";
        private int _crtLength = 0;

        /// <summary>
        /// Only for testing purposes
        /// </summary>
        /// <param name="startingCycle"></param>
        public CycleCalculator(int startingCycle)
        {
            _cycle = startingCycle;
        }

        public CycleCalculator()
        {

        }

        internal void StartClockCircuit(List<string> signals, bool shouldPrint = true)
        {
            foreach (string signal in signals)
            {
                ExecuteSignal(signal);

                if (_cycle == 240) break;

            }

            if (shouldPrint)
            {
                Console.WriteLine($"The signal strength is: {_sum}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"CRT below:");
                Console.WriteLine(_CRT);
            }
        }

        public int GetSignalStrength(List<string> signals)
        {
            StartClockCircuit(signals, false);
            return _sum;
        }

        public string RenderSprite(List<string> signals)
        {
            StartClockCircuit(signals, false);
            return _CRT;
        }

        private void ExecuteSignal(string signal)
        {
            ExecuteCycle();

            if (signal.Contains("noop")) return;
            if (_cycle == 240) return;

            ExecuteCycle();

            _x += GetValueFromString(signal);
        }

        private void ExecuteCycle()
        {
            _cycle++;

            if (_cycle == 20 || _cycle == 60 || _cycle == 100 || _cycle == 140 || _cycle == 180 || _cycle == 220)
            {
                _sum += _x * _cycle;
            }

            DrawPixel();

            if (_cycle == 240) return;

            if (_crtLength == 40)
            {
                _CRT += "\r\n";
                _crtLength = 0;
            }
        }

        private void DrawPixel()
        {
            if (_x == _crtLength || _x + 1 == _crtLength || _x - 1 == _crtLength)
            {
                _CRT += "#";
            }
            else
            {
                _CRT += ".";
            }

            _crtLength++;
        }

        private int GetValueFromString(string valueAndText)
        {
            var value = valueAndText.Replace("addx ", "");

            if (!string.IsNullOrEmpty(value))
            {
                if (int.TryParse(value, out int number))
                {
                    return number;
                }
            }

            return 0;
        }
    }
}

