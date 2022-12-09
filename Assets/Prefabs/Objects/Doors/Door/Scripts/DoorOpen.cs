using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : StateMachineBehaviour {

    public override void OnStateExit(Animator animator, AnimatorStateInfo state, int layer) {
        // used to diseble a door's collider in order to allow a player to walk through it
    }
    
}
