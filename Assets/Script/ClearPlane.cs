using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPlane : MonoBehaviour
{
    public GameObject EnemyStageWaves;
    private BoxCollider clearPlaneCollider;

    void Start()
    {
        clearPlaneCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        int objcount = EnemyStageWaves.transform.childCount;

        //ステージ内の敵が全滅したらトリガーをＯＮにする
        if(objcount == 0)
        {
            clearPlaneCollider.isTrigger = true;
        }
    }
}
