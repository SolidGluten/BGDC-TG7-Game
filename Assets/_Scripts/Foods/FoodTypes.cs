using System;

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
        Crab,
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
        MincedSalmon,
        MincedShrimp,
        MincedClam,
        MincedCrab,
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
        PanFriedCrab, //Cooked version of crab

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
        FriedShrimp,
        FriedClam,
        FriedCrab,
        FrenchFries,
        FriedCarrot,
        FriedMushroom,
        FriedCorn,

        BaconNEggs, //Bacon + Egg
        SurfNTurf, //Steak + PanSearedShrimp
        FishNChips, //Fries + GrilledSalmon

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

    public class TypeUtils{
        public static SideDish GetRandomSideDish()
        {
            return (SideDish)UnityEngine.Random.Range(0, Enum.GetNames(typeof(SideDish)).Length);
        }

        public static DrinkType GetRandomDrink()
        {
            return (DrinkType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(DrinkType)).Length);
        }
    }
}
