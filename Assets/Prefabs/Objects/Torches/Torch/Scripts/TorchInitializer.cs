using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInitializer : MonoBehaviour {

    public enum State { Burning, Smoking, Idle, };
    public State initialState;

    public void Awake() {

        Animator animator = gameObject.GetComponent<Animator>();

        switch (initialState) {
            
            case State.Burning:
                animator.SetTrigger("toBurning");
                break;
            
            case State.Smoking:
                animator.SetTrigger("toSmoking");
                break;
            
            default:
                animator.SetTrigger("toIdle");
                break;
            
        }

    }

}
