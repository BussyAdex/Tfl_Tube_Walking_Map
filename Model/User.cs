namespace TfL_Walking_Distance_Version3.Model
{
    abstract class User
    {

        public int UserID { get; set; } = 0;

        public string UserName { get; set; }

        public string UserType { get; set; }

        public User(string userName, string userType)
        {
            this.UserID = this.UserID++;
            UserName = userName;
            UserType = userType;
        }

        public User()
        {
            this.UserID = this.UserID++;
            UserName = "";
            UserType = "Customer";
        }

        public abstract void Display();
    }
}
