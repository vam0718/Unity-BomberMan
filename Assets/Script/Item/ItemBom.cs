using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBom : MonoBehaviour
{
    bool triggerFlag = true;

    void Update()
    {
        float z = 4;
        this.transform.Rotate(0.0f, 0.0f, z);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            if(triggerFlag)
            {
                triggerFlag = false;
                PlayerStatus.bomSetCount++;
                Destroy(gameObject);
            }
        }

        if(hit.gameObject.tag == "Fire" || hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
