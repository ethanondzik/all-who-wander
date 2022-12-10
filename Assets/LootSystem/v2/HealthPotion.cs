using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public GameObject Player;
    public CombatSpecs playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatSpecs>();


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
        playerStats.HP = playerStats.HP+(playerStats.MaxHP*0.25f);
        if(playerStats.HP > playerStats.MaxHP){
            playerStats.HP = playerStats.MaxHP;
        }
        Destroy(this.gameObject);
        Debug.Log("Healed Player");
    } 
}
