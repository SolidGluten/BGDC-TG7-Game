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
        MincedDrumstick,
        MincedPork,
        MincedEgg,
        MincedSalmon,
        MincedShrimp,
        MincedClam,
        MincedCrab,
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
        BaconNEggs, //Bacon + Egg
        SurfNTurf, //Steak + PanSearedShrimp
        FishNChips, //Fries + GrilledSalmon
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
}
