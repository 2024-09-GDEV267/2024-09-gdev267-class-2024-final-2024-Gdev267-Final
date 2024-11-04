using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Holder
{
    Player,
    Opponent,
    Expedition,
    Discard,
    Deck
}

public class Player : MonoBehaviour
{
    public bool has_acted;
    public bool has_drawn;

    public GameObject selected_card;

    public GameObject player_hand;
    public GameObject[] player_slots;
    public List<GameObject> player_cards;

    private void Update()
    {

    }

    public void FirstEight()
    {
        int count = 0;

        foreach (GameObject card in player_cards)
        {
            Card script = card.GetComponent<Card>();

            script.holder = Holder.Player;
            script.in_hand = true;

            card.transform.position = Vector3.zero;

            card.transform.SetParent(player_slots[count].transform);

            card.transform.position = player_slots[count].transform.position;

            card.SetActive(true);

            count++;
        }
           

    }



}
