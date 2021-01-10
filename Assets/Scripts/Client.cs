using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private float cdChangeAngle = 0f;
    public float maxChangeAngle = 2f;
    public float minChangeAngle = .25f;
    public float minAngleValue = 5;
    public float maxAngleValue = 20;
    private float changeAngle;
    // Start is called before the first frame update
    void Start()
    {
        changeAngle = UnityEngine.Random.Range(minChangeAngle, maxChangeAngle);
        cdChangeAngle = changeAngle;
        Debug.Log(changeAngle);
    }

    // Update is called once per frame
    void Update()
    {
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

    internal bool WantChoc(HotChoc_State current)
    {
        throw new NotImplementedException();
    }

    internal void GiveChoc(HotChoc hotChoc)
    {
        throw new NotImplementedException();
    }

    internal bool WantToast(Toast_State current)
    {
        throw new NotImplementedException();
    }

    internal void GiveToast(Toast toast)
    {
        throw new NotImplementedException();
    }
}
