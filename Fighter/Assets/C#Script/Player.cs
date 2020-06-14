using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Range(0f, 1f)]
    public float speed;
    [Header("選擇操控玩家的方式")]
    public ControlType control;
    [Header("手機搖桿物件")]
    public GameObject JoystickObject;
    bool UseJoystick;
    bool MouseClick;
    public enum ControlType
    {
        鍵盤 = 0, 手機陀羅儀 = 1, 滑鼠 = 2, 手機搖桿 = 3
    }
    [Header("玩家血量")]
    public float PlayerHP;
    float ScriptHP;
    [Header("玩家血量")]
    public Image HPBar;
    [Header("打死敵機加分")]
    public float AddScore;
    float ScriptScore;
    public Text ScoreText;

    string SaveScore = "SaveScore";
    // Start is called before the first frame update
    void Start()
    {
        ScriptHP = PlayerHP;
    }

    public void HurtPlayer(float hurt)
    {
        ScriptHP -= hurt;
        ScriptHP = Mathf.Clamp(ScriptHP, 0, PlayerHP);
        HPBar.fillAmount = ScriptHP / PlayerHP;
        if (ScriptHP <= 0)
        {
            PlayerPrefs.SetFloat(SaveScore, ScriptScore);
            Application.LoadLevel("GameOver");
        }
    }
    public void Score()
    {
        ScriptScore += AddScore;
        ScoreText.text = "Score:" + ScriptScore;
    }

    // Update is called once per frame
    void Update()
    {
        //#if UNITY_STANDALONE
        if ((int)control == 0)
        {
            transform.Translate(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"), 0f);
        }
        //#endif

        //#if UNITY_ANDROID
        if ((int)control == 1)
        {
            transform.Translate(speed * Input.acceleration.x, speed * Input.acceleration.y, 0f);
        }
        //#endif
        if ((int)control == 2)
        {
            if (Input.GetMouseButton(0))
            {
                if (MouseClick)
                {
                    Vector3 Point;
                    Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    transform.position = new Vector3(Point.x, Point.y, transform.position.z);
                    Cursor.visible = false;
                }
            }
            else 
            {
                Cursor.visible = true;
            }
        }
        if ((int)control == 3)
        {
            JoystickObject.SetActive(true);
        }
        else
        {
            JoystickObject.SetActive(false);
        }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);
    }

    public void UsingJoystick()
    {
        UseJoystick = true;
    }
    public void UnUsingJoystick()
    {
        UseJoystick = false;
    }
    public void IsUsingJoystick(Vector3 pos)
    {
        transform.Translate(speed * pos.x, speed * pos.y, 0f);
    }
    private void OnMouseDown()
    {
        MouseClick = true;
    }
    private void OnMouseUp()
    {
        MouseClick = false;
    }
}
