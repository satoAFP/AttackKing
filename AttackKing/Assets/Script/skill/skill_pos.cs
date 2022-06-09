using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_pos : MonoBehaviour
{

    //共有変数
    [System.NonSerialized] public GameObject skill;
    [System.NonSerialized] public bool AttackStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackStart)
        {
            //スキルが無いときはクローンしない
            if (skill != null)
            {
                //スキルの生成
                GameObject clone = Instantiate(skill, transform.position, Quaternion.identity);
            }

            AttackStart = false;
        }
    }
}
