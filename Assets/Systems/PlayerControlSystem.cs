using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlSystem : MovementSystem {
    
    public GameObject[] SpellPrefabs;
    public GameObject ArrowPrefab;
    
    public GameObject sword;
    public GameObject spear;
    public GameObject staff;
    public GameObject actor;

    private MovementSpecs movement;
    private Animator animator;

    public override void Start() {
        
        actor = gameObject.transform.Find("Interactor").gameObject;
        sword = gameObject.transform.Find("Sword").gameObject;
        spear = gameObject.transform.Find("Spear").gameObject;

        movement = gameObject.GetComponent<MovementSpecs>();
        animator = gameObject.GetComponent<Animator>();

        base.Start();

    }
    
    public void SetAnimationState(string name, bool boolean) {
        animator.SetBool(name, boolean);
    }
    
    public void ResetAnimationState() {
        animator.SetBool("isSword", false);
        animator.SetBool("isSpell", false);
        animator.SetBool("isArrow", false);
        animator.SetBool("isSpear", false);
    }

    public void OnSword() {

        var meleeSystem = sword.GetComponent<MeleeSystem>();
        meleeSystem.Attack();
        
        SetAnimationState("isSword", true);
        
    }
    
    public void OnSpear() {
        
        var meleeSystem = spear.GetComponent<MeleeSystem>();
        meleeSystem.Attack();
        
        SetAnimationState("isSpear", true);
        
    }

    public void OnSpell() {

        int prefabIndex = Random.Range(0, SpellPrefabs.Length - 1);
        var spellPrefab = SpellPrefabs[prefabIndex];

        var position = gameObject.transform.position;
        var rotation = Quaternion.identity;
        
        GameObject.Instantiate(spellPrefab, position, rotation);

        SetAnimationState("isSpell", true);
        
    }

    public void OnArrow() {
        
        var position = gameObject.transform.position;
        var rotation = Quaternion.identity;

        GameObject.Instantiate(ArrowPrefab, position, rotation);
        
        SetAnimationState("isArrow", true);
        
    }
    
    public void OnSwordEnd() {
        ResetAnimationState();
    }
    
    public void OnSpellEnd() {
        ResetAnimationState();
    }
    
    public void OnSpearEnd() {
        ResetAnimationState();
    }
    
    public void OnArrowEnd() {

        // Instantiate(ArrowPrefab, Vector3.zero, Quaternion.identity);
        
        SetAnimationState("isArrow", false);

    }
    
    public void OnInteract() { }
    
    public void OnMove(InputValue context) {

        movement.movementDirection = context.Get<Vector2>();
    }
    
    public void OnLook(InputValue context) {
        // not implemented
    }

    public void OnPause(InputAction.CallbackContext context) { }

    public override void SetDirection(Vector3 direction) {

        animator.SetBool("isMoving", false);

        if (direction != Vector3.zero) {
            
            animator.SetBool("isMoving", true);
            
            if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y)) {

                animator.SetBool("isUp", false);
                animator.SetBool("isDown", false);
                
                if (direction.x > 0) {
                    
                    animator.SetBool("isRight", true);
                    animator.SetBool("isLeft", false);

                    sword.GetComponent<MeleeSystem>().SetRight();
                    spear.GetComponent<MeleeSystem>().SetRight();
                    actor.GetComponent<MeleeSystem>().SetRight();

                }

                else {
                    
                    animator.SetBool("isLeft", true);
                    animator.SetBool("isRight", false);
                    
                    sword.GetComponent<MeleeSystem>().SetLeft();
                    spear.GetComponent<MeleeSystem>().SetLeft();
                    actor.GetComponent<MeleeSystem>().SetLeft();
                    
                }

            }

            if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {

                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", false);
                
                if (direction.y > 0) {
                    
                    animator.SetBool("isUp", true);
                    animator.SetBool("isDown", false);
                    
                    sword.GetComponent<MeleeSystem>().SetUp();
                    spear.GetComponent<MeleeSystem>().SetUp();
                    actor.GetComponent<MeleeSystem>().SetUp();
                    
                }

                else {
                    
                    animator.SetBool("isDown", true);
                    animator.SetBool("isUp", false);
                    
                    sword.GetComponent<MeleeSystem>().SetDown();
                    spear.GetComponent<MeleeSystem>().SetDown();
                    actor.GetComponent<MeleeSystem>().SetDown();
                    
                }

            }
               
        }

    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }
    
}
