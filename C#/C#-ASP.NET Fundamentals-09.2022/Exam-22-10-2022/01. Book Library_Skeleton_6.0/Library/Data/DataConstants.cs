namespace Library.Data
{
    public class DataConstants
    {
        public class ApplicationUser
        {
            public const int UsernameMaxLenght = 20;
            public const int UsernameMinLenght = 5;
            public const int EmailMaxLenght = 60;
            public const int EmailMinLenght = 10;
            public const int PasswordMaxLenght = 20;
            public const int PasswordMinLenght = 5;
        }

        public class Book
        {
            public const int TitleMaxLenght = 50;
            public const int TitleMinLenght = 10;
            public const int AuthorMaxLenght = 50;
            public const int AuthorMinLenght = 5;
            public const int DescriptionMaxLenght = 5000;
            public const int DescriptionMinLenght = 5;
            public const string RatingMaxValue = "10.00";
            public const string RatingMinValue = "0.00";
        }

        public class Category
        {
            public const int NameMaxLenght = 50;
            public const int NameMinLenght = 5;
        }

        public class Error
        {
            public const string UsernameError = "Username must be between {1} and {0} symbols!";
            public const string EmailError = "Email must be valid!";
            public const string EmailErrorLenght = "Email must be between {1} and {0} symbols!";
            public const string PasswordNotMatch = "Passwords not match!";
            public const string ViewModelError = "Something wrong. Please try again!";
            public const string UsernameIsTaken = "Username exist!";
            public const string WrongLogin = "Username or passwor is not correct!";

            public const string TitleLenghtError = "Title must be between {1} and {0} symbols!";
            public const string AuthorLenghtError = "Author must be between {1} and {0} symbols!";
            public const string DescriptionLenghtError = "Description must be between {1} and {0} symbols!";
        }
    }
}
