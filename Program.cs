/*
* Program.cs
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
                    Console.Clear();
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
                    Console.WriteLine("===========================================");
                    Console.WriteLine();
                    Console.Write("Enter an option: ");
                    user_Selected_Option = Convert.ToInt32(Console.ReadLine());

                    // getting value to determin the option using switch
                    switch (user_Selected_Option)
                    {
                        case 1:
                            Adding_User_Reservation();
                            break;
                        case 2:
                            Edit_Existing_Reservation();
                            break;
                        case 3:
                            user_Existing_Reservation_Cancel();
                            break;
                        case 4:
                            Chart_Disply();
                            break;
                        case 5:
                            restart_Program = false;
                            break;
                         default:
                            Console.WriteLine("Enter a valid option, press any key to go back.");
                            Console.ReadKey();
                            break;
                    }
				} while (restart_Program);
                {
                    // Ending message with sleep mode for 550s
                    Console.Write("Loading");
                    for (int i = 0; i <= 5; i++)
                    {
                        Thread.Sleep(550);
                        Console.Write(".");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Thank You ");
                    Thread.Sleep(550);
                }	

			}
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please Enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        // Function is for creating room for the users in the array
        // FormatException
        // option 1
        static void Adding_User_Reservation()
        {
            String customer_Name, user_desition , type_Identifier;
            int preferred_Row,preferred_Column;
           try 
            {
                // to disply all the chart.
                Dispaly_Function_Seat();
                Console.Write("Enter the Name:");
                customer_Name = Console.ReadLine();
                customer_Name = customer_Name.ToLower();
                Console.WriteLine();
                Console.Write("Enter preferred row No:");
                preferred_Row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter preferred column No:");
                preferred_Column = Convert.ToInt32(Console.ReadLine());
                type_Identifier = seats[preferred_Row - 1, preferred_Column - 1];
                Console.WriteLine();

                if (char.IsDigit(type_Identifier[0]))
                {
                    // conformin the values are ok for the user and is that seat is available.
                    Console.Clear();
                    Console.WriteLine($"You entered");
                    Console.WriteLine();
                    Console.WriteLine($"Row No: {preferred_Row}");
                    Console.WriteLine();
                    Console.WriteLine($"Column No: {preferred_Column}");
                    Console.WriteLine();
                    Console.Write("To confirm enter yes to continue with OR to change enter no: ");
                    user_desition = Console.ReadLine();
                    user_desition = user_desition.ToLower();
                    if (user_desition == "yes")
                    {
                        if (preferred_Row <= seats.GetLength(0) && preferred_Column <= seats.GetLength(1))
                        {
                            seats[preferred_Row - 1, preferred_Column - 1] = customer_Name;
                            Font_Color_True(" Seat reserved successfully! ");
                            Loading_Bar();
                        }
                        else
                        {
                            Font_Color_False("No reservation found");
                        }
                    }
                    else
                    {
                        // again entering information.
                        Console.WriteLine("Enter again ");
                        Console.WriteLine();
                        Chart_Disply();
                        Console.Write("Enter the name:");
                        customer_Name = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter preferred row No:");
                        preferred_Row = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter preferred column No:");
                        preferred_Column = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }

                } else
                {
                    Font_Color_False(" The entred seat is booked ");
                    Loading_Bar();
                }
            }
            catch (FormatException Error) 
            {
                Console.WriteLine(Error .Message);
            }

        }
        //option2 
        //Edit Existing Reservation
        static void Edit_Existing_Reservation()
        {
            int reservation_Row_id ;
            int reservation_Column_id ;
            string edit_Reservation_Conformation;
            try
            {
                // displaying all seats && getting the data.
                Console.Clear();
                Dispaly_Function_Seat();
                Console.WriteLine();
                Console.Write("Enter the row No: ");
                reservation_Row_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter the column No: ");
                reservation_Column_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                // checing the entered id are valied in the list.
                string seat_reservation_value = seats[reservation_Row_id - 1, reservation_Column_id - 1];
                if (!seat_reservation_value.Any(char.IsNumber))
                {
                    Console.Write($"Do you want to edit reservation: ");
                    edit_Reservation_Conformation = Console.ReadLine();
                    edit_Reservation_Conformation = edit_Reservation_Conformation.ToLower();
                    if (edit_Reservation_Conformation == "yes")
                    {
                        Console.Write("Enter the name to convert: ");
                        seats[reservation_Row_id - 1, reservation_Column_id - 1] = Console.ReadLine();
                        Console.WriteLine();
                        Font_Color_True(" Name converted successfully!");
                    }
                }else
                {
                    Font_Color_False("Enter seat is not booked yet..");
                    //Console.WriteLine("Enter seat is not booked yet..");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values.");
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
            }
        }
        //option3
        //Cancel Existing Reservation
        static void user_Existing_Reservation_Cancel()
        {
            string user_Name;
            int reservation_Row_id;
            int reservation_Column_id;
            string user_Cancelation_Conformation;
           
            try
            {
                // clearing the screan and display the chart.
                Console.Clear();
                Dispaly_Function_Seat();
                Console.WriteLine();
                Console.Write("Enter the row No: ");
                reservation_Row_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter the column No: ");
                reservation_Column_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter the name used on booking: ");
                user_Name = Console.ReadLine();
                user_Name = user_Name.ToLower();
                Console.WriteLine(user_Name);
                // checking the user entred data are true.
                if (seats[reservation_Row_id - 1,reservation_Column_id - 1].Contains(user_Name))
                {
                    Console.WriteLine();
                    Console.Write("Enter yes to conformation cancelation OR no: ");
                    user_Cancelation_Conformation = Console.ReadLine();
                    user_Cancelation_Conformation = user_Cancelation_Conformation.ToLower();
                    if (user_Cancelation_Conformation != "no")
                    {
                        seats[reservation_Row_id - 1, reservation_Column_id - 1] = "Canceld ";
                        Console.WriteLine();
                        //Console.ForegroundColor = ConsoleColor.Green;
                        Font_Color_True(" Seat reserved successfully!");
                        //Console.WriteLine(" Seat reserved successfully! ");
                    }
                    else
                    {
                        Console.WriteLine();
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine("“No reservation found");
                        Font_Color_False("No reservation found");
                    }
                }
                else
                {
                    Console.WriteLine("Name not found");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values.");
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
            }
        }

        // option 4 
        // Displaying the all values in the array
        static void Chart_Disply()
        {
            try
            {
                Console.Clear ();
                Console.WriteLine();
                // for displaying all the seats .
                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    Console.Write($"Row {i + 1}: ");
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        Console.Write($"{seats[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine ();
                Console.WriteLine("Press any key to go back main menu.");
                Console.ReadKey();
            }
            catch (FormatException Error)
            {
                Console.WriteLine (Error .Message);
            }
        }
            

        // function is for display chart/ seats for other function.
        static void Dispaly_Function_Seat()
        {
            try
            {
                Console.Clear();
                Console.WriteLine();
                for (int i = 0; i < seats.GetLength(0); i++)
                {
                    Console.Write($"Row {i + 1}: ");
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        Console.Write($"{seats[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch (FormatException Error)
            {
                Console.WriteLine(Error.Message);
            }
        }
        // styling starts 
        static void Loading_Bar()
        {
            // Ending message with sleep mode for 450s
            Loading_Bar();
        }
        // background color chnaging function
        static void Font_Color_True(string true_Value)
        {
            Console.WriteLine();
           Console.ForegroundColor = ConsoleColor.Green;
           Console.WriteLine(true_Value);
           Console.ForegroundColor= ConsoleColor.Black;
            Console.WriteLine();
            Console.Write("Press any key to go back main menu.");
            Console.ReadKey();
        }
        
        // for red font
        static void Font_Color_False(string false_Value)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(false_Value);
            Console.ForegroundColor= ConsoleColor.Black;
            Console.WriteLine();
            Console.Write("Press any key to go back main menu.");
            Console.ReadKey();
        }
    }
}
