using System;

using Foundation;

namespace Beemouser.QuartzCoreHelpers
{
    //[Register("WindowInfo")]
    public class WindowInfo : NSObject
    {
        private nint _windowNumber;
        private string _windowOwnerName;

        //[Export("WindowNumber")]
        public nint WindowNumber {
            get { return _windowNumber; }
            set
            {
                //WillChangeValue("WindowNumber");
                _windowNumber = value;
                //DidChangeValue("WindowNumber");
            }
        }


        //[Export("WindowOwnerName")]
        public string WindowOwnerName
        {
            get { return _windowOwnerName; }
            set
            {
                //WillChangeValue("WindowOwnerName");
                _windowOwnerName = value;
                //DidChangeValue("WindowOwnerName");
            }
        }
    }
}