using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy1;
    public GameObject enemy2;
    public float spawnTime = 10.0f;
    public Transform[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        // playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        // InvokeRepeating("함수", 딜레이 시간, 반복시간);
        // 해당 함수를 딜레이 시간 이후에 호출하고, 반복 시간을 추가로 해당 함수를 반복적으로 호출함
    }

    void Spawn()
    {
        // 플레이어의 체력이 0이라면
        if (playerHealth.currentHealth <= 0.0f)
            return;

        int spawnPointIndex1 = Random.Range(0, spawnPoints.Length);
        int spawnPointIndex2 = Random.Range(0, spawnPoints.Length);

        // 두 가지 다른 스폰 지점에서 각각 다른 적을 생성합니다.
        Instantiate(enemy1, spawnPoints[spawnPointIndex1].position, spawnPoints[spawnPointIndex1].rotation);
        Instantiate(enemy2, spawnPoints[spawnPointIndex2].position, spawnPoints[spawnPointIndex2].rotation);
    }
}