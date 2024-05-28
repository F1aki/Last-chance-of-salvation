using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float damage = 30;
    public Animator animator;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    public float attackDistance = 1.5F;
    public AudioSource Sound2;
    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }
    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoints();
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        AttackUpdate();
    }
    private void AttackUpdate()
    {
        if(_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    private void NoticePlayerUpdate()
    {
        
        _isPlayerNoticed = false;
        if (_playerHealth.value <= 0) return;
        var diraction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, diraction) < viewAngle)
        {
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, diraction, out hit))
            {
                if (hit.collider.GetComponent<PlayerController>() != null)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                  PickNewPatrolPoints();
            }
        }  
    }
    private void PickNewPatrolPoints()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    public void AttackDamageEvent()
    {
        AttackDamage();
    }
    public void AttackDamage()
    {
        if (!_isPlayerNoticed) return;
        if (_navMeshAgent.remainingDistance > (_navMeshAgent.stoppingDistance + attackDistance)) return;
        
        _playerHealth.DealDamage(damage);
        Sound2.Play();
    }


}