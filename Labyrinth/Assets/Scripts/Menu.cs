using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameObject menuBody;
    public static bool startGame;
    public static AudioSource[] sounds;
    private Slider volumeSlider;
    private Slider soundSlider;
    // Start is called before the first frame update
    private void Start()
    {
        menuBody = GameObject.Find("Body");
        volumeSlider = GameObject.Find("Slider Volume").GetComponent<Slider>();
        soundSlider = GameObject.Find("Slider Sound Effects").GetComponent<Slider>();
        startGame = false;
        sounds = GetComponents<AudioSource>();
        
        
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuBody.activeSelf == false)
            {
                menuBody.SetActive(true);
                startGame = false;
                SetVolume(0f, 0f);

            }
            else
            {
                SetVolume(volumeSlider.value, soundSlider.value);
                menuBody.SetActive(false);
                startGame = true;
            }
            
        }
    }

    public void OnClickButtonStart()
    {
        SetVolume(volumeSlider.value, soundSlider.value);
        menuBody.SetActive(false);
        startGame = true;
        if (!sounds[0].isPlaying)
        {
            sounds[0].Play();
        }
    }

    private void SetVolume(float volume, float soundEff)
    {
        foreach (var sound in sounds)
        {
            sound.volume = soundEff;
        }
        sounds[0].volume = volume;
    }

}
