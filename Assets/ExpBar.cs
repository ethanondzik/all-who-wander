using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public CombatSpecs playerStats;

    //if we wanted to start the player which xp > 0
    public void InitExpBar(float xp) {
        slider.maxValue = xp;
        slider.value = xp;
    }

    public void AdjustExpBar(float xp) {
        slider.value = xp;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitExpBar(playerStats.experience);
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = playerStats.experienceThershold;
        AdjustExpBar(playerStats.experience);
    }
}
