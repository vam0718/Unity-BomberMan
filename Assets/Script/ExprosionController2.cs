using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprosionController2 : MonoBehaviour
{

    public float exprosionDelay;
    public GameObject ExprosionPrefab;
    public bool unblockHit = false;

    //条件タグにヒットしたら、スケール調整できるように※１
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "UnbreakBlock" || hit.gameObject.tag == "breakBlock" || hit.gameObject.tag == "Wall" || hit.gameObject.tag == "Bom")
        {
            unblockHit = true;
        }
    }

    //火力調整処理
    void FixedUpdate()
    {
        //※１
        if (!unblockHit)
        {
            //炎のスケール(Y)が火力値より小さい時
            if (transform.localScale.y < PlayerStatus.firePower)
            {
                // i が火力値より小さい時はループ
                for (int i = 0; i <= PlayerStatus.firePower; i++)
                {
                    Vector3 scale = transform.localScale;
                    Vector3 pos = transform.position;
                    scale.y += 0.2f;
                    pos.z += 0.2f;

                    transform.localScale = scale;
                    transform.position = pos;
                }
            }
        }

        //一定秒後消滅
        exprosionDelay -= Time.deltaTime;
        if (exprosionDelay < 0)
        {
            Destroy(ExprosionPrefab.gameObject);
        }

    }
}
