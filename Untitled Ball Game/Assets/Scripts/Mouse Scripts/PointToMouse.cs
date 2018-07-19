using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour {
    public float speed = 10f;
    public Transform cube;
    void FixedUpdate()
    {
        cube.localPosition = new Vector3(0, 0, 0);
        var screenHeight = Screen.height;
        var screenWidth = Screen.width;
        Vector3 mousePos = Input.mousePosition;
        float opp = (mousePos.y - (screenHeight / 2)) - cube.position.y;
        float adj = (mousePos.x - (screenWidth / 2)) - cube.position.x;
        mousePos.z = 0;
        /*
        Vector3 direction = mousePos - cube.position;
        Quaternion rotation = Quaternion.Euler(0, 0, -direction.x * speed);
        cube.rotation = rotation;
        */
        
        var angle = Mathf.Atan2(opp, adj) * Mathf.Rad2Deg;
        cube.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


       
    }
}
