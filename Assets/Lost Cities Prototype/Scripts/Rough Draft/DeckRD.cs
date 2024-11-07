using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRD : MonoBehaviour
{

    static public DeckRD Deck;



    private void Awake()
    {
        Deck = this;
    }
}
