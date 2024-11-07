using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ColorCard : MonoBehaviour
{
    AreaR("Red"),
    AreaG("Green"),
    AreaB("Blue"),
    AreaW("White"),
    AreaY("Yellow");

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
    private final Expedition exp;
    private final int value;

    public Card(Expedition exp, int value)
    {
        this.exp = exp;
        this.value = value;
    }

    public String getColor()
    {
        return exp.getColor();
    }

    // ... other methods for getting rank, suit, etc.
}

public class Main
{
    public static void main(String[] args)
    {
        Card card = new Card(Expedition.AreaR, 10);
        System.out.println("Card color: " + card.getColor());
    }
}

// -- expedition colors
//data Color = Red | Green | White | Blue | Yellow 
//             deriving (Eq,Ord,Show,Read,Enum,Bounded)
//
//-- card face values: 0=investment; 2..10=value
//type Face = Int

//-- a card with a color and face
//type Card = (Color,Face) 

//-- a stack cards (of the same color)
//type Stack = [Face]

//-- projection functions
//color :: Card -> Color
//color = fst

//face :: Card -> Face
//face = snd


//-- the full playing deck
//fullDeck :: [Card]
//fullDeck = [(c,f) | c<-colors, f<-faces]

//-- all color
//colors :: [Color]
//colors = [minBound .. maxBound]

//-- all faces, including repeated investment cards
//faces :: [Face]
//faces = 0:0:0:[2..10]-- expedition colors
//data Color = Red | Green | White | Blue | Yellow 
 //            deriving (Eq,Ord,Show,Read,Enum,Bounded)

//-- card face values: 0=investment; 2..10=value
//type Face = Int

//-- a card with a color and face
//type Card = (Color,Face) 

//-- a stack cards (of the same color)
//type Stack = [Face]

//-- projection functions
//color :: Card -> Color
//color = fst

//face :: Card -> Face
//face = snd


//-- the full playing deck
//fullDeck :: [Card]
//fullDeck = [(c,f) | c<-colors, f<-faces]

//-- all color
//colors :: [Color]
//colors = [minBound .. maxBound]

//-- all faces, including repeated investment cards
//faces :: [Face]
//faces = 0:0:0:[2..10]
+