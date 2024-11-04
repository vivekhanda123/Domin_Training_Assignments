using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator_pattern
{
    public interface Pizza
    {
        string MakePizza();
    }

    public class PlainPizza : Pizza
    {
        public string MakePizza()
        {
            return "Plain Pizza";
        }
    }
    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
        public virtual string MakePizza() 
        { 
            return pizza.MakePizza();
        }
    }
    public class ChickenPizza : PizzaDecorator
    {
        public ChickenPizza(Pizza pizza) : base(pizza)
        {

        }
        public override string MakePizza()
        {
            return pizza.MakePizza() + AddChicken();
        }
        public string AddChicken()
        {
            return "Chicken Added";
        }
    }
    public class VegetablePizza: PizzaDecorator
    {
        public VegetablePizza(Pizza pizza) : base(pizza)
        {

        }
        public override string MakePizza()
        {
            return base.MakePizza() + AddVegetables();    
        }
        private string AddVegetables()
        {
            return "Vegetable Added";
        }
    }
}


    

