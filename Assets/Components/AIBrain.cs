using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour {

    public AIState state;
    public AIState substate;

    public bool playerInMeleeRange;

    public int attackCounter;
    public int idleCounter;
    public int moveCounter;
    public int hurtCounter;
    
    public int chaseRadius;
    public int attackRadius;
    public float scale;
    
    public Vector3 avatarPosition;

}
