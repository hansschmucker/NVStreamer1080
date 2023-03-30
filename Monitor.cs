using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCD.Struct;

namespace NVStreamer1080
{
    class Monitor
    {
        public string DisplayName = "";
        public string PathString = "";
        public DisplayConfigPathInfo Path;
        public IEnumerable<DisplayConfigModeInfo> Modes;

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
