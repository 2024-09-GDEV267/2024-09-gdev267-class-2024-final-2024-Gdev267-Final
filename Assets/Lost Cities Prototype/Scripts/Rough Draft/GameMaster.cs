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

public enum Pile
{
    Deck,
    Human_Hand,
    Robot_Hand,
    Expedition_Plot,
    Expedition_Discard
}

public class GameMaster : MonoBehaviour
{

    public Dictionary<Round, Order> Best_of_Three = new();

    [Header("Turn Details")]
    public Order current_turn;
    public Order[] turn_order = new Order[2];

    [Header("Object References")]
    public GameObject Deck;
    private DeckRD deck_script;
    public GameObject Human;
    private HumanRD human_script;
    public GameObject Robot;
    private RobotRD robot_script;


    private void Awake()
    {
        deck_script = Deck.GetComponent<DeckRD>();
        human_script = Human.GetComponent<HumanRD>();
        robot_script = Robot.GetComponent<RobotRD>();
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

            human_script.Add_Card_to_Hand(card);
        }


     // Deal 8 Cards to Robot Order
        for (int count = 1; count <= 8; count++)
        {
            GameObject card = deck_script.Draw_Card();

            robot_script.Add_Card_to_Hand(card);
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

}
