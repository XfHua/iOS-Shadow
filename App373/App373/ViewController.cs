using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using System.Reflection.Emit;
using UIKit;

namespace App373
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            UILabel cell = new UILabel();
            cell.BackgroundColor = UIColor.Blue;
            cell.Text = "test";

            UIView shadowView = new UIView(new CoreGraphics.CGRect(100, 100, 200, 100));
            shadowView.Layer.ShadowColor = UIColor.Black.CGColor;
            shadowView.Layer.ShadowRadius = 8.0f;
            shadowView.Layer.ShadowOffset = new CGSize(13.0, 13.0);
            shadowView.Layer.ShadowOpacity = 0.5f;

            cell.Frame = shadowView.Bounds;

            //Top Left Right Corners
            var maskPathTop = UIBezierPath.FromRoundedRect(cell.Bounds, UIRectCorner.TopLeft | UIRectCorner.TopRight, new CoreGraphics.CGSize(8, 8));
            var shapeLayerTop = new CAShapeLayer();
            shapeLayerTop.Frame = cell.Bounds;
            //shapeLayerTop.BorderWidth = 3;
            //shapeLayerTop.BorderColor = VM.RedColor.ToNativeColor().CGColor;
            shapeLayerTop.Path = maskPathTop.CGPath;

            //Bottom Left Right Corners
            var maskPathBottom = UIBezierPath.FromRoundedRect(cell.Bounds, UIRectCorner.BottomLeft | UIRectCorner.BottomRight, new CoreGraphics.CGSize(8, 8));
            var shapeLayerBottom = new CAShapeLayer();
            shapeLayerBottom.Frame = cell.Bounds;
            //shapeLayerBottom.BorderColor = VM.RedColor.ToNativeColor().CGColor;
            //shapeLayerBottom.BorderWidth = 3;
            shapeLayerBottom.Path = maskPathBottom.CGPath;

            //All Corners
            var maskPathAll = UIBezierPath.FromRoundedRect(cell.Bounds, UIRectCorner.BottomLeft | UIRectCorner.BottomRight | UIRectCorner.TopLeft | UIRectCorner.TopRight, new CoreGraphics.CGSize(8, 8));
            var shapeLayerAll = new CAShapeLayer();
            shapeLayerAll.Frame = cell.Bounds;
            //shapeLayerAll.BorderWidth = 3;
            //shapeLayerAll.BorderColor = VM.RedColor.ToNativeColor().CGColor;
            shapeLayerAll.Path = maskPathAll.CGPath;

            cell.Layer.Mask = shapeLayerAll;

            shadowView.AddSubview(cell);
            View.Add(shadowView);

        }

    }
}