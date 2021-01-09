using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour
{
    public GameManager manager;
    private IDraggable colliding;
    private void OnMouseDown()
    {
       manager.ChangeCursor(Cursor_State.Dustbin);
    }
}
