using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BGMScript : MonoBehaviour
{
    AudioSource audioSource;
    public Slider gameVolume;
    public GameObject[] GO;

    [Header("Player Prefs")]
    string PREF_BGMVOL = "bgmvol"; 
    string PREF_BGMSTAT = "bgmstat"; 

    private static BGMScript instance = null;
    public static BGMScript Instance
    {
        get {return instance;}
    }
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance !=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
        gameVolume.value = audioSource.volume = PlayerPrefs.GetFloat(PREF_BGMVOL, 0.5f);
        if(PlayerPrefs.GetInt(PREF_BGMSTAT, 1) == 1) {
            PlayBGM();
        } else {
            PauseBGM();
        }
    }

    void Update()
    {
        SetVolume();
    }

    public void SetVolume()
    {
        audioSource.volume = gameVolume.value;
        PlayerPrefs.SetFloat(PREF_BGMVOL, audioSource.volume);
    }

    public void PlayBGM()
    {
        audioSource.Play();
    }

    public void PauseBGM()
    {
        audioSource.Pause();
    }

    public void ToggleBGM()
    {
        if (PlayerPrefs.GetInt(PREF_BGMSTAT, 1) == 1) {
            PauseBGM();
            PlayerPrefs.SetInt(PREF_BGMSTAT, 0);
            Debug.Log("Pause");
        } else if (PlayerPrefs.GetInt(PREF_BGMSTAT, 1) == 0) {
            PlayBGM();
            PlayerPrefs.SetInt(PREF_BGMSTAT, 1);
            Debug.Log("Play");
        }
    }
}
