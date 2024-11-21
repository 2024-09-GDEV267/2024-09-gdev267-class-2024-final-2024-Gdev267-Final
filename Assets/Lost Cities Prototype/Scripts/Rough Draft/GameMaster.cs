using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Order
{
    Human,
    Robot
}

public enum Round
{
    First,
    Second,
    Third,
}

public class GameMaster : MonoBehaviour
{
    public static GameMaster S;

    public Dictionary<Round, Order> Best_of_Three = new();

    [Header("Turn Details")]
    public Order current_turn;
    public Order[] turn_order = new Order[2];
    private bool human_turn_start = false;
    private bool robot_turn_start = false;

    [Header("Object References")]
    public GameObject Deck;
    private DeckRD deck_script;
    public GameObject Human;
    private HumanRD human_script;
    public GameObject Robot;
    private RobotRD robot_script;
    public GameObject action_slot;

    [Header("Expiditions")]
    public GameObject Blue_Expedition;
    public GameObject Green_Expedition;
    public GameObject White_Expedition;
    public GameObject Yellow_Expedition;
    public GameObject Red_Expedition;

    [Header("Game Details")]
    public bool last_card_drawn = false;
    public GameObject[] card_slot;
    public GameObject card_selected = null;
    public GameObject robot_slected;


    private void Awake()
    {
        deck_script = Deck.GetComponent<DeckRD>();
        human_script = Human.GetComponent<HumanRD>();
        robot_script = Robot.GetComponent<RobotRD>();

        S = this;
    }

    void Start()
    {
     // Coin Flip Scene
        int coin_flip = UnityEngine.Random.Range(0, 2);

        //current_turn = turn_order[coin_flip];
        current_turn = Order.Human;


     // Deck
        // Create all cards and shuffle

        deck_script.Initialize_Deck();


     // Deal 8 Cards to Human Order
        for (int count = 1; count <= 8; count++)
        {
            GameObject card = deck_script.Draw_Card();

            CardRD cardRD = card.GetComponent<CardRD>();

            cardRD.current_pile = Pile.Human_Hand;

            human_script.Add_Card_to_Hand(card);
        }


     // Deal 8 Cards to Robot Order
        for (int count = 1; count <= 8; count++)
        {
            GameObject card = deck_script.Draw_Card();

            CardRD cardRD = card.GetComponent<CardRD>();

            cardRD.current_pile = Pile.Robot_Hand;

            robot_script.Add_Card_to_Hand(card);
        }

        deck_script.Set_Top_Deck();

        Game_Loop();

    }

    private void Action_Slot_Card(GameObject card)
    {
        if (card_slot[0] == null)
        {
            card_selected.transform.position = action_slot.transform.position;
            card_slot[0] = card;
        } 
        
        else if ( card == card_slot[0])
        {
            human_script.Readd_Card(card_slot[0]);

            human_script.selected_card = null;
            card_selected = null;
        }

        else
        {
            human_script.Readd_Card(card_slot[0]);

            card_selected.transform.position = action_slot.transform.position;
            card_slot[0] = card;
        }
        
    }

    private void Game_Loop()
    {
        if (last_card_drawn)
        {
            Score_Scene();
        } else
        {
            switch (current_turn)
            {
                case Order.Human:
                    if (!human_turn_start)
                    {
                        human_turn_start = true;
                        human_script.my_turn = true;

                        Debug.Log("Human Turn");
                    }

                    // Turn Off Turn
                    if (human_script.has_played && human_script.has_drawed)
                    {
                        human_turn_start = false;

                        human_script.my_turn = false;
                        human_script.has_played = false;
                        human_script.has_drawed = false;

                        current_turn = Order.Robot;
                    }

                    break;

                case Order.Robot:
                    if (!robot_turn_start)
                    {
                        robot_turn_start = true;
                        robot_script.my_turn = true;

                        Debug.Log("Robot Turn");
                    }

                    // Wait For Outcome
                    //robot_script.Take_Turn();

                    //Turn Off Turn
                    if (robot_script.has_played && robot_script.has_drawed)
                    {
                        robot_turn_start = false;

                        robot_script.my_turn = false;
                        robot_script.has_played = false;
                        robot_script.has_drawed = false;

                        current_turn = Order.Human;
                    }

                    break;
            }

        }

    }

    public void Score_Scene()
    {
        Debug.LogWarning("End Game Scene");
    }

    public void Select(GameObject card)
    {
        CardRD card_script = card.GetComponent<CardRD>();

        switch (card_script.current_pile)
        {
            case Pile.Deck:
                break;

            case Pile.Human_Hand:
                human_script.selected_card = card;
                card_selected = card;

                Action_Slot_Card(card);
                break;

            case Pile.Robot_Hand:
                break;

            case Pile.Expedition_Plot:
                break;

            case Pile.Expedition_Discard:
                break;
        }


    }

    public void Play_Action()
    {
        if (current_turn != Order.Human) return;

        if (card_selected == null) return;

        CardRD card = card_selected.GetComponent<CardRD>();

        switch (card.colour)
        {
            case Colour.Blue:
                Debug.Log("Playing a Blue Card");
                break;

            case Colour.Green:
                Debug.Log("Playing a Green Card");
                break;

            case Colour.White:
                Debug.Log("Playing a White Card");
                break;

            case Colour.Yellow:
                Debug.Log("Playing a Yellow Card");
                break;

            case Colour.Red:
                Debug.Log("Playing a Red Card");
                break;

        }
    }

    public void Discard_Action()
    {

    }

}
