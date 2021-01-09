using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Cursor_Script cursor;
    
    public void ImpossibleToGrill()
    {
        Debug.LogError("Impossible de grillé un toast");
    }
    public void ImpossibleToFill()
    {
        Debug.LogError("Impossible de remplir la tasse");
    }
    public void ChangeCursor(Cursor_State newCursor)
    {
        cursor.ChangeState(newCursor);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
