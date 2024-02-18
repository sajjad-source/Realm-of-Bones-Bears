using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;


/*
 * https://discussions.unity.com/t/making-an-object-rotate-to-face-another-object/27560
 * https://discussions.unity.com/t/detect-mouseover-click-for-ui-canvas-object/152611/5
 * https://www.youtube.com/watch?v=m8rGyoStfgQ
 */
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    public Interactable focus;

    Camera cam;
    PlayerMotor motor;
    public int currentHealth = 100;
    public int currentAttack = 5;
    public int currentDefense = 0;
    public int attackRadius = 2;
    public float attackRate = 3f;

    private float lastAttackTime;


    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 30.0f);
            if (Physics.Raycast(ray, out hit, 100f, movementMask)) //movementMask -> Should I add it?
            {
                transform.GetComponent<NavMeshAgent>().isStopped = false;
                transform.GetComponentInChildren<Animator>().SetTrigger("NoAttack");
                motor.MoveToPoint(hit.point);
                RemoveFocus();
                
            }
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    transform.GetComponent<NavMeshAgent>().isStopped = false;
                    transform.GetComponentInChildren<Animator>().SetTrigger("NoAttack");
                    SetFocus(interactable);
                }
                // Check if hit an interactable
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, attackRadius);
            foreach (Collider collider in enemies)
            {
                if (collider.gameObject.CompareTag("Enemy"))
                {
                    if (Time.time > lastAttackTime + attackRate)
                    {
                        transform.GetComponent<NavMeshAgent>().isStopped = true;
                        transform.GetComponentInChildren<Animator>().SetTrigger("Attack");
                        collider.GetComponent<Enemy>().TakeDamage(currentAttack);
                        Debug.Log("Attacking");
                        lastAttackTime = Time.time;
                    }

                }
            }

        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
            
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
