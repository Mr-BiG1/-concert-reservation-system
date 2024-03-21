/*
* Program.cs
* Assignment 4 a concert reservation system.
* Revision History:
* Darsan, Albin: March 20, 2024: Created
* In this project, all gaps (spaces) are intentionally used to enhance readability
* between various elements such as contents, text, and output. This consistent
* formatting practice aims to make the code more organized and easy to understand.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A4GeorgeDSA4AntonyA
{
    internal class Program
    {
        // The Main menu wiht do loop 
        static string[,] seats;
        static void Main(string[] args)
		{
            int user_Selected_Option;
            int seat_Row;
            int seat_Col;
            int defalt_Seat_Value;
            bool restart_Program = true;

			// changing the  background and forground color ...
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();
			try
			{
                // getting the row and colum for the 2D array
                Console.Write("Enter the Number rows want:");
                seat_Row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter Number of Seats/row:");
                seat_Col = Convert.ToInt32(Console.ReadLine());
                seats = new string[seat_Row, seat_Col];
                // setting the array
                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        defalt_Seat_Value = j + 1;
                        seats[i,j] = defalt_Seat_Value.ToString();
                    }
                }
                // option wiht do loop && row and colum setting.
                do
				{
                    // Main Menu Option 
					Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.WriteLine("Waterloo concert hall reservation system");
                    Console.WriteLine();
                    Console.WriteLine("1. Reserve a seat");
                    Console.WriteLine();
                    Console.WriteLine("2. Edit Existing Reservation");
                    Console.WriteLine();
                    Console.WriteLine("3. Cancel Reservation");
                    Console.WriteLine();
                    Console.WriteLine("4. Display Seating Chart ");
                    Console.WriteLine();
                    Console.WriteLine("5. Exit");
					Console.WriteLine();
                    Console.WriteLine(seats.Length);
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.Write("Enter an option: ");
                    user_Selected_Option = Convert.ToInt32(Console.ReadLine());

                    // getting value to determin the option using switch
                    switch (user_Selected_Option)
                    {
                        case 1:
                            Console.WriteLine("Option1");
                            Adding_User_Reservation();
                            break;
                        case 2:
                            Console.WriteLine("Option2");
                            break;
                        case 3:
                            Console.WriteLine("Option3");
                            break;
                        case 4:
                            Chart_Disply();
                            break;
                        case 5:
                            restart_Program = false;
                            break;
                    }
				} while (restart_Program);
                {
                    // Ending message with sleep mode for 550s
                    Console.WriteLine("Thamk You ");
                    Thread.Sleep(550);
                }	

			}
			catch (Exception Error)
			{
                Console.WriteLine(Error .Message);
			}
        }
        // Function is for creating room for the users in the array
        // FormatException
        static void Adding_User_Reservation()
        {
           try 
            {
                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        Console.Write($"{seats[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }catch (FormatException Error) 
            {
                Console.WriteLine(Error .Message);
            }
        }
        // option 4 
        // Displaying the all values in the array
        static void Chart_Disply()
        {
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    Console.Write($"{seats[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter to go back");
            Console.ReadKey();
        }
    }
}