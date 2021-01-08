using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OnCursor { Nothing,Choc,Peanut,Iceberry,Marshmallow,WhippedCream,Dustbin}
public class GameManager : MonoBehaviour
{
    public OnCursor onCursor = OnCursor.Nothing;
    private IDraggable dragNDrop;
    public void Throw()
    {
        if(dragNDrop != null)
        {
            Debug.Log("Throw : "+ dragNDrop.ToString());
            dragNDrop.Throw();
            dragNDrop = null;
        }
    }
    public void SetDraggable(IDraggable draggable)
    {
        dragNDrop = draggable;
    }
    public void ChangeCursor(OnCursor newCursor)
    {
        onCursor = newCursor;
        Debug.Log("New Cursor "+newCursor.ToString());
        switch (newCursor)
        {
            case OnCursor.Nothing:
                break;
            case OnCursor.Choc:
                break;
            case OnCursor.Peanut:
                break;
            case OnCursor.Iceberry:
                break;
            case OnCursor.Marshmallow:
                break;
            case OnCursor.WhippedCream:
                break;
            case OnCursor.Dustbin:
                break;
            default:
                break;
        }
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
