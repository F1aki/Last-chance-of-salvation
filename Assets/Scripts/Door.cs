using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DA6 DA6;
    public DoorAnimation5 DoorAni5;
    public DoorAnimation DoorAni;
    public PlayerController pl;
    private int I = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "D5" && pl.hasKey1)
        {
            DoorAni5.animationdoor5 = true;
        }
        else if (other.gameObject.tag == "D4" && pl.hasKey2)
        {
            DoorAni.animationdoor = true;
        }
        else if (other.gameObject.tag == "D2" && pl.hasKey3)
        {
            Destroy(other.gameObject);
        }
<<<<<<< Updated upstream
        else if (other.gameObject.tag == "D6" && pl.hasKey4)
        {
            DA6.animationdoor6 = true;
            
            Debug.Log(I);
        }

=======
        else if (other.gameObject.tag == "D1" && pl.hasKey4)
        {
            Destroy(other.gameObject);
        }
>>>>>>> Stashed changes
    }
}   
