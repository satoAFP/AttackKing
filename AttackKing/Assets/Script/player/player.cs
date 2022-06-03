using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : base_player
{
    private JOB_TYPE JOB;

    // Start is called before the first frame update
    void Start()
    {
        job = (int)JOB_TYPE.WARRIOR;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
