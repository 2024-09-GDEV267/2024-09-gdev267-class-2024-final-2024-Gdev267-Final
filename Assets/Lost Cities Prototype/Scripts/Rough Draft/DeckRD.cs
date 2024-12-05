using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckRD : MonoBehaviour
{
    public GameObject Deck;

    [Header("Deck Properties")]
    public GameObject card_prefab;
    public List<GameObject> deck_list;

    public void Initialize_Deck()
    {
        var colours = Enum.GetValues(typeof(Colour));

        foreach (Colour colour in colours)
        {

            for (int value = 1; value <= 10; value++)
            {

                if (value == 1)
                {

                    for (int agreement_counter = 1; agreement_counter <= 3; agreement_counter++)
                    {

                        Create_Card(colour, value);

                    }
                }

                else
                {

                    Create_Card(colour, value);

                }

            }
        }

        Shuffle(ref deck_list);
    }


    private void Create_Card(Colour colour, int value)
    {
        GameObject temp_card = Instantiate(card_prefab);
        CardRD card = temp_card.GetComponent<CardRD>();

        card.Constructor(colour, value);

        card.current_pile = Pile.Deck;

        temp_card.transform.SetParent(Deck.transform);

        deck_list.Add(temp_card);
    }


    public void Shuffle(ref List<GameObject> deck_list)
    {
        List<GameObject> shuffle;

        int index;

        shuffle = new List<GameObject>();

        while (deck_list.Count > 0)
        {
            index = UnityEngine.Random.Range(0, deck_list.Count);

            shuffle.Add(deck_list[index]);

            deck_list.RemoveAt(index);
        }

        deck_list = shuffle;

    }

    public void Last_Card_Check()
    {
        int remaining_cards = deck_list.Count;

        if (remaining_cards == 0)
        {
            // Inform Game Master
            GameMaster.S.last_card_drawn = true;
            Debug.LogWarning("LAST CARD DRAWN!");
        }

    }

    public GameObject Draw_Card()
    {
        GameObject card = deck_list[(deck_list.Count) - 1];

        deck_list.RemoveAt((deck_list.Count) - 1);

        Last_Card_Check();

        return card;
    }

    public void Put_Back(GameObject card)
    {
        deck_list.Add(card);
    }

}
