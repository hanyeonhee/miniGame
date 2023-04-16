using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ㅋ_ㅋ,, 
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public float interval = 1.5f; // 1.5초 마다
    public float range = 3;
    float term;
    /*float random;
    Vector3 randomposition;
    Vector3 startPos;*/

    // Start is called before the first frame update
    void Start()
    {
        term = interval; // 시작부터 벽이 나오게 하기 위해
    }

    // Update is called once per frame 
    void Update()
    {
        term += Time.deltaTime;
        if (term >= interval)
        {
            /*random = Random.Range(-2, 2);
            randomposition.x += 4;
            randomposition.y += random;*/
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation);
            
            if (Random.Range(0,2) == 0) // 50% 확률로
            {
                Instantiate(dropPrefab); // 떨어지는 장애물 생성
            }
            term -= interval;
        }
        //randomposition = startPos;
    }
}
