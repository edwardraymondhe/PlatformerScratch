using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    float attackRange;

    public float Speed = 2.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponentInParent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //attackRange = animator.GetComponentInParent<PlayerCombat>().attackRange;
        //enemy.lookAtPlayer();

        animator.GetComponentInParent<Enemy>().lookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, Speed * Time.fixedDeltaTime);
        
        rb.MovePosition(newPos);

        // Vector2.Distance()
        //Debug.Log("Range " + attackRange);
        //Debug.Log("Distance " + Vector2.Distance(player.position, rb.position));
        if (Vector2.Distance(player.position, rb.position) <= 1f)
        {
            animator.SetTrigger("Attack");
            return;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");    
    }

}
