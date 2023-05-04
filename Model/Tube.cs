namespace TfL_Walking_Distance_Version3.Model
{
    internal class Tube
    {
        public string SourceRoute { get; set; }
        public string DestinationRoute { get; set; }
        public int NormalTime { get; set; }
        public string TubeName { get; set; }
        public int Delay { get; set; }
        public STATUS Status { get; set; }

        public string DelayReason { get; set; }
        public Tube(string sourceRoute, string destinationRoute, int norTime, string name)
        {
            SourceRoute = sourceRoute;
            DestinationRoute = destinationRoute;
            NormalTime = norTime;
            TubeName = name;
            Delay = 0;
            Status = STATUS.Open;
            DelayReason = "";
        }

        public int RouteTime()
        {
            int tm = this.NormalTime + this.Delay;

            return tm;
        }
    }
}
