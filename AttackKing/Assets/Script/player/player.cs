using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : base_player
{
    private JOB_TYPE JOB;
    private Rigidbody2D rb;
    private GameObject clickedGameObject = null;//クリックされたオブジェクト
    private now_weapon ChildObj = null;

    // Start is called before the first frame update
    void Start()
    {
        job = (int)JOB_TYPE.WARRIOR;
        exe = 0;
        //weapon = null;
        hp = 50;
        mp = 20;
        mp_regene = 1;
        strength = 5;
        defense = 5;
        magic = 5;
        barrier = 5;
        attack_speed = 1.0f;
        move_speed = 3.0f;
        luc = 5;

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ChildObj = transform.GetChild(0).gameObject.GetComponent<now_weapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        Attack();

        

        GetWeapon();
    }



    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, move_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-move_speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, -move_speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(move_speed, rb.velocity.y);
        }
    }

    /// <summary>
    /// 攻撃処理
    /// </summary>
    private void Attack()
    {
        //攻撃処理
        if (Input.GetMouseButton(0))
        {
            weapon.gameObject.SetActive(true);

            //攻撃するとクールタイム初期化
            //sord_time = sord_cool;
        }
    }


    /// <summary>
    /// 武器取得処理
    /// </summary>
    private void GetWeapon()
    {
        if (Input.GetMouseButton(1))
        {
            //カーソルの位置にレイを飛ばす
            clickedGameObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            
            if (hit2d)
            {
                //そのオブジェクトを格納
                clickedGameObject = hit2d.transform.gameObject;

                if (clickedGameObject.tag == "drop")
                {
                    ChildObj.wd = clickedGameObject.GetComponent<drop_weapon>().Wd;

                    //右クリックしたアイテムを削除
                    Destroy(clickedGameObject);
                }
            }
        }
    }

    

    public int AllStrength()
    {
        int a = 0;
        return a;
    }
}
