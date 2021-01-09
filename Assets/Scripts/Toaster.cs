using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    public GameManager manager;
    public float grillTime = 10f;
    public int maxToasts = 1;
    public Sprite empty, grillingOne, grillBoth;
    private float[] currentGrillRemain ;
    private Toast[] toasts;
    private SpriteRenderer sr;
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponent<ParticleSystem>();
        toasts = new Toast[maxToasts];
        currentGrillRemain = new float[maxToasts];
        for (int i = 0; i < maxToasts; i++)
        {
            currentGrillRemain[i] = 0f;
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        int toastGrilling = 0;
        for (int i = 0; i < maxToasts; i++)
        {
            if (currentGrillRemain[i] > 0f)
            {
                toastGrilling++;
                currentGrillRemain[i] -= Time.deltaTime;
                if (currentGrillRemain[i] <= 0f)
                {
                    EndGrill(toasts[i]);
                    toasts[i] = null;
                }
            }
        }
        if(toastGrilling > 0)
        {
            sr.sprite = (toastGrilling == maxToasts?grillBoth:grillingOne);
            if(!ps.isPlaying)
                ps.Play();
        }
        else
        {
            sr.sprite = empty;
            ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    private void EndGrill(Toast toast)
    {
        toast.ChangeState(Toast_State.Grilled);
    }
    public bool Grilling(Toast toast)
    {
        bool flag = false;
        int i = 0;
        while (!flag && i < maxToasts)
        {
            if(toasts[i] == null)
            {
                toasts[i] = toast;
                currentGrillRemain[i] = grillTime;
                flag = true;
            }
            else
            {
                i++;
            }
        }
        return flag;
    }
}
