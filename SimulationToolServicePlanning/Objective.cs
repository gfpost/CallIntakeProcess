namespace Simulator
{
    public class Objective
    {
        public long First;
        public long Second;
        public long Third;
        public long Fourth;

        public bool IsBetterThanOther(Objective other)
        {
            if (First != other.First)
                return First < other.First;

            if (Second != other.Second)
                return Second < other.Second;

            if (Third != other.Third)
                return Third < other.Third;

            return Fourth < other.Fourth;
        }

        public bool IsSame(Objective other)
        {
            return First == other.First && Second == other.Second && Third == other.Third && Fourth == other.Fourth;
        }

        public Objective(long first)
        {
            First = first;
        }

        public Objective(long first, long second)
        {
            First = first;
            Second = second;
        }

        public Objective(long first, long second, long third, long fourth = 0)
        {
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
        }

        public override string ToString()
        {
            return $"{First}; {Second}; {Third}; {Fourth}";
        }
    }
}
