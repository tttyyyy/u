﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour,Imanipulate
{
    public MateriaStatus initialMateria;
    //
    public MateriaStatus materia;
    
    //デバッグの為
    Collider coll;
    MeshRenderer rend;
    private void Start()
    {
        coll = GetComponent<Collider>();
        rend = GetComponent<MeshRenderer>();
        become(initialMateria);
    }

    //要素を入れて、現在元素によって元素を変える
    public void Change(Element e)
    {
        switch (e)
        {
            case Element.cold:
                if(materia==MateriaStatus.LIQUID)
                {
                    become(MateriaStatus.SOLID);
                }
                if(materia==MateriaStatus.GAS)
                {
                    become(MateriaStatus.LIQUID);
                }
                break;
            case Element.hot:
                if (materia == MateriaStatus.LIQUID)
                {
                   become(MateriaStatus.GAS);
                }
                if (materia == MateriaStatus.SOLID)
                {
                    become(MateriaStatus.LIQUID);
                }
                break;
        }
    }

    //元素を変える関数
    void become(MateriaStatus s)
    {
        materia = s;
        switch (s)
        {
            case MateriaStatus.GAS:
                coll.isTrigger = true;
                rend.enabled = false;
                break;
            case MateriaStatus.LIQUID:
                coll.isTrigger = true;
                rend.enabled = true;
                break;
            case MateriaStatus.SOLID:
                coll.isTrigger = false;
                rend.enabled = true;
                break;
        }
    }
    public void ComeBack()
    {
        
    }
}
