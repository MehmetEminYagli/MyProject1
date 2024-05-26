using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;


    private void LateUpdate()
    {
        if (targetPlayer != null)
        {
            //kamera ile oyuncu arasında olan uzaklık ayarı
            Vector3 desiredPosition = targetPlayer.position + offset;
            //a pozisyonu ile b pozisyonu arası lerp ile geçiş yapıyoruz geçiş yaparken smoothspeed hızı ile daha smooth yapıyoruz
            Vector3 smoothedPosisiton = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosisiton; //kameranın yeni pozisyonunu güncelliyoruz.

            transform.LookAt(targetPlayer); // ile de kamera oyuncuya bakar pozisyonda duruyor;
        }
    }
}
