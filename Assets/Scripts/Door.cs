using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DA6 DA6;
    public DoorAnimation5 DoorAni5;
    public DoorAnimation DoorAni;
    public PlayerController pl;
    public DoorAnimation door;
    public DoorAnimation5 door5;
    public DoorAnimation2 door2;
    private int I = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "D5" && pl.hasKey1)
        {
            DoorAni5.animationdoor5 = true;
            door5.Door5(); 
        }
        else if (other.gameObject.tag == "D4" && pl.hasKey2)
        {
            DoorAni.animationdoor = true;
            door.Door4();
        }
        else if (other.gameObject.tag == "D2" && pl.hasKey3)
        {
            door2.animationdoor2 = true;
            door2.Door2();
        }
        else if (other.gameObject.tag == "D6" && pl.hasKey4)
        {
            DA6.animationdoor6 = true;
            DA6.Door6();
            
            Debug.Log(I);
        }

    }
}   
