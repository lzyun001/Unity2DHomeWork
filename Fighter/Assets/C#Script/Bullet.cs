using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("子彈飛行速度")]
    public float speed;
    [Header("子彈消滅時間")]
    public float time;
    [Header("爆炸特效")]
    public GameObject Effect;
    [Header("爆炸音效")]
    public AudioSource EffectAudio;

    private void Start()
    {
        EffectAudio = GameObject.Find("bomb").GetComponent<AudioSource>();
        Destroy(gameObject, time);
    }
    private void Update()
    {
        //Vector3.up(0,1,0) Vector3.down(0,-1,0) Vector3.forward(1,0,0) 
        //transform.Translate(0,speed,0);
        transform.Translate(Vector3.up * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().tag == "Enemy")
        {
            Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            EffectAudio.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
    
}
