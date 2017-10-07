using System;
using System.Runtime.InteropServices;

namespace Api.Library
{
    public class Class1
    {
        public string GetOS()
        {
            string osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            return osNameAndVersion;
        }


    }
}
