using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Expedition : MonoBehaviour
{


    public List<GameObject> cards;
    private DeckRD deck_script;
    public GameObject Deck;

    private void Awake()
    {
        deck_script = Deck.GetComponent<DeckRD>();
    }
    
    // Start is called before the first frame update
    void Start(){
        
    }

    void Update()
    {
        if(!cards.Any())
        {
            for (int count = 1; count <= 5; count++)
            {
                GameObject card_to_draw = deck_script.Draw_Card();
                Debug.Log(card_to_draw);
                Add_Card(card_to_draw);
            }
        }
    }
    void Add_Card(GameObject card){
        cards.Add(card);
        Calculate_Score();
    }

    void Calculate_Score(){

        int score = 0;

        foreach(GameObject card in cards) {
            Card card_data = card.GetComponent<Card>();
            Debug.Log(card_data.value);
        }
    }
}
