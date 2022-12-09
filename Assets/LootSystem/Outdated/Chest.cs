using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collidable
{
    protected override void detectCollision(Collider2D touching)
    {
        Debug.Log("Grant Items");
    }
}
