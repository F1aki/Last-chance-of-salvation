using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation2 : MonoBehaviour
{
    public bool animationdoor2 = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Door2()
    {
        if (animationdoor2 == true)
        {
            animator.SetTrigger("D2");
        }
    }
}
