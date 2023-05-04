using TfL_Walking_Distance_Version3.Model;
using TfL_Walking_Distance_Version3.View;
namespace TfL_Walking_Distance_Version3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TfL_App londonMap = new TfL_App();
  
            string[] londonFilePath = londonMap.GetFiles();

            londonMap.StoreRecords(londonFilePath);

            londonMap.Start();

        }
    }
}