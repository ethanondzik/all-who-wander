using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public CombatSpecs playerStats;
    private int quantity;
    private AudioSource ding;

    public int Value { get => quantity; set => this.quantity = value; }


    void Start(){
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatSpecs>();
    }
    protected void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            objectsAction(other);
        }    
    }
    protected void objectsAction(Collider2D other)
    {
        Wallet current = null;
        quantity = Random.Range(10, 26);
        if (other.TryGetComponent<Wallet>(out current))
        {
            playerStats.experience = playerStats.experience+quantity;
            current.lootCrystal(quantity);
            Destroy(this.gameObject);
        }
        Debug.Log("Grant Crystals:  " + quantity);

    } 
}
