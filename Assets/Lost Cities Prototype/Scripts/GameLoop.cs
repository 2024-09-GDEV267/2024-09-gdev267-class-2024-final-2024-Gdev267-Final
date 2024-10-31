using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Card;

public class GameLoop : MonoBehaviour
{

    public GameObject actionButtons;
    public GameObject drawButton;
    public GameObject endTurnButton;

    private string player_name = "Player 1";
    private Card[] hand_1 = new Card[8];
    private Card[] hand_1 = new Card[8];

    

    public void play_card()
    {
        Debug.Log(player_name + " played a card");
        actionButtons.SetActive(false);
        drawButton.SetActive(true);
    }
    public void discard_card()
    {
        Debug.Log(player_name + " discarded a card");
        actionButtons.SetActive(false);
        drawButton.SetActive(true);
    }
    public void draw()
    {
        Debug.Log(player_name + " drew a card");
        drawButton.SetActive(false);
        endTurnButton.SetActive(true);
    }
    public void end_turn()
    {
        Debug.Log(player_name + " ended their turn");
        if(player_name.Equals("Player 1")) {
            player_name = "Player 2";
        } else {
            player_name = "Player 1";
        }
        endTurnButton.SetActive(false);
        actionButtons.SetActive(true);
    }
}
