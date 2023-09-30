using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _powerUpSpeed = 3f;

    //ID for powerups
    // 0 = triple shot
    // 1 = speed boost
    // 2 = shield

    [SerializeField]
    private int powerupID;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-9.1f, 9.1f), 8.08f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // move down speed 3
        transform.Translate(Vector3.down * _powerUpSpeed * Time.deltaTime);
        // when leave the scren destroy this object
        if (transform.position.y <-6.1f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ontrigger collision
        // only be collected by plyer (use tags)
        if (other.tag == "Player")
        {

            //communicate with player script
            Player player = other.transform.GetComponent<Player>(); //script communicate with player
            //if (player != null)
            //{
            //    if (powerupID == 0)
            //    {
            //        player.TripleShotActive();
            //    }
            //    else if (powerupID == 1)
            //    {
            //        player.SpeedBoosted();
            //    }
            //    //if powerupID is o
                
            //    //else if powerupID is 1 speedboost
            //    //else shield powerup
            //}
           
            // Switch Statment Optimization

            switch (powerupID)
            {
                case 2:
                    Debug.Log("Collected Sheild");
                    break;

                case 1:
                    player.SpeedBoosted();
                    break;

                case 0:
                    player.TripleShotActive();
                    break;

                default:
                    Debug.Log("Default Value");
                    break;
              
            }

            Destroy(this.gameObject);
                
        }
    }  

}
