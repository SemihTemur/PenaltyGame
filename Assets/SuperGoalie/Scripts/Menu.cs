using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public AudioSource audioSource;

    public Sprite soundOn, soundOff;



    public bool isPlay;
  

    // S�nglenton
    public static Menu Instance;



    private void Awake()
    {
        // E�er bir �nceki �rnek varsa, bu �rne�i yok etme
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            isPlay = true;
            // Bu nesneyi di�er sahnelerde yok etme
            DontDestroyOnLoad(gameObject);
        }
    }


 

}
