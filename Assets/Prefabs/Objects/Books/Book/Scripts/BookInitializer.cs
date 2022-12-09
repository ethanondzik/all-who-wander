using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInitializer : MonoBehaviour {
    
    public bool isOpen;
    
    void Awake() {

        Animator animator = gameObject.GetComponent<Animator>();

        if (isOpen) {
            animator.SetBool("isOpen", true);
        }
        
    }

}
