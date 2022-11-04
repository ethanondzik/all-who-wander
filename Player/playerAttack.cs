using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    //weapon area data//
    
    public Transform attackPos;
    public LayerMask onlyEnemies;
    public float attackRange;
    public int damage;
    public AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenAttack <= 0){
            if(Input.GetKey(KeyCode.O)){
                attackSound.Play();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, onlyEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().takeDamage(damage);
                }

            }
            timeBetweenAttack = startTimeBetweenAttack;
        } else {
            timeBetweenAttack -= Time.deltaTime;
        }
        
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    
}
