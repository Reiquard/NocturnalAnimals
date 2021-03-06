﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;

namespace NocturnalAnimals
{

    public static class Patch_RaceProperties
    {
        
        [HarmonyPatch(typeof(RaceProperties), nameof(RaceProperties.SpecialDisplayStats))]
        public static class Patch_SpecialDisplayStats
        {

            public static void Postfix(ThingDef parentDef, ref IEnumerable<StatDrawEntry> __result)
            {
                // Body clock
                __result = __result.AddItem(new StatDrawEntry(StatCategoryDefOf.BasicsPawn, "NocturnalAnimals.BodyClock".Translate(),
                    $"NocturnalAnimals.BodyClock_{ExtendedRaceProperties.Get(parentDef).bodyClock}".Translate(), "NocturnalAnimals.BodyClock_Description".Translate(), 2500));
            }

        }

    }

}
