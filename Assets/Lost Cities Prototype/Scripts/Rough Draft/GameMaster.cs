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

    [Header("Game Details")]
    public bool last_card_drawn = false;


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

        current_turn = turn_order[coin_flip];


     // Deck
        // Create all cards and shuffle

        deck_script.Initialize_Deck();


     // Deal 8 Cards to Human Order
        for (int count = 1; count <= 8; count++)
        {
            GameObject card = deck_script.Draw_Card();

            CardRD cardRD = card.GetComponent<CardRD>();

            cardRD.pile = Pile.Human_Hand;

            human_script.Add_Card_to_Hand(card);
        }


     // Deal 8 Cards to Robot Order
        for (int count = 1; count <= 8; count++)
        {
            GameObject card = deck_script.Draw_Card();

            CardRD cardRD = card.GetComponent<CardRD>();

            cardRD.pile = Pile.Robot_Hand;

            robot_script.Add_Card_to_Hand(card);
        }

        //Game_Loop();

    }

    private void Update()
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

                    // Wait For Input
                    //human_script.Take_Turn();

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
     // 2 Actions per Turn
        // Play { Play to Expidition Plot || Discard to Expidition Discard }
        // Draw { Either from Deck || from Expidition Discard }
            // Exeption ! Card draw cannot be the same card discarded same turn

     // Loop through turn order
        // Deck signals last card drawn !

     // Calculating Scene
        // Add Round and Winner to Best_of_Three 

     // Next Round Loser Goes First

     // Repeat Game Loop x2

     // Round Finale Calculation Scene

    }

    public MonoBehaviour Current_Turn_Holder()
    {
        if (current_turn == Order.Human)
        {
            return human_script;
        }
        else
        {
            return robot_script;
        }
    }

    public void Score_Scene()
    {
        Debug.LogWarning("End Game Scene");
    }

}
