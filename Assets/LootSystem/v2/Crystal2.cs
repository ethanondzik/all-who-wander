using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Crystal2 : MonoBehaviour
{

    private int quantity;
    private AudioSource ding;
    public bool isTriggerActive;
    public int Value { get => quantity; set => this.quantity = value; }


    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            isTriggerActive = true;
        }    
        if(isTriggerActive == true){
            if(Input.GetKeyDown(KeyCode.Space)){
                objectsAction(other);
            }
        }

    }

   public void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            isTriggerActive = false;
        }
    }

    public void Update(){

    }
    protected void objectsAction(Collider2D other)
    {
        Wallet current = null;
        quantity = Random.Range(1, 11);
        if (other.TryGetComponent<Wallet>(out current))
        {
            current.lootCrystal(quantity);
            Destroy(this.gameObject);
        }
        Debug.Log("Grant Crystals:  " + quantity);

    } 
}

