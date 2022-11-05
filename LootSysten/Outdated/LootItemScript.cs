using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItemScript : MonoBehaviour
{
    
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        //gives object a box collider at start
        boxCollider = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
