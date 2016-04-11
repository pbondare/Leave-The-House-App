using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    public abstract class Command
    {
        public string Description;
        public string ResponseHot;
        public string ResponseCold;
        protected IReciever _reciever = null;

        // Constructor
        public Command(IReciever reciever, string description, string responseHot, string responseCold)
        {
            _reciever = reciever;
            Description = description;
            ResponseHot = responseHot;
            ResponseCold = responseCold;
        }

        public abstract bool Execute();
    }

    public class PutOnFootwearCommand : Command
    {
        public PutOnFootwearCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.PutOnFootwear);
            return _reciever.GetResult();
        }
    }

    public class PutOnHeadwearCommand : Command
    {
        public PutOnHeadwearCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.PutOnHeadwear);
            return _reciever.GetResult();
        }
    }

    public class PutOnSocksCommand : Command
    {
        public PutOnSocksCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.PutOnSocks);
            return _reciever.GetResult();
        }
    }

    public class PutOnShirtCommand : Command
    {
        public PutOnShirtCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.PutOnShirt);
            return _reciever.GetResult();
        }
    }

    public class PutOnJacketCommand : Command
    {
        public PutOnJacketCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.PutOnJacket);
            return _reciever.GetResult();
        }
    }

    public class PutOnPantsCommand : Command
    {
        public PutOnPantsCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.PutOnPants);
            return _reciever.GetResult();
        }
    }

    public class LeaveHouseCommand : Command
    {
        public LeaveHouseCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.LeaveHouse);
            return _reciever.GetResult();
        }
    }

    public class TakeOffPajamasCommand : Command
    {
        public TakeOffPajamasCommand(IReciever reciever, string description, string responseHot, string responseCold)
            : base(reciever, description, responseHot, responseCold)
        {
        }

        public override bool Execute()
        {
            _reciever.SetAction(ActionItems.TakeOffPajamas);
            return _reciever.GetResult();
        }
    }

    public enum ActionItems
    {
        PutOnFootwear = 1,
        PutOnHeadwear = 2,
        PutOnSocks = 3,
        PutOnShirt = 4,
        PutOnJacket = 5,
        PutOnPants = 6,
        LeaveHouse = 7,
        TakeOffPajamas = 8
    }


}
