using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMasterRD : MonoBehaviour
{
    public static UIMasterRD S;

    [Header("Buttons")]
    public GameObject play_object;
    public Button play_button;
    public GameObject discard_object;
    public Button discard_button;


    private void Awake()
    {
        S = this;
    }

    public void Set_Human_Active()
    {
        
    }

    public void On_Play_Pressed()
    {
        Debug.Log("Play Button Pressed");
        GameMaster.S.Play_Action();
    }

    public void On_Discard_Pressed()
    {
        Debug.Log("Discard Button Pressed");
        GameMaster.S.Discard_Action();
    }

    public void Display_Draw_Buttons(bool blue, bool green, bool white, bool yellow, bool red)
    {

    }
}
