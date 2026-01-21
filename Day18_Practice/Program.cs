// // Question 1: 

// using Day18_Practice;

// namespace Day18_Practice
// {
//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             ItemOperations.Execute();
//         }
//     }
// }


// // Question 2: 

// using System;
// using Day18_Practice;
// using System.Collections.Generic;

// namespace Day18_Practice
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Enter number of movies:");
//             int n = int.Parse(Console.ReadLine());

//             for (int i = 0; i < n; i++)
//             {
//                 Console.WriteLine("Enter movie details (Title,Artist,Genre,Ratings):");
//                 string details = Console.ReadLine();
//                 MovieOperations.AddMovie(details);
//             }

//             Console.WriteLine("Enter genre to search:");
//             string genre = Console.ReadLine();

//             List<Movie> genreMovies = MovieOperations.ViewMoviesByGenre(genre);

//             if (genreMovies.Count == 0)
//             {
//                 Console.WriteLine($"No Movies found in genre '{genre}'");
//             }
//             else
//             {
//                 Console.WriteLine("Movies by Genre:");
//                 foreach (var movie in genreMovies)
//                 {
//                     Console.WriteLine($"{movie.Title},{movie.Artist},{movie.Genre},{movie.Ratings}");
//                 }
//             }

//             Console.WriteLine("\nMovies Sorted by Ratings:");
//             var sortedMovies = MovieOperations.ViewMoviesByRatings();
//             foreach (var movie in sortedMovies)
//             {
//                 Console.WriteLine($"{movie.Title},{movie.Artist},{movie.Genre},{movie.Ratings}");
//             }
//         }
//     }
// }


// // Question 3: 

// using System;
// using Day18_Practice;

// namespace Day18_Practice
// {
//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Enter number of subjects:");
//             int n = int.Parse(Console.ReadLine());

//             for (int i = 0; i < n; i++)
//             {
//                 Console.WriteLine("Enter marks:");
//                 int num = int.Parse(Console.ReadLine());
//                 NumberOperations.AddNumbers(num);
//             }

//             double gpa = NumberOperations.GetGPAScored();

//             if (gpa == -1)
//             {
//                 Console.WriteLine("No Numbers Available");
//                 return;
//             }

//             Console.WriteLine("GPA: " + gpa);

//             char grade = NumberOperations.GetGradeScored(gpa);

//             if (grade == '\0')
//             {
//                 Console.WriteLine("Invalid GPA");
//             }
//             else
//             {
//                 Console.WriteLine("Grade: " + grade);
//             }
//         }
//     }
// }


// // Question 4: 

// using System;
// using Day18_Practice;

// namespace Day18_Practice
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Enter Member Id:");
//             int memberId = int.Parse(Console.ReadLine());

//             Console.WriteLine("Enter Age:");
//             int age = int.Parse(Console.ReadLine());

//             Console.WriteLine("Enter Weight:");
//             double weight = double.Parse(Console.ReadLine());

//             Console.WriteLine("Enter Height:");
//             double height = double.Parse(Console.ReadLine());

//             Console.WriteLine("Enter Goal:");
//             string goal = Console.ReadLine();

//             MeditationCenter.AddYogaMember(memberId, age, weight, height, goal);

//             double bmi = MeditationCenter.CalculateBMI(memberId);

//             if (bmi == 0)
//             {
//                 Console.WriteLine($"MemberId '{memberId}' is not present");
//                 return;
//             }

//             Console.WriteLine("BMI: " + bmi);

//             int fee = MeditationCenter.CalculateYogaFee(memberId);
//             Console.WriteLine("Yoga Fee: " + fee);
//         }
//     }
// }


// // Question 5: 

// using System;

// namespace Day18_Practice
// {
//     public class Program
//     {
//         public EcommerceShop MakePayment(string? name, double balance, double amount)
//         {
//             if (balance < amount)
//             {
//                 throw new InsufficientWalletBalanceException(
//                     "Insufficient balance in your digital wallet"
//                 );
//             }

//             return new EcommerceShop
//             {
//                 UserName = name,
//                 WalletBalance = balance - amount,
//                 TotalPurchaseAmount = amount
//             };
//         }

//         public static void Main()
//         {
//             Program p = new Program();

//             Console.Write("Enter user name: ");
//             string name = Console.ReadLine();

//             Console.Write("Enter wallet balance: ");
//             double balance = double.Parse(Console.ReadLine());

//             Console.Write("Enter purchase amount: ");
//             double amount = double.Parse(Console.ReadLine());

//             try
//             {
//                 EcommerceShop shop = p.MakePayment(name, balance, amount);
//                 Console.WriteLine("Payment successful");
//             }
//             catch (InsufficientWalletBalanceException ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//         }
//     }
// }


// // Question 6: 

// using System;

// namespace Day18_Practice
// {
//     public class Program
//     {
//         public User ValidatePassword(string name, string password, string confirmationPassword)
//         {
//             if (!password.Equals(confirmationPassword, StringComparison.Ordinal))
//             {
//                 throw new PasswordMismatchException(
//                     "Password entered does not match"
//                 );
//             }

//             return new User
//             {
//                 Name = name,
//                 Password = password,
//                 ConfirmationPassword = confirmationPassword
//             };
//         }

//         public static void Main()
//         {
//             Program p = new Program();

//             Console.Write("Enter name: ");
//             string name = Console.ReadLine();

//             Console.Write("Enter password: ");
//             string password = Console.ReadLine();

//             Console.Write("Confirm password: ");
//             string confirmationPassword = Console.ReadLine();

//             try
//             {
//                 User user = p.ValidatePassword(name, password, confirmationPassword);
//                 Console.WriteLine("Registered Successfully");
//             }
//             catch (PasswordMismatchException ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//         }
//     }
// }


// // Question 7: 

// using System;

// namespace Day18_Practice
// {
//     public class Program
//     {
//         public EstimateDetails ValidateConstructionEstimate(float constructionArea, float siteArea)
//         {
//             if (constructionArea <= siteArea)
//             {
//                 return new EstimateDetails
//                 {
//                     ConstructionArea = constructionArea,
//                     SiteArea = siteArea
//                 };
//             }

//             throw new ConstructionEstimateException(
//                 "Sorry your Construction Estimate is not approved"
//             );
//         }

//         public static void Main()
//         {
//             Program p = new Program();

//             Console.Write("Enter Construction Area: ");
//             float constructionArea = float.Parse(Console.ReadLine());

//             Console.Write("Enter Site Area: ");
//             float siteArea = float.Parse(Console.ReadLine());

//             try
//             {
//                 EstimateDetails details =
//                     p.ValidateConstructionEstimate(constructionArea, siteArea);

//                 Console.WriteLine("Construction Estimate Approved");
//             }
//             catch (ConstructionEstimateException ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//         }
//     }
// }


// // Question 8: 

// using System;

// namespace Day18_Practice
// {
//     public class Program
//     {
//         public VerifiedUser ValidatePhoneNumber(string name, string phoneNumber)
//         {
//             if (phoneNumber != null && phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit))
//             {
//                 return new VerifiedUser
//                 {
//                     Name = name,
//                     PhoneNumber = phoneNumber
//                 };
//             }

//             throw new InvalidPhoneNumberException("Invalid phone number");
//         }

//         public static void Main()
//         {
//             Program p = new Program();

//             Console.Write("Enter name: ");
//             string name = Console.ReadLine();

//             Console.Write("Enter phone number: ");
//             string phoneNumber = Console.ReadLine();

//             try
//             {
//                 VerifiedUser user = p.ValidatePhoneNumber(name, phoneNumber);
//                 Console.WriteLine("User Verified");
//             }
//             catch (InvalidPhoneNumberException ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//         }
//     }
// }
