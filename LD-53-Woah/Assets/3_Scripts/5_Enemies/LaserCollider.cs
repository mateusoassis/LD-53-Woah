using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollider : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DisableCol());
    }

    IEnumerator DisableCol()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
