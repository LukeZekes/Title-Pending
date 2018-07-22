using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToMouse : MonoBehaviour {
    public float speed = 10f;
    public Transform cube;
    public Transform aim;
    ///private Vector3 targetPos;

    void FixedUpdate() { 
    
        cube.localPosition = new Vector3(0, 0, 0);
        var screenHeight = Screen.height;
        var screenWidth = Screen.width;
        Vector3 mousePos = Input.mousePosition;
        ///mousePos -= new Vector3(screenHeight / 2, screenWidth / 2, 0);
        float opp = (mousePos.y - (screenHeight / 2)) - cube.position.y;
        float adj = (mousePos.x - (screenWidth / 2)) - cube.position.x;
        mousePos.z = 0;
        ///aim.position = mousePos;
        ///targetPos = new Vector3(cube.position.x, aim.position.y , aim.position.z);
        ///cube.LookAt(targetPos);

        
        var angle = Mathf.Atan2(opp, adj) * Mathf.Rad2Deg;
        cube.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        


       
    }
}
