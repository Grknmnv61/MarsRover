using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Enums;

namespace BusinessLayer
{
    public class Rover : IRover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnum Direction { get; set; }
        public Plato Plato { get; set; }
        public string MovementInformation { get; set; }

        public Rover(int x, int y, DirectionEnum direction, Plato plato)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.Plato = plato;
        }

        public Rover(int x, int y, DirectionEnum direction, Plato plato, string movementInformation)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.Plato = plato;
            this.MovementInformation = movementInformation;
        }

        public void Move(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.N:
                    if (Y + 1 <= Plato.Y)
                        this.Y++;
                    break;
                case DirectionEnum.E:
                    if (X + 1 <= Plato.X)
                        this.X++;
                    break;
                case DirectionEnum.S:
                    if (Y - 1 >= 0)
                        this.Y--;
                    break;
                case DirectionEnum.W:
                    if (X - 1 >= 0)
                        this.X--;
                    break;
            }
        }

        public void TurnLeft90(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.N:
                    this.Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.W:
                    this.Direction = DirectionEnum.S;
                    break;
                case DirectionEnum.S:
                    this.Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.E:
                    this.Direction = DirectionEnum.N;
                    break;

                default:
                    break;
            }
        }

        public void TurnRight90(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.N:
                    this.Direction = DirectionEnum.E;
                    break;
                case DirectionEnum.E:
                    this.Direction = DirectionEnum.S;
                    break;
                case DirectionEnum.S:
                    this.Direction = DirectionEnum.W;
                    break;
                case DirectionEnum.W:
                    this.Direction = DirectionEnum.N;
                    break;

                default:
                    break;
            }
        }

        public string GetRoverLocationInformation()
        {
            return $"({X},{Y}) {Direction}";
        }
    }
}