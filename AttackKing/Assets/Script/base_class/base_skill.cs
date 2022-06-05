using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_skill : MonoBehaviour
{
    public enum ATTACK_TYPE
    {
        STRAIGHT,   //真っすぐ飛ぶ攻撃
        TAP_POINT,  //クリックした場所に攻撃
        AROUND,     //自身の周りを攻撃
        BUFF,       //バフ
    }

    public string name;
    public int strength;
    public int magic;
    public float move_speed;
}
