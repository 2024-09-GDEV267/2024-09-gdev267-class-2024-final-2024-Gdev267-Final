using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCard : MonoBehaviour
{
    HEARTS("Red"),
    DIAMONDS("Red"),
    CLUBS("Black"),
    SPADES("Black");

    private final String color;

    Suit(String color)
    {
        this.color = color;
    }

    public String getColor()
    {
        return color;
    }
}

public class Card
{
    private final Suit suit;
    private final int rank;

    public Card(Suit suit, int rank)
    {
        this.suit = suit;
        this.rank = rank;
    }

    public String getColor()
    {
        return suit.getColor();
    }

    // ... other methods for getting rank, suit, etc.
}

public class Main
{
    public static void main(String[] args)
    {
        Card card = new Card(Suit.HEARTS, 10);
        System.out.println("Card color: " + card.getColor());
    }
}
