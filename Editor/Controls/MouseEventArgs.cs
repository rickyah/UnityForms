using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms
{
    
    public class MouseEventArgs : EventArgs
        {
            public MouseEventArgs(int button, Vector2 location, int clicks)
            {
                this.Button = (MouseButton)button;
                this.Clicks = clicks;
                this.Location = new Point(location);
                this.Delta = 0;
            }
            
            public MouseButton Button;
            public int Clicks;
            public int Delta;
            public Point Location;
            public int X { get { return Location.X;} }
            public int Y { get { return Location.Y;} }
        }
    
}