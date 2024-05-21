using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    
    public bool animationdoor = false;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "D4" && animationdoor == true)
        {
            animator.SetTrigger("D4");
        }
    }
}
        