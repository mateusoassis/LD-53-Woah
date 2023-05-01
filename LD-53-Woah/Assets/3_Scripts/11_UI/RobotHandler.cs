using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotHandler : MonoBehaviour
{
    public Animator robotAnim;
    [SerializeField] private Image robotColor;
    [SerializeField] private Image eyesHolder;

    [Header("Idle Anim")]
    [SerializeField] private float idleAnimDelay;
    [SerializeField] private float idleAnimDelayTimer;

    [Header("Taken Damage Anim")]
    public bool takenDamage;
    [SerializeField] private float takenDamageDelay;
    [SerializeField] private float takenDamageDelayTimer;

    [Header("Happy Anim")]
    public bool happy;
    [SerializeField] private float happyDelay;
    [SerializeField] private float happyDelayTimer;

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

        if(happy)
        {
            if(happyDelayTimer <= happyDelay)
            {
                happyDelayTimer += Time.deltaTime;
            }
            else
            {
                ResetHappyTimer();
            }
        }
    }
    
    public void ResetColorTimer()
    {
        robotColor.sprite = redBlueSprites[0];
        takenDamage = false;
        takenDamageDelayTimer = 0f;
        TriggerIdleAnim();
        ResetIdleTimer();
    }

    public void ResetIdleTimer()
    {
        idleAnimDelayTimer = 0f;
    }
    public void ResetHappyTimer()
    {
        happy = false;
        happyDelayTimer = 0f;
        TriggerIdleAnim();
        ResetIdleTimer();
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
        happyDelayTimer = happyDelay;
    }
    public void RegularSprite()
    {
        robotColor.sprite = redBlueSprites[0];
    }

    public void HappyRobotAnim()
    {
        happy = true;
        robotAnim.SetTrigger("HappyAnim");
        //ResetHappyTimer();
        takenDamageDelayTimer = takenDamageDelay;
    }
}
