using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DA6 : MonoBehaviour
{
    public bool animationdoor6 = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animationdoor6 == true)
        {
            animator.SetTrigger("D6");
        }
    }
}
