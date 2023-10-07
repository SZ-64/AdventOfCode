namespace Common.Grid
{
    /// <summary>
    /// Class holding data representing a single light in a matrix.
    /// </summary>
    public class Light
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOn { get; set; }
        public int Brightness { get; set; }

        public Light (int x, int y)
        {
            X = x;
            Y = y;
            IsOn = false;
            Brightness = 0;
        }
    }
}
