using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public CombatSpecs playerStats;
    //the class is instanizted upon runtime, need to declare a game object
    //public GameObject playerStats;
    

    public void InitHealthBar(float health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void AdjustHealthBar(float health) {
        slider.value = health;
    }

    void Start() {
        //playerStats = gameOBject.GetComponent<CombatSpecs>();
        InitHealthBar(playerStats.MaxHP);
    }

    void Update() {
        //assuming that the .HP field is meant to be the players current health
        slider.value = playerStats.HP;
        slider.maxValue = playerStats.MaxHP;
        AdjustHealthBar(playerStats.HP);
    }
   
}
