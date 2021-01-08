using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour
{
    public GameManager manager;
    private void OnMouseDown()
    {
       manager.ChangeCursor(OnCursor.Dustbin);
    }

    private void OnMouseUp()
    {
        manager.Throw();   
    }
}
