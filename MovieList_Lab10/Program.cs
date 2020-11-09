using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace MovieList_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldLoop = true;
            var movieList = new List<Movie>();
            var Holes = new Movie("Holes", "drama");
            movieList.Add(Holes);

            var Disturbia = new Movie("Disturbia", "horror");
            movieList.Add(Disturbia);

            var FreddyVsJason = new Movie("Freddy Vs. Jason", "horror");
            movieList.Add(FreddyVsJason);

            var SpiderMan = new Movie("Spider-Man, into the spiderverse", "animated");
            movieList.Add(SpiderMan);

            var StarWars = new Movie("Star Wars", "scifi");
            movieList.Add(StarWars);

            var OnePunchMan = new Movie("One Punch Man", "animated");
            movieList.Add(OnePunchMan);

            var HarryPotter = new Movie("Harry Potter", "scifi");
            movieList.Add(HarryPotter);
            var LegallyBlonde = new Movie("Legally Blonde", "drama");
            movieList.Add(LegallyBlonde);

            var StarTrek = new Movie("Star Trek", "scifi");
            movieList.Add(StarTrek);

            var Rubber = new Movie("Rubber", "horror");
            movieList.Add(Rubber);


            while (shouldLoop)
            {
                uint userSelection = ViewMovieOrAddNew();

                if (userSelection == 1)
                {
                    string searchCriteria = AskForCategory();
                    WriteMoviesOfSearchCriteria(movieList, searchCriteria);
                }
                else
                {
                    PromptAndAddNewMovie(movieList);
                }

                shouldLoop = ContinueOrclose(movieList);
            }

        }

        private static bool ContinueOrclose(List<Movie> movieList)
        {
            while (true)
            {
                Console.WriteLine("Would you like to:");
                Console.WriteLine("[1]: Continue");
                Console.WriteLine("[2]: View Movies and Exit");

                if (uint.TryParse(Console.ReadLine(), out uint userContinue) && userContinue < 3)
                {
                    if (userContinue != 1)
                    {
                        foreach (Movie movie in movieList)
                        {
                            Console.WriteLine($"Title: {movie.Title}");
                            Console.WriteLine($"Category: {movie.Category}");
                            Console.WriteLine("\n");
                        }
                        Console.WriteLine("Thank you! Press enter to end application.");
                        Console.ReadLine();
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Selection, try again.");
                }
            }
            
        }

        private static void PromptAndAddNewMovie(List<Movie> movieList)
        {
            bool completeMovie = false;
            while (!completeMovie)
            {
                Console.WriteLine("Please Enter a title for the movie:");
                string userTitle = Console.ReadLine();
                if (userTitle.Length < 1)
                {
                    continue;
                }

                Console.WriteLine("Please Enter a category for the movie:");
                Console.WriteLine("Animated, Drama, Horror, Scifi");
                string userCategory = Console.ReadLine().ToLower();
                if (userCategory.Length < 1)
                {
                    continue;
                }

                Console.WriteLine("Great adding the following to the Movie List:");
                Console.WriteLine($"Title: {userTitle}");
                Console.WriteLine($"Category: {userCategory}");
                var userMovie = new Movie(userTitle, userCategory);
                movieList.Add(userMovie);
                completeMovie = true;
            }
        }

        public static string AskForCategory()
        {
            while (true)
            {
                Console.WriteLine("Would you like to:");
                Console.WriteLine("[1]: Search by NAME");
                Console.WriteLine("[2]: Search by CATEGORY");
                if (uint.TryParse(Console.ReadLine(), out uint searchCriteria) && searchCriteria < 3)
                {
                    if (searchCriteria == 1)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please enter the NAME to search by");
                            string nameToSearchBy = Console.ReadLine();
                            if (nameToSearchBy.Length < 1)
                            {
                                Console.WriteLine("Invalid Entry, please try again.");
                            }
                            else
                            {
                                return nameToSearchBy;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter the CATEGORY to search by");
                        string categoryToSearchBy = Console.ReadLine();
                        if (categoryToSearchBy.Length < 1)
                        {
                            Console.WriteLine("Invalid Entry, please try again.");
                        }
                        else
                        {
                            return categoryToSearchBy;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Selection, Please try again.");
                }
            }
            
        }

        public static void WriteMoviesOfSearchCriteria(List<Movie> movieList,string searchCriteria) 
        {
            int moviesThatMatched = 0;
            Console.WriteLine("Matched Movies:");
            foreach (Movie movie in movieList)
            {
                if (movie.Title == searchCriteria.ToLower() || movie.Category == searchCriteria.ToLower())
                {
                    Console.WriteLine($"Title: {movie.Title}");
                    Console.WriteLine($"Category: {movie.Category}");
                    Console.WriteLine("\n");
                    moviesThatMatched++;
                }
            }
            if (moviesThatMatched < 1)
            {
                Console.WriteLine("No Movies Matched That Search Criteria");
            }
        }

        public static uint ViewMovieOrAddNew()
        {
            while (true)
            {
                Console.WriteLine("Would you like to:");
                Console.WriteLine("[1]: View Existing Movie");
                Console.WriteLine("[2]: Add New Movie");
                if (uint.TryParse(Console.ReadLine(), out uint userSelection) && userSelection < 3)
                {
                    return userSelection;
                }
                else
                {
                    Console.WriteLine("Invalid selection, please try again");
                }
            }
        }
    }

    public class Movie 
    {
        public Movie(string title, string category)
        {
            Category = category;
            Title = title;
        }

        private string _category;
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Category 
        {
            get {return _category; } 
            set { _category = value; } 
        }
    }
}
