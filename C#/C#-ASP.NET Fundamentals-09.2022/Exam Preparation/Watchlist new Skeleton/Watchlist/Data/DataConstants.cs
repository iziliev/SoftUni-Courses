namespace Watchlist.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int MinUsernameLenght = 5;
            public const int MaxUsernameLenght = 50;
            public const int MinEmailLenght = 10;
            public const int MaxEmailLenght = 60;
            public const int MinPasswordLenght = 5;
            public const int MaxPasswordLenght = 20;
        }

        public class Movie
        {
            public const int MinTitleLenght = 10;
            public const int MaxTitleLenght = 50;
            public const int MinDirectorLenght = 5;
            public const int MaxDirectorLenght = 50;
            public const string MinRatingValue = "0.00";
            public const string MaxRatingValue = "10.00";
        }

        public class Genre
        {
            public const int MinGenreNameLenght = 5;
            public const int MaxGenreNameLenght = 50;
        }

        public class Error
        {
            public const string ModelStateError = "Something wrong. Please try again!";
            public const string PasswordNotMatch = "Password doesn't not match!";
            public const string UsernameExist = "Username is already registered!";
            public const string LoginError = "Username or Password are wrong!";
        }
    }
}
