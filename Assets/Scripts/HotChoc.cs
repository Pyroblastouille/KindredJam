using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HotChoc_State { Empty,Filling,Filled,Marshmallow,WhippedCream}
public class HotChoc : IDraggable
{
    public GameManager manager;
    public Sprite empty, filled, marshmallow, whippedCream;
    private SpriteRenderer sr;
    private HotChoc_State current;
    private bool isInHotChocMaker = false;
    private bool isInDustbin = false;
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        ChangeState(HotChoc_State.Empty);
    }

    public void ChangeState(HotChoc_State state)
    {
        sr.enabled = true;
        canDrag = true;
        switch (state)
        {
            case HotChoc_State.Empty:
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                current = HotChoc_State.Empty;
                sr.sprite = empty;
                break;
            case HotChoc_State.Filling:
                if (current == HotChoc_State.Empty)
                {
                    canDrag = false;
                    current = HotChoc_State.Filling;
                    sr.enabled = false;
                }
                break;
            case HotChoc_State.Filled:
                if (current == HotChoc_State.Filling)
                {
                    ps.Play();
                    current = HotChoc_State.Filled;
                    sr.sprite = filled;
                }
                break;
            case HotChoc_State.Marshmallow:
                if (current == HotChoc_State.Filled)
                {
                    current = HotChoc_State.Marshmallow;
                    sr.sprite = marshmallow;
                }
                break;
            case HotChoc_State.WhippedCream:
                if (current == HotChoc_State.Filled)
                {
                    current = HotChoc_State.WhippedCream;
                    sr.sprite = whippedCream;
                }
                break;
            default:
                break;
        }
    }

    public override void Throw()
    {
        ChangeState(HotChoc_State.Empty);
    }
    public override string ToString()
    {
        return "Hot Chocolate";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HotChocMaker"))
            isInHotChocMaker = true;
        if (collision.CompareTag("Dustbin"))
            isInDustbin = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HotChocMaker"))
            isInHotChocMaker = false;
        if (collision.CompareTag("Dustbin"))
            isInDustbin = false;
    }
    public override bool GiveToClient(Client client)
    {
        
        if (client.WantChoc(current))
        {
            client.GiveChoc(this);
            ChangeState(HotChoc_State.Empty);
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Release()
    {
        transform.position = startPosition;

        if (isInHotChocMaker)
        {
            if (!GameObject.FindGameObjectWithTag("HotChocMaker").GetComponent<HotChocMaker>().Filling(this))
            {
                manager.ImpossibleToFill();
            }
            else
            {
                ChangeState(HotChoc_State.Filling);
            }
        }
        if (isInDustbin)
            ChangeState(HotChoc_State.Empty);
    }
}
