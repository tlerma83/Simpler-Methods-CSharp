using System;
using System.Collections.Generic;

namespace expression_members
{


    public class Bug
    {
    /*
        You can declare a typed public property, make it read-only,
        and initialize it with a default value all on the same
        line of code in C#. Readonly properties can be set in the
        class' constructors, but not by external code.
    */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

    // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";


    // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            // best practice when referencing a set property is to refer to "this", always this
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        //Prey is a set property so use this as a reference
        public string PreyList => string.Join(",", this.Prey);

        // Convert this method to an expression member
        public string PredatorList => string.Join(", ", this.Predators);

        // Convert this to expression method (hint: use a C# ternary)
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}" : $"{this.Name} is still hungry.";
    }


    class Program
    {
        static void Main(string[] args)
        {

            List<Bug> bugList = new List<Bug>(){
                new Bug("Sam", "ant", new List<string>(){"Me", "birds"}, new List<string>(){"Crumbs"}),
                new Bug("Kenny", "mouse", new List<string>(){"Cat"}, new List<string>(){"Salsa"})
            };


            foreach(Bug item in bugList){
                //for each Bug object in buglist console the Name, Species, PredatorList, and PreyList properties
                Console.WriteLine($"Is there a bug? {item.Name} {item.Species} {item.PredatorList} {item.PreyList}");
                // Formal Name is a Method already set, pass in the Item to get response
                Console.WriteLine(item.FormalName);
            }

            // this passes a string along with the Bug object at index 0 to the Eat Method in Bug Class
            Console.WriteLine(bugList[0].Eat("cheese"));
            
        }
    }
}
