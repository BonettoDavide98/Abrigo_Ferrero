using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QVLEGSCOG2362.Pagine.SottoPagine
{
    public partial class UCPaginaSelezionePattern : UserControl
    {
        public UCPaginaSelezionePattern()
        {
            InitializeComponent();

            nudRows.Increment = 1;
            nudColumns.Increment = 1;
        }

        private void InitializePattern()
        {
            int rows = (int)nudRows.Value;
            int columns = (int)nudColumns.Value;

            TableLayoutPanel tlpContainer = new TableLayoutPanel()
            {
                RowCount = rows,
                ColumnCount = 1,
                Dock = DockStyle.Fill
            };
        }
    }
}
