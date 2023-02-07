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
        public bool DebugWindow = false;
        public int CacheImageSize = 256;

        public int CustomTagCoverNonPrintableMargin = 15;
        public int CustomTagCoverOffsetIncrementX = 45;
        public int CustomTagCoverOffsetIncrementY = 45;
        public int CustomTagCoverInitialColumn = 0;
        public int CustomTagCoverInitialRow = 0;
        public int CustomTagCoverSize = 40;
        public double CustomTagOutlineWidth = 0.5;
        public string CustomTagCoverFilename = "CustomTagCover.pdf";

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
