using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DA7 : MonoBehaviour
{
    // Start is called before the first frame update

    public bool animationdoor7 = false;
    public Animator animator;
    public GameObject gameplayUI;
    public GameObject END;
    public PlayerHealth ph;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Door7()
    {
        if (animationdoor7 == true)
        {
            Destroy(gameObject);
            gameplayUI.SetActive(false);
            END.SetActive(true);
            ph.END();
        }
    }


}
