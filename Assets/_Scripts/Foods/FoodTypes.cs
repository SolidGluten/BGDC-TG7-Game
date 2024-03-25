using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Types
{
    public enum FoodType
    {
        Ingredient,
        SemiProcessed,
        Dish,
        SideDish,
        Beverage
    }

    public enum BaseIngredient
    {
        None,
        Beef,
        Drumstick,
        Porkchop,
        Egg,
        Salmon,
        Shrimp,
        Clam,
        //Crab,
        Lobster,
        Potato,
        Carrot,
        Mushroom,
        Corn,
    }

    public enum SemiProcessed
    {
        None,
        MincedBeef,
        MincedChicken,
        MincedPork,
        BeatenEgg,
        FermentedBeef,
        FermentedDrumstick,
        FermentedPorkchop,
        FermentedEgg
    }

    public enum DishType
    {
        None,
        Steak, //Cooked version of beef
        CookedChicken, //Cooked version of drumstick
        CookedPorkChop, //Cooked version of porkchop
        SunnySideUp, //Cooked version of egg
        GrilledSalmon, //Cooked version of salmon
        PanSearedShrimp, //Cooked version of shrimp
        SauteedClams, //Cooked version of clams
        PanFriedLobster, //Cooked version of crab

        Meatball, //Cooked & Cut version of beef
        GrilledChicken, //Cooked & Cut version of drumstick
        CripsyBacon, //Cooked & Cut version of porkchop
        Omellete, //Cooked & Cut version of egg

        CarrotSoup,
        PotatoSoup,
        CornSoup,
        MushroomSoup,

        FriedSteak,
        FriedChicken,
        FriedPorkchop,
        FriedEgg,

        BatteredSalmon,
        FriedLobster,
        //FriedCrab,
        FriedClam,
        FriedShrimp,

        FrenchFries,
        FriedCarrot,
        FriedMushroom,
        FriedCorn,

        BaconNEggs, //Bacon + Egg
        SurfNTurf, //Steak + PanSearedShrimp
        StuffedChicken, //Chicken + Shrimp

        SauteedPotato,
        SauteedCarrot,
        SauteedCorn,
        SauteedMushroom
    }

    
    public enum DrinkType
    {
        None,
        Red,
        Orange, //Red + Yellow
        Yellow,
        Green, //Yellow + Blue
        Blue,
        Purple //Red + Blue
    }

    public enum SideDish
    {
        None,
        CutCarrot,
        CutPotato,
        CutCorn,
        CutMushroom
    }

    public class TypeUtils {
        public static SideDish GetRandomSideDish()
        {
            Dictionary<SideDish, int> SideDishWeights = new Dictionary<SideDish, int>();
            SideDishWeights.Add(SideDish.None, 2);
            SideDishWeights.Add(SideDish.CutPotato, 1);
            SideDishWeights.Add(SideDish.CutMushroom, 1);
            SideDishWeights.Add(SideDish.CutCarrot, 1);
            SideDishWeights.Add(SideDish.CutCorn, 1);

            int total = SideDishWeights.Values.Sum();
            Random random = new Random();
            int rand = random.Next(total) + 1; //returs number between 1-total

            int sum = 0;
            foreach (KeyValuePair<SideDish, int> pair in SideDishWeights) {
                sum += pair.Value;
                if (rand <= sum) {
                    return pair.Key;
                }
            }

            return SideDish.None;
        }

        public static DrinkType GetRandomDrink()
        {
            Dictionary<DrinkType, int> DrinkTypeWeights = new Dictionary<DrinkType, int>();
            DrinkTypeWeights.Add(DrinkType.None, 3);
            DrinkTypeWeights.Add(DrinkType.Blue, 1);
            DrinkTypeWeights.Add(DrinkType.Orange, 1);
            DrinkTypeWeights.Add(DrinkType.Green, 1);
            DrinkTypeWeights.Add(DrinkType.Red, 1);
            DrinkTypeWeights.Add(DrinkType.Yellow, 1);
            DrinkTypeWeights.Add(DrinkType.Purple, 1);

            int total = DrinkTypeWeights.Values.Sum();
            Random random = new Random();
            int rand = random.Next(total) + 1; //returs number between 1-total 
            //4

            int sum = 0;
            foreach (KeyValuePair<DrinkType, int> pair in DrinkTypeWeights) {
                sum += pair.Value;
                if (rand <= sum) {
                    return pair.Key;
                }
            }

            return DrinkType.None;
        }
    }
}
