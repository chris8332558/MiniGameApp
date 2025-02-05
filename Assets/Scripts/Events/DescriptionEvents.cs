using UnityEngine;
using System;

namespace Chris
{
    public static class DescriptionEvents
    {
        public static Action<string> GameTitleSet;
        public static Action<float> GameplayTimeSet;
        public static Action<string> DescriptionSet;
        public static Action<int> GameSceneIdxSet;

        public static Action<GameType, int> DescriptionChanged;
    }
}
