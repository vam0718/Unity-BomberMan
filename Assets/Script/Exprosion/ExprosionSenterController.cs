﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Exprosionの中心処理

public class ExprosionSenterController : MonoBehaviour
{
    public float exprosionDelay;
    public GameObject ExprosionPrefab;

	void FixedUpdate ()
    {
        exprosionDelay -= Time.deltaTime;
        if (exprosionDelay < 0)
        {
            Destroy(ExprosionPrefab.gameObject);
        }
    }
}
