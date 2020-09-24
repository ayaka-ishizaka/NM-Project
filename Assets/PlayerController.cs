using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRigidbody;
    //前身のスピード
    private float forwardForce = 500.0f;
    //方向転換のスピード
    float angleSpeed = 150;

    // Start is called before the first frame update
    void Start()
    {
        this.myRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //上矢印キーを押し続けた場合
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Animatorコンポーネントを取得し、"Run"をtrueにする
            GetComponent<Animator>().SetTrigger("Run");
            //前進する
            this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
        }

        //上矢印を離した場合
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //Animatorコンポーネントを取得し、"Idle"をtrueにする
            GetComponent<Animator>().SetTrigger("Idle A");
            //止まる
            this.myRigidbody.velocity = Vector3.zero;
        }

        //左右キーで方向転換
        float Angle = Input.GetAxisRaw("Horizontal") * Time.deltaTime * angleSpeed;
        transform.Rotate(Vector3.up * Angle);
    }
}
