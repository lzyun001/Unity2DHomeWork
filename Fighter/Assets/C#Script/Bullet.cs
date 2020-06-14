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
        if (collision.gameObject.tag == "Enemy" && gameObject.tag =="PlayerMissle")
        {
            Instantiate(Effect, collision.transform.position, collision.transform.rotation);
            GameObject.Find("Player").GetComponent<Player>().Score();
            EffectAudio.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "EnemyMissle" && gameObject.tag == "PlayerMissle")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && gameObject.tag == "EnemyMissle")
        {
            GameObject.Find("Player").GetComponent<Player>().HurtPlayer(10f);
        }
    }
    
}
