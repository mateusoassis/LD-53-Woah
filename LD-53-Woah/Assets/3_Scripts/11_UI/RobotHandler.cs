using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotHandler : MonoBehaviour
{
    public Animator robotAnim;
    [SerializeField] private Image robotColor;
    [SerializeField] private Image eyesHolder;
    [SerializeField] private float idleAnimDelay;
    [SerializeField] private float idleAnimDelayTimer;

    public bool takenDamage;
    [SerializeField] private float takenDamageDelay;
    [SerializeField] private float takenDamageDelayTimer;

    // 0 = blue
    // 1 = red
    [SerializeField] private Sprite[] redBlueSprites;

    // 0 = happy
    // 1 = taken damage
    [SerializeField] private Sprite[] eyeSprites;

    void Update()
    {
        if(idleAnimDelayTimer <= idleAnimDelay)
        {
            idleAnimDelayTimer += Time.deltaTime;
        }
        else
        {
            TriggerIdleAnim();
            ResetIdleTimer();
        }

        if(takenDamage)
        {
            robotColor.sprite = redBlueSprites[1];
            if(takenDamageDelayTimer <= takenDamageDelay)
            {
                takenDamageDelayTimer += Time.deltaTime;
            }
            else
            {
                ResetColorTimer();
            }
        }
    }
    
    public void ResetColorTimer()
    {
        robotColor.sprite = redBlueSprites[0];
        takenDamage = false;
        takenDamageDelayTimer = 0f;
        TriggerIdleAnim();
    }

    public void ResetIdleTimer()
    {
        idleAnimDelayTimer = 0f;
    }

    public void TriggerIdleAnim()
    {
        robotAnim.SetTrigger("IdleAnim");
    }

    public void TakenDamageSprite()
    {
        robotColor.sprite = redBlueSprites[1];
        eyesHolder.sprite = eyeSprites[1];
        takenDamageDelayTimer = 0f;
        robotAnim.SetTrigger("TakenDamageAnim");
        ResetIdleTimer();
    }
    public void RegularSprite()
    {
        robotColor.sprite = redBlueSprites[0];
    }
}
