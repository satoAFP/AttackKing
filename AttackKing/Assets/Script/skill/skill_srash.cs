using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_srash : MonoBehaviour
{
    [Header("消えるまでの時間")]
    public int delete_time;
    [Header("移動速度")]
    public float skill_speed;
    [Header("減速力")]
    public float slow_power;

    Vector3 shotForward;

    // Start is called before the first frame update
    void Start()
    {

        // クリックした座標の取得（スクリーン座標からワールド座標に変換）
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 向きの生成（Z成分の除去と正規化）
        shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

        // 弾に速度を与える
        this.gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * skill_speed;

        // transformを取得
        Transform cloneTransform = this.gameObject.transform;

        // ワールド座標を基準に、回転を取得
        Vector3 worldAngle = cloneTransform.eulerAngles;
        worldAngle.z = GetAim(transform.position, mouseWorldPos) - 45; // ワールド座標を基準に、z軸を軸にした回転を10度に変更
        cloneTransform.eulerAngles = worldAngle; // 回転角度を設定
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * skill_speed;

        if (skill_speed >= slow_power)
        {
            skill_speed -= slow_power;
        }

        delete_time--;

        if (delete_time == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //二点間の角度を求める関数
    //引数1　原点となるオブジェクト座標
    //引数2　角度を求めたいオブジェクト座標
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
