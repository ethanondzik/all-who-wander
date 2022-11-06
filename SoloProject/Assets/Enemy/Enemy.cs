using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : MonoBehaviour


{
    private Collider2D boxCollider;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage){
        health -= damage;
        Debug.Log("Ouch!");
    }
}
