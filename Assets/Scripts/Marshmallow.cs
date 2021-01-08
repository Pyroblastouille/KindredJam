using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshmallow : MonoBehaviour
{
    public GameManager manager;
    private void OnMouseDown()
    {
       manager.ChangeCursor(OnCursor.Marshmallow);
    }
}
