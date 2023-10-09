using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    //speed variable of 8

    private float _speed = 8.0f;

    private bool _isEnemyLaser = false;

    // Update is called once per frame
    void Update()
    {
        if(_isEnemyLaser == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        //translate laser up
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        // if the laser on y position > 7.5 then destroy the laser

        if (transform.position.y > 7.5f)
        {
            if (this.transform.parent == null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    void MoveDown()
    {
        //translate laser up
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // if the laser on y position > 7.5 then destroy the laser

        if (transform.position.y < -7.5f)
        {
            if (this.transform.parent == null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && _isEnemyLaser == true)
        {
            Player player = other.GetComponent<Player>();
            
            if(player != null)
            {
                player.Damage();
            }
        }
    }

}
