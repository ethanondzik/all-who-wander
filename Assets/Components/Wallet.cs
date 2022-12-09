using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int quantity;

    public int Crystals {get => quantity; set => quantity = value;}

    public void lootCrystal(int val){
        quantity += val; 
    }
}