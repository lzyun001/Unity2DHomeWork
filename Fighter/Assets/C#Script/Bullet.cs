using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("子彈飛行速度")]
    public float speed;
    [Header("子彈消滅時間")]
    public float time;

    private void Update()
    {
        //Vector3.up(0,1,0) Vector3.down(0,-1,0) Vector3.forward(1,0,0) 
        //transform.Translate(0,speed,0);
        transform.Translate(Vector3.up * speed);
    }
}
