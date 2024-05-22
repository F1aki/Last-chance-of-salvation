using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemAi : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30f;
    public PlayerHealth _playerHealth;
    private EnemyHealth _health;
    //public Animator e;


    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed = false;


    public bool IsAlive()
    {
        return _health.IsAlive();
    }


    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Enemy();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _health = GetComponent<EnemyHealth>();
        //e.SetBool("Run", true);
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {

                _playerHealth.DealDamage(damage * Time.deltaTime);
                //e.SetBool("Attack", true);

            }
            else
            {
                //e.SetBool("Attack", false);
            }
        }

    }


    private void Enemy()
    {
        var i = Random.Range(0, patrolPoints.Count);
        _navMeshAgent.destination = patrolPoints[i].position;
    }


    private void Update()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if (_isPlayerNoticed == false)
            {
                Enemy();
            }
        }

        AttackUpdate();

        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }

        _ray();
    }


    private void _ray()
    {
        var direction = player.transform.position - transform.position;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
                else
                {
                    _isPlayerNoticed = false;
                }
            }
            else
            {
                _isPlayerNoticed = false;
            }

        }
        else
        {
            _isPlayerNoticed = false;
        }





    }


}

