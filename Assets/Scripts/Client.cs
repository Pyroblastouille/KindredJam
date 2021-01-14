using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public float maxChangeAngle = 2f;
    public float minChangeAngle = .25f;
    public float minAngleValue = 5;
    public float maxAngleValue = 20;
    public int itemsInCommand = 2;
    public Sprite happy, neutral, angry;
    public float maxHappiness = 100;
    public float happinessDecrementPerSecond = 0.5f;
    public float limitNeutral = 66;
    public float limitAngry = 33;
    public GameManager manager;
    
    private float cdChangeAngle = 0f;
    private float currentHappiness = 100f;
    private float changeAngle;
    private SpriteRenderer spriteRenderer;
    private List<Toast_State> toastsCommand = new List<Toast_State>();
    private List<HotChoc_State> hotChocCommand = new List<HotChoc_State>();
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        changeAngle = UnityEngine.Random.Range(minChangeAngle, maxChangeAngle);
        cdChangeAngle = changeAngle;
        GenerateCommand();
    }
    private void GenerateCommand()
    {
        for (int i = 0; i < itemsInCommand; i++)
        {
            //4 states available in hot choc
            //5 states available in toast
            //9 states possible
            int val = UnityEngine.Random.Range(0, 9);
            if(val < 4)
            {
                hotChocCommand.Add((HotChoc_State)val);
            }
            else
            {
                val -= 4;
                toastsCommand.Add((Toast_State)val);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentHappiness -= happinessDecrementPerSecond * Time.deltaTime;
        if(currentHappiness < limitNeutral)
        {
            if(currentHappiness < limitAngry)
            {
                spriteRenderer.sprite = angry;
            }
            else
            {
                spriteRenderer.sprite = neutral;
            }
        }
        else
        {
            spriteRenderer.sprite = happy;
        }

        cdChangeAngle -= Time.deltaTime;
        if(cdChangeAngle <= 0f)
        {

            if(GetComponent<Rigidbody2D>().rotation < 0)
            {
                GetComponent<Rigidbody2D>().SetRotation(UnityEngine.Random.Range(minAngleValue, maxAngleValue));
            }
            else
            {
                GetComponent<Rigidbody2D>().SetRotation(-UnityEngine.Random.Range(minAngleValue, maxAngleValue));
            }
            cdChangeAngle = changeAngle;
        }
    }

    private bool WantHotChoc(HotChoc_State current)
    {
        return hotChocCommand.Contains(current);
    }

    public bool GiveHotChoc(HotChoc hotChoc)
    {
        if (WantHotChoc(hotChoc.CurrentState))
        {
            return hotChocCommand.Remove(hotChoc.CurrentState);
        }
        return false;
    }

    private bool WantToast(Toast_State current)
    {
        return toastsCommand.Contains(current);
    }

    public bool GiveToast(Toast toast)
    {
        if (WantToast(toast.CurrentState))
        {
            return toastsCommand.Remove(toast.CurrentState);
        }
        return false;
    }
}
