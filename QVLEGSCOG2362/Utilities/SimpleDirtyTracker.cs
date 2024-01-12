using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Utilities
{
    public class SimpleDirtyTracker
    {

        private bool _isDirty;
        private List<Control> NoModificaList = null;

        // property denoting whether the tracked form is clean or dirty
        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
        public bool Enabled { get; set; }
        // methods to make dirty or clean
        public void SetAsDirty()
        {
            _isDirty = true;
        }

        public void SetAsClean()
        {
            _isDirty = false;
        }

        // initialize in the constructor by assigning event handlers
        public SimpleDirtyTracker(Control.ControlCollection coll) : this(coll, null) { }

        // initialize in the constructor by assigning event handlers
        public SimpleDirtyTracker(Control.ControlCollection coll, params Control[] noModifica)
        {
            if (noModifica != null)
                NoModificaList = noModifica.ToList();

            this.Enabled = true;

            AssignHandlersForControlCollection(coll);
        }

        private bool IsDirtyControl(Control c)
        {
            bool ret = true;
            if (NoModificaList != null)
            {
                ret = !NoModificaList.Contains(c);
            }

            return ret;
        }

        // recursive routine to inspect each control and assign handlers accordingly
        private void AssignHandlersForControlCollection(Control.ControlCollection coll)
        {
            if (coll != null)
                foreach (Control c in coll)
                {
                    string name = c.Name;
                    if (IsDirtyControl(c))
                    {
                        if (c is NumericUpDown)
                        {
                            (c as NumericUpDown).ValueChanged += SimpleDirtyTracker_ValueChanged;
                        }

                        if (c is CheckBox)
                        {
                            (c as CheckBox).CheckedChanged += SimpleDirtyTracker_CheckedChanged;
                        }

                        // recurively apply to inner collections
                        if (c.HasChildren)
                            AssignHandlersForControlCollection(c.Controls);
                    }
                }
        }

        private void SimpleDirtyTracker_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                CheckBox c = (CheckBox)sender;
                string name = c.Name;

                _isDirty = true;
            }
        }

        private void SimpleDirtyTracker_ValueChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                NumericUpDown c = (NumericUpDown)sender;
                string name = c.Name;

                _isDirty = true;
            }
        }

    }
}
