using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSiteVoloteaUIAutomation.Utilities.Objects
{
    public class AppVersion
    {
        private static string platform;
        private static string folderPath;

        public static string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        public static string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }


    }
}
