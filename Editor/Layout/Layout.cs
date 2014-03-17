using UnityEngine;
using System;

namespace UnityForms.Layouts
{
    
    public static class Layout
    {
        public class OutlineLayoutHelper
        {
            public HorizontalLayout Horizontal 
            {
                get
                {
                    return new HorizontalLayout(GUI.skin.box);    
                }
            }
            
            public VerticalLayout Vertical 
            {
                get
                {
                    return new VerticalLayout(GUI.skin.box);    
                }
            }
        }
        
        public static OutlineLayoutHelper Outlined = new OutlineLayoutHelper();
        

        public static HorizontalLayout HorizontalWithStyle(GUIStyle style)
        {
        
            return new HorizontalLayout(style);
        
        }
        public static HorizontalLayout Horizontal 
        {
            get
            {
                return new HorizontalLayout();    
            }
        }
        
        public static VerticalLayout Vertical 
        {
            get
            {
                return new VerticalLayout();    
            }
        }
    }
    
}