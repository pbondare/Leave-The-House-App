using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    public static class InputProcessor
    {
        public static string ProcessInputs(string[] args)
        {
            Utilities.ValidateInputCount(args);

            Weather weather = Utilities.ParseWeatherInput(args[0]);
            int[] commands = Utilities.ParseCommandsInput(args);

            return ProcessInputs(weather, commands).ToString();           
        }

        public static Output ProcessInputs(Weather weather, int[] commands)
        {
            Output output = new Output();
            UserState userstate = new UserState();
            CommandExecutor commandProcessor = new CommandExecutor(userstate, weather);

            // create and execute commands
            for (int i = 0; i < commands.Length; i++)
            {
                try
                {
                    Command command = CommandFactory.CreateCommand(commandProcessor, commands[i]);

                    if (command == null)
                    {
                        throw new System.ArgumentException("Command set could not be created. Please provide integers between 1 and 8.");
                    }

                    bool success = command.Execute();
                    if (success)
                    {
                        if (weather == Weather.COLD)
                        {
                            output.commandExecutionResults.Add(command.ResponseCold);
                        }
                        else if (weather == Weather.HOT)
                        {
                            output.commandExecutionResults.Add(command.ResponseHot);
                        }
                    }
                    else
                    {
                        output.commandExecutionResults.Add("fail");
                        output.UserWasAbleToLeaveTheHouse = false;
                        return output; // do not continue processing the rest of the commands
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            output.UserWasAbleToLeaveTheHouse = true;
            return output;
        }
    }
}
