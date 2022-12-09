using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSpecs : MonoBehaviour {

    public Element elementalAffinities;
    public Element elementalWeaknesses;

    public int specialAttackPower = 1;
    public int specialDefendPower = 1;
    public int attackPower = 1;
    public int defendPower = 1;

    public int MaxHP = 100;
    public int HP = 25;

    public int level = 1;
    public int experience = 0;
    public int experienceThershold = 100;

    public bool invulnerable = false;

}
