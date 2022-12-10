using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;





public class LevelSystem : MonoBehaviour
{
    
    public CombatSpecs playerStats;
    public float expCurrent;
    public float expThreshold;
    public float true_multiplier = 1.25f;
    public float AtkPower;
    public void checkForLevel(){
        if(playerStats.experience > playerStats.experienceThershold){
            levelUp(ref true_multiplier);
        }
    }
    public void levelUp(ref float multiplier){
        playerStats.level = playerStats.level+1;
        playerStats.experience = 1;
        playerStats.experienceThershold = (playerStats.experienceThershold*multiplier); 
        playerStats.MaxHP = (playerStats.MaxHP*multiplier-(10*multiplier));
        playerStats.HP = (playerStats.MaxHP);
        playerStats.attackPower = (playerStats.attackPower+multiplier);
        playerStats.defendPower = (playerStats.defendPower+multiplier);
        multiplier = (multiplier*1.055f);

    }

    public void testLevelUp(){
        levelUp(ref true_multiplier);
    }

    void Awake(){
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatSpecs>();
  
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        expCurrent = playerStats.experience;
        expThreshold = playerStats.experienceThershold;


    }

    // Update is called once per frame
    void Update()
    {
        checkForLevel();
    }
}
