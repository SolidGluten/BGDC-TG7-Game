using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Types
{
    public enum BaseIngredient
    {
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
        Corn, //<- still questiionable
    }

    public enum DishType
    {
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
        FishMChips, //Fries + GrilledSalmon
    }

    [Flags]
    public enum ProcessType
    {
        Fry = 1,
        Cut = 2,
        DeepFry = 4,
        Oven = 8,
        DryAged = 16,
        Soup = 32
    }

    public enum SideDishType
    {
        CutCarrot,
        CutPotato,
        CutCorn,
        CutMushroom
    }
}
