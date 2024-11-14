using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRD : MonoBehaviour
{
    public bool my_turn;

    [Header("Play/Discard, Draw")]
    public Action[] action = new Action[2];
    public Action current_action;

    [Header("Action Checks")]
    public bool has_played;
    public bool has_drawed;

    [Header("Cards in Hand")]
    public List<GameObject> cards;
    public GameObject Game;
    private GameMaster game_script;

    public void Awake()
    {
        game_script = Game.GetComponent<GameMaster>();
    }


    public void Add_Card_to_Hand(GameObject card)
    {
        if (Open_Spot_Check())
        {
            card.transform.SetParent(this.transform);

            cards.Add(card);
        }

    }

    public void Add_Draw_to_Hand(GameObject card)
    {
        if (Open_Spot_Check() && has_played)
        {
            card.transform.SetParent(this.transform);

            cards.Add(card);
        }

    }

    public bool Open_Spot_Check()
    {
        if (cards.Count < 8)
        {
            return true;
        }

        return false;
    }

    public void Take_Turn()
    {
        has_played =  false;
        has_drawed = false;
        Debug.Log("Robot Taking Turn ...");
        //Play or Discard
        has_played = true;

        //Draw card
        has_drawed = true;

        //End turn

    }
}
