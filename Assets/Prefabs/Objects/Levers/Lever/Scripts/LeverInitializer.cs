using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInitializer : MonoBehaviour {
    
    public enum State { On, Off, };
    public State initialState;

    void Awake() {

        Animator animator = gameObject.GetComponent<Animator>();

        if (initialState == State.On) {
            animator.SetTrigger("toOn");
        }

    }
    
}
