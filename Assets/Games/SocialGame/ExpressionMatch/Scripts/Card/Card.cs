using UnityEngine;

public enum CardType
{
    None,
    Happy,
    Sad,
    Angry,
    Surprise,
}

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public Sprite sprite;
    public CardType type;
}

