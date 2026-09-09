using StupidTemplate.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Mane.Mods
{
    internal class Weather
    {
        private static void SetTime(float fraction)
        {
            BetterDayNightManager instance = BetterDayNightManager.instance;
            bool flag = instance == null;
            if (!flag)
            {
                int num = (instance.dayNightLightmapNames != null && instance.dayNightLightmapNames.Length != 0) ? instance.dayNightLightmapNames.Length : 8;
                int num2 = Mathf.Clamp(Mathf.RoundToInt((float)(num - 1) * fraction), 0, num - 1);
                instance.SetTimeOfDay(num2, true);
                try
                {
                    NotifiLib.SendNotification("<color=grey>[</color><color=cyan>WEATHER</color><color=grey>]</color> " + instance.GetTimeOfDayString());
                }
                catch
                {
                }
            }
        }

        public static void Night()
        {
            Weather.SetTime(0.95f);
        }

        public static void Evening()
        {
            Weather.SetTime(0.72f);
        }
        public static void Day()
        {
            Weather.SetTime(0.45f);
        }
        public static void Morning()
        {
            Weather.SetTime(0.22f);
        }
    }
}
