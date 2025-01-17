﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private static HealthController instance;

    public static HealthController Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    public MonsterHPBarPool monsterHPBarPool;

    [SerializeField]
    private BossHPBarPool bossHPBarPool;
    [SerializeField]
    public Image PlayerHPBar;

    public List<HPAndSpeedManager> currentHealths;

    public List<Text> HPTexts;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // for enemy
    public void LocateHealthBar(List<Enemy> enemy)
    {
        for(int i = 0; i < enemy.Count; ++i)
        {
            // TODO critical image need to be used
            HPAndSpeedManager enemHPManager = monsterHPBarPool.GetFromPool();
            enemHPManager.transform.position = enemy[i].transform.position + Vector3.up * 1f;
            enemHPManager.transform.localScale = Vector3.one;

            enemHPManager.Init();

            enemy[i].SetSpeed(enemHPManager.GetSpeed());
            enemy[i].SetActSpeed(Random.Range(.75f, 1.25f));
            //health connect with enemy
            currentHealths.Add(enemHPManager);
            HPTexts.Add(enemHPManager.GetText());

            enemy[i].SetHealth(currentHealths[i]);

            // Reset monster health every spawn
            //enemy[i].ResetMonster();
            enemy[i].healthText = HPTexts[i];

            //enemy[i].healthText.text = enemy[i].getCurrentHP().ToString() + " / " 
            //    + enemy[i].getMaxHP().ToString();
        }
    }

    // for boss
    public void Locatebosshealthbar(List<Enemy> enemy)
    {
        for (int i = 0; i < enemy.Count; ++i)
        {
            // TODO critical image need to be used
            HPAndSpeedManager enemHPManager = bossHPBarPool.GetFromPool();
            enemHPManager.transform.position = enemy[i].transform.position + Vector3.up * 3f;
            //enemHPManager.transform.localScale = Vector3.one;

            enemy[i].SetSpeed(enemHPManager.GetSpeed());

            enemHPManager.Init();

            enemy[i].SetSpeed(enemHPManager.GetSpeed());
            enemy[i].SetActSpeed(Random.Range(.75f, 1.25f));

            //health connect with enemy
            currentHealths.Add(enemHPManager);
            HPTexts.Add(enemHPManager.GetText());

            enemy[i].SetHealth(currentHealths[i]);

            // Reset monster health every spawn
            //enemy[i].ResetMonster();
            Debug.Log(enemy.Count);
            enemy[i].healthText = HPTexts[i];
        }

    }

}
