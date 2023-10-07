using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _rotationSpeed = 25f;

    //[SerializeField]
    //private float _astroSpeed = 5f;

    [SerializeField]
    private GameObject _explosionPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(0, -_astroSpeed * Time.deltaTime);
        //transform.Translate(movement);

        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        
       
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(other.gameObject);
        }

        if (other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
