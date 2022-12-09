using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : WeaponSystem {

	public void Explode(GameObject enemy) {
		
		MovementSpecs movement = gameObject.GetComponent<MovementSpecs>();
		MovementSpecs enemyMovement = enemy.GetComponent<MovementSpecs>();
		AIBrain enemyBrain = enemy.GetComponent<AIBrain>();

		var stateCheck = new List<AIState>{
			AIState.Idle, AIState.Patrol, AIState.Chase
		};

        if (stateCheck.Contains(enemyBrain.state)) {
			
			Animator animator = gameObject.GetComponent<Animator>();
			enemyBrain.state = AIState.Frozen;
	
			Vector3 scale = new Vector3(12, 12, 12);
			Vector3 position = enemy.transform.position;

			gameObject.transform.position = position;
			gameObject.transform.localScale = scale;

			animator.SetTrigger("toMain");

			movement.movementDirection = Vector3.zero;
			enemyMovement.movementDirection = Vector3.zero;

			gameObject.transform.SetParent(enemy.transform);

			return;

		}

		Destroy(gameObject);

	}

	public void OnExplodeEnd() {
		
		GameObject enemy = gameObject.transform.parent.gameObject;
		GameObject player = GameObject.Find("Player");

		base.PlayerAttackEnemy(player, enemy);

		Destroy(gameObject);

	}

    public void OnTriggerEnter2D(Collider2D collider) {

        if (collider.gameObject.tag == "Enemy") {

            GameObject enemy = collider.gameObject;        
            Explode(enemy);

			return;
            
        }

        if (collider.gameObject.tag != "Player") {
            if (collider.gameObject.tag != "Weapon") {
				Destroy(gameObject);
			}
        }
        
    }

    public void OnBecameInvisible() {
        Destroy(gameObject);
    }
    
    void Awake() {

        MovementSpecs movement = gameObject.GetComponent<MovementSpecs>();
        
        GameObject player = GameObject.Find("Player");
        Animator playerAnimator = player.GetComponent<Animator>();

        void SetSpellPosition(float offsetX, float offsetY) {
            
            float posX = player.transform.position.x + offsetX;
            float posY = player.transform.position.y + offsetY;

            gameObject.transform.position = new Vector3(posX, posY, 0);
            
        }
        
        void SetMovementDirection(float x, float y, float z) {
            movement.movementDirection = new Vector3(x, y, z);
        }
        
        if (playerAnimator.GetBool("isUp")) {
            SetSpellPosition(0, 2.15f);
            SetMovementDirection(0, 1.0f, 0);
            return;
        }
        
        if (playerAnimator.GetBool("isLeft")) {
            SetSpellPosition(-1.55f, 0);
            SetMovementDirection(-1.0f, 0, 0);
            return;
        }
        
        if (playerAnimator.GetBool("isRight")) {
            SetSpellPosition(1.55f, 0);
            SetMovementDirection(1.0f, 0, 0);
            return;
        }
        
        if (playerAnimator.GetBool("isDown")) {
            SetSpellPosition(0, -1.35f);
            SetMovementDirection(0, -1.0f, 0);
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
