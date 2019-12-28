using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class androidScript : MonoBehaviour
{
    karakter kr; //script türünden değişken tanımlandı

    private void Start()
    {
        kr = GetComponent<karakter>(); //script değeri atandı
    }

    public void sol()
    {

        kr.sol = true;
    }
   public void sag()
    {

        kr.sag = true;

    }
    public void solup()
    {

        kr.sol = false;
    }
    public void sagup()
    {

        kr.sag = false;
    }
    public void ziplama()
    {

        if (kr.yerdemi) //yerdemi değişkeni aktif ise
        {
           
            kr.buttonziplama(); //zıplama fonksiyonunu cagır

        }


    }
}
