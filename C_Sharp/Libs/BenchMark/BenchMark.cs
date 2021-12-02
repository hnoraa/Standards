using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchMark
{
    /// <summary>
    /// Class to test duration of processes/algorithms
    /// Can set marks to show the differences between different implementations of code
    /// </summary>
    public class BenchMark
    {
        /// <summary>
        /// Data packet 
        /// </summary>
        private struct Data
        {
            /// <summary>
            /// Duration of the mark (from _start property in parent class)
            /// </summary>
            public double seconds;

            /// <summary>
            /// Custom message to give information
            /// </summary>
            public string message;
        };

        /// <summary>
        /// BenchMark start time
        /// </summary>
        private DateTime _start;

        /// <summary>
        /// BenchMark end time
        /// </summary>
        private DateTime _end;

        /// <summary>
        /// A mark is an infdividual time spot relative to the _start time property
        /// It uses the Data struct defined above
        /// </summary>
        private List<Data> _marks;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BenchMark()
        {
            _marks = new List<Data>();
        }

        /// <summary>
        /// Sets the start time
        /// </summary>
        public void Start()
        {
            _start = DateTime.Now;
        }

        /// <summary>
        /// Sets the end time
        /// </summary>
        public void End()
        {
            _end = DateTime.Now;
        }

        /// <summary>
        /// Create a new mark
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        public void Mark(string message)
        {
            Data d = new Data();
            TimeSpan ts = DateTime.Now - _start;
            d.seconds = ts.TotalSeconds;
            d.message = message;

            _marks.Add(d);
        }

        /// <summary>
        /// The duration of the entire run
        /// </summary>
        /// <returns>TimeSpan.TotalSeconds duration</returns>
        private double Duration()
        {
            TimeSpan ts = _end - _start;
            return ts.TotalSeconds;
        }

        /// <summary>
        /// Reports the durations with statistics
        /// </summary>
        public void Report()
        {
            double longest = 0.0;
            string longestM = "";
            double shortest = 0.0;
            string shortestM = "";
            double average = 0.0;

            Console.WriteLine($"=====================================================================================");
            Console.WriteLine("Bench Mark Test Report");
            Console.WriteLine($"\tTest Start: {_start} Test End {_end}");
            Console.WriteLine($"=====================================================================================");

            if (_marks.Count() < 1)
            {
                Console.WriteLine("Marks:");
                foreach (Data d in _marks)
                {
                    Console.WriteLine($"\tMark -\t{d.message}\n\tDuration -\t{d.seconds}");
                    if (d.seconds > longest)
                    {
                        longest = d.seconds;
                    }
                    if (d.seconds < shortest || shortest == 0.0)
                    {
                        shortest = d.seconds;
                    }
                    average += d.seconds;
                }

                longestM = _marks.FirstOrDefault(s => s.seconds == longest).message;
                shortestM = _marks.FirstOrDefault(s => s.seconds == shortest).message;
                average = (average) / _marks.Count;

                Console.WriteLine($"=====================================================================================");
                Console.WriteLine("Statistics");
                Console.WriteLine($"Longest Mark:\t{longest}\t({longestM})");
                Console.WriteLine($"Shortest Mark:\t{shortest}\t({shortestM})");
                Console.WriteLine($"Average:\t{average}");

                Console.WriteLine($"=====================================================================================");
            }

            Console.WriteLine($"Overall Duration: {Duration()}");
        }
    }
}
