using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeddyBench
{
    public class Settings
    {
        public string Username = "";
        public bool NfcEnabled = false;
        public string NfcType = "Proxmark3";
        public bool DebugWindow = false;
        public int CacheImageSize = 256;

        public int CustomTagNonPrintableMargin = 15;
        public int CustomTagGapX = 5;
        public int CustomTagGapY = 5;
        public int CustomTagInitialColumn = 0;
        public int CustomTagInitialRow = 0;
        public int CustomTagSize = 40;
        public double CustomTagOutlineWidth = 0.5;
        public string CustomTagCoverFilename = "CustomTagCover.pdf";
        public string CustomTagBacksideFilename = "CustomTagBackside.pdf";

        public static Settings FromFile(string file)
        {
            Settings s = null;

            try
            {
                s = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(file));
            }
            catch(Exception ex)
            {
            }

            if(s != null)
            {
                return s;
            }

            return new Settings();
        }

        public bool Save(string file)
        {
            try
            {
                File.WriteAllText(file, JsonConvert.SerializeObject(this, Formatting.Indented));
                return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }
    }
}
