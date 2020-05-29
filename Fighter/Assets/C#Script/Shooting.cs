using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour  
{
    [Header("設定幾秒產生一顆子彈")]
    public float CreateTime;
    [Header("子彈物件")]
    public GameObject Bullet;
    [Header("子彈生成點")]
    public Transform CreateObject;
    private void Start()
    {
        InvokeRepeating("CreateBullet", CreateTime, CreateTime);
    }
    void CreateBullet()
    {
        Instantiate(Bullet, CreateObject.position, CreateObject.rotation);
    }
}
