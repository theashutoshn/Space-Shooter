using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 4f;

    // global 
    private Player _player;

    private Animator _anim;

    

    [SerializeField]
    private AudioSource _audioScource;

    void Start()
    {
        _player = GameObject.Find ("Player")?.GetComponent<Player>();

        if(_player == null)
        {
            Debug.LogError("Player is NULL");
        }

        _anim = GetComponent<Animator>();

        if(_anim == null)
        {
            Debug.LogError("Anim is NULL");
        }

        _audioScource = GetComponent<AudioSource>();

        if(_audioScource == null)
        {
            Debug.LogError("Audio Source is Null");
        }
       
        

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

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioScource.Play();
            Destroy(this.gameObject, 2.8f);
            
        }

        // if other is laser then destroy laser then damage us    

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            // Add 10 to the score
            if(_player != null)
            {
                _player.AddScore(10);
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioScource.Play();
            Destroy(this.gameObject, 2.8f);
            
        }


    }

}
