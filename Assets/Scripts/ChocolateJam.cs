using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateJam : MonoBehaviour
{
    public GameManager manager;
    private void OnMouseDown()
    {
       manager.ChangeCursor(OnCursor.Choc);
    }
}
