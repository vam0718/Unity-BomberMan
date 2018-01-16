using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void OnTriggerEnter(Collider hit)
    {
        //ヒットしたトリガーのオブジェクトのタグがFireの時に、オブジェクトを削除する
        if (hit.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
        }
    }
}
