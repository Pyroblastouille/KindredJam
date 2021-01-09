using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhippedCream : MonoBehaviour
{
    public GameManager manager;
    private void OnMouseDown()
    {
       manager.ChangeCursor(Cursor_State.WhippedCream);
    }
}
