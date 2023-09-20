using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovSystem : MonoBehaviour
{
    private float h;
    private float v;
    private bool isJump = false;
    [SerializeField]
    private float jumpPower = 5;
    [SerializeField]
    private float movSpeed = 5;
    [SerializeField]
    private float rotateSpeed = 10.0f;
    [SerializeField]
    private Transform cameraArm;
    Rigidbody rb;
    Vector3 rot;
    Vector3 destPos;
    Vector3 dir;
    Quaternion lookTarget;
    bool move = false;
    public AtkSystem atkSystem;
    public Camera mainCam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 클릭");
            atkSystem.Atk();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);
    }
    private void FixedUpdate()
    {
        Mov();
        LookAround();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void GetInput()
    {
        if (Input.GetAxisRaw("Jump") == 1)
        {
            Debug.Log("jump = " + Input.GetAxisRaw("Jump"));
        }
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }
    private void Mov()
    {
        GetInput();
        Vector3 mov = new Vector3(h, 0, v).normalized;
        Vector3 lookForward = new Vector3(mainCam.transform.forward.x, 0f, mainCam.transform.forward.z).normalized;
        Vector3 lookRight = new Vector3(mainCam.transform.right.x, 0f, mainCam.transform.right.z).normalized;
        Vector3 moveDir = (lookForward * mov.z + lookRight * mov.x).normalized * 1f;

        this.transform.forward = lookForward * 0.3f;
        transform.position += moveDir * Time.deltaTime * 5f;
        if (Input.GetAxisRaw("Jump") == 1 && !isJump)
        {
            rb.AddForce(new Vector3(0, 1f, 0) * jumpPower, ForceMode.Impulse);
            isJump = true;
            Debug.Log("Jump");
        }
    }
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;

        cameraArm.rotation = Quaternion.Euler(camAngle.x - mouseDelta.y, camAngle.y + mouseDelta.x, camAngle.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isJump = false;
            Debug.Log("착지");
        }
    }
}
