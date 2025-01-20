using UnityEngine;
using System;

namespace Chris
{
    /// <summary>
    /// Events that happen in one screens
    /// </summary>
    public static class SceneEvents
    {
        // Splash Scene
        public static Action<float> LoadProgressUpdated; 
        public static Action LoadCompleted;

        // Start Scene
        public static Action StartButtonClicked;

        // Load and Unload scene additively
        public static Action<int> LoadSceneByIndex;
        public static Action UnloadLastScene;
    }
}
