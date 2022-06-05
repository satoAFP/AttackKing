using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class now_weapon : base_weapon
{
    [Header("消えるまでの時間")] public int delete_time;

    [Header("移動速度")] public int sord_speed;

    [Header("複製するスキル")] public GameObject skill;



    [System.NonSerialized] public WeaponData WeaponData;            //武器データ作成

    //クローンするオブジェクト
    private GameObject clone;

    //折り返しまでの時間
    private int time = 0;

    //これが真のとき攻撃できる
    private bool atack_flag = true;

    //攻撃する方向ベクトル
    private Vector3 mem_shotForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //攻撃処理
        if (atack_flag == true)
        {
            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
            mem_shotForward = shotForward;

            // 弾に速度を与える
            this.gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * sord_speed;

            // transformを取得
            Transform cloneTransform = this.gameObject.transform;

            // ワールド座標を基準に、回転を取得
            Vector3 worldAngle = cloneTransform.eulerAngles;
            worldAngle.z = GetAim(transform.position, mouseWorldPos) + 135; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
            cloneTransform.eulerAngles = worldAngle; // 回転角度を設定

            atack_flag = false;
        }

        //出現時間の折り返しまでくると戻ってくる
        if (time == (delete_time / 2))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = -mem_shotForward * sord_speed;
        }
        
        //消去
        time++;
        if (time == delete_time)
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            atack_flag = true;
            time = 0;
        }

    }

    /// <summary>
    /// 二点間の角度を求める関数
    /// </summary>
    /// <param name="p1">原点となるオブジェクト座標</param>
    /// <param name="p2">角度を求めたいオブジェクト座標</param>
    /// <returns>z二点間の角度</returns>
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
