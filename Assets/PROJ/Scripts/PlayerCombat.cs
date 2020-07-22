using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayer;

    public Transform attackPoint;
    public float attackRange;
    public int attackDamage = 20;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;


    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            // implement the attackRate
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            Debug.Log("We've dealed" + attackDamage + "damage to "+ enemy.name );
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
