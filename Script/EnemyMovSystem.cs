using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovSystem : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    public float bullet1Atk = 10.0f;
    public float bullet2Atk = 30.0f;
    private GameObject player;
    private Queue<GameObject> movQueue = new Queue<GameObject>();
    Vector3 moveDirection;
    public bool isPatrol = false;
    public bool isApproach = false;
    public bool isAttack = false;
    private Rigidbody rb;
    [SerializeField]
    private float slimeHp=100;
    [SerializeField]
    private float turtleHp = 150;

    private void Start()
    {
        player = GameObject.Find("Player");
        movQueue = null;
        rb = GetComponent<Rigidbody>();
        StartCoroutine("PatrolDir");
    }
    private void Update()
    {
        MovSystem();
        if (isPatrol)
        {
            Patrol();
        }else if (isAttack)
        {
            this.transform.LookAt(player.transform);
            isAttack = false;
        }
        if(slimeHp<=0 || turtleHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void MovSystem()
    {
        if ((this.transform.position - player.transform.position).magnitude >= 3)
        {
            isPatrol = true;
            isAttack = false;
        }else if((this.transform.position - player.transform.position).magnitude < 3)
        {
            isPatrol = false;
            isAttack = true;
            StartCoroutine("Atk");
        }
    }
    private void Patrol()
    {
        rb.velocity = moveDirection * speed;
        transform.forward = moveDirection;
    }
    private void Approach()
    {
        if((this.transform.position - player.transform.position).magnitude < 5)
        {
            this.transform.position += (player.transform.position - this.transform.position).normalized *speed * Time.deltaTime;
            this.transform.LookAt(player.transform);
        }
    }
    private IEnumerator PatrolDir()
    {
        for (; ; )
        {
            int x, z;
            x = Random.Range(0, 360);
            z = Random.Range(0, 360);
            moveDirection = new Vector3(Mathf.Sin(x), 0, Mathf.Cos(z)).normalized;
            yield return new WaitForSeconds(1.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.name == "Bullet1(Clone)")
            {
                Debug.Log("Bullet1충돌");
                if (this.gameObject.name == "Slime(Clone)")
                {
                    this.slimeHp -= bullet1Atk;
                }
                if (this.gameObject.name == "Turtle(Clone)")
                {
                    this.slimeHp -= bullet1Atk;
            }
        }
            if (other.gameObject.name == "Bullet2(Clone)")
            {
                Debug.Log("Bullet2충돌");
                if (this.gameObject.name == "Slime(Clone)")
                {
                    this.slimeHp -= bullet2Atk;
            }
            if (this.gameObject.name == "Turtle(Clone)")
            {
                    this.slimeHp -= bullet2Atk;
            }
        }
    }
    private IEnumerator Atk()
    {
        yield return new WaitForSeconds(0.5f);
        isPatrol = true;
        isAttack = false;
    }
}
