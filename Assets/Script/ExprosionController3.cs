using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprosionController3 : MonoBehaviour
{
    public float exprosionDelay;
    public GameObject ExprosionPrefab;
    public bool unblockHit = false;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "UnbreakBlock" || hit.gameObject.tag == "breakBlock" || hit.gameObject.tag == "Wall" || hit.gameObject.tag == "Bom")
        {
            unblockHit = true;
        }

        /*if (hit.gameObject.tag == "breakBlock")
        {
            unblockHit = true;
        }

        if (hit.gameObject.tag == "Wall")
        {
            unblockHit = true;
        }*/
    }

        void FixedUpdate()
    {
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
                    pos.x -= 0.2f;

                    transform.localScale = scale;
                    transform.position = pos;
                }
                //fireScale();
            }
        }


        exprosionDelay -= Time.deltaTime;
        if (exprosionDelay < 0)
        {
            Destroy(ExprosionPrefab.gameObject);
        }

    }
}
