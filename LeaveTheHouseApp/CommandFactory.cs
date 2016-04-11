using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    public static class CommandFactory
    {
       /// <summary>
       /// This method instantiates and returns the relevant command based on id provided.
       /// </summary>
       /// <param name="reciever"></param>
       /// <param name="id"></param>
       /// <returns>Command</returns>
        public static Command CreateCommand(IReciever reciever, int id)
        {
            switch (id)
            {
                case 1:
                    return new PutOnFootwearCommand(reciever, "Put on footwear", "sandals", "boots");
                case 2:
                    return new PutOnHeadwearCommand(reciever, "Put on headwear", "sun visor", "hat");
                case 3:
                    return new PutOnSocksCommand(reciever, "Put on socks", "fail", "socks");
                case 4:
                    return new PutOnShirtCommand(reciever, "Put on shirt", "t-shirt", "shirt");
                case 5:
                    return new PutOnJacketCommand(reciever, "Put on jacket", "fail", "jacket");
                case 6:
                    return new PutOnPantsCommand(reciever, "Put on pants", "shorts", "pants");
                case 7:
                    return new LeaveHouseCommand(reciever, "Leave house", "leaving house", "leaving house");
                case 8:
                    return new TakeOffPajamasCommand(reciever, "Take off pajamas", "Removing PJs", "Removing PJs");
                default:
                    return null;
            }
        }
    }
}
