using System;
using AppKit;
using Beemouser.DbContexts;
using Beemouser.Domain.Models;
using Beemouser.QuartzCoreHelpers;
using CoreGraphics;
using Foundation;

namespace Beemouser
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        private NSStatusItem StatusItem { get; set; }

        public AppDelegate()
        {
        }

        private NSImage getStatusBarItemImage()
        {
            
            var image = new NSImage()
            {
                Name = "AppIcon",
                Size = new CGSize(16, 16)
            };

            return image;
        }

        private void showPreferences()
        {
            var storyboard = NSStoryboard.FromName("Main", null);
            var controller = (NSViewController)storyboard.InstantiateControllerWithIdentifier("PreferencesController");
            controller.PresentViewControllerAsModalWindow(controller);
        }

        private void makeStatusBarMenu()
        {
            var statusBar = NSStatusBar.SystemStatusBar;

            var item = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
            item.Title = "BeeMouser";

            item.Button.Activated += (sender, args) =>
            {
                showPreferences();
            };

            StatusItem = item;
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
            CaptureClicks();

            makeStatusBarMenu();
        }

        public override void WillTerminate(NSNotification notification) {
            // Insert code here to tear down your application
        }

        private void CaptureClicks()
        {
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
        
        private string GetWindow(nint windowNumber) {
            var service = new WindowInfoService();

            return service.GetWindowOwnerName(windowNumber);
        }
    }
}
