using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBerryJam : MonoBehaviour
{
    public GameManager manager;
    private void OnMouseDown()
    {
       manager.ChangeCursor(Cursor_State.Iceberry);
    }
}
