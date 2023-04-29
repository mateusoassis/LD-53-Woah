using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public PlayerStatus playerStatusScript;
    public Transform destinationPoint;
    public float enemySpeed;


    void Start()
    {
        destinationPoint = GameObject.Find("DestinationPoint").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 a = transform.position;
        Vector2 b = destinationPoint.position;
        transform.position = Vector2.MoveTowards(a, b, enemySpeed * Time.fixedDeltaTime);
    }
}
