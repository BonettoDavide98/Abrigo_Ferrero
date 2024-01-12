using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCTrackBar : UserControl
    {

        public event EventHandler ValueChanged;

        public string Descrizione { get { return ucTrackBarBase1.Descrizione; } set { ucTrackBarBase1.Descrizione = value; } }

        public int Minimum { get { return ucTrackBarBase1.Minimum; } set { ucTrackBarBase1.Minimum = value; SetMinMax(); } }
        public int Maximum { get { return ucTrackBarBase1.Maximum; } set { ucTrackBarBase1.Maximum = value; SetMinMax(); } }
        public int ValueMin { get { return ucTrackBarBase1.ValueMin; } set { ucTrackBarBase1.ValueMin = value; SetMinMax(); nudMin.Value = value; } }
        public int ValueMax { get { return ucTrackBarBase1.ValueMax; } set { ucTrackBarBase1.ValueMax = value; SetMinMax(); nudMax.Value = value; } }

        public int StepDisplayValue { get { return ucTrackBarBase1.StepDisplayValue; } set { ucTrackBarBase1.StepDisplayValue = value; } }
        public int PosizioneBarra { get { return ucTrackBarBase1.PosizioneBarra; } set { ucTrackBarBase1.PosizioneBarra = value; } }
        public int PosizioneStep { get { return ucTrackBarBase1.PosizioneStep; } set { ucTrackBarBase1.PosizioneStep = value; } }
        public int DimensioneBarra { get { return ucTrackBarBase1.DimensioneBarra; } set { ucTrackBarBase1.DimensioneBarra = value; } }
        public int DimensioneFreccia { get { return ucTrackBarBase1.DimensioneFreccia; } set { ucTrackBarBase1.DimensioneFreccia = value; } }
        public int Margine { get { return ucTrackBarBase1.Margine; } set { ucTrackBarBase1.Margine = value; } }
        public int MinDifferenzaMaxMin { get { return ucTrackBarBase1.MinDifferenzaMaxMin; } set { ucTrackBarBase1.MinDifferenzaMaxMin = value; } }
        public bool VisualizzaStep { get { return ucTrackBarBase1.VisualizzaStep; } set { ucTrackBarBase1.VisualizzaStep = value; } }
        public bool UsaDoppioValore { get { return ucTrackBarBase1.UsaDoppioValore; } set { ucTrackBarBase1.UsaDoppioValore = value; } }
        public bool VisuaizzaValori { get { return ucTrackBarBase1.VisuaizzaValori; } set { ucTrackBarBase1.VisuaizzaValori = value; } }
        public Color PrimoColore { get { return ucTrackBarBase1.PrimoColore; } set { ucTrackBarBase1.PrimoColore = value; } }
        public Color SecondoColore { get { return ucTrackBarBase1.SecondoColore; } set { ucTrackBarBase1.SecondoColore = value; } }
        public bool ColoraTutto { get { return ucTrackBarBase1.ColoraTutto; } set { ucTrackBarBase1.ColoraTutto = value; } }
        public bool ColoraHue { get { return ucTrackBarBase1.ColoraHue; } set { ucTrackBarBase1.ColoraHue = value; } }

        public UCTrackBarBase.Rotazione RotazioneStep { get { return ucTrackBarBase1.RotazioneStep; } set { ucTrackBarBase1.RotazioneStep = value; } }
        public UCTrackBarBase.TipoDisegno Disegno { get { return ucTrackBarBase1.Disegno; } set { ucTrackBarBase1.Disegno = value; } }
        public UCTrackBarBase.FormaCursore CursoreMinimo { get { return ucTrackBarBase1.CursoreMinimo; } set { ucTrackBarBase1.CursoreMinimo = value; } }
        public UCTrackBarBase.FormaCursore CursoreMassimo { get { return ucTrackBarBase1.CursoreMassimo; } set { ucTrackBarBase1.CursoreMassimo = value; } }


        public UCTrackBar()
        {
            InitializeComponent();
        }
        
        private void SetMinMax()
        {
            nudMin.Minimum = ucTrackBarBase1.Minimum;
            nudMin.Maximum = ucTrackBarBase1.ValueMax;


            nudMax.Minimum = ucTrackBarBase1.ValueMin;
            nudMax.Maximum = ucTrackBarBase1.Maximum;
        }

        private void ucTrackBarBase1_ValueChanged(object sender, EventArgs e)
        {
            SetMinMax();
            nudMin.Value = ucTrackBarBase1.ValueMin;
            nudMax.Value = ucTrackBarBase1.ValueMax;
            ValueChanged?.Invoke(this, e);
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            ucTrackBarBase1.ValueMin = (int)nudMin.Value;
            ucTrackBarBase1.ValueMax = (int)nudMax.Value;
            SetMinMax();
            ValueChanged?.Invoke(this, e);
        }

    }
}
