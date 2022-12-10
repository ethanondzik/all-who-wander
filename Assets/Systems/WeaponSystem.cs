using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    public void PlayerAttackEnemy(GameObject player, GameObject enemy) {

	    MovementSpecs enemyMovement = enemy.GetComponent<MovementSpecs>();
        CombatSpecs enemySpecs = enemy.GetComponent<CombatSpecs>();
        CombatSpecs playerSpecs = player.GetComponent<CombatSpecs>();
        GameObject enemyAvatar = enemy.transform.Find("Avatar").gameObject;
        Animator enemyAnimator = enemyAvatar.GetComponent<Animator>();
        AIBrain enemyBrain = enemy.GetComponent<AIBrain>();
		
        var stateCheck = new List<AIState>{
	        AIState.Idle, AIState.Patrol, AIState.Chase, AIState.Frozen
        };
        
        if (stateCheck.Contains(enemyBrain.state)) {

	        enemyMovement.movementDirection = Vector3.zero;
            enemySpecs.HP -= 50.0f*(playerSpecs.attackPower);

            if (enemySpecs.HP <= 0) {
	            
	            enemyMovement.movementDirection = Vector3.zero;
                enemyBrain.state = AIState.Death;

                enemyAnimator.SetBool("isDying", true);
                
            }

            else {

	            enemyBrain.state = AIState.Hurt;
                enemyBrain.hurtCounter = 25;
				
                enemyAnimator.SetBool("isHurting", true);
				
            }		
			
        }

    }
    
}
