using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotChocMaker : MonoBehaviour
{
    public GameManager manager;
    public float fillTime = 10f;
    public int maxHotChocs = 1;
    public Sprite filling, empty;
    private HotChoc[] hotChocs;
    private float[] currentFillRemain;
    private ParticleSystem ps;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponent<ParticleSystem>();
        hotChocs = new HotChoc[maxHotChocs];
        currentFillRemain = new float[maxHotChocs];
        for (int i = 0; i < maxHotChocs; i++)
        {
            currentFillRemain[i] = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool fillingACup = false;
        for (int i = 0; i < maxHotChocs; i++)
        {
            if (currentFillRemain[i] > 0f)
            {
                fillingACup = true;
                currentFillRemain[i] -= Time.deltaTime;
                if (currentFillRemain[i] <= 0f)
                {
                    EndFilling(hotChocs[i]);
                    hotChocs[i] = null;
                }
            }
        }
        if (fillingACup)
        {
            sr.sprite = filling;
            if (!ps.isPlaying)
                ps.Play();
        }
        else
        {
            sr.sprite = empty;
            ps.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    public bool Filling(HotChoc hotChoc)
    {
        bool flag = false;
        int i = 0;
        if(hotChoc.CurrentState != HotChoc_State.Empty)
        {
            return flag;
        }
        while (!flag && i < maxHotChocs)
        {
            if (hotChocs[i] == null)
            {
                hotChocs[i] = hotChoc;
                currentFillRemain[i] = fillTime;
                flag = true;
            }
            else
            {
                i++;
            }
        }
        return flag;
    }
    private void EndFilling(HotChoc hotChoc)
    {
        hotChoc.ChangeState(HotChoc_State.Filled);
    }
}
