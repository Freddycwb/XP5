using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorSprite : MonoBehaviour
{
    [SerializeField] private Vector2 hotSpot;

    [SerializeField] private Vector2 hitPoint;

    public void SetCursor(Texture2D sprite)
    {
        Cursor.SetCursor(sprite, hotSpot, CursorMode.ForceSoftware);
    }
}
