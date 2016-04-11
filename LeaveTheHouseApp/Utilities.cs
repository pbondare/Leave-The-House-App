using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    public static class Utilities
    {
        /// <summary>
        /// This method parses user input and returns the weather type
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>Weather</returns>
        public static Weather ParseWeatherInput(string userInput)
        {
            Weather weather;
            string weatherInput = userInput;

            if (weatherInput.Equals("HOT", StringComparison.OrdinalIgnoreCase))
            {
                weather = Weather.HOT;
                //Console.WriteLine(weatherInput);
                return weather;
            }
            else if (weatherInput.Equals("COLD", StringComparison.OrdinalIgnoreCase))
            {
                weather = Weather.COLD;
                //Console.WriteLine(weatherInput);
                return weather;
            }
            else
            {
                throw new System.ArgumentException("Please provide a valid weather input <COLD, HOT> and try again.");
            }
        }

        /// <summary>
        /// This method parses user input and returns a command array.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns>int[]</returns>
        public static int[] ParseCommandsInput(string[] userInput)
        {
            // put the command entries in a new array
            string[] commandInputs = new String[userInput.Length - 1];
            for (int i = 0; i < userInput.Length - 1; i++)
            {
                if (userInput[i + 1].Trim().TrimEnd(',').Length > 1)
                {
                    throw new FormatException("An error occurred when parsing command inputs. Please provide comman separated integers with a space after each integer value.");
                }
                commandInputs[i] = userInput[i + 1].Trim().TrimEnd(',');
            }
                        
            int[] commands = new int[commandInputs.Length];

            for (int i = 0; i < commands.Length; i++)
            {
                try
                {
                    commands[i] = Int32.Parse(commandInputs[i]);            
                }
                catch (System.FormatException ex)
                {
                    throw new FormatException("An error occurred when parsing command inputs. Please provide integers only.", ex.InnerException);                    
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }
            return commands;
        }

        public static void ValidateInputCount(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Please provide a weather state followed by integer commands.");
            }
        }
    }
}
