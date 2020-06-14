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
    [Header("射擊音效")]
    public AudioSource ShootingSound;
    private void Start()
    {
        ShootingSound = GameObject.Find("shoot2").GetComponent<AudioSource>();
        InvokeRepeating("CreateBullet", CreateTime, CreateTime);
    }
    void CreateBullet()
    {
        Instantiate(Bullet, CreateObject.position, CreateObject.rotation);
        ShootingSound.Play();
    }
}
