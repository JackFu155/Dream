﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    public GameObject door;
    public List<GameObject> cubes;
    public float raiseSpeed;
    public bool isActivated = false;
    public bool isActivated2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isActivated = button.GetComponent<Button>().activated;
        isActivated2 = button2.GetComponent<Button>().activated;
        if (isActivated == true && isActivated2 == true)
        {
            if (door.transform.position.y < 6.0f)
            {
                door.transform.position += new Vector3(0.0f, raiseSpeed, 0.0f);
            }
        }
        else
        {
            if (door.transform.position.y > 2.0f)
            {
                door.transform.position -= new Vector3(0.0f, raiseSpeed, 0.0f);
            }
        }
    }
}
