using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Bear : Enemy
{
    private Animator animator;
    private float lastAttackTime;
    public int baseHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
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
            animator.SetTrigger("Run Forward");

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }

    public override void Attack()
    {
        animator.ResetTrigger("Run Forward");
        animator.SetTrigger("Attack1");
        // Give damage to player?
    }

    public override IEnumerator Die()
    {
        yield return new WaitForSeconds(3);
    }

    public override void TakeDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            {
               /* Die();*/
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
