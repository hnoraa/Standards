using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
        /// <param name="toFile">Redirect Console output to a file</param>        
        public void Report(bool toFile = false)
        {
            double longest = 0.0;
            string longestM = "";
            double shortest = 0.0;
            string shortestM = "";
            double average = 0.0;

            string line = "=====================================================================================";

            // used for writing to a report file
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            string fileName = $"./Report_{DateTime.Now.Ticks}.txt";

            try
            {
                ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cannot open {fileName} for writing");
                Console.WriteLine(e.Message);
                return;
            }

            if (toFile)
            {
                // this redirects the console to the output
                Console.SetOut(writer);
            }

            Console.WriteLine(line);
            Console.WriteLine("Bench Mark Test Report");
            Console.WriteLine($"\tTest Start:\t{_start.ToString("MM/dd/yyyy HH:mm:ss")}\t({TimeSpan.FromTicks(_start.Ticks).TotalSeconds}s)" +
                $"\n\tTest End:\t{_end.ToString("MM/dd/yyyy HH:mm:ss")}\t({TimeSpan.FromTicks(_end.Ticks).TotalSeconds}s)");
            Console.WriteLine(line);

            if (_marks.Count() > 1)
            {
                Console.WriteLine("Marks");

                _marks.ForEach(d => Console.WriteLine($"\tMark -\t\t{d.message}\n\tDuration -\t{d.seconds:0.000000}"));

                longest = _marks.Max(x => x.seconds);
                shortest = _marks.Min(x => x.seconds);
                average = _marks.Average(x => x.seconds);

                longestM = _marks.FirstOrDefault(s => s.seconds == longest).message;
                shortestM = _marks.FirstOrDefault(s => s.seconds == shortest).message;

                Console.WriteLine(line);
                Console.WriteLine("Statistics");
                Console.WriteLine($"Longest Mark:\t{longest:0.000000}s\t({longestM})");
                Console.WriteLine($"Shortest Mark:\t{shortest:0.000000}s\t({shortestM})");
                Console.WriteLine($"Average:\t{average:0.000000}s");

                Console.WriteLine(line);
            }

            Console.WriteLine($"Overall Duration {Duration()}s");

            if(toFile)
            {
                // redirect back to Console output
                Console.SetOut(oldOut);
                writer.Close();
                ostrm.Close();
                Console.WriteLine("Report written to file successfully.");
            }
        }
    }
}
