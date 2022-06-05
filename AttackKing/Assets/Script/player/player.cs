using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : base_player
{
    private JOB_TYPE JOB;
    private Rigidbody2D rb;

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        Attack();
    }

    /// <summary>
    /// ˆÚ“®ˆ—
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
    /// UŒ‚ˆ—
    /// </summary>
    private void Attack()
    {
        //UŒ‚ˆ—
        if (Input.GetMouseButton(0))
        {
            weapon.gameObject.SetActive(true);

            //UŒ‚‚·‚é‚ÆƒN[ƒ‹ƒ^ƒCƒ€‰Šú‰»
            //sord_time = sord_cool;
        }
    }

    

    public int AllStrength()
    {
        int a = 0;
        return a;
    }
}
