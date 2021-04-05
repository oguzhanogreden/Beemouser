using System;
using AppKit;
using Beemouser.DbContexts;
using Beemouser.Domain.Models;
using Beemouser.QuartzCoreHelpers;
using Foundation;

namespace Beemouser
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application

            // Do any additional setup after loading the view.
            NSEvent.AddGlobalMonitorForEventsMatchingMask(NSEventMask.LeftMouseDown, (NSEvent theEvent) =>
            {
                var windowNumber = theEvent.WindowNumber;

                var now = DateTime.UtcNow;

                Console.WriteLine(theEvent);

                using (var _context = new ClickContext())
                {
                    _context.Add(new Click
                    {
                        WindowOwnerName = GetWindow(windowNumber) ?? "unknown"
                    });
                    _context.SaveChanges();
                }
            });
        }
        
        public override void WillTerminate(NSNotification notification) {
            // Insert code here to tear down your application
        }
        
        private string GetWindow(nint windowNumber) {
            var service = new WindowInfoService();

            return service.GetWindowOwnerName(windowNumber);
        }
    }
}
