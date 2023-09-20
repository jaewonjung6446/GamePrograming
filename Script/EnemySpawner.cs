using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int x, y, dis;
    int genNum;
    [SerializeField]
    private GameObject slime;
    [SerializeField]
    private GameObject turtle;
    private void Start()
    {
        StartCoroutine("Spawner");
    }
    private void GenPos()
    {
        x = Random.Range(0, 360);
        y = Random.Range(0, 360);
        dis = Random.Range(3, 8);
        genNum = Random.Range(1, 3);
    }
    private IEnumerator Spawner()
    {
        for (; ; )
        {
            GameObject enemy;
            GenPos();
            switch (genNum)
            {
                case 1:
                    enemy = GameObject.Instantiate(slime);
                    enemy.transform.position = new Vector3(Mathf.Sin(x), 0, Mathf.Cos(y)) * dis;
                    break;
                case 2:
                    enemy = GameObject.Instantiate(turtle);
                    enemy.transform.position = new Vector3(Mathf.Sin(x), 0,Mathf.Cos(y)) * dis;
                    break;
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
