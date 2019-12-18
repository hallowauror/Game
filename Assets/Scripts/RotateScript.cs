﻿using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public float rotateSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
