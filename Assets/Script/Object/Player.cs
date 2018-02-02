using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject BomPrefab;
    public GameObject GameController;
    public GameObject MethodOfOperation;

    private AudioSource sourses;

    private CapsuleCollider playerCollider;

    public static bool colliderHit = false;
    public bool clearHit = false;
    public static bool enemyExtinction = false;

    bool forwardmove;
    bool backmove;
    bool rightmove;
    bool leftmove;

    void Start()
    {
        //プレイヤーコライダー取得
        playerCollider = GetComponent<CapsuleCollider>();
        sourses = GetComponent<AudioSource>();

        Debug.Log(PlayerStatus.bomSetCount);
    }


    //操作処理
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float x;
        float z;

        //実機操作切り替え
        if (Application.isEditor)
        {
            MethodOfOperation.SetActive(true);

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            if (colliderHit == false)
            {
                if (Input.GetKeyDown("z")) BomSet();
            }

            if (Input.GetKeyDown("y")) colliderHit = false;

            if (clearHit == false)
            {
                rigidbody.AddForce(x * PlayerStatus.speed, 0, z * PlayerStatus.speed);
                rigidbody.velocity = Vector3.zero;
            }

            //クリアパネル接触時の処理
            else
            {
                rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            }
            
        }
        else
        {
            GameController.SetActive(true);

            if (clearHit == false)
            {
                rigidbody.velocity = Vector3.zero;

                if (forwardmove == true)
                {
                    rigidbody.AddForce(0, pos.y, pos.z + PlayerStatus.speed);
                }
                if (backmove == true)
                {
                    rigidbody.AddForce(0, pos.y, pos.z - PlayerStatus.speed);
                }
                if (rightmove == true)
                {
                    rigidbody.AddForce(pos.x + PlayerStatus.speed, pos.y, 0);
                }
                if (leftmove == true)
                {
                    rigidbody.AddForce(pos.x - PlayerStatus.speed, pos.y, 0);
                }
            }

            //クリアパネル接触時の処理
            else
            {
                rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
                rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            }

            //エディター上実機操作用
            /*rigidbody.velocity = Vector3.zero;

            if (forwardmove == true)
            {
                rigidbody.AddForce(0, pos.y, pos.z + PlayerStatus.speed);
            }
            if (backmove == true)
            {
                rigidbody.AddForce(0, pos.y, pos.z - PlayerStatus.speed);
            }
            if (rightmove == true)
            {
                rigidbody.AddForce(pos.x + PlayerStatus.speed, pos.y, 0);
            }
            if (leftmove == true)
            {
                rigidbody.AddForce(pos.x - PlayerStatus.speed, pos.y, 0);
            }*/
        }
    }

    //ボムセットメソッド
    public void BomSet()
    {
        if (colliderHit == false)
        {
            //最大設置ボム数以上にボムを置けないように処理
            if (PlayerStatus.bomSetCount <= 0) return;

            //ボムプレハブ生成、設置数減少
            Instantiate(BomPrefab, transform.position, transform.rotation);
            PlayerStatus.bomSetCount--;
        }
    }

    //トリガーヒット処理
    void OnTriggerEnter(Collider hit)
    {        
        //ボム
        if (hit.gameObject.tag == "Bom")
        {
            colliderHit = true;
        }

        //ファイヤにヒットしたらオブジェクト削除
        if (hit.gameObject.tag == "Fire")
        {
            Destroy(gameObject);
        }

        //ClearPlaneにヒットしたらすり抜け
        if (hit.gameObject.tag == "ClearPlane")
        {
            playerCollider.isTrigger = true;
            clearHit = true;

            //ＢＧＭ切り替え
            AudioController.sourses[0].Stop();
            AudioController.sourses[1].Play();
        }

        if (hit.gameObject.tag == "Item")
        {
            //ＳＥ再生
            sourses.Play();
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        //敵に接触したら消滅
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    //ボタンが押されているかいないかを検出する
    public void forwardButtonDown()
    {
        forwardmove = true;
    }
    public void forwardButtonUp()
    {
        forwardmove = false;
    }
    public void backButtonDown()
    {
        backmove = true;
    }
    public void backButtonUp()
    {
        backmove = false;
    }
    public void rightButtonDown()
    {
        rightmove = true;
    }
    public void rightButtonUp()
    {
        rightmove = false;
    }
    public void leftButtonDown()
    {
        leftmove = true;
    }
    public void leftButtonUp()
    {
        leftmove = false;
    }
}