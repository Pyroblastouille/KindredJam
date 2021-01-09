using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Toast_State { Empty,Grilled,Grilling,Choc,Peanut,IceBerry}
public class Toast : IDraggable
{
    public GameManager manager;
    public Sprite empty, grilled, choc, peanut, iceBerry;

    private bool isInToaster = false;
    private bool isInDustbin = false;
    private Toast_State current;
    private SpriteRenderer sr;
    private Vector2 defaultPosition;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        sr = GetComponent<SpriteRenderer>();
        ChangeState(Toast_State.Empty);
    }

    public void ChangeState(Toast_State state)
    {
        sr.enabled = true;
        canDrag = true;
        switch (state)
        {
            case Toast_State.Empty:
                current = Toast_State.Empty;
                sr.sprite = empty;
                break;
            case Toast_State.Grilling:
                if(current == Toast_State.Empty)
                {
                    canDrag = false;
                    current = Toast_State.Grilling;
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

    public override void Throw()
    {
        ChangeState(Toast_State.Empty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toaster"))
            isInToaster = true;
        if (collision.CompareTag("Dustbin"))
            isInDustbin = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Toaster"))
            isInToaster = false;
        if (collision.CompareTag("Dustbin"))
            isInDustbin = false;
    }

    public override bool GiveToClient(Client client)
    {

        if (client.WantToast(current))
        {
            client.GiveToast(this);
            ChangeState(Toast_State.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string ToString()
    {
        return "Toast";
    }

    public override void Release()
    {
        transform.position = startPosition;

        if (isInToaster)
        {
            if (!GameObject.FindGameObjectWithTag("Toaster").GetComponent<Toaster>().Grilling(this))
            {
                manager.ImpossibleToGrill();
            }
            else
            {
                ChangeState(Toast_State.Grilling);
            }
        }
        if (isInDustbin)
            ChangeState(Toast_State.Empty);
    }
}
