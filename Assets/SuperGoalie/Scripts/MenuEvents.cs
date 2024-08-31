using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEvents : MonoBehaviour
{
    public Button aud�oImage;


    private Sprite sprite;
    private void Start()
    {
       
        if (Menu.Instance.isPlay)
        {
            aud�oImage.GetComponent<Button>().GetComponent<Image>().sprite = Menu.Instance.soundOn;
            Menu.Instance.audioSource.mute = false;
        }
        else
        {
            aud�oImage.GetComponent<Button>().GetComponent<Image>().sprite = Menu.Instance.soundOff;
            Menu.Instance.audioSource.mute = true;
        }

    }


    public void OpenGameSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(3);
    }

    public void Aud�oImageSettings()
    {
        sprite = aud�oImage.GetComponent<Button>().GetComponent<Image>().sprite;

        if (sprite == Menu.Instance.soundOn)
        {
            aud�oImage.GetComponent<Button>().GetComponent<Image>().sprite = Menu.Instance.soundOff;
            Menu.Instance.isPlay = false;
            Menu.Instance.audioSource.mute=true;
        }
        else
        {
            aud�oImage.GetComponent<Button>().GetComponent<Image>().sprite = Menu.Instance.soundOn;
            Menu.Instance.isPlay = true;
            Menu.Instance.audioSource.mute = false;
        }



    }

}
