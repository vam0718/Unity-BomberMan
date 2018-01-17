using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject ItemDropPrefab;

    void OnTriggerEnter(Collider hit)
    {
        //ヒットしたトリガーのオブジェクトのタグがFireの時に、オブジェクトを削除する
        if (hit.gameObject.tag == "Fire")
        {
            if (ItemDropPrefab == null)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
                Instantiate(ItemDropPrefab, transform.position, ItemDropPrefab.transform.rotation);
            }
        }
    }
}
