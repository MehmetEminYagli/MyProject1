using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player; // Oyuncunun pozisyonu
    public float moveSpeed = 3f; // Düşmanın hareket hızı

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Oyuncunun transform bileşenine erişim sağlanır
    }

    void Update()
    {
        if (player != null)
        {
            // Düşmanın oyuncuya doğru bakması sağlanır
            Vector3 direction = player.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Düşmanın oyuncuya doğru hareket etmesi sağlanır
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
