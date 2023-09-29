using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    //speed variable of 8

    private float _speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // if the laser on y position > 7.5 then destroy the laser

        if(transform.position.y > 7.5f)
        {
            if(this.transform.parent == null)
            {
                Destroy(this.gameObject);
            }
            else 
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
