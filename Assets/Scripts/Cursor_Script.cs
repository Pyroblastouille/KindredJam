using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cursor_State { Empty, Choc, Peanut, Iceberry, Marshmallow, WhippedCream, Dustbin }
public class Cursor_Script : MonoBehaviour
{
    public Sprite choc, peanut, iceberry, marshmallow, chantilly, dustbin;
    private Cursor_State current = Cursor_State.Empty;
    private SpriteRenderer cursor;
    private Collider2D collider2d;

    private IDraggable draggable;
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        cursor = GetComponent<SpriteRenderer>();
    }
    public void ChangeState(Cursor_State newCursor)
    {

        current = newCursor;
        collider2d.enabled = true;
        switch (newCursor)
        {
            case Cursor_State.Empty:
                cursor.sprite = null;
                collider2d.enabled = false;
                break;
            case Cursor_State.Choc:
                cursor.sprite = choc;
                break;
            case Cursor_State.Peanut:
                cursor.sprite = peanut;
                break;
            case Cursor_State.Iceberry:
                cursor.sprite = iceberry;
                break;
            case Cursor_State.Marshmallow:
                cursor.sprite = marshmallow;
                break;
            case Cursor_State.WhippedCream:
                cursor.sprite = chantilly;
                break;
            case Cursor_State.Dustbin:
                cursor.sprite = dustbin;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 3);
        if (Input.GetMouseButtonUp(0))
        {
            if (draggable != null)
            {
                if (current == Cursor_State.Dustbin)
                    draggable.Throw();

                if (draggable is Toast)
                {
                    Toast t = (Toast)draggable;
                    switch (current)
                    {
                        case Cursor_State.Choc:
                            t.ChangeState(Toast_State.Choc);
                            break;
                        case Cursor_State.Peanut:
                            t.ChangeState(Toast_State.Peanut);
                            break;
                        case Cursor_State.Iceberry:
                            t.ChangeState(Toast_State.IceBerry);
                            break;
                    }
                }
                else
                {
                    HotChoc h = (HotChoc)draggable;
                    switch (current)
                    {
                        case Cursor_State.Marshmallow:
                            h.ChangeState(HotChoc_State.Marshmallow);
                            break;
                        case Cursor_State.WhippedCream:
                            h.ChangeState(HotChoc_State.WhippedCream);
                            break;
                    }
                }
            }
            ChangeState(Cursor_State.Empty);
            draggable = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toast") || collision.CompareTag("HotChoc"))
        {
            draggable = collision.GetComponent<IDraggable>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Toast") || collision.CompareTag("HotChoc"))
        {
            draggable = null;
        }
    }
}
