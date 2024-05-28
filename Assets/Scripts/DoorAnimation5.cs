using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation5 : MonoBehaviour
{
    public bool animationdoor5 = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Door5()
    {
        if (animationdoor5 == true)
        {
            animator.SetTrigger("D5");
        }
    }
}
