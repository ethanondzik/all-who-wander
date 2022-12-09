using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSystem : MonoBehaviour {
    
    private GameObject owner;
    private EnemyControlSystem control;

    public void Start() {
        owner = gameObject.transform.parent.gameObject;
        control = owner.GetComponent<EnemyControlSystem>();
    }
    
    public void OnHurtEnd() {
        control.OnHurtEnd();
    }
    
    public void OnDeathEnd() {
        control.OnDeathEnd();
    }

    public void OnAttackEnd() {
        control.OnAttackEnd();
    }
    
}
