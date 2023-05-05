namespace TfL_Walking_Distance_Version3.Model
{
    class TubeStation
    {
        private static int SID = 0;

        public int StationID { get; set; }

        public string Name { get; set; }

        public ACCESS StationAccess { get; set; }

        public int TravelZone { get; set; }

        public STATUS StationStatus { get; set; }

        public TubeStation(string Name,
                 ACCESS StationAccess, int TravelZone,
                 STATUS StationStatus)
        {
            StationID = SID++;
            this.Name = Name;
            this.StationAccess = StationAccess;
            this.TravelZone = TravelZone;
            this.StationStatus = StationStatus;
        }

        public TubeStation(string Name)
        {
            StationID = SID++;
            this.Name = Name;
            StationAccess = ACCESS.Escalator; ;
            TravelZone = 1;
            StationStatus = STATUS.Open;
        }

        public string ToString()
        {
            return "Station: [ " +
                                StationID.ToString() + ", " +
                                Name + ", " +
                                StationAccess.ToString() + ", " +
                                TravelZone.ToString() + ", " +
                                StationStatus.ToString() +
                            " ]"
                   ;
        }


    }
}
