using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInitializer : MonoBehaviour {

    public enum State { Open, Closed, };
    public State initialState;
    
    void Awake() {

        Animator animator = gameObject.GetComponent<Animator>();

        if (initialState == State.Open) {
            animator.SetTrigger("isOpen");
        }
        
    }
    
}
