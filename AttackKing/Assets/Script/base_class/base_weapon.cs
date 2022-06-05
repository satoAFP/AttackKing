using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class base_weapon : MonoBehaviour
{
    public struct WeaponData
    {
        public string name;
        public Sprite image;
        public GameObject skill;
        public int strength;
        public int magic;
        public float weight;
        public float cool_time;
    }
}
