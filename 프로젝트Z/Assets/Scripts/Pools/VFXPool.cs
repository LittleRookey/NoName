﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    player_atk1,
    player_atk2,
    monster_atk2,
    monster_atk3,
    monster_atk4,
    monster_atk5,
    monster_atk6,
    monster_bloodyatk,
    general_bloodyAtk,
    magicAtk1,
    magicAtk2,
    waterAtk,
    fireBomb,
    fireHit, 
    fireWork,
    b_bloodyDark,
    b_brightFire,
    b_brightLight,
    b_darkIce,
    b_fire,
    b_magicLight,
    b_water
}
public class VFXPool : ObjectPool<Timer>
{

    [SerializeField]
    private GameObject recycleEffectBin;

    protected override Timer AddFunctionality(int id)
    {
        Timer temp = Instantiate(mOrigin[id], recycleEffectBin.transform);
        mPool[id].Add(temp);
        return temp;
    }
}
