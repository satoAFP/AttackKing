using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class base_weapon : MonoBehaviour
{
    // 元ステータス設定用 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// 武器ステータス
    /// </summary>
    public struct WeaponData
    {
        public string name;
        public Sprite image;
        public GameObject skill;
        public int strength;
        public int magic;
        public float weight;
        public int mp_cost;
    }

    /// <summary>
    /// 追加ステータス
    /// </summary>
    public struct AddStatus
    {
        public string[] addname;        //追加ステータスの名前
        public float[] addvalue;        //追加ステータスの数値
    }



    // 追加ステータス登録用 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// 追加ステータス一覧
    /// </summary>
    public enum ADD_STATUS_TYPE
    {
        HP,
        MP,
        STRENGTH,
        DEFENSE,
        MAGIC,
        BARRIER,
        SPEED,
        MOVE,
        LUC,
        HP_REGENE,
        MP_REGENE,
    }
    //ステータス名前入力用
    [System.NonSerialized]public string[] add_status_type =
    {
        "HP","MP","STRENGTH","DEFENSE","MAGIC","BARRIER",
        "SPEED","MOVE","LUC","HP_REGENE","MP_REGENE"
    };



    // 武器登録用 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    /// <summary>
    /// 武器種
    /// </summary>
    public enum WEAPON_TYPE
    {
        PROXIMITY,
        DISTANCE,
        MAGIC,
    }

    
}
