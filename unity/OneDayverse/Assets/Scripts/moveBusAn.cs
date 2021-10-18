using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBusAn : MonoBehaviour
{
    GameObject bus; // 오브젝트
    Transform target; // 위치 정보

    public float speed = 50;

    public float start_point = 176;
    public float end_point = -164;
    public float stop_point = -16;

    private float timer = 0.0f;
    private float waiting = 3.0f;


    void Start()
    {
        bus = GameObject.Find("SchoolBus"); // 해당 이름의 오브젝트를 찾아 연결
        target = bus.GetComponent<Transform>();

        target.position = new Vector3(176, -83, 135); // bus 오브젝트를 초기 위치
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // 고정 좌표 이동
        InvokeRepeating("Update_Moving", 3f, 8f); // 해당 함수를 1초 뒤 실행 시킨 후 5초 간격으로 반복 실행
        
        
    }

    private void Update_Moving()
    {
        if (target.position.x > -16)
        {
            target.position = Vector3.MoveTowards(target.position, new Vector3(stop_point, -83, 135), Time.deltaTime * speed);
        } else if(target.position.x <= -16)
        {
            timer += Time.deltaTime;
            if (timer > waiting)
                 target.position = Vector3.MoveTowards(target.position, new Vector3(end_point, -83, 135), Time.deltaTime * speed);
        }

        if(target.position.x == end_point)
        {
            Debug.Log("사라져");
            Destroy(this);
            InvokeRepeating("Instan_bus", 2f, 2f);
        }
    }

    private void Instan_bus()
    {
        Debug.Log("나타나라");
        Instantiate(bus);
        // Update_Moving();
    }
}
