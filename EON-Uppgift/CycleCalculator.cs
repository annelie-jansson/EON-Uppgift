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

        public int RunCycles(List<string> signals)
        {
            foreach (string signal in signals)
            {
                if (_cycle > 220) break;

                Tick(signal);
            }
            return _sum;
            
        }

        private void Tick(string signal)
        {
            IncrementAndHandleCycle();

            if (signal.Contains("noop")) return;

            IncrementAndHandleCycle();

            _x += GetValueFromString(signal);
        }

        private void IncrementAndHandleCycle()
        {
            _cycle++;

            if (_cycle == 20 || _cycle == 60 || _cycle == 100 || _cycle == 140 || _cycle == 180 || _cycle == 220)
            {
                _sum += _x * _cycle;
            }
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

