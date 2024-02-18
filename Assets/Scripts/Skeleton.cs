using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Enemy
{
    private Animator animator;
    private float lastAttackTime;
    public int baseHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        currHealth = baseHealth;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < attackRange)
        {
            agent.isStopped = true;

            if (Time.time > lastAttackTime + attackRate)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else if (distance <= lookRadius)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetTrigger("NoAttack");

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    public override void Attack()
    {
        animator.SetTrigger("Attack");
        // Give damage to player?
    }

    public override IEnumerator Die()
    {
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    public override void TakeDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            {
                StartCoroutine(Die());
            }
        }
    }
    public override void FaceTarget()
    {
        base.FaceTarget();
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}
