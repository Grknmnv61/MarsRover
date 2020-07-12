using BusinessLayer.Enums;
using BusinessLayer.Helpers;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Provider
{
    public class Calculate : IProvider<Rover>
    {
        public void Execute(Rover rover)
        {
            foreach (var item in rover.MovementInformation)
            {
                MoveEnum moveEnum;
                Enum.TryParse(item.ToString().ToUpper(), out moveEnum);

                switch (moveEnum)
                {
                    case MoveEnum.M:
                        rover.Move(rover.Direction);
                        break;
                    case MoveEnum.R:
                        rover.TurnRight90(rover.Direction);
                        break;
                    case MoveEnum.L:
                        rover.TurnLeft90(rover.Direction);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
