using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Toast_State { Empty,Grilled,Grilling,Choc,Peanut,IceBerry}
public class Toast : MonoBehaviour, IDraggable
{
    public GameManager manager;
    public Sprite empty, grilled, choc, peanut, iceBerry;

    private Toast_State current;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ChangeState(Toast_State.Empty);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeState(Toast_State state)
    {
        sr.enabled = true;
        switch (state)
        {
            case Toast_State.Empty:
                current = Toast_State.Empty;
                sr.sprite = empty;
                break;
            case Toast_State.Grilling:
                if(current == Toast_State.Empty)
                {
                    sr.enabled = false;
                }
                break;
            case Toast_State.Grilled:
                if(current == Toast_State.Grilling)
                {
                    current = Toast_State.Grilled;
                    sr.sprite = grilled;
                }
                break;
            case Toast_State.Choc:
                if(current == Toast_State.Grilled)
                {
                    current = Toast_State.Choc;
                    sr.sprite = choc;
                }
                break;
            case Toast_State.Peanut:
                if (current == Toast_State.Grilled)
                {
                    current = Toast_State.Peanut;
                    sr.sprite = peanut;
                }
                break;
            case Toast_State.IceBerry:
                if (current == Toast_State.Grilled)
                {
                    current = Toast_State.IceBerry;
                    sr.sprite = iceBerry;
                }
                break;
            default:
                break;
        }
    }

    public void Throw()
    {
        ChangeState(Toast_State.Empty);
    }
    private void OnMouseDrag()
    {
        manager.SetDraggable(this);
    }
    public override string ToString()
    {
        return "Toast";
    }

}
