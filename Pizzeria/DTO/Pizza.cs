using System;
using System.Collections.Generic;

namespace Pizzeria.DTO
{
    public enum PizzaName: byte { NeapolitanPizza, ThreeCheeses, Hawaiian }
    public class Pizza
    {
        public PizzaName PizzaName { get; internal set; }
        public List<Cheese> Cheeses { get; internal set; }
        public DateTime SettedDate { get; internal set; }
        public DateTime ValidUntil { get; internal set; }
        public List<string> Fillings { get; internal set; }
        public bool IsRaw { get; internal set; }
        public bool WithCrust { get; internal set; }
    }
}
