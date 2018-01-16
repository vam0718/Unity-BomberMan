using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprosionController : MonoBehaviour {

    public float exprosionDelay;
    public GameObject ExprosionPrefab;
    public bool unblockHit = false;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "UnbreakBlock")
        {
            this.transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
            unblockHit = true;
        }

        if (hit.gameObject.tag == "breakBlock")
        {
            this.transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
            unblockHit = true;
        }
    }

    void FixedUpdate()
    {
        if (!unblockHit)
        {
            //炎のスケール(Y)が火力値より小さい時
            if (transform.localScale.y < PlayerStatus.firePower)
            {
                // i が火力値より小さい時はループ
                for (int i = 1; i <= PlayerStatus.firePower; i++)
                {
                    this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.1f, transform.localScale.z);
                }
            }
        }
        

        exprosionDelay -= Time.deltaTime;
        if (exprosionDelay < 0)
        {
            Destroy(ExprosionPrefab.gameObject);
        }
        
    }
}
