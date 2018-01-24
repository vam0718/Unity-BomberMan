using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject BomPrefab;

    public AudioSource[] sourses;

    private CapsuleCollider playerCollider;

    public static bool colliderHit = false;
    public bool clearHit = false;
    public bool enemyExtinction = false;


    void Start()
    {
        //プレイヤーコライダー取得
        playerCollider = GetComponent<CapsuleCollider>();
        sourses = GetComponents<AudioSource>();
        sourses[0].Play();
    }

    //ボムセット処理
    void Update()
    {
        if (colliderHit == false)
        {
            if (Input.GetKeyDown("z")) BomSet();
        }

        if (Input.GetKeyDown("y"))colliderHit = false;
    }

    //操作処理
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //操作分岐
        if(clearHit == false)
        {
            rigidbody.AddForce(x * PlayerStatus.speed, 0, z * PlayerStatus.speed);
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            pos.y -= 0.5f;
        }
    }

    //ボムセットメソッド
    public void BomSet()
    {
        if (PlayerStatus.bomSetCount <= 0) return;

        Instantiate(BomPrefab, transform.position, transform.rotation);
        PlayerStatus.bomSetCount--;
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

            sourses[0].Stop();
            sourses[1].Play();
        }

        if (hit.gameObject.tag == "Item")
        {
            sourses[2].Play();
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}