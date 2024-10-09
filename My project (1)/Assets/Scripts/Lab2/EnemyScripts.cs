using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs; // Các loại enemy
    [SerializeField]
    Vector3 startPosition; // Vị trí xuất hiện của enemy
    [SerializeField]
    int period = 2; // Mỗi 2 giây xuất hiện 1 enemy
    [SerializeField]
    int MaximumCount = 10; // Số lượng tối đa cho mỗi loại enemy
    float time = 0;
    [SerializeField]
    bool EnableExtend;

    List<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new List<GameObject>();

        // Tạo trước MaximumCount cho mỗi loại enemy
        foreach (var prefab in prefabs)
        {
            for (int i = 0; i < MaximumCount; i++)
            {
                GameObject newEnemy = Instantiate(prefab);
                newEnemy.SetActive(false); // Chưa kích hoạt ngay
                enemyPool.Add(newEnemy); // Thêm vào pool
            }
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > period)
        {
            GameObject newEnemy = GetRandomFreeEnemy(); // Random chọn một enemy chưa active
            if (newEnemy != null)
            {
                newEnemy.SetActive(true);
                EnemyHealth enemyHealth = newEnemy.GetComponent<EnemyHealth>();
                enemyHealth.currentHealth = 50;
                enemyHealth.valueText.text = "50 / 50";
                newEnemy.transform.position = startPosition;
                time = 0;
            }
        }
    }

    private GameObject GetRandomFreeEnemy()
    {
        List<GameObject> availableEnemies = new List<GameObject>();

        foreach (var enemy in enemyPool)
        {
            if (!enemy.activeSelf)
            {
                availableEnemies.Add(enemy);
            }
        }

        if (availableEnemies.Count > 0)
        {
            int randomIndex = Random.Range(0, availableEnemies.Count);
            return availableEnemies[randomIndex];
        }

        if (EnableExtend)
        {
            int randomPrefabIndex = Random.Range(0, prefabs.Length);
            GameObject newEnemy = Instantiate(prefabs[randomPrefabIndex]);
            newEnemy.SetActive(false);
            enemyPool.Add(newEnemy);
            return newEnemy;
        }

        return null;
    }
}
