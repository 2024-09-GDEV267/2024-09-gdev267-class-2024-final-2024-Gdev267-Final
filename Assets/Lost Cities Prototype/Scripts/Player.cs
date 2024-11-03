using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player_hand;
    public GameObject[] player_slots;
    public List<GameObject> player_cards;

    public void FirstEight()
    {
        int count = 0;

        foreach (GameObject card in player_cards)
        {
            card.transform.position = Vector3.zero;

            card.transform.SetParent(player_slots[count].transform);

            card.transform.position = player_slots[count].transform.position;

            card.SetActive(true);

            count++;
        }
           

    }

    private void OnMouseEnter()
    {
        //Debug.Log("enter");
        
        Vector3 new_position = player_hand.transform.position;

        new_position.y += 1;

        player_hand.transform.position = new_position;
    }

    private void OnMouseExit()
    {
        //Debug.Log("exit");

        Vector3 new_position = player_hand.transform.position;

        new_position.y -= 1;

        player_hand.transform.position = new_position;
    }
}
