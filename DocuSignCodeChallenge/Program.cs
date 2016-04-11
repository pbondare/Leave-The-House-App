using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveTheHouseApp;

namespace DocuSignCodeChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {          
            try
            {                
                string output = InputProcessor.ProcessInputs(args);
                Console.WriteLine("Output: " + output);
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
            }            
        } 
    }
}
