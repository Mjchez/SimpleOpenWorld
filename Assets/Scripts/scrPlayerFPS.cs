﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerFPS : MonoBehaviour
{
    public CharacterController chtr;
    Vector3 move, rot;

    void Start()
    {
    	if(!chtr)
    	chtr = GetComponent<CharacterController>();
    	Cursor.lockState = CursorLockMode.Locked;    
    }

    
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        rot.y = Input.GetAxis("Mouse X");

        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * 5);
        transform.Rotate(rot);
    }
}
