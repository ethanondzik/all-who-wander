using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlSystem : MovementSystem {

    private SpriteRenderer sprite;
    private Animator animator;
    
    private MovementSpecs movement;
    private CombatSpecs specs;
    private AIBrain brain;
    public Crystal crystalPreFab;
    public HealthPotion hpPot;

    public override void Start() {

        GameObject avatar = gameObject.transform.Find("Avatar").gameObject;
        sprite = avatar.GetComponent<SpriteRenderer>();
        animator = avatar.GetComponent<Animator>();

        movement = gameObject.GetComponent<MovementSpecs>();
        specs = gameObject.GetComponent<CombatSpecs>();
        brain = gameObject.GetComponent<AIBrain>();

		brain.hurtCounter 	= 0;
        brain.attackCounter = 0;
        brain.moveCounter   = 0;
        brain.idleCounter   = 50;
        
        brain.state = AIState.Idle;
        brain.substate = AIState.Idle;

        base.Start();

    }

    public bool GetPlayerInChaseRange() {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 selfPosition   = gameObject.transform.position;
        Vector3 playerPosition = player.transform.position;

        float  distance =  Vector3.Distance(playerPosition, selfPosition);
        return distance <= brain.chaseRadius;

    }
    
    public bool GetPlayerInMeleeRange() {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        Vector3 selfPosition   = gameObject.transform.position;
        Vector3 playerPosition = player.transform.position;

        float xDistance = Mathf.Abs(playerPosition.x - selfPosition.x);
        float yDistance = Mathf.Abs(playerPosition.y - selfPosition.y);

        bool xRange = xDistance < 2.15f;
        bool yRange = yDistance < 0.55f && yDistance > 0.45f;

        return xRange && yRange;

    }
    
    public void SelectPatrolDirection() {

        int axis = Random.Range(0, 2);
        int sign = Random.Range(0, 2);

        Vector3 direction;
        direction = (axis == 0) ? Vector3.left : Vector3.up;
        direction = (sign == 0) ? direction : direction * -1.0f;

        movement.movementDirection = direction;

    }

    public void Idle() {

        bool playerInChaseRange = GetPlayerInChaseRange();
        bool playerInMeleeRange = GetPlayerInMeleeRange();

        if (playerInMeleeRange) {
            brain.state = AIState.Attack;
            return;
        }
        
        if (playerInChaseRange) {
            brain.state = AIState.Chase;
            return;
        }

        if (brain.idleCounter <= 0) {

            SelectPatrolDirection();
            
            brain.state = AIState.Patrol;
            brain.moveCounter = 25;
            
            return;
            
        }

        brain.idleCounter -= 1;

    }

    public void Patrol() {

        bool playerInChaseRange = GetPlayerInChaseRange();
        bool playerInMeleeRange = GetPlayerInMeleeRange();
        
        if (playerInMeleeRange) {
            brain.state = AIState.Attack;
            return;
        }
        
        if (playerInChaseRange) {
            brain.state = AIState.Chase;
            return;
        }
        
        if (brain.moveCounter <= 0) {

            movement.movementDirection = Vector3.zero;
            
            brain.state = AIState.Idle;
            brain.idleCounter = 50;
            
            return;
            
        }

        brain.moveCounter -= 1;
        
    }
    
    public void Chase() {
        
        bool playerInChaseRange = GetPlayerInChaseRange();
        bool playerInMeleeRange = GetPlayerInMeleeRange();

        if (playerInMeleeRange) {
            brain.state = AIState.Attack;
            return;
        }
        
        if (playerInChaseRange) {

            GameObject anchorL = GameObject.Find("AnchorL");
            GameObject anchorR = GameObject.Find("AnchorR");
            GameObject player  = GameObject.Find("Player");
        
            Vector3 selfPosition = gameObject.transform.position;
            Vector3 playerPosition = player.transform.position;
            Vector3 anchorPosition;
            
            if (selfPosition.x < playerPosition.x) {
                anchorPosition = anchorL.transform.position;
            }
        
            else {
                anchorPosition = anchorR.transform.position;
            }

            Vector3 direction;
            direction = anchorPosition - selfPosition;
            direction = direction.normalized;

            movement.movementDirection = direction;
            
        }

        else {
            brain.state = AIState.Idle;
            brain.idleCounter = 50;    
        }

    }

    public void Attack() {

        bool playerInChaseRange = GetPlayerInChaseRange();
        bool playerInMeleeRange = GetPlayerInMeleeRange();

        movement.movementDirection = Vector3.zero;

        if (!playerInMeleeRange && playerInChaseRange) {
            brain.state = AIState.Chase;
            return;
        }
            
        if (!playerInMeleeRange) {
            brain.state = AIState.Idle;
            return;
        }

        animator.SetBool("isAttackingOne", true);
        specs.invulnerable = true;

    }

    public void Frozen() {

        if (brain.attackCounter <= 0) {
            brain.state = AIState.Idle;
            return;
        }

        brain.attackCounter -= 1;

    }

	public void OnAttackEnd() {

        animator.SetBool("isAttackingOne", false);

		brain.state = AIState.Frozen;
		brain.attackCounter = 25;

		specs.invulnerable = false;

	}

	public void OnHurtEnd() {
		
        animator.SetBool("isHurting", false);

		brain.state = AIState.Idle;
		brain.idleCounter = 0;

		specs.invulnerable = false;

	}

	public void OnDeathEnd() {
        int lootRoll;
        lootRoll = Random.Range(1, 101);
        if(lootRoll > 25){
            Crystal crystal = Instantiate(crystalPreFab, transform.position, transform.rotation, null);
        } else{
            HealthPotion HP_Pot = Instantiate(hpPot, transform.position, transform.rotation, null);
        }
     
		Destroy(gameObject);
	}
    
    public override void SetDirection(Vector3 direction) {

        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3 selfPosition = gameObject.transform.position;

        animator.SetBool("isMoving", (bool) (direction != Vector3.zero));

        if (brain.state == AIState.Patrol) {

            if (direction.x > 0) {
                Vector3 scale = new Vector3(-brain.scale, brain.scale, 0);
                gameObject.transform.localScale = scale;
            }

            if (direction.x < 0) {
                Vector3 scale = new Vector3(+brain.scale, brain.scale, 0);
                gameObject.transform.localScale = scale;
            }
            
        }
        
        if (brain.state == AIState.Chase)  {

            if (selfPosition.x < playerPosition.x) {
                Vector3 scale = new Vector3(-brain.scale, brain.scale, 0);
                gameObject.transform.localScale = scale;
            }
            
            if (selfPosition.x > playerPosition.x) {
                Vector3 scale = new Vector3(+brain.scale, brain.scale, 0);
                gameObject.transform.localScale = scale;
            }

        }

    }

    public override void FixedUpdate() {

        switch (brain.state) {
            
            case AIState.Idle:
                Idle();
                break;
            
            case AIState.Patrol:
                Patrol();
                break;
            
            case AIState.Chase:
                Chase();
                break;
            
            case AIState.Attack:
                Attack();
                break;
            
            case AIState.Frozen:
                Frozen();
                break;
            
        }
        
        base.FixedUpdate();
        
    }

}
