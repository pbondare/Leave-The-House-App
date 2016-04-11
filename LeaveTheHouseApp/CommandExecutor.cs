using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveTheHouseApp
{
    /// <summary>
    /// This is the command executor object which contains all the business logic for command execution.
    /// </summary>
    public class CommandExecutor : IReciever
    {
        private Weather _weather;
        private UserState _user;
        ActionItems currentAction;

        public CommandExecutor(UserState user, Weather weather)
        {
            _weather = weather;
            _user = user;
        }

        #region IReciever Members

        public void SetAction(ActionItems action)
        {
            currentAction = action;
        }

        public bool GetResult()
        {
            switch (currentAction)
            {
                case ActionItems.TakeOffPajamas:
                    if (_user.PajamasOn)
                    {
                        _user.PajamasOn = false;
                        return true;
                    }
                    return false;
                case ActionItems.PutOnFootwear:
                    if (_user.PajamasOn || _user.FootwearOn || !_user.PantsOn)
                        return false;
                    else if (_weather == Weather.COLD && !_user.SocksOn)
                    {
                        return false;
                    }
                    else
                    {
                        _user.FootwearOn = true;
                        return true;
                    }
                case ActionItems.PutOnHeadwear:
                    if (_user.PajamasOn || _user.HeadwearOn)
                        return false;
                    else
                    {
                        _user.HeadwearOn = true;
                        return true;
                    }
                case ActionItems.PutOnSocks:
                    if (_user.PajamasOn || _user.SocksOn || _user.FootwearOn || _weather == Weather.HOT)
                        return false;
                    else
                    {
                        _user.SocksOn = true;
                        return true;
                    }
                case ActionItems.PutOnShirt:
                    if (_user.PajamasOn || _user.ShirtOn || _user.HeadwearOn || _user.JacketOn)
                        return false;
                    else
                    {
                        _user.ShirtOn = true;
                        return true;
                    }
                case ActionItems.PutOnJacket:
                    if (_user.PajamasOn || _user.JacketOn || _weather == Weather.HOT)
                        return false;
                    else
                    {
                        _user.JacketOn = true;
                        return true;
                    }
                case ActionItems.PutOnPants:
                    if (_user.PajamasOn || _user.PantsOn || _user.FootwearOn)
                        return false;
                    else
                    {
                        _user.PantsOn = true;
                        return true;
                    }
                case ActionItems.LeaveHouse:
                    if (_weather == Weather.HOT)
                    {
                        if (_user.PajamasOn || !_user.FootwearOn || !_user.HeadwearOn || !_user.ShirtOn || !_user.PantsOn)
                            return false;
                        else
                        {
                            _user.LeftHouse = true;
                            return true;
                        }
                    }
                    else if (_weather == Weather.COLD)
                    {
                        if (_user.PajamasOn || !_user.FootwearOn || !_user.HeadwearOn || !_user.ShirtOn || !_user.PantsOn ||
                            !_user.JacketOn || !_user.SocksOn)
                            return false;
                        else
                        {
                            _user.LeftHouse = true;
                            return true;
                        }
                    }
                    return false;
                default:
                    return false;
            }
        }

        #endregion IReciever Members
    }

    public class UserState
    {
        public bool PajamasOn { get; set; }
        public bool FootwearOn { get; set; }
        public bool HeadwearOn { get; set; }
        public bool SocksOn { get; set; }
        public bool ShirtOn { get; set; }
        public bool JacketOn { get; set; }
        public bool PantsOn { get; set; }
        public bool LeftHouse { get; set; }

        public UserState()
        {
            PajamasOn = true;
            FootwearOn = false;
            HeadwearOn = false;
            SocksOn = false;
            ShirtOn = false;
            JacketOn = false;
            PantsOn = false;
            LeftHouse = false;
        }

        public UserState(bool pajamasOn, bool footwearOn, bool headwearOn, bool socksOn, bool shirtOn, bool jacketOn, bool pantsOn, bool leftHouse)
        {
            PajamasOn = pajamasOn;
            FootwearOn = footwearOn;
            HeadwearOn = headwearOn;
            SocksOn = socksOn;
            ShirtOn = shirtOn;
            JacketOn = jacketOn;
            PantsOn = pantsOn;
            LeftHouse = leftHouse;
        }

    }

    public enum Weather
    {
        HOT = 1,
        COLD = 2
    }

    public enum State
    {
        PajamasOn = 1,
        FootwearOn = 2,
        HeadwearOn = 3,
        SocksOn = 4,
        ShirtOn = 5,
        JacketOn = 6,
        PantsOn = 7,
        LeftHouse = 8
    }
}
