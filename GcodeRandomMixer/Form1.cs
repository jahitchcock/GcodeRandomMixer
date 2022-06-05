using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GcodeRandomMixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string originalFileName;
        private int numberOfExtruders;
        private string searchString;
        static Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string line;
            originalFileName = txt_originalFile.Text;
            searchString = txt_Search.Text;
            numberOfExtruders = Int32.Parse(cmb_extruders.Text) - 1; //Gcode uses a Zero starting array for extruder numbers 0,1,2 for 3 extruders
            if (!String.IsNullOrEmpty(originalFileName) 
                && ! String.IsNullOrEmpty(searchString) 
                && saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sr_input = new StreamReader(originalFileName);
                var sr_output = new StreamWriter(saveFileDialog1.FileName);
                while ((line = sr_input.ReadLine()) != null)
                {
                    if (line.StartsWith(searchString))
                    {
                        var mix = Generate_Mix_Ratio(numberOfExtruders);
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

        private void btn_fileBrowser_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filename = openFileDialog1.FileName;
                    originalFileName = filename;
                    txt_originalFile.Text = filename;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
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
                    var r = rnd.Next(loop+1, 100-totalMix-loop);
                    currentMix = 100 - totalMix - r;
                    totalMix = totalMix + currentMix;
                }
                else
                {
                    currentMix = 100 - totalMix;
                }
                string mixstring = "";
                if(currentMix < 10)
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
