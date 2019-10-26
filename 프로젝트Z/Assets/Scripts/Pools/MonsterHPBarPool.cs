﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHPBarPool : ObjectPool<Health>
{

    [SerializeField]
    private Canvas canvas;

    // Start is called before the first frame update

    public override Health GetFromPool(int id = 0)
    {
        for (int i = 0; i < mPool[id].Count; ++i)
        {
            if (!mPool[id][i].gameObject.activeInHierarchy)
            {
                mPool[id][i].gameObject.SetActive(true);
                return mPool[id][i];
            }
        }

        // if lists are all in use

        return SetTransform(id);
    }

    public Health SetTransform(int id)
    {
        Health temp = Instantiate(mOrigin[id], canvas.transform);
        //temp.transform.position = GameController.Instance.GetFrontEnemy().gameObject.transform.position + Vector3.up * 2;

        //temp.transform.parent = canvas.gameObject.transform;
        //temp.transform.position = GameController.Instance.GetFrontEnemy().gameObject.transform.position;

        //Image enemHealthBar = Instantiate(healthBarEnemy, canvas.transform);
        //enemHealthBar.transform.position = enemy[i].transform.position + Vector3.up * 1f;
        //enemHealthBar.transform.localScale = Vector3.one;

        mPool[id].Add(temp);
        return temp;
    }
}
