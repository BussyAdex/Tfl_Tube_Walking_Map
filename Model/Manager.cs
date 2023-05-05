

namespace TfL_Walking_Distance_Version3.Model
{
    class Manager : User
    {
        public Manager() 
        {
            base.UserType = "Manager";
        }
        public override void Display()
        {
            Console.WriteLine($"Name {base.UserName} Type {base.UserType}");
        }
    }
}
