using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    /// <summary>
    /// Simple object to hold command execution results.
    /// </summary>
    public class Output
    {
        public List<string> commandExecutionResults { get; set; }
        public bool UserWasAbleToLeaveTheHouse { get; set; }

        public Output()
        {
            commandExecutionResults = new List<string>();
            UserWasAbleToLeaveTheHouse = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            String prefix = "";

            foreach (var result in commandExecutionResults)
            {
                sb.Append(prefix);
                prefix = ", ";
                sb.Append(result);                
            }

            return sb.ToString();
        }
    }
}
