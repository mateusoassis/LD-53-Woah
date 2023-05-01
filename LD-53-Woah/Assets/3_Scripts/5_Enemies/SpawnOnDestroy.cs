using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject fatPlusPrefab;

    void OnDestroy()
    {
        GameObject fatPlus = Instantiate(fatPlusPrefab, this.transform.position, Quaternion.identity);
        GetComponent<EnemyBehaviour>().playerStatus.enemyCounter++;
    }
}
