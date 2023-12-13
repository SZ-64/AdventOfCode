namespace Day7
{
    public class Gate
    {
        public List<Gate> Inputs { get; set; }
        public Operations Operation { get; set; }
        public int Argument { get; set; }
        public ushort Value { get; set; }

        public Gate()
        {
            Inputs = new List<Gate>();
            Operation = Operations.PASSTHROUGH;
            Argument = 0;
            Value = 0;
        }

        public Gate(Operations op)
        {
            Inputs = new List<Gate>();
            Operation = op;
            Argument = 0;
            Value = 0;
        }

        public Gate(ushort value)
        {
            Inputs = new List<Gate>();
            Operation = Operations.PASSTHROUGH;
            Argument = 0;
            Value = value;
        }
    }
}
