using UnityEngine;
using System;

public static class GameEvents
{
    public static Action GameStarted;
    public static Action GameEnded;
    public static Action GamePaused;
    public static Action<float> GameplayTimeChanged;
    public static Action<float> GameplayTimeSet;
    public static Action<float> GameplayTimeTicked;
}
