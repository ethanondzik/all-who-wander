using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : Collidable
{
    protected override void detectCollision(Collider2D hit){
    Debug.Log("Hero! There are quests we need to do!");
    }
}
