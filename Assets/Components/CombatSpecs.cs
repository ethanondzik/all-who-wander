using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSpecs : MonoBehaviour {

    public Element elementalAffinities;
    public Element elementalWeaknesses;

    public int specialAttackPower = 1;
    public int specialDefendPower = 1;
    public float attackPower = 1;
    public double defendPower = 1;

    public float MaxHP = 100;
    public float HP = 25;

    public int level = 1;
    public float experience = 0;
    public float experienceThershold = 100;

    public bool invulnerable = false;

}
