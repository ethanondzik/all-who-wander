using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInitializer : MonoBehaviour {

    public enum Direction {
        North,
        NorthEast,
        NorthWest,
        West,
        East,
        SouthEast,
        SouthWest,
        South,
    }

    public Direction initialDirection;
    
    void Awake() {

        Animator animator = gameObject.GetComponent<Animator>();
        
        switch (initialDirection) {
            
            case Direction.North:
                animator.SetTrigger("toNorth");
                break;
            
            case Direction.NorthEast:
                animator.SetTrigger("toNorthEast");
                break;
            
            case Direction.NorthWest:
                animator.SetTrigger("toNorthWest");
                break;
            
            case Direction.West:
                animator.SetTrigger("toWest");
                break;
            
            case Direction.East:
                animator.SetTrigger("toEast");
                break;
            
            case Direction.SouthEast:
                animator.SetTrigger("toSouthEast");
                break;
            
            case Direction.SouthWest:
                animator.SetTrigger("toSouthWest");
                break;
            
            case Direction.South:
                animator.SetTrigger("toSouth");
                break;
            
        }
        
    }
    
}
