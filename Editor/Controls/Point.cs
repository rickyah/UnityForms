using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms
{
        
        public struct Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public Point(Point pos)
            {
                this.X = pos.X;
                this.Y = pos.Y;
            }
            public Point(Vector2 pos)
            {
                this.X = (int)pos.x;
                this.Y = (int)pos.y;
            }
            
            public int X;
            public int Y;
        }
    
}