using UnityEngine;
using System.Collections.Generic;

public class CardProvider : MonoBehaviour
{
    //[SerializeField] CardHolder cardHolderPrefab;
    [SerializeField] private List<Card> cards;

    public Card GetRandomCard()
    {
        int idx = Random.Range(0, cards.Count);
        return cards[idx];
    }
}
