using System;
using System.Collections;
using System.Collections.Generic;
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

}
