using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStripe : MonoBehaviour
{
    private float _speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() //Up to down and reallocate up
    {

        //Move down
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        //If down border, reallocate to up border
        if (transform.position.y < -7) //down
            transform.position = new Vector3(transform.position.x, 7, 0);

    }

}
