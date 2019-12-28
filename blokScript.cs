using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blokScript : MonoBehaviour
{
    public Transform[] enemyPositions; //Enemy'nin pozisyonlarını kodlarla kontrol etmek için dizi oluşturuyoruz
    public int sayi; //kontrol edilebilir int türünden sayi tanımlıyoruz
    public float hiz; //kontrol edilebilir float türünden hiz tanımlıyoruz
    private void Start()
    {
        transform.position = enemyPositions[0].position; //Enemy'nin başlangıç pozisyonu, belirlediğimiz gameobjectine eşitleniyor
        sayi = 0; //tanımladığımız sayi değişkenine değer veriyoruz.
    }
    private void Update()
    {

        if (transform.position == enemyPositions[sayi].position) //enemy'nin pozisyonu sayiya(0'a) eşit ise
        {
            sayi++; //sayiyi 1 arttır

        }
        if (sayi >= enemyPositions.Length) //sayinin büyüklüğü enemy'nin gameobjectlerinin uzunlugundan büyük ise
        {
            sayi = 0; //sayiyi sıfırla

        }
        transform.position = Vector3.MoveTowards(transform.position, enemyPositions[sayi].position, hiz * Time.deltaTime); //bunu bende bilmiyorum 
        //transform.LookAt(enemyPositions[sayi]);
    }

}
