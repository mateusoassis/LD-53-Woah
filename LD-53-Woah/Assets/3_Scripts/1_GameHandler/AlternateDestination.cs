using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateDestination : MonoBehaviour
{
    public PlayerStatus playerStatus;
    void Start()
    {
        playerStatus = GameObject.Find("DestinationPoint").GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Alternate");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Destroy CD Reset Alternate");
            playerStatus.TakeDamage(other.gameObject.transform.GetComponent<EnemyBehaviour>().damage);
            playerStatus.DestroyResetCooldown();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Vitamin"))
        {
            Debug.Log("Freeze CD Reset Alternate");
            playerStatus.FreezeResetCooldown();
            playerStatus.robotHandler.HappyRobotAnim();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("GorduraPlus"))
        {
            Debug.Log("Haste CD Reset Alternate");
            playerStatus.HasteResetCooldown();
            Destroy(other.gameObject);
        }
    }
}
