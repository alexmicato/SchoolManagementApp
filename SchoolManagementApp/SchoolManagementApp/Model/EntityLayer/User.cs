using System.ComponentModel;

namespace SchoolManagementApp.Model.EntityLayer
{
    public class User : INotifyPropertyChanged
    {
        private int userID;
        private string username;
        private string password;
        private string userType;

        public string UserType
        {
            get { return userType; }
            set
            {
                if (userType != value)
                {
                    userType = value;
                    OnPropertyChanged(nameof(UserType));
                }
            }
        }
        public int UserID
        {
            get { return userID; }
            set
            {
                if (userID != value)
                {
                    userID = value;
                    OnPropertyChanged(nameof(UserID));
                }
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public User()
        {

        }

        public User(string username, string password, string type)
        {
            this.username = username;
            this.password = password;
            this.userType = type;
        }

        public User(int userID, string username, string password, string type)
        {
            this.userID = userID;
            this.username = username;
            this.password = password;
            this.userType = type;   
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
