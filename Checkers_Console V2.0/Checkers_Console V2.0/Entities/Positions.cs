
namespace Checkers_Console_V2._0.Entities
{
    class Positions
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Positions(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public static Positions ReadString_ReturnPosition(string s)
        {
            return new Positions(int.Parse(s[0] + ""), int.Parse(s[1] + ""));
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
