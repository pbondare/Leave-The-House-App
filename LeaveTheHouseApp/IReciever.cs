using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    public interface IReciever
    {
        void SetAction(ActionItems action);
        bool GetResult();
    }
}
