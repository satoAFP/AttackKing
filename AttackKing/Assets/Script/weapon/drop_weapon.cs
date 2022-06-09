using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop_weapon : base_weapon
{
    //共有変数
    public WeaponData Wd = new WeaponData()               //ドロップ時のステータス格納用
    {
        name = "", image = null, skill = null,
        strength = 0, magic = 0, weight = 0, mp_cost = 0
    };

    public AddStatus As = new AddStatus()                 //ドロップ時の追加ステータス格納用
    {
        addname = new string[5],
        addvalue = new float[5]
    };
 


    // Start is called before the first frame update
    void Start()
    {
        //ドロップする武器決定
        WeaponDecision();

        //追加ステータス決定
        AddStatusDecision();

        //Debug.Log(Wd.name);
        //Debug.Log(Wd.image);
        //Debug.Log(Wd.skill);
        //Debug.Log(Wd.strength);
        //Debug.Log(Wd.magic);
        //Debug.Log(Wd.weight);
    }



    /// <summary>
    /// ドロップする武器決定
    /// </summary>
    private void WeaponDecision()
    {
        //now_drop_weaponsを参照し、そこからドロップする武器をランダムで取得
        now_drop_weapons drop_manager = GameObject.Find("NowDropWeapons").GetComponent<now_drop_weapons>();
        int weapon_num = Random.Range(0, drop_manager.NowDropWeapon.Length);
        format_weapon drop_weapon = drop_manager.NowDropWeapon[weapon_num].GetComponent<format_weapon>();

        //取得した武器のステータス格納
        Wd.name = drop_weapon.Name;
        Wd.image = drop_weapon.Image;
        Wd.skill = drop_weapon.Skill;
        Wd.strength = drop_weapon.Strength;
        Wd.magic = drop_weapon.Magic;
        Wd.weight = drop_weapon.Weight;
        Wd.mp_cost = drop_weapon.mp_cost;
    }


    /// <summary>
    /// 追加ステータス決定関数
    /// </summary>
    private void AddStatusDecision()
    {
        //追加ステータスの数決定
        int status_num = Random.Range(0, 5);

        //追加ステータスの内容決定
        for (int i = 0; i < 5; i++)
        {
            //追加ステータスの数だけランダムで数値作成
            if (i < status_num)
            {
                int ast_num = Random.Range(0, add_status_type.Length);

                As.addname[i] = add_status_type[ast_num];
                As.addvalue[i] = Mathf.Floor(CheckStatus(ast_num));
            }
            else
            {
                As.addname[i] = "---";
                As.addvalue[i] = 0;
            }
            //Debug.Log(As.addname[i] + " : " + As.addvalue[i]);
        }
    }


    /// <summary>
    /// 追加ステータスの数値設定
    /// </summary>
    /// <param name="ast_num">ステータス名の番号</param>
    /// <returns></returns>
    private float CheckStatus(int ast_num)
    {
        switch(ast_num)
        {
            case (int)ADD_STATUS_TYPE.HP:
                return Random.Range(10, 20);
            case (int)ADD_STATUS_TYPE.MP:
                return Random.Range(1, 10);
            case (int)ADD_STATUS_TYPE.STRENGTH:
                return Random.Range(1, 10);
            case (int)ADD_STATUS_TYPE.DEFENSE:
                return Random.Range(1, 10);
            case (int)ADD_STATUS_TYPE.MAGIC:
                return Random.Range(1, 10);
            case (int)ADD_STATUS_TYPE.BARRIER:
                return Random.Range(1, 10);
            case (int)ADD_STATUS_TYPE.SPEED:
                return Random.Range(1, 5);
            case (int)ADD_STATUS_TYPE.MOVE:
                return Random.Range(0.5f, 1.0f);
            case (int)ADD_STATUS_TYPE.LUC:
                return Random.Range(5, 10);
            case (int)ADD_STATUS_TYPE.HP_REGENE:
                return Random.Range(1, 3);
            case (int)ADD_STATUS_TYPE.MP_REGENE:
                return Random.Range(1, 3);
        };
        return 0;  
    }


}
