using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour {

    public MovementSpecs movementSpecs;
    public Rigidbody2D body;
    
    public virtual void Start() {
        movementSpecs = gameObject.GetComponent<MovementSpecs>();
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    
    public virtual void SetDirection(Vector3 direction) {
        
    }
    
    public bool UpdatePosition(Vector3 direction) {
    
        Vector2 deltaPosition = direction;
        deltaPosition = deltaPosition * movementSpecs.movementSpeed;
        deltaPosition = deltaPosition * Time.fixedDeltaTime;
        
        body.MovePosition(body.position + deltaPosition);
    
        return true;
    
    }

    public bool TryMove(Vector3 direction) {

        var result = new List<RaycastHit2D>();
        var filter = new ContactFilter2D();
        float offset = 0.1f;

        if (body.Cast(direction, filter, result, offset) == 0) {
            return UpdatePosition(direction);
        }
        
        return false;
    
    }

    public virtual void FixedUpdate() {

        Vector3 movementDirection = movementSpecs.movementDirection;

        SetDirection(movementDirection);
        
        if (movementDirection != Vector3.zero) {

            if (TryMove(movementDirection)) {
                return;
            }
            
            if (TryMove(new Vector3(movementDirection.x, 0, 0))) {
                return;
            }
            
            if (TryMove(new Vector3(0, movementDirection.y, 0))) {
                return;
            }

        }

    }
    
}
