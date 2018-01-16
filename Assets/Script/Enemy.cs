using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp;
    public float speed;
    public bool axisswitch;

    //Enemyの自動移動処理
    void Update ()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        rigidbody.velocity = Vector3.zero;

        if (axisswitch)
        {
            rigidbody.AddForce(pos.x + speed, 0, 0);
        }
        else
        {
            rigidbody.AddForce(0, 0, pos.z + speed);
        }

        //HPが０になったら消滅
        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }

    //トリガーヒット処理
    void OnTriggerEnter(Collider hit)
    {
        //FireにヒットしたらＨＰが１減る処理
        if(hit.gameObject.tag == "Fire")
        {
            hp = hp - 1;

            if(hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    //壁やボムに当たったら逆方向に移動する処理
    void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.tag == "UnbreakBlock" || hit.gameObject.tag == "breakBlock" || hit.gameObject.tag == "Wall" || hit.gameObject.tag == "Bom")
        {
            speed *= -1;
        }
    }
}
