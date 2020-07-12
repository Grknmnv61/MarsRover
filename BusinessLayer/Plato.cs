using BusinessLayer.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Plato : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Plato(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
