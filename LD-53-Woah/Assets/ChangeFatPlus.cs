using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFatPlus : MonoBehaviour
{
    public Sprite spriteFatPlus;
    public string fatPlusTag;

    public void ChangeFatType()
    {
        GetComponent<SpriteRenderer>().sprite = spriteFatPlus;
        gameObject.tag = fatPlusTag;
    }

}
