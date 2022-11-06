using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] touching = new Collider2D[10];

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Collision work//
        //OverlapCollider looks for any overlap between two boxColliders than places those overlaps in the touching[] array//
        boxCollider.OverlapCollider(filter, touching);
        for(int i = 0; i < touching.Length; i++){
            if(touching[i] == null){
                continue;
            }

            detectCollision(touching[i]);
            
            //resets the array values back to NULL for when the objects move away from each other//
            touching[i] = null;
        }

    }
    
    protected virtual void detectCollision(Collider2D touching){
        Debug.Log("Collision Detected!");
        
    }
}
