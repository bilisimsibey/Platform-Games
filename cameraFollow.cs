using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform karakter;//transform türünden karakter değişkeni tanımlandı
    public float x, y; //float türünden x ve y tanımlandı
    private void Start()
    {
        karakter = GameObject.FindGameObjectWithTag("Player").transform; //karakter değişkeninin transform değeri atandı
    }
    private void Update()
    {
        transform.position = new Vector3(karakter.position.x+x,karakter.position.y+y,-10); //kameranın pozisyon değerleri atandı
    }
}
