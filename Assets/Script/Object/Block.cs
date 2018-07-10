using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject ItemDropPrefab;
    private Animator animator;
    private bool FireHit = false;
    private float HitDelay = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(FireHit)
        {
            HitDelay -= Time.deltaTime;
            animator = GetComponent<Animator>();
            GetAnimator().SetTrigger("FireHit");

            if(HitDelay <= 0)
            {
                if (ItemDropPrefab == null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    Instantiate(ItemDropPrefab, 
                                transform.position, 
                                ItemDropPrefab.transform.rotation);
                }
            }
        }
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    void OnTriggerEnter(Collider hit)
    {
        //ヒットしたトリガーのオブジェクトのタグがFireの時に、オブジェクトを削除する
        if (hit.gameObject.tag == "Fire")
        {
            FireHit = true;

        }
    }
}
