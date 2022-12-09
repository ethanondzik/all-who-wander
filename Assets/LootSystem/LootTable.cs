using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{

public GameObject Player;
public GameObject HealthPotion;
public GameObject Crystal;

public void DropItem(){

    int lootRoll;
    lootRoll = Random.Range(1, 10);
    if(lootRoll < 6){
    }
}
}
