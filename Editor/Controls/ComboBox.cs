using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

namespace UnityForms.Controls
{
    public class ComboBox : SelectableContainer
    {
        protected override void OnPaint()
        {
            SelectedIndex = EditorGUILayout.Popup(SelectedIndex, Childs.Select( c => c.Text).ToArray());
        }
    }
   
}