using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class IDraggable:MonoBehaviour
{
    public abstract void Throw();
    public abstract bool GiveToClient(Client client);
    public abstract void Release();

    protected Vector2 startPosition;
    private RectTransform rect;
    private bool isDragging = false;
    protected bool canDrag = true;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startPosition = transform.position;
    }
    public void OnMouseDown()
    {
        if(canDrag)
            isDragging = true;
    }
    private void Update()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0,0,4);
        }
    }
    public void OnMouseUp()
    {
        isDragging = false;
        Release();
    }
}
