using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueExpeditionRD : MonoBehaviour
{
    [Header("Attributes")]
    public Colour my_color = Colour.Blue;

    [Header("Objects")]
    public GameObject expidition_plot;
    public GameObject expidition_top_deck;

    [Header("Plots")]
    public List<GameObject> human_plot;
    public List<GameObject> robot_plot;
    public List<GameObject> expedition_discard;

    public void Set_Top_Deck()
    {
        if (expedition_discard.Count ==  0) return;

        int last_card = expedition_discard.Count - 1;

        GameObject card = expedition_discard[(expedition_discard.Count) - 1];

        card.transform.SetParent(expidition_top_deck.transform);

        card.transform.position = expidition_top_deck.transform.position;

        card.SetActive(true);
    }

}
