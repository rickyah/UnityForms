using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using UnityEngine;
using UnityEditor;

namespace UnityForms.Primitives
{
    public static class Draww
    {
        public static void RectangleOutline(Rect rect)
        {
            RectangleOutline(rect, Color.black);
        }
        
        public static void RectangleOutline(Rect rect, Color color)
        {
            Handles.color = color;
            
            Handles.BeginGUI();
       
            Handles.DrawLine( 
                new Vector3(rect.x, rect.y), 
                new Vector3(rect.x  + rect.width, rect.y));
                
            Handles.DrawLine( 
                new Vector3(rect.x, rect.y), 
                new Vector3(rect.x, rect.y + rect.height));
                
            Handles.DrawLine( 
                new Vector3(rect.x + rect.width, rect.y), 
                new Vector3(rect.x + rect.width, rect.y  + rect.height));
                
            Handles.DrawLine( 
                new Vector3(rect.x, rect.y + rect.height), 
                new Vector3(rect.x  + rect.width, rect.y + rect.height));
            
            Handles.EndGUI();
        }
    }
    
}