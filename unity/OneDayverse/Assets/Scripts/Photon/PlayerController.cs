using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.IO;
// using static GameController;//게임 컨트롤러 사용
public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{     

    [SerializeField] GameObject cameraHolder;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    
    // [SerializeField] Item[] items;
    // int itemIndex;
    // int previousItemIndex = -1;

    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;
    Rigidbody rb;
    PhotonView PV;
    PlayerManager playerManager;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
    }
    void Start()
    {
        if(PV.IsMine)
        {   
            // EquipItem(0);
        }
        else{
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);       
        }
    }
    void Update()
    {
        if(!PV.IsMine)
            return;

        Look();
        Move();
        Jump();

        if(transform.position.y < -10f)
        {
            Die();
        }

        if(3.5< transform.position.z && transform.position.z < 5.5)
        {
            if(-3.7 < transform.position.x  && transform.position.x < -1.8)
            {
                transform.position = SpawnManager.Instance.GetSpawnpoint(2).position;
                // transform.position = location.position;
            }
        }
        if(37.3< transform.position.z && transform.position.z < 40.3)
        {
            if(-3.7 < transform.position.x  && transform.position.x < -1.8)
            {
                transform.position = SpawnManager.Instance.GetSpawnpoint(1).position;
            }
        }

        if(42.2< transform.position.z && transform.position.z < 44.2)
        {   
            if(7.3 < transform.position.x  && transform.position.x < 9.3)
            {
                transform.position = SpawnManager.Instance.GetSpawnpoint(0).position;
                // transform.position = location.position;
            }
        }
        if(16.7< transform.position.z && transform.position.z < 18.7)
        {
            if(7.3 < transform.position.x  && transform.position.x < 9.3)
            {
                transform.position = SpawnManager.Instance.GetSpawnpoint(3).position;
            }
        }
    }


    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }


    void FixedUpdate()
    {
        if(!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }


    public void TakeDamage(float damage){
        PV.RPC("RPC_Takedamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {   
        if(!PV.IsMine)
            return;

        Debug.Log("피해를 입다." + damage);
    }  

    void Die()
    {
        playerManager.Die();
    } 
    public void moveToLargeClass()
    {   
        Debug.Log("111");
        // Transform spawnpoint =SpawnManager.Instance.GetSpawnpoint(2);
        // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position,  spawnpoint.rotation, 0, new object[] {PV.ViewID});
    }
}
