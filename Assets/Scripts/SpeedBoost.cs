using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float _speedboostspeed = 3f;


    void Start()
    {
        transform.position = new Vector3(Random.Range(-9.3f, 9.3f), 8.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speedboostspeed * Time.deltaTime);

        if (transform.position.y < -6.60)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            other.GetComponent<Player>().SpeedBoosted();
                    
            Destroy(this.gameObject);
        }
    }
}
