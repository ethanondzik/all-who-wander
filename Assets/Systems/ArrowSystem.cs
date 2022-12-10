using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSystem : WeaponSystem {

    public void OnTriggerEnter2D(Collider2D collider) {

        var exceptedCollisions = new List<string>{
	        "Player", "Weapon", "Interactor", "Item"
        };

        if (collider.gameObject.tag == "Enemy") {

            GameObject player = GameObject.Find("Player");
            GameObject enemy  = collider.gameObject;
            
            base.PlayerAttackEnemy(player, enemy);
            
        }

        if (!exceptedCollisions.Contains(collider.gameObject.tag)) {
            Destroy(gameObject);
        }
        
    }

	public void OnBecomeInvisible() {
		Destroy(gameObject);
	}

    public void Awake() {

        MovementSpecs movement = gameObject.GetComponent<MovementSpecs>();
        Animator animator = gameObject.GetComponent<Animator>();
        
        GameObject player = GameObject.Find("Player");
        Animator playerAnimator = player.GetComponent<Animator>();
        
        void SetArrowState(string state, float offsetX, float offsetY) {
            
            animator.SetTrigger(state);
                
            float posX = player.transform.position.x + offsetX;
            float posY = player.transform.position.y + offsetY;

            gameObject.transform.position = new Vector3(posX, posY, 0);
            
        }
        
        void SetArrowCollider(float sizeX, float sizeY) {

            var collider = gameObject.GetComponent<BoxCollider2D>();
            collider.size = new Vector2(sizeX, sizeY);

        }

        void SetMovementDirection(float x, float y, float z) {
            movement.movementDirection = new Vector3(x, y, z);
        }
        
        if (playerAnimator.GetBool("isUp")) {
            
            SetArrowState("toUp", 0, 2.15f);
            SetArrowCollider(3.0f, 9.6f);
            SetMovementDirection(0.0f, 1.0f, 0);

            return;
        }
        
        if (playerAnimator.GetBool("isLeft")) {
            
            SetArrowState("toLeft", -1.55f, 0);
            SetArrowCollider(9.6f, 2.0f);
            SetMovementDirection(-1.0f, 0.0f, 0);

            return;
        }
        
        if (playerAnimator.GetBool("isRight")) {
            
            SetArrowState("toRight", 1.55f, 0);
            SetArrowCollider(9.6f, 2.0f);
            SetMovementDirection(1.0f, 0.0f, 0);
            
            return;
        }
        
        if (playerAnimator.GetBool("isDown")) {

            SetArrowState("toDown", 0, -1.35f);
            SetArrowCollider(3.0f, 9.6f);
            SetMovementDirection(0.0f, -1.0f, 0);

            return;
        }

    }
    
    public void FixedUpdate() {

        MovementSpecs specs = gameObject.GetComponent<MovementSpecs>();
        Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        
        Vector2 deltaPosition = specs.movementDirection;
        deltaPosition = deltaPosition * specs.movementSpeed;
        deltaPosition = deltaPosition * Time.fixedDeltaTime;

        body.MovePosition(body.position + deltaPosition);

    }
    
}
