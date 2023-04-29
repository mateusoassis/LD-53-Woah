using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;


    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawn() 
    {   
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine("Spawn");
    }
}
