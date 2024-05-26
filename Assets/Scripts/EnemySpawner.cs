using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Oluşturulacak düşmanın prefabı
    public float spawnInterval = 2f; // Düşmanların spawn aralığı
    public float spawnRadius = 10f; // Düşmanların spawn edileceği alanın yarıçapı

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir nokta seç
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        randomPoint.y = 0; // Y eksenindeki pozisyonu sıfırla

        // Seçilen noktanın altında 'ground' etiketi olan bir nesne var mı kontrol et
        RaycastHit hit;
        if (Physics.Raycast(new Vector3(randomPoint.x, 100, randomPoint.z), Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("ground"))
            {
                // Yerden yükseklik göz önünde bulundurularak spawn konumu ayarlanır
                Vector3 spawnPosition = hit.point + Vector3.up * enemyPrefab.transform.localScale.y; 
                // Eğer 'ground' etiketi olan bir nesne varsa, düşmanı o noktada spawn et
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
