using System;

using ObjCRuntime;
using System.Runtime.InteropServices;

using CoreGraphics;
using Foundation;
using System.Collections.Generic;

using System.Linq;

namespace Beemouser.QuartzCoreHelpers
{
    public class WindowInfoService
    {
        
        [DllImport(@"/System/Library/Frameworks/QuartzCore.framework/QuartzCore")]
        private static extern IntPtr CGWindowListCopyWindowInfo(CGWindowListOption option, uint relativeToWindow);

        public List<WindowInfo> GetWindows()
        {

            var windowInfoArray = getWindowInfoArray();

            return MapToTypedArray(windowInfoArray);
        }

        public string GetWindowOwnerName(nint windowNumber)
        {
            return GetWindows()
                .Where(x => x.WindowNumber == windowNumber)
                .FirstOrDefault()
                .WindowOwnerName;
        }

        private NSArray getWindowInfoArray()
        {
            IntPtr windowInfoPtr = CGWindowListCopyWindowInfo(CGWindowListOption.All, 0);

            return Runtime.GetNSObject<NSArray>(windowInfoPtr);
        }

        // todo: Can I now skip this since I have a registered an NSObject implementation?
        private List<WindowInfo> MapToTypedArray(NSArray array)
        {
            var windowInfos = new List<WindowInfo>();


            for (uint i = 0; i < array.Count; i++)
            {
                var nsObject = Runtime.GetNSObject<NSObject>(array.ValueAt(i));

                var windowName = nsObject.ValueForKey(new NSString("kCGWindowOwnerName")).ToString();
                var windowNumber = nint.Parse(nsObject.ValueForKey(new NSString("kCGWindowNumber")).ToString());

                windowInfos.Add(new WindowInfo
                {
                    WindowOwnerName = windowName,
                    WindowNumber = windowNumber
                });
            }

            return windowInfos;
        }
    }
}
