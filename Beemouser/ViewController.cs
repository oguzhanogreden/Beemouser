using System;

using AppKit;
using Foundation;

using CoreGraphics;
using System.Runtime.InteropServices;
using ObjCRuntime;

using Beemouser.Domain.Models;
using Beemouser.QuartzCoreHelpers;
using Beemouser.DbContexts;

namespace Beemouser
{
    public partial class ViewController : NSViewController
    {
        
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
            NSEvent.AddGlobalMonitorForEventsMatchingMask(NSEventMask.LeftMouseDown, (NSEvent theEvent) =>
            {
                Console.WriteLine(theEvent);
                var windowNumber = theEvent.WindowNumber;

                var now = DateTime.UtcNow;

                using (var _context = new ClickContext())
                {
                    _context.Add(new Click
                    {
                        ClickedAt = DateTime.UtcNow,
                        WindowOwnerName = getWindow(windowNumber) ?? "unknown"
                    });
                }
            });
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        private string getWindow(nint windowNumber)
        {
            var service = new WindowInfoService();

            return service.GetWindowOwnerName(windowNumber);
        }
    }
}
