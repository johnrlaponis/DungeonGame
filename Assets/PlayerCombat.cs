using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //When we have animations take the slashes away from this note directly below
    //public Animator animator;

    //This will allow a point for the melee attacks to hit enemies
    public Transform attackPoint;
    public float attackRange = 0.5f;
    //To detect the enemies in your attack range
    public LayerMask enemyLayers;
    //How much damage you do
    public int attackDamage = 20;
    //How many times you can attack a second
    public float attackRate = 2f;
    //when can attack next
    float nextAttackTime = 0f;


    void Update()
    {
        if(Time.time <= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       
    }

    void Attack()
    {
        //Play attack animation
        //Delete the slashes from directly below when animations are input
        //animator.SetTrigger("Attack");

        //Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    //To see and adjust the area that you are attacking, can be deleted later after fine tuning
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
