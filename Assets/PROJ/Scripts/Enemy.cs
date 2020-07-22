using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currHealth;
    public int maxHealth = 100;

    public HealthBar healthBar;

    public Animator animator;

    public Transform player;
    bool isFlipped = false;
    Vector3 flipped;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        animator.SetTrigger("Hurt");

        currHealth -= damage;
        healthBar.setHealth(currHealth);

        if(currHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        // Die Anim
        //GetComponent<>().enabled = false;

        this.enabled = false;
        // Disabling all the stuff
    }

    public void lookAtPlayer()
    {
        flipped = transform.localScale;
        flipped.z *= -1f;

        if(player.position.x < transform.position.x && isFlipped == false)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        if(player.position.x > transform.position.x && isFlipped == true)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }

    }
}
