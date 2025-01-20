using UnityEngine;
using System;

namespace Chris
{
    public static class SettingEvents
    {
        // Presenter --> View: When first set the vol from model or read player's setting data
        public static Action<float> MasterSliderSet;
        public static Action<float> SFXSliderSet;
        public static Action<float> MusicSliderSet;

        // Presenter --> Model: When player change the sliders
        public static Action<float> MasterSliderChanged;
        public static Action<float> SFXSliderChanged;
        public static Action<float> MusicSliderChanged;
    }
}
