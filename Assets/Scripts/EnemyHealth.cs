using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;
    public AudioSource Sound;
    public AudioSource Sound1;
    public bool IsAlive()
    {
        return value > 0;
    }
    public void DealDamage(float damage)
    { 
        value -= damage;
        if (value <= 0)
        {

            EnemyDeath();
            ///Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("hit");
            Sound1.Play();
        }
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("Death");
        Sound.Play();
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
