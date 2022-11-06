using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    private Vector3 moveDelta;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //reset move delta for movement loop//
        moveDelta = new Vector3(x, y, 0);

        if(moveDelta.x > 0){
            transform.localScale = Vector3.one;
        } else if (moveDelta.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.Translate(moveDelta * Time.deltaTime);
    }

}
