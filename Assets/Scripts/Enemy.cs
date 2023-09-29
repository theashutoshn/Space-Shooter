using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4f;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 7, 0); // by writing Random.Range(-8f, 8f), I want to spawn the enemy at random when the game begins and when the Spawning restarts
    }

    // Update is called once per frame
    void Update()
    {
        // move down enemy 4 meter per second

        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
                
        // if bottom of the screen, respawn at the top with new random X position

        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if other is player , then damage player and then destory us 
        if (other.tag == "Player")
        {
            //other.transform.GetComponent<Player>().Damage(); OR
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }

        // if other is laser then destroy laser then damage us    

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }


    }

}
