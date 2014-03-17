using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEditor;

using UnityForms.Layouts;

namespace UnityForms
{
    public class RadioButtonGroup : ListControl
    {    
        protected override void BindItemEvents()
        {
            this.ControlAdded += (object thisGroup, ControlEventArgs addedCtrlArgs) => {
                var ctrl = addedCtrlArgs.Control as RadioButton;
                if(ctrl != null) 
                {
                    ctrl.CheckedChanged += (object sender, EventArgs changedArgs) => {
                        var senderRadioButton = sender as RadioButton;
                        if (senderRadioButton.Checked)
                        {
                            UpdateIndexes(Controls.IndexOf(senderRadioButton as Control));
                        }
                    };
                }
            };
        }
        
        protected void UpdateIndexes(int newSelectedIndex)
        {
            var oldRb = Controls[SelectedIndex] as RadioButton;
            var newRb = Controls[newSelectedIndex] as RadioButton;
            
            if (oldRb != null) oldRb.SetChecked(false);
            if (newRb != null) newRb.SetChecked(true);
            
            SelectedIndex = newSelectedIndex;
        }
    }
}