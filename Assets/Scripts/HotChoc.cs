using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HotChoc_State { Empty,Filling,Filled,Marshmallow,WhippedCream}
public class HotChoc : MonoBehaviour, IDraggable
{
    public GameManager manager;
    public Sprite empty, filled, marshmallow, whippedCream;
    private SpriteRenderer sr;
    private HotChoc_State current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeState(HotChoc_State state)
    {
        sr.enabled = true;
        switch (state)
        {
            case HotChoc_State.Empty:
                current = HotChoc_State.Empty;
                sr.sprite = empty;
                break;
            case HotChoc_State.Filling:
                if (current == HotChoc_State.Empty)
                {
                    sr.enabled = false;
                }
                break;
            case HotChoc_State.Filled:
                if (current == HotChoc_State.Filling)
                {
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

    public void Throw()
    {
        ChangeState(HotChoc_State.Empty);
    }
    private void OnMouseDrag()
    {
        manager.SetDraggable(this);
    }
    public override string ToString()
    {
        return "Hot Chocolate";
    }
}
