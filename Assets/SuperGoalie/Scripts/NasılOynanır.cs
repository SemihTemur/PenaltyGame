using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NasılOynanır : MonoBehaviour
{
    public Text howtoPlaytext;

    void Start()
    {
#if UNITY_STANDALONE

        string text = "Bu Oyun iki kişilik oynanan bir oyundur. Oyuncular gelen 5 penaltı vuruşunu kurtarmaya çalışır. En çok penaltı Kurtaran oyunu kazanır.  Eşit sayıda  kurtariş olursa maç uzar.Sol taraftaki oyuncu zıplamak için w tuşu'nu sola gitmek için a tuşu'nu sağa gitmek için d tuşu'nu kullanır.Sağdaki oyuncu ise sola gitmek için sol ok yön tuşu'nu sağa gitmek için sağ ok yön tuşu'nu zıplamak için yukarı ok tuşu'nu kullanması gerekir.Keyifli Oyunlar :)";
        howtoPlaytext.text = text;
       
       

#elif UNITY_ANDROID || UNITY_IOS

        string text = "Bu Oyun iki kişilik oynanan bir oyundur. Oyuncular gelen 5 penaltı vuruşunu kurtarmaya çalışır. En çok penaltı Kurtaran oyunu kazanır.  Eşit sayıda  kurtariş olursa maç uzar. Oyuncular Kaleciyi hareket ettirmek için Aşağıdaki butonları kullanması gerekir. Keyifli oyunlar :)";
        howtoPlaytext.text = text;



#endif
    }



}
