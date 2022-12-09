using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public GameObject Player;
    public double playerHealthMax;
    public double playerHealthCurrent;
    private CombatSpecs playerCombatSpecs;
    public double healing;

    // Start is called before the first frame update
    void Start()
    {
        playerCombatSpecs = Player.GetComponent<CombatSpecs>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            objectsAction(other);
        }    
    }

    protected void objectsAction(Collider2D other)
    {
        playerHealthMax = playerCombatSpecs.MaxHP;
        playerHealthCurrent =  playerCombatSpecs.HP;
        healing = playerHealthMax * 0.25;
        playerCombatSpecs.HP = (int) (healing + playerHealthCurrent);
        Destroy(this.gameObject);
        Debug.Log("Healed Player");
    } 
}
