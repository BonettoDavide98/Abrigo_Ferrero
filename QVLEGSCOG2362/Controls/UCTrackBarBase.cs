using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace QVLEGSCOG2362
{
    public partial class UCTrackBarBase : UserControl
    {

        public event EventHandler ValueChanged;

        private string descrizione;
        public string Descrizione
        {
            get { return this.descrizione; }
            set
            {
                this.descrizione = value;
                if (this.descrizione.Length <= 0)
                {
                    this.eA = false;
                }
                else
                {
                    this.eA = true;
                }
                this.C();
            }
        }

        public int Minimum { get; set; }
        public int Maximum { get; set; }

        private int valueMin;
        public int ValueMin
        {
            get { return this.valueMin; }
            set
            {
                this.valueMin = value;
                this.C();
            }
        }

        private int valueMax;
        public int ValueMax
        {
            get { return this.valueMax; }
            set
            {
                this.valueMax = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        public int StepDisplayValue { get; set; }

        public int PosizioneBarra { get; set; }

        public int PosizioneStep { get; set; }

        public int DimensioneBarra { get; set; }

        private int dimensioneFreccia;
        public int DimensioneFreccia
        {
            get { return this.dimensioneFreccia; }
            set
            {
                this.dimensioneFreccia = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        public int Margine { get; set; }

        public int MinDifferenzaMaxMin;

        private bool visualizzaStep;

        public bool VisualizzaStep
        {
            get { return this.visualizzaStep; }
            set
            {
                this.visualizzaStep = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        public bool UsaDoppioValore { get; set; }

        private bool visuaizzaValori;
        public bool VisuaizzaValori
        {
            get { return this.visuaizzaValori; }
            set
            {
                this.visuaizzaValori = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private Color primoColore;
        public Color PrimoColore
        {
            get { return this.primoColore; }
            set
            {
                this.primoColore = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private Color secondoColore;
        public Color SecondoColore
        {
            get { return this.secondoColore; }
            set
            {
                this.secondoColore = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private bool coloraTutto;
        public bool ColoraTutto
        {
            get { return this.coloraTutto; }
            set
            {
                this.coloraTutto = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private bool coloraHue;
        public bool ColoraHue
        {
            get { return this.coloraHue; }
            set
            {
                this.coloraHue = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private UCTrackBarBase.Rotazione rotazioneStep;
        public UCTrackBarBase.Rotazione RotazioneStep
        {
            get { return this.rotazioneStep; }
            set
            {
                this.rotazioneStep = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private UCTrackBarBase.TipoDisegno disegno;
        public UCTrackBarBase.TipoDisegno Disegno
        {
            get { return this.disegno; }
            set
            {
                this.disegno = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private UCTrackBarBase.FormaCursore cursoreMinimo;
        public UCTrackBarBase.FormaCursore CursoreMinimo
        {
            get { return this.cursoreMinimo; }
            set
            {
                this.cursoreMinimo = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }

        private UCTrackBarBase.FormaCursore cursoreMassimo;
        public UCTrackBarBase.FormaCursore CursoreMassimo
        {
            get { return this.cursoreMassimo; }
            set
            {
                this.cursoreMassimo = value;
                if (base.IsHandleCreated)
                {
                    base.Invalidate();
                }
            }
        }



        private bool eA;

        private UCTrackBarBase.f k;

        private int p = 10;

        private Point[] q;

        private bool r;

        private bool s;





        private int valueMinMemo = -1;
        private int valueMaxMemo = -1;



        public UCTrackBarBase()
        {
            InitializeComponent();

            this.q = new Point[5];

            this.descrizione = "";

            this.PosizioneStep = 35;
            this.PosizioneBarra = 20;
            this.DimensioneBarra = 8;
            this.dimensioneFreccia = 6;

            this.Margine = 20;

            this.Minimum = 0;
            this.Maximum = 100;

            this.ValueMin = 0;
            this.ValueMax = 100;

            this.MinDifferenzaMaxMin = 0;

            this.visualizzaStep = true;
            this.UsaDoppioValore = true;

            this.rotazioneStep = Rotazione.Zero;
            this.disegno = UCTrackBarBase.TipoDisegno.Interno;
        }





        public void IncrementMin(int inc)
        {
            int v = this.ValueMin;
            if (v + inc > this.ValueMax)
            {
                this.ValueMin = this.ValueMax - this.MinDifferenzaMaxMin;
            }
            else
            {
                this.ValueMin = v + inc;
            }
        }

        public void DecrementMin(int inc)
        {
            int v = this.ValueMin;
            if (v - inc < this.Minimum)
            {
                this.ValueMin = this.Minimum;
            }
            else
            {
                this.ValueMin = v - inc;
            }
        }

        public void IncrementMax(int inc)
        {
            int v = this.ValueMax;
            if (v + inc > this.Maximum)
            {
                this.ValueMax = this.Maximum;
            }
            else
            {
                this.ValueMax = v + inc;
            }
        }

        public void DecrementMax(int inc)
        {
            int v = this.ValueMax;
            if (v - inc < this.ValueMin)
            {
                this.ValueMax = this.ValueMin + this.MinDifferenzaMaxMin;
            }
            else
            {
                this.ValueMax = v - inc;
            }
        }







        public void A(UCTrackBarBase.f A_0)
        {
            this.k = A_0;
        }

        private void A(Graphics A_0)
        {
            int num;
            SizeF sizeF;
            int num1 = this.B();
            int num2 = this.A(this.valueMin);
            num = (!this.UsaDoppioValore ? 0 : this.A(this.valueMax));
            this.p = base.Width - 2 * this.Margine;
            Pen pen = new Pen(SystemColors.ButtonShadow);
            Pen pen1 = new Pen(SystemColors.ButtonHighlight);
            A_0.Clear(SystemColors.Control);

            if (coloraTutto)
            {
                if (!coloraHue)//due colori
                {
                    LinearGradientBrush gradientBrush1 = new LinearGradientBrush(this.ClientRectangle, this.primoColore, this.secondoColore, LinearGradientMode.Horizontal);

                    ColorBlend cblend1 = new ColorBlend(2);
                    cblend1.Colors = new Color[2] { this.primoColore, this.secondoColore };
                    cblend1.Positions = new float[2] { 0f, 1f };

                    gradientBrush1.InterpolationColors = cblend1;

                    A_0.FillRectangle(gradientBrush1, this.ClientRectangle);
                }
                else//spettro della h (hue)
                {
                    LinearGradientBrush gradientBrush1 = new LinearGradientBrush(this.ClientRectangle, Color.Red, Color.Red, LinearGradientMode.Horizontal);

                    ColorBlend cblend1 = new ColorBlend(361);
                    cblend1.Colors = new Color[361];
                    cblend1.Positions = new float[361];

                    for (int i = 0; i < 361; i++)
                    {
                        HsvToRgb(i, 1, 1, out int red, out int green, out int blue);

                        Color rgb = Color.FromArgb(red, green, blue);

                        cblend1.Colors[i] = rgb;
                        cblend1.Positions[i] = (i * 1f) / 360;
                    }

                    gradientBrush1.InterpolationColors = cblend1;

                    A_0.FillRectangle(gradientBrush1, this.ClientRectangle);
                }
            }

            string str = this.descrizione;
            if (this.eA && !this.visuaizzaValori)
            {
                A_0.DrawString(str, this.Font, Brushes.Black, new PointF(0f, 0f));
            }
            if (this.visuaizzaValori)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("      ");
                stringBuilder.Append(str);
                stringBuilder.Append("   ");
                stringBuilder.Append(this.valueMin);
                if (this.UsaDoppioValore)
                {
                    stringBuilder.Append("   ");
                    stringBuilder.Append(this.valueMax);
                }
                if (!base.Enabled)
                {
                    A_0.DrawString(stringBuilder.ToString(), this.Font, Brushes.DarkGray, new PointF(0f, 0f));
                }
                else
                {
                    A_0.DrawString(stringBuilder.ToString(), this.Font, Brushes.Black, new PointF(0f, 0f));
                }
            }
            if (this.StepDisplayValue > 0)
            {
                for (int i = this.Minimum; i <= this.Maximum; i += this.StepDisplayValue)
                {
                    int num3 = this.A(i);
                    A_0.DrawLine(pen, num3, this.PosizioneBarra + 3, num3, this.PosizioneBarra + 5);
                }
                if (this.visualizzaStep)
                {
                    if (this.rotazioneStep == UCTrackBarBase.Rotazione.Zero)
                    {
                        for (int j = this.Minimum; j <= this.Maximum; j += this.StepDisplayValue)
                        {
                            int num4 = this.A(j);
                            string str1 = j.ToString();
                            sizeF = A_0.MeasureString(str1, this.Font);
                            int width = (int)sizeF.Width;
                            if (!base.Enabled)
                            {
                                A_0.DrawString(j.ToString(), this.Font, Brushes.DarkGray, (float)(num4 - width / 2), (float)this.PosizioneStep);
                            }
                            else
                            {
                                A_0.DrawString(j.ToString(), this.Font, Brushes.Black, (float)(num4 - width / 2), (float)this.PosizioneStep);
                            }
                        }
                    }
                    else if (this.rotazioneStep == UCTrackBarBase.Rotazione.Novanta)
                    {
                        A_0.RotateTransform(-90f);
                        int num5 = 0;
                        sizeF = A_0.MeasureString("  ", this.Font);
                        int height = (int)sizeF.Height;
                        for (int k = this.Minimum; k <= this.Maximum; k += this.StepDisplayValue)
                        {
                            sizeF = A_0.MeasureString(k.ToString(), this.Font);
                            int width1 = (int)sizeF.Width;
                            if (width1 > num5)
                            {
                                num5 = width1;
                            }
                        }
                        for (int l = this.Minimum; l <= this.Maximum; l += this.StepDisplayValue)
                        {
                            int num6 = this.A(l);
                            l.ToString();
                            if (!base.Enabled)
                            {
                                A_0.DrawString(l.ToString(), this.Font, Brushes.DarkGray, (float)(-this.PosizioneStep - num5), (float)num6 - (float)height * 0.5f);
                            }
                            else
                            {
                                A_0.DrawString(l.ToString(), this.Font, Brushes.Black, (float)(-this.PosizioneStep - num5), (float)num6 - (float)height * 0.5f);
                            }
                        }
                    }
                }
            }
            A_0.ResetTransform();
            if (this.disegno == UCTrackBarBase.TipoDisegno.Nessuno || !this.UsaDoppioValore)
            {
                A_0.DrawLine(pen, this.Margine, this.PosizioneBarra, this.Margine + this.p, this.PosizioneBarra);
                A_0.DrawLine(pen1, this.Margine, this.PosizioneBarra + this.DimensioneBarra + 2, this.Margine + this.p, this.PosizioneBarra + this.DimensioneBarra + 2);
            }
            else if (this.disegno == UCTrackBarBase.TipoDisegno.Esterno)
            {
                A_0.DrawLine(pen, this.Margine, this.PosizioneBarra, this.Margine + this.p, this.PosizioneBarra);
                A_0.DrawLine(pen1, this.Margine, this.PosizioneBarra + this.DimensioneBarra + 2, this.Margine + this.p, this.PosizioneBarra + this.DimensioneBarra + 2);

                if (!coloraTutto)
                {
                    if (!base.Enabled)
                    {
                        A_0.FillRectangle(Brushes.Gray, this.Margine, this.PosizioneBarra + 1, num2 - this.Margine, this.DimensioneBarra);
                        A_0.FillRectangle(Brushes.Gray, num, this.PosizioneBarra + 1, this.p - num + this.Margine, this.DimensioneBarra);
                    }
                    else
                    {
                        A_0.FillRectangle(Brushes.LightGreen, this.Margine, this.PosizioneBarra + 1, num2 - this.Margine, this.DimensioneBarra);
                        A_0.FillRectangle(Brushes.LightGreen, num, this.PosizioneBarra + 1, this.p - num + this.Margine, this.DimensioneBarra);
                    }
                }
                else
                {
                    A_0.FillRectangle(Brushes.Transparent, this.Margine, this.PosizioneBarra + 1, num2 - this.Margine, this.DimensioneBarra);
                    A_0.FillRectangle(Brushes.Transparent, num, this.PosizioneBarra + 1, this.p - num + this.Margine, this.DimensioneBarra);
                }
            }
            else if (this.disegno == UCTrackBarBase.TipoDisegno.Interno)
            {
                A_0.DrawLine(pen, this.Margine, this.PosizioneBarra, this.Margine + this.p, this.PosizioneBarra);
                A_0.DrawLine(pen1, this.Margine, this.PosizioneBarra + this.DimensioneBarra + 2, this.Margine + this.p, this.PosizioneBarra + this.DimensioneBarra + 2);

                if (!coloraTutto)
                {
                    if (!base.Enabled)
                    {
                        A_0.FillRectangle(Brushes.Gray, num2, this.PosizioneBarra + 1, num - num2, this.DimensioneBarra);
                    }
                    else
                    {
                        A_0.FillRectangle(Brushes.LightGreen, num2, this.PosizioneBarra + 1, num - num2, this.DimensioneBarra);
                    }
                }
                else
                {
                    A_0.FillRectangle(Brushes.Transparent, num2, this.PosizioneBarra + 1, num - num2, this.DimensioneBarra);
                }
            }

            if (!this.r)
            {
                this.A(this.cursoreMinimo, A_0, num2, num1, Brushes.Blue);
            }
            else
            {
                this.A(this.cursoreMinimo, A_0, num2, num1, Brushes.Green);
            }
            if (this.UsaDoppioValore)
            {
                if (!this.s)
                {
                    this.A(this.cursoreMassimo, A_0, num, num1, Brushes.Blue);
                }
                else
                {
                    this.A(this.cursoreMassimo, A_0, num, num1, Brushes.Green);
                }
            }
            pen.Dispose();
            pen1.Dispose();
        }

        private void A(UCTrackBarBase.FormaCursore A_0, Graphics A_1, int A_2, int A_3, Brush A_4)
        {
            Rectangle rectangle;
            if (this.dimensioneFreccia == 0)
            {
                this.dimensioneFreccia = 1;
            }
            switch (A_0)
            {
                case UCTrackBarBase.FormaCursore.Rombo:
                    {
                        rectangle = new Rectangle(A_2 - this.dimensioneFreccia, A_3 - this.dimensioneFreccia, this.dimensioneFreccia * 2, this.dimensioneFreccia * 2);
                        this.q = new Point[] { new Point(A_2, this.dimensioneFreccia + A_3), new Point(this.dimensioneFreccia + A_2, A_3), new Point(A_2, -this.dimensioneFreccia + A_3), new Point(-this.dimensioneFreccia + A_2, A_3), new Point(A_2, this.dimensioneFreccia + A_3) };
                        this.A(A_1, this.q, rectangle);
                        return;
                    }
                case (UCTrackBarBase.FormaCursore)1:
                    {
                        return;
                    }
                case UCTrackBarBase.FormaCursore.Cerchio:
                    {
                        rectangle = new Rectangle(A_2 - this.dimensioneFreccia, A_3 - this.dimensioneFreccia, this.dimensioneFreccia * 2, this.dimensioneFreccia * 2);
                        this.A(A_1, rectangle);
                        return;
                    }
                case UCTrackBarBase.FormaCursore.FrecciaSinistra:
                    {
                        this.q = new Point[] { new Point(A_2, this.dimensioneFreccia + A_3), new Point(A_2, -this.dimensioneFreccia + A_3), new Point(-this.dimensioneFreccia + A_2, A_3), new Point(A_2, this.dimensioneFreccia + A_3) };
                        A_1.FillPolygon(Brushes.Green, this.q);
                        return;
                    }
                case UCTrackBarBase.FormaCursore.FrecciaDestra:
                    {
                        this.q = new Point[] { new Point(A_2, this.dimensioneFreccia + A_3), new Point(this.dimensioneFreccia + A_2, A_3), new Point(A_2, -this.dimensioneFreccia + A_3), new Point(A_2, this.dimensioneFreccia + A_3) };
                        A_1.FillPolygon(Brushes.Green, this.q);
                        return;
                    }
                case UCTrackBarBase.FormaCursore.Linea:
                    {
                        rectangle = new Rectangle(A_2 - this.dimensioneFreccia, A_3 - this.dimensioneFreccia, this.dimensioneFreccia, this.dimensioneFreccia * 2);
                        this.CreaRettangolo(A_1, rectangle);
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }

        private void A(Graphics A_0, Point[] A_1, Rectangle A_2)
        {
            Color darkBlue = Color.DarkBlue;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(A_2, darkBlue, Color.White, -135f);
            Blend blend = new Blend()
            {
                Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f },
                Factors = new float[] { 0f, 0f, 0.2f, 0.6f, 0.8f, 1f }
            };
            linearGradientBrush.Blend = blend;
            A_0.FillPolygon(linearGradientBrush, A_1);
        }

        private void A(Graphics A_0, Rectangle A_1)
        {
            Color darkBlue = Color.DarkBlue;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(A_1, darkBlue, Color.White, -135f);
            Blend blend = new Blend()
            {
                Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f },
                Factors = new float[] { 0f, 0f, 0.2f, 0.6f, 0.8f, 1f }
            };
            linearGradientBrush.Blend = blend;
            this.A(A_0, linearGradientBrush, A_1);
        }

        private void CreaRettangolo(Graphics A_0, Rectangle A_1)
        {
            Color darkBlue = Color.DarkBlue;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(A_1, darkBlue, Color.White, -135f);
            Blend blend = new Blend()
            {
                Positions = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f },
                Factors = new float[] { 0f, 0f, 0.2f, 0.6f, 0.8f, 1f }
            };
            linearGradientBrush.Blend = blend;

            A_0.FillRectangle(linearGradientBrush, A_1);
            //this.A(A_0, linearGradientBrush, A_1);
        }

        protected virtual void A(Graphics A_0, object A_1, Rectangle A_2)
        {
            if (A_1 is LinearGradientBrush)
            {
                A_0.FillEllipse((LinearGradientBrush)A_1, A_2);
                return;
            }
            if (A_1 is PathGradientBrush)
            {
                A_0.FillEllipse((PathGradientBrush)A_1, A_2);
            }
        }

        private int A(int A_0)
        {
            int num;
            float a0 = (float)(A_0 - this.Minimum);
            num = (a0 != 0f ? (int)((float)this.Margine + (float)this.p * a0 / (float)(this.Maximum - this.Minimum)) : this.Margine);
            return num;
        }

        private bool A(int A_0, int A_1)
        {
            //int num = this.A(this.valueMax);
            //if (A_0 >= num && A_0 <= num + this.dimensioneFreccia && A_1 >= this.PosizioneBarra && A_1 <= this.PosizioneBarra + this.dimensioneFreccia)
            //{
            //    return true;
            //}
            //return false;

            int num = this.A(this.valueMax);
            if (A_0 >= num - this.dimensioneFreccia && A_0 <= num + this.dimensioneFreccia)
            {
                int num1 = this.B();
                if (A_1 >= num1 - this.dimensioneFreccia && A_1 <= num1 + this.dimensioneFreccia)
                {
                    return true;
                }
            }
            return false;
        }

        private void MouseMoveEvent(object A_0, MouseEventArgs A_1)
        {
            int num = this.valueMin;
            int num1 = this.valueMax;
            if (this.r)
            {
                float x = (float)(A_1.X - this.Margine);
                if (x != 0f)
                {
                    float single = (float)(this.Maximum - this.Minimum);
                    this.valueMin = (int)Math.Round((double)((float)this.Minimum + x / (float)this.p * single));
                }
                else
                {
                    this.valueMin = this.Minimum;
                }
                if (this.UsaDoppioValore && this.valueMax - this.valueMin < this.MinDifferenzaMaxMin)
                {
                    this.valueMin = this.valueMax - this.MinDifferenzaMaxMin;
                }
                if (this.valueMin < this.Minimum)
                {
                    this.valueMin = this.Minimum;
                }
                if (this.valueMin > this.Maximum)
                {
                    this.valueMin = this.Maximum;
                }
            }
            if (this.UsaDoppioValore && this.s)
            {
                float x1 = (float)(A_1.X - this.Margine);
                if (x1 != 0f)
                {
                    float single1 = (float)(this.Maximum - this.Minimum);
                    this.valueMax = (int)Math.Round((double)((float)this.Minimum + x1 / (float)this.p * single1));
                }
                else
                {
                    this.valueMax = this.Minimum;
                }
                if (this.valueMax < this.Minimum)
                {
                    this.valueMax = this.Minimum;
                }
                if (this.valueMax > this.Maximum)
                {
                    this.valueMax = this.Maximum;
                }
                if (this.valueMax - this.valueMin < this.MinDifferenzaMaxMin || this.valueMax < this.valueMin)
                {
                    this.valueMax = this.valueMin + this.MinDifferenzaMaxMin;
                }
            }
            if (this.valueMin != num || this.valueMax != num1)
            {
                this.C();
                this.B(this.valueMin);
            }
        }

        private void B(int A_0)
        {
            //if (this.aa != null)
            //{
            //    this.A(this, new ad().A(A_0, this.N()));
            //}
        }

        private int B()
        {
            return (int)((float)this.PosizioneBarra + (float)this.DimensioneBarra * 0.5f);
        }

        private bool B(int A_0, int A_1)
        {
            int num = this.A(this.valueMin);
            if (A_0 >= num - this.dimensioneFreccia && A_0 <= num + this.dimensioneFreccia)
            {
                int num1 = this.B();
                if (A_1 >= num1 - this.dimensioneFreccia && A_1 <= num1 + this.dimensioneFreccia)
                {
                    return true;
                }
            }
            return false;
        }

        private void MouseUpEvent(object A_0, MouseEventArgs A_1)
        {
            this.r = false;
            this.s = false;
            this.C();

            if (this.valueMinMemo != this.valueMin || this.valueMaxMemo != this.valueMax)
            {
                EventHandler eh = ValueChanged;
                if (eh != null)
                {
                    eh(this, new EventArgs());
                }
            }
        }

        private void C()
        {
            Graphics graphic = base.CreateGraphics();
            this.A(graphic);
            graphic.Dispose();
        }

        private void MouseDownEvent(object A_0, MouseEventArgs A_1)
        {
            this.valueMinMemo = this.valueMin;
            this.valueMaxMemo = this.valueMax;

            if (!this.B(A_1.X, A_1.Y))
            {
                this.r = false;
            }
            else
            {
                this.r = true;
                this.s = false;
            }
            if (!this.UsaDoppioValore)
            {
                this.s = false;
            }
            else if (!this.A(A_1.X, A_1.Y))
            {
                this.s = false;
            }
            else
            {
                this.s = true;
                this.r = false;
            }
            if (this.r || this.s)
            {
                this.C();
            }
        }

        public void D(int A_0)
        {
            this.valueMax = A_0;
            this.R();
        }

        public void G(int A_0)
        {
            this.valueMin = A_0;
            this.R();
        }

        public UCTrackBarBase.f I()
        {
            return this.k;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.A(e.Graphics);
        }

        public void R()
        {
            if (!base.InvokeRequired)
            {
                this.C();
                return;
            }
            UCTrackBarBase.c _c = new UCTrackBarBase.c(this.R);
            base.Invoke(_c, new object[0]);
        }

        public class a : EventArgs
        {
            public int aAAAA;

            public int b;

            public a(int A_0, int A_1)
            {
                this.aAAAA = A_0;
                this.b = A_1;
            }
        }

        public enum TipoDisegno
        {
            Nessuno,
            Interno,
            Esterno
        }

        private delegate void c();

        public enum FormaCursore
        {
            Rombo = 0,
            Cerchio = 2,
            FrecciaSinistra = 3,
            FrecciaDestra = 4,
            Linea = 5
        }

        public delegate void e(object A_0, UCTrackBarBase.a A_1);

        public struct f
        {
            public float a;

            public float b;
        }

        public enum Rotazione
        {
            Zero,
            Novanta
        }

        private void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
    }
}
