using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprosionController1 : MonoBehaviour
{

    public float exprosionDelay;
    public GameObject ExprosionPrefab;
    public bool unblockHit = false;

    //条件タグにヒットしたら、スケール調整できるように※１
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "UnbreakBlock" || 
            hit.gameObject.tag == "breakBlock" || 
            hit.gameObject.tag == "Wall" || 
            hit.gameObject.tag == "Bom" || 
            hit.gameObject.tag == "Enemy")
        {
            unblockHit = true;
        }
    }

    void Fire()
    {
        if (!unblockHit)
        {
            if (transform.localScale.y < PlayerStatus.firePower)
            {
                // i が火力値より小さい時はループ
                for (int i = 0; i <= PlayerStatus.firePower; i++)
                {
                    Vector3 scale = transform.localScale;
                    Vector3 pos = transform.position;
                    scale.y += 0.05f;
                    pos.x += 0.05f;

                    transform.localScale = scale;
                    transform.position = pos;

                    //Fire();

                }
            }
        }
    }

    //火力調整処理
    void FixedUpdate()
    {
       //※１
        Fire();        

        //一定秒後消滅
        exprosionDelay -= Time.deltaTime;
        if (exprosionDelay < 0)
        {
            Destroy(ExprosionPrefab.gameObject);
        }

    }
}
