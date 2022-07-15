using System;
using System.IO;

namespace GcodeRandomMixer
{
    public class gcodeRandomize
    {
        public gcodeRandomize()
        {
        }

        static Random rnd = new Random();

        public void GenerateMix(string originalFileName, string newFileName = "", int extruders = 3, string searchString = ";LAYER:")
        {
            string line;
            if (String.IsNullOrEmpty(searchString))
            {
                searchString = ";LAYER:";
            }
            if (String.IsNullOrEmpty(newFileName))
            {
                newFileName = originalFileName.Replace(".gc", "_mix.gc");
            }
            if (extruders <= 1)
            {
                extruders = 3;
            }
            extruders = extruders - 1; //Gcode uses a Zero starting array for extruder numbers 0,1,2 for 3 extruders
            if (!String.IsNullOrEmpty(originalFileName))
            {
                var sr_input = new StreamReader(originalFileName);
                var sr_output = new StreamWriter(newFileName);
                while ((line = sr_input.ReadLine()) != null)
                {
                    if (line.StartsWith(searchString))
                    {
                        var mix = Generate_Mix_Ratio(extruders);
                        sr_output.WriteLine(line + Environment.NewLine + mix);
                    }
                    else
                    {
                        sr_output.WriteLine(line);
                    }
                }
                sr_input.Close();
                sr_output.Close();
            }
        }

        private string Generate_Mix_Ratio(int extruders)
        {
            string Result = String.Concat(System.Environment.NewLine, "; Adding New Mix Ratio", System.Environment.NewLine);
            var currentMix = 100;
            int totalMix = 0;
            var loop = extruders;

            while (loop >= 0)
            {
                if (loop > 0) //Grab a random number unless we're on the last extruder to ensure we total 100
                {
                    var r = rnd.Next(loop + 1, 100 - totalMix - loop);
                    currentMix = 100 - totalMix - r;
                    totalMix = totalMix + currentMix;
                }
                else
                {
                    currentMix = 100 - totalMix;
                }
                string mixstring = "";
                if (currentMix < 10)
                {
                    mixstring = "0" + currentMix.ToString();
                }
                else
                {
                    mixstring = currentMix.ToString();
                }
                Result = String.Concat(Result, "M163 S", loop.ToString(), " P.", mixstring, System.Environment.NewLine);
                loop = loop - 1;
            }

            return Result;
        }
    }
}