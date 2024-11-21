using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMasterRD : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject play_button;
    public GameObject discard_button;


    public void On_Play_Pressed()
    {
        Debug.Log("Play Button Pressed");
    }

    public void On_Discard_Pressed()
    {
        Debug.Log("Discard Button Pressed");
    }
}
