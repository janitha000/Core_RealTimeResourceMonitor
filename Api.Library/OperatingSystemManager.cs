using System;
using System.Runtime.InteropServices;

namespace Api.Library
{
    public class OperatingSystemManager
    {
        public string GetOS()
        {
            string osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            return osNameAndVersion;
        }

        public string GetFramework()
        {
            string framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            return framework;
        }
    }
}
