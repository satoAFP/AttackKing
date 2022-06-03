using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_player : MonoBehaviour
{
    public enum JOB_TYPE
    {
        WARRIOR,    //ím
        ARCHER,     //‹|m
        MAGICIAN,   //–‚–@g‚¢
    }

    public int job;
    public int exe;
    public GameObject weapon;
    public int hp;
    public int mp;
    public int mp_regene;
    public int strength;
    public int defense;
    public int magic;
    public int barrier;
    public float attack_speed;
    public float move_speed;
    public int luc;
}
