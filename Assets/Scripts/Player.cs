    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    /// To create variable
    //public or private refrence
    //data type
    //every variable has a name
    //optional value assigned
    public float speed = 6f;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;

    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawnmanager;

    // varibale if triple shoot is enable

    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private bool _isTripleShotActive = false;


    void Start()
    {
        // take the current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        _spawnmanager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnmanager == null)
        {
            Debug.LogError("The Spawn Manager is null");
        }



    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();

        }



    }

    void CalculateMovement()
    {
        // PLAYER INPUT || USER INPUT \\
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // [Below I can call transform.Translate function in 3 different type] \\
        // 1 type \\
        //transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);  //transform.Translate(new Vector3(1,0,0)); && //transform.Translate(Vector3.right * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * speed *Time.deltaTime);

        // 2 type \\
        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);

        // 3 type \\
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * speed * Time.deltaTime);



        // PLAYER BOUND || RESTRAINING PLAYER IN CERTAIN DIRECTION \\
        // I want the object to not move in + y direction. so I will create condition that object will not move in +y direction by simply saying,
        // if object position y >=0; object should snap to 0;

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y <= -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }

        //if (transform.position.x >= 9.2f)
        //{
        //    transform.position = new Vector3(9.2f, transform.position.y, 0);
        //}
        //else if (transform.position.x <= -9.2f)
        //{
        //    transform.position = new Vector3(-9.2f, transform.position.y, 0);
        //}

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.2f, 9.2f), transform.position.y, 0);
    }

    void FireLaser()
    {
        // I want to spawn a laser when I hit a space key

        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive == true)
        {
            // Instantiate Triple Shot
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.85f, 0), Quaternion.identity);
        }


        //Vector3 offset = new Vector3(0, 1.08f, 0);
        //Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);

        //OR 


        // if space key is press
        // if tripleshot is active or true
        // fire 3 laser

        // else fire single laser





    }

    public void Damage()
    {
        //_lives = _lives - 1;
        _lives -= 1;
        //_lives--;

        //now check if dead then destroy player

        if (_lives < 1)
        {
            // communicate with spawn manager and let them know to stop spawning when the player dies.

            _spawnmanager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    //IENUmerartor triple shot power down routine
    //wait for 5 sec
    //set triple shot to flase
    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }


    public void SpeedBoosted()
    {
        speed = 10f;

        StartCoroutine(SpeedBoostRoutine());

    }

    IEnumerator SpeedBoostRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speed = 6.0f;
    }

}
