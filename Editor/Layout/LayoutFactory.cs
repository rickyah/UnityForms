using System;
using UnityEngine;

namespace UnityForms.Layouts
{
    public static class LayoutFactory
    {
        private static T GetLayout<T>(params object[] ctorParams) where T : Layout
        {
            var layoutInstance = (T)Activator.CreateInstance(typeof(T), ctorParams);
            layoutInstance.BeginLayout();
            return layoutInstance;
        }

        public class OutlineLayoutHelper
        {
            public HorizontalLayout Horizontal
            {
                get
                {
                    return GetLayout<HorizontalLayout>(GUI.skin.box);
                }
            }

            public VerticalLayout Vertical
            {
                get
                {
                    return GetLayout<VerticalLayout>(GUI.skin.box);
                }
            }
        }

        public static OutlineLayoutHelper Outlined = new OutlineLayoutHelper();

        public static HorizontalLayout HorizontalWithStyle(GUIStyle style)
        {
        
            return GetLayout<HorizontalLayout>(style);
        
        }

        public static HorizontalLayout Horizontal
        {
            get
            {
                return GetLayout<HorizontalLayout>();    
            }
        }

        public static VerticalLayout Vertical
        {
            get
            {
                return GetLayout<VerticalLayout>();    
            }
        }
    }
}