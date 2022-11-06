using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Interactable : MonoBehaviour
{
    public bool trigger = false;
    private Collider2D boxCollider;

    protected virtual void Start() {
            boxCollider = GetComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
    }

    public virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Trigger Enter");
            trigger = true;
        }   
    }

    public virtual void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Trigger Exit!");
            trigger = false;
        }
    }

    protected virtual void Update() {
        if(trigger == true && Input.GetKeyDown(KeyCode.Space)){
            objectsAction();
        }
    }


    protected virtual void objectsAction(){
        Debug.Log("Im being interacted with!!!");

    } 



}