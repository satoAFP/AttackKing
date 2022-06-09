using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class now_weapon : base_weapon
{
    public WeaponData wd = new WeaponData()             //武器データ作成
    {
        name = "", image = null, skill = null,
        strength = 0, magic = 0, weight = 0, mp_cost = 0
    };


    private GameObject clone;               //クローンするオブジェクト
    private int time = 0;                   //折り返しまでの時間
    private bool atack_flag = true;         //これが真のとき攻撃できる
    private Vector3 mem_shotForward;        //攻撃する方向ベクトル
    private float sord_speed = 0;           //攻撃速度
    private Rigidbody2D rb;                 //リジットボディ取得用
    private player player;                  //プレイヤー取得用
    private skill_pos sp;                   //スキルポスの取得用

    // Start is called before the first frame update
    void Start()
    {
        wd.weight = 50;
        Debug.Log(System.Enum.GetValues(typeof(ADD_STATUS_TYPE)).Length);

        //初期化
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = transform.parent.gameObject.GetComponent<player>();
        sp = transform.parent.gameObject.GetComponent<skill_pos>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(wd.name);
        Debug.Log(wd.image);
        Debug.Log(wd.skill);
        Debug.Log(wd.strength);
        Debug.Log(wd.magic);
        Debug.Log(wd.weight);
        //攻撃処理
        if (atack_flag == true)
        {
            //武器の速度調整
            sord_speed = 100 / (wd.weight * 2);

            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
            mem_shotForward = shotForward;

            // 弾に速度を与える
            rb.velocity = shotForward * sord_speed;

            // transformを取得
            Transform cloneTransform = this.gameObject.transform;

            // ワールド座標を基準に、回転を取得
            Vector3 worldAngle = cloneTransform.eulerAngles;
            worldAngle.z = GetAim(transform.position, mouseWorldPos) - 45; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
            cloneTransform.eulerAngles = worldAngle; // 回転角度を設定



            //使用するスキル決定
            sp.skill = wd.skill;
            //スキルの攻撃開始許可
            sp.AttackStart = true;
            //攻撃処理終了
            atack_flag = false;
        }

        //出現時間の折り返しまでくると戻ってくる
        if (time == (wd.weight))
        {
            rb.velocity = -mem_shotForward * sord_speed;
        }
        
        //消去
        time++;
        if (time == wd.weight * 2) 
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            atack_flag = true;
            time = 0;
        }

        //主人公とのずれを修正
        MoveCorrection();
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

    /// <summary>
    /// 武器が主人公についてくるように修正用
    /// </summary>
    private void MoveCorrection()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += new Vector3(0, 0.01f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += new Vector3(-0.01f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += new Vector3(0, -0.01f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += new Vector3(0.01f, 0, 0);
        }
    }
}
