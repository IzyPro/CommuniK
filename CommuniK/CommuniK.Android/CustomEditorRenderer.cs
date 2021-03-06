﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using CommuniK.Droid;
using CommuniK.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace CommuniK.Droid
{
    public class CustomEditorRenderer : EditorRenderer
    {
        //public static void init() { }
        public CustomEditorRenderer(Context context) : base(context) { }
        protected override void OnElementChanged (ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                //GradientDrawable gd = new GradientDrawable();
                //gd.SetColor(global::Android.Graphics.Color.Transparent);
                //this.Control.SetBackgroundDrawable(gd);
            }
        }
    }
}