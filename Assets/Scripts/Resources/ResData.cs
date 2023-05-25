using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResData : MonoBehaviour
{
    public static class Gui
    {
        public static Texture2D chest01 = Resources.Load("Gui/Chest_1") as Texture2D;

        public static Texture2D bottle01 = Resources.Load("Gui/Bottle_1") as Texture2D;

        public static Texture2D key01 = Resources.Load("Gui/Key_1") as Texture2D;

        public static Texture2D speedBoots01 = Resources.Load("Gui/SpeedBoots_1") as Texture2D;

        public static Texture2D jumpBoost01 = Resources.Load("Gui/JumpBoost_1") as Texture2D;

    }
    public static class Sounds
    {
        public static class Footsteps
        {
            public static AudioClip[] concrete = {
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_01") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_02") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_03") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_04") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_05") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_06") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_07") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Concrete/Footstep_Concrete_08") as AudioClip
            };

            public static AudioClip[] wood = {
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_01") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_02") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_03") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_04") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_05") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_06") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_07") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Wood/Footstep_Wood_08") as AudioClip,
            };

            public static AudioClip[] gravel = {
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_01") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_02") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_03") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_04") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_05") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_06") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_07") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Gravel/Footstep_Gravel_08") as AudioClip
            };

            public static AudioClip[] metal = {
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_01") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_02") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_03") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_04") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_05") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_06") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_07") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Metal/Footstep_Metal_08") as AudioClip
            };

            public static AudioClip[] water = {
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_01") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_02") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_03") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_04") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_05") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_06") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Water/Footstep_Water_07") as AudioClip
            };

            public static AudioClip[] snow = {
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_01") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_02") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_03") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_04") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_05") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_06") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_07") as AudioClip,
                Resources.Load ("Sounds/Footsteps/Snow/Footstep_Snow_08") as AudioClip
            };
        }

    }
}
