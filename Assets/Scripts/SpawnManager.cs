using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;

    [SerializeField]
    private GameObject _speedBosstPrefab;

    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnSpeedBoost());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //spwan gameobjects every 5 seconds
    //create a coroutine of type IEnumerator -- Yeild events
    //while loop

    IEnumerator SpawnEnemyRoutine()
    {
        //while loop
        //Instantite enemy prefab
        //Yeild wait for 5 second
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }
        
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_tripleShotPowerupPrefab, posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }

    }

    IEnumerator SpawnSpeedBoost()
    {
        while(_stopSpawning == false)
        {
            Vector3 posToSpawnSpeedBoost = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_speedBosstPrefab, posToSpawnSpeedBoost, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
