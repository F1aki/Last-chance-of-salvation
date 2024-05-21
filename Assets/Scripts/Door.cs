using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    public PlayerController pl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "D5" && pl.hasKey1)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "D4" && pl.hasKey2)
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "D2" && pl.hasKey3)
        {
            Destroy(other.gameObject);
        }
    }
}   
