using System;
using System.Collections.Generic;

namespace Pizzeria.DTO
{
    public enum PizzaName: byte { NeapolitanPizza, ThreeCheeses, Hawaiian }
    public class Pizza
    {
        public PizzaName PizzaName { get; set; }
        public List<Cheese> Cheeses { get; set; }
        public DateTime SettedDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public List<string> Fillings { get; set; }
        public bool IsRaw { get; set; }
        public bool WithCrust { get; set; }
    }
}
