using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanging : MonoBehaviour
{
    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
