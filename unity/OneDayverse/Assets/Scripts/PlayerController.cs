using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 7f;
    //캐릭터 콘트롤러 변수 추가
    CharacterController cc;

    // 중력 변수
    float gravity = -5f;
    //수직 속력 변수
    float yVelocity = 0;
    // 점프력 변수
    public float jumpPower = 10f;
    // 점프 상태 변수 : bool ->> true / false
    public bool isJumping = false;

    private Vector3 moveVec;

    private Vector3 v_movement;


    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // x축
        float v = Input.GetAxis("Vertical");    // z축

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        moveVec = new Vector3(h, 0, v).normalized;


        // 만일 점프 중이었고, 다시 바닥에 착지했다면
        if (isJumping && cc.collisionFlags == CollisionFlags.Below)
        {
            isJumping = false;
            yVelocity = 0;
        }

        // 만일 키보드 스페이스 바를 입력했고, 점프를 하지 않은 상태라면
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // 캐릭터 수직 속도에 점프력을 적용하고 점프 상태로 변경
            yVelocity = jumpPower;
            isJumping = true;
        }

        // 캐릭터 수직 속도에 중력 값 적용
        yVelocity += gravity * Time.deltaTime;

        // yVelocity = yVelocity + gravity * Time.deltaTime;

        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        // when moving forward
        if (h == 0 && v == 0)
        {
            anim.SetBool("isMove", false);
        }
        else 
        {
            anim.SetBool("isMove", true);
        }

        transform.LookAt(transform.position + moveVec);
    }

}