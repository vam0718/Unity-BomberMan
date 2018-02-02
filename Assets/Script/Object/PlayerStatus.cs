using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーステータス

public class PlayerStatus : MonoBehaviour
{
    //プレイヤー移動スピード
    public static float speed = 60;

    //最大ボム設置可能数初期値
    private static int maxBomSetCount = 1;

    //エクスプロージョン火力
    public static float firePower = 0.5f;

    //最大ボム設置可能数
    public static int bomSetCount = maxBomSetCount;

}
