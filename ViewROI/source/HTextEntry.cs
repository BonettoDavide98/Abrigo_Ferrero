namespace ViewROI
{
    public class HTextEntry
    {

        public string Font { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }

        public HTextEntry(string font, int row, int column, string color, string text)
        {
            this.Font = font;
            this.Row = row;
            this.Column = column;
            this.Color = color;
            this.Text = text;
        }

    }
}