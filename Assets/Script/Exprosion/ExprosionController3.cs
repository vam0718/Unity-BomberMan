using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprosionController3 : MonoBehaviour
{
    public float exprosionDelay;
    public GameObject ExprosionPrefab;
    public bool unblockHit = false;

    //条件タグにヒットしたら、スケール調整できるように※１
    void OnTriggerEnter(Collider hit)
    {
        switch (hit.gameObject.tag)
        {
            case "UnbreakBlock":
            case "breakBlock":
            case "Wall":
            case "Bom":
            case "Enemy":
                unblockHit = true;
                break;
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
                    pos.x -= 0.05f;

                    transform.localScale = scale;
                    transform.position = pos;
                }
            }
        }
    }

    //火力調整処理
    void FixedUpdate()
    {
        Fire();

        //一定秒後消滅
        exprosionDelay -= Time.deltaTime;
        if (exprosionDelay < 0)
        {
            Destroy(ExprosionPrefab.gameObject);
        }

    }
}
