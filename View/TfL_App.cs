using System.Xml.Linq;
using TfL_Walking_Distance_Version3.Model;
using static System.Collections.Specialized.BitVector32;
using System.Diagnostics;

namespace TfL_Walking_Distance_Version3.View
{
    class TfL_App
    {
        protected List<Tube> routeRecords = new List<Tube>();
        protected List<TubeStation> stationRecords = new List<TubeStation>();
        protected Stopwatch timer = new Stopwatch();
        public TfL_App() { }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("**************************************");
            Console.WriteLine("******** TfL Walking Distance ********");
            Console.WriteLine("**************************************");
            Console.WriteLine("");

            Console.WriteLine("*     Welcome to TfL Application     *");
            Console.WriteLine("*     Check your walking distance    *");
            Console.WriteLine("");

         

            int j = 0;
            while(j < 1)
            {
                Console.WriteLine("Please press the option below:");
                Console.WriteLine("0. Customer");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Exit");
                Console.WriteLine("Enter option : ");
                string val = Console.ReadLine();
                if (val != null)
                {
                    try
                    {
                        int val1 = int.Parse(val);
                        if (val1 == 0 || val1 == 1 || val1 == 2)
                        {
                            Console.Clear();
                            if (val1 == 1)
                            {
                                Console.WriteLine("########################################");
                                Console.WriteLine("###     This is the Manager's Tab    ###");
                                Console.WriteLine("########################################");
                                
                                
                                int a = 0;
                                while (a < 1)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Please the option below");
                                    Console.WriteLine("1. Add Or Remove walking time delay to a Route");
                                    Console.WriteLine("2. Update Route Status");
                                    Console.WriteLine("3. Print list of Impossible Route");
                                    Console.WriteLine("4. Print list of Delayed Route");
                                    Console.WriteLine("5. Back");
                                    Console.WriteLine("Enter option : ");
                                    string val5 = Console.ReadLine();
                                    try
                                    {
                                        int val6 = int.Parse(val5);
                                        Console.Clear();
                                        switch (val6)
                                        {
                                            case 1:
                                                Console.WriteLine("Add Or Remove walking time (delay) to a Route");
                                                Console.WriteLine("Please enter source station");
                                                string stNameAddSt = Console.ReadLine();
                                                int x = 0;
                                                while (x < 1)
                                                {
                                                    if (CheckStation(stNameAddSt))
                                                    {
                                                        x++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Start Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        stNameAddSt = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("Please enter destination station");
                                                string stNameAddDt = Console.ReadLine();
                                                int y = 0;
                                                while (y < 1)
                                                {
                                                    if (CheckStation(stNameAddDt))
                                                    {
                                                        y++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Destination Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        stNameAddDt = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("");
                                                Console.WriteLine("Please input delay time");
                                                Console.WriteLine("To remove delay time -> Set time to 0");
                                                Console.WriteLine("To add delay time -> Set time to value");
                                                Console.WriteLine("Enter time : ");
                                                int z = 0;
                                                string stNameAddTt = Console.ReadLine();
                                                int stNameAddInt = 0;
                                                while (z < 1)
                                                {
                                                    try
                                                    {
                                                        stNameAddInt = int.Parse(stNameAddTt);
                                                        z++;
                                                    }
                                                    catch (SystemException ex)
                                                    {
                                                        Console.WriteLine("Execepetion Message: " + ex.Message);
                                                        Console.WriteLine("please input a valid value");
                                                        stNameAddTt = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("Reason for adding or removing");
                                                string stNameReason = Console.ReadLine();
                                                bool add = SetDelayTime(stNameAddSt, stNameAddDt, stNameAddInt, stNameReason);
                                                if (add)
                                                {
                                                    Console.WriteLine($"Delay {stNameAddInt} has been added to route {stNameAddSt} -> {stNameAddDt}");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Error adding delay");
                                                }
                                                Console.ReadLine();
                                                    break;
                                            case 2:
                                                Console.WriteLine("Update Route Status");
                                                Console.WriteLine("Please enter source station");
                                                string stNameRsSt = Console.ReadLine();
                                                int c = 0;
                                                while (c < 1)
                                                {
                                                    if (CheckStation(stNameRsSt))
                                                    {
                                                        c++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Start Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        stNameRsSt = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("Please enter destination station");
                                                string stNameRsDt = Console.ReadLine();
                                                int d = 0;
                                                while (d < 1)
                                                {
                                                    if (CheckStation(stNameRsDt))
                                                    {
                                                        d++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Destination Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        stNameRsDt = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("Please the option below to update station status");
                                                Console.WriteLine("1. Open");
                                                Console.WriteLine("2. Closed");
                                                Console.WriteLine("Enter Option");
                                                string stNameRsSs = Console.ReadLine();
                                                int stNameRsSsInt = 0;
                                                STATUS update = STATUS.Open;
                                                int e = 0;
                                                while (e < 1) 
                                                {
                                                    try
                                                    {
                                                        stNameRsSsInt = int.Parse(stNameRsSs);
                                                        if (stNameRsSsInt == 1)
                                                        {
                                                            update = STATUS.Open;
                                                            e++;
                                                        }
                                                        else if(stNameRsSsInt == 2)
                                                        {
                                                            update=STATUS.Closed;
                                                            e++;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Input number not valid");
                                                        }
                                                        
                                                    }
                                                    catch (SystemException ex)
                                                    {
                                                        Console.WriteLine("Execepetion Message: " + ex.Message);
                                                        Console.WriteLine("please input a valid value");
                                                        stNameRsSs = Console.ReadLine();
                                                    }
                                                    bool rsUpdate = SetRouteUpdate(stNameRsSt, stNameRsDt, update);
                                                    if (rsUpdate)
                                                    {
                                                        Console.WriteLine($"Status updated {update} has been added to route {stNameRsSt} -> {stNameRsDt}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Error updating route");
                                                    }
                                                }
                                                Console.ReadLine();
                                                break;
                                            case 3:
                                                Console.WriteLine("Print list of Impossible Route");
                                                PrintImposible();
                                                Console.ReadLine();
                                                break;
                                            case 4:
                                                Console.WriteLine("Print list of Delayed Route");
                                                PrintDelayed();
                                                Console.ReadLine();
                                                break;
                                            case 5:
                                                a++;
                                                break;
                                            default:
                                                Console.WriteLine("Please enter number within range");
                                                break;
                                        }
                                    }
                                    catch (SystemException ex)
                                    {
                                        Console.WriteLine("Execepetion Message: " + ex.Message);
                                        Console.WriteLine("please input a valid value");
                                    }
                                }
                            }
                            else if (val1 == 0)
                            {
                                Console.WriteLine("########################################");
                                Console.WriteLine("###     This is the Customer's Tab   ###");
                                Console.WriteLine("########################################"); 
                                int b = 0;
                                while (b < 1)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Please the option below");
                                    Console.WriteLine("1. Find routes fastest path ");
                                    Console.WriteLine("2. Display tube information");
                                    Console.WriteLine("3. Back");
                                    Console.WriteLine("Enter option : ");
                                    string val2 = Console.ReadLine();
                                    try
                                    {
                                        int val3 = int.Parse(val2);
                                        Console.Clear();
                                        switch (val3)
                                        {
                                            case 1:
                                                Console.WriteLine("Find routes fastest path from Source Station to Destination Station");
                                                Console.WriteLine("Enter Source Station name: ");
                                                string stName = Console.ReadLine();
                                                int i = 0;
                                                while (i < 1)
                                                {
                                                    if (CheckStation(stName))
                                                    {
                                                        i++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Start Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        stName = Console.ReadLine();
                                                    }
                                                }
                                                Console.WriteLine("Enter Destination Station name: ");
                                                string edName = Console.ReadLine();
                                                int h = 0;
                                                while (h < 1)
                                                {
                                                    if (CheckStation(edName))
                                                    {
                                                        h++;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Destination Station is not in London Zone 1");
                                                        Console.WriteLine("Please enter station again : ");
                                                        edName = Console.ReadLine();
                                                    }
                                                }
                                                timer.Start();
                                                GetShortestPath(stName, edName);
                                                timer.Stop();
                                                TimeSpan time = timer.Elapsed;
                                                Console.WriteLine("");
                                                Console.WriteLine($"Time taken from to search for route {stName} -> {edName} = {time.Milliseconds} Milliseconds");
                                                Console.ReadLine();
                                                break;
                                            case 2:
                                                Console.WriteLine("Display tube information");
                                                Console.WriteLine("Please enter tube name:");
                                                int c = 0;
                                                while (c < 1)
                                                {
                                                    string varName = Console.ReadLine();
                                                    if (CheckTubeName(varName))
                                                    {
                                                        GetTubeDetails(varName);
                                                        c++;
                                                        Console.ReadLine();
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Tube Name is not in our record for Zone 1");
                                                        Console.WriteLine("Please input tube name");
                                                    }
                                                }
                                                break;
                                            case 3:
                                                b++;
                                                break;
                                            default:
                                                Console.WriteLine("Please enter number within range");
                                                break;
                                        }
                                    }
                                    catch (SystemException ex)
                                    {
                                        Console.WriteLine("Execepetion Message: " + ex.Message);
                                        Console.WriteLine("please input a valid value");
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Good Bye.....");
                                Console.WriteLine("Please any Key");
                                j++;
                            }
                        }
                        else 
                        {
                            Console.WriteLine($"Execepetion Message: {val1} is not in the menu" );
                            Console.WriteLine("please input a valid value");
                        }
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine("Execepetion Message: " + ex.Message);
                        Console.WriteLine("please input a valid value");
                    }
                }
                else
                {
                    Console.WriteLine("please input a value - Input Empty");
                }
            }
            
        }
        
        public string[] GetFiles()
        {
            string path = "TFLRoute";
            string[] files = Array.Empty<string>();
        
            try
            {
                files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    files.Append(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred getting file : " + ex.Message);
            }

            return files;
        }

        public Tuple<List<Tube>,List<TubeStation>> StoreRecords(string[] filepath)
        {
            
            Tuple<List<Tube>, List<TubeStation>> dataRecords = Tuple.Create(routeRecords, stationRecords);

            foreach(string fp  in filepath) 
            {
                string[] lines = File.ReadAllLines(fp);
             
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line) || line.Contains("\t")) continue;
                        string tubeLineName = Path.GetFileNameWithoutExtension(fp);
                        string[] lineArray = line.Trim().Split(',');
                        string sourceStation = lineArray[0];
                        string[] timeArray = lineArray[1].Trim().Split('=');
                        string destStation = timeArray[0];
                        int timeDiff = 0;
                        try
                        {
                            timeDiff = int.Parse(timeArray[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Warning : Time from file is compliance " + ex.Message);
                        }

                        int create = 0;
                        foreach (TubeStation tubeStation in stationRecords)
                        {
                        string see = tubeStation.Name.ToLower().Trim();
                            if (tubeStation.Name.ToLower().Trim() == sourceStation.ToLower().Trim())
                            {
                                create++;
                                break;
                            }
                        }
                        if (create == 0)
                        {
                            TubeStation Station = new TubeStation(sourceStation);
                            stationRecords.Add(Station);
                        }

                    int create1 = 0;
                    foreach (TubeStation tubestation in stationRecords)
                    {
                        if (tubestation.Name.ToLower().Trim() == destStation.ToLower().Trim())
                        {
                            create1++;
                            break;
                        }
                    }
                    if (create1 == 0)
                    {
                        TubeStation Station1 = new TubeStation(destStation);
                        stationRecords.Add(Station1);
                    }

                    Tube route = new Tube(sourceStation, destStation, timeDiff, tubeLineName);
                        routeRecords.Add(route);
                    } 
            }
            return dataRecords;
        }

        public int[] DijkstraShortestPath(List<TubeStation> station, List<Tube> tube, string startVertex, string endVertex)
        {
   
            int stationCount = station.Count;
            int[] vertexPath = new int[stationCount];
            bool[] visitedVertex = new bool[stationCount];
            int[] pathLength = new int[stationCount];

            Dictionary<int, string> stationDictionary = new Dictionary<int, string>();
            int k = 0;
            foreach (TubeStation tb in station)
            {
                string name = tb.Name;
                stationDictionary.Add(k, name);
                k++;
            }

            for (int i = 0; i < stationCount; i++)
            {
                pathLength[i] = int.MaxValue;
                vertexPath[i] = -1;
            }
            int startKey = stationDictionary.FirstOrDefault(x => x.Value == startVertex).Key;
            pathLength[startKey] = 0;

            int endKey = stationDictionary.FirstOrDefault(x => x.Value == endVertex).Key;

            for (int i = 0; i < stationCount; i++)
            {
                int vertexCurrentSearch = -1;
                int defaultPL = int.MaxValue;

                for (int j = 0; j < stationCount; j++)
                {
                    if (!visitedVertex[j] && pathLength[j] < defaultPL)
                    {
                        defaultPL = pathLength[j];
                        vertexCurrentSearch = j;
                    }
                }


                if (vertexCurrentSearch == -1 || vertexCurrentSearch == endKey)
                {
                    break;
                }

                visitedVertex[vertexCurrentSearch] = true;

                string currentVertex = stationDictionary.FirstOrDefault(x => x.Key == vertexCurrentSearch).Value;

                foreach (Tube tb in tube)
                {
                    if (tb.SourceRoute == currentVertex && tb.Status == STATUS.Open)
                    {
                        string ntVertex = tb.DestinationRoute.Trim();

                        int nearestVertex = stationDictionary.FirstOrDefault(x => x.Value == ntVertex).Key;

                        int vertexTime = tb.RouteTime();

                        if (!visitedVertex[nearestVertex])
                        {
                            int weight = pathLength[vertexCurrentSearch] + vertexTime;

                            if (weight < pathLength[nearestVertex])
                            {
                                pathLength[nearestVertex] = weight;
                                vertexPath[nearestVertex] = vertexCurrentSearch;
                            }
                        }
                    }

                }
            }
            return vertexPath;
        }

        public void GetShortestPath(string start, string end)
        {
            int[] shortestqueuedVertex = DijkstraShortestPath(stationRecords, routeRecords, start, end);

            Dictionary<int, string> stationDictionary = new Dictionary<int, string>();
            int k = 0;
            foreach (TubeStation tb in stationRecords)
            {
                string name = tb.Name;
                stationDictionary.Add(k, name);
                k++;
            }

            int endKey = stationDictionary.FirstOrDefault(x => x.Value == end).Key;
            int startKey = stationDictionary.FirstOrDefault(x => x.Value == start).Key;

            Console.WriteLine("##########################################");
            Console.WriteLine("#     Shortest Route Display             #");
            Console.WriteLine("##########################################");
            Console.WriteLine("");
            Console.WriteLine($"Route:   {start}  to  {end} :");

            int totalTime = 0;
            int vertexId = endKey;
            Stack<int> queuedVertex = new Stack<int>();

            while (vertexId != startKey)
            {
                queuedVertex.Push(vertexId);
                vertexId = shortestqueuedVertex[vertexId];
            }
            queuedVertex.Push(startKey);

            int counter = 2;
            bool writeStart = true;
            bool isChange = false;
            string tubeline = "";
            string previousTubeName = "";
            while (queuedVertex.Count > 1)
            {
                int vertexInt1 = queuedVertex.Pop();
                int vertexInt2 = queuedVertex.Peek();
                string vertexName1 = stationDictionary.FirstOrDefault(x => x.Key == vertexInt1).Value;
                string vertexName2 = stationDictionary.FirstOrDefault(x => x.Key == vertexInt2).Value;

                int routeTime = 0;
                
                foreach (Tube tb in routeRecords)
                {
                    if (tb.SourceRoute.Trim().ToLower() == vertexName1.Trim().ToLower() && tb.DestinationRoute.Trim().ToLower() == vertexName2.Trim().ToLower())
                    {
                        routeTime = tb.RouteTime();
                        tubeline = tb.TubeName;
                        if (string.IsNullOrEmpty(previousTubeName))
                        {
                            previousTubeName = tubeline;
                        }
                        if (previousTubeName.Trim().ToLower() != tubeline.Trim().ToLower())
                        {
                            isChange = true;
                            previousTubeName = tubeline;
                        }
                        break;
                    }
                }
                totalTime += routeTime;

                if (writeStart)
                {
                    Console.WriteLine($"({1}) Start:   {start} ({tubeline})");
                    writeStart = false;
                }

                if (isChange)
                {
                    Console.WriteLine($"({counter}) Change:  {vertexName1} ({tubeline}) to {vertexName2} ({tubeline}) -> {routeTime} min");
                    counter++;
                    isChange = false;
                }
                else
                {
                    Console.WriteLine($"({counter})          {vertexName1} ({tubeline}) to {vertexName2} ({tubeline}) -> {routeTime} min");
                    counter++;
                }
            }

            Console.WriteLine($"({counter}) End:     {end} ({tubeline})");
            Console.WriteLine($"Total Journey Time: {totalTime} minutes");

        }
        
        public bool CheckStation(string name)
        {
            foreach(TubeStation tb in stationRecords)
            {
                if (tb.Name.Trim().ToLower() == name.Trim().ToLower()) return true;
            }
            return false;
        }

        public bool CheckTubeName(string name)
        {
            foreach (Tube tb in routeRecords)
            {
                if (tb.TubeName.Trim().ToLower() == name.Trim().ToLower()) return true;
            }
            return false;
        }

        public void GetTubeDetails(string name)
        {
            Console.WriteLine("####################################");
            Console.WriteLine("#######  Tube Information     ######");
            Console.WriteLine("####################################");
            Console.WriteLine("");
            Console.WriteLine($"Tube information for {name}");
            foreach (Tube tb in routeRecords)
            {
                if (tb.TubeName.Trim().ToLower() == name.Trim().ToLower())
                {
                    string source = tb.SourceRoute;
                    string destination = tb.DestinationRoute;
                    int time = tb.RouteTime();
                    Console.WriteLine($"Source: {source}  Destination: {destination}  Time: {time}");
                }
            }
        }

        public bool SetDelayTime(string sName, string dName, int t, string rs)
        {
            foreach (Tube tb in routeRecords)
            {
                if (tb.SourceRoute.Trim().ToLower() == sName.Trim().ToLower() && tb.DestinationRoute.Trim().ToLower() == dName.Trim().ToLower())
                {
                    tb.Delay = t;
                    tb.DelayReason = rs;
                    return true;    
                }
            }
            return false ;
        }

        public bool SetRouteUpdate(string sName, string dName, STATUS st)
        {
            foreach (Tube tb in routeRecords)
            {
                if (tb.SourceRoute.Trim().ToLower() == sName.Trim().ToLower() && tb.DestinationRoute.Trim().ToLower() == dName.Trim().ToLower())
                {
                    tb.Status = st;
                    return true;
                }
            }
            return false;
        }

        public void PrintImposible()
        {
            int counter = 1;
            foreach (Tube tb in routeRecords)
            {
               if (tb.Status == STATUS.Closed)
                {
                    Console.WriteLine($"({counter})  source {tb.SourceRoute}  destination {tb.DestinationRoute}  Tube {tb.TubeName}");
                    counter++;
                }
            }
            if (counter > 1)
            {
                Console.WriteLine("Above are the listed of closed route");
            }
            else
            {
                Console.WriteLine("There are no closed route on the map");
            }
        }

        public void PrintDelayed()
        {
            int counter = 1;
            foreach (Tube tb in routeRecords)
            {
                if (tb.Delay > 0)
                {
                    Console.WriteLine($"({counter})  source {tb.SourceRoute} -> destination {tb.DestinationRoute} -> Tube {tb.TubeName} Delay -> {tb.Delay} -> Reason {tb.DelayReason}");
                    counter++;
                }
            }
            if (counter > 1)
            {
                Console.WriteLine("Above are the listed of closed route");
            }
            else
            {
                Console.WriteLine("There are no closed route on the map");
            }
        }
    }
}
