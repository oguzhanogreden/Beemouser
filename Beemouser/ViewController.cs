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
    }
}
