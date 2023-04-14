using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBackGroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudio;
    [SerializeField] private AudioClip[] audio;
    [SerializeField] private levelComplete levelFinish;
    [SerializeField] private GameOverButtonScripts gameOver;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinish.isLevelComplete==true&& gameOver.isGameOver==false)
        {
            switchMusictoGameplayMusic(audio[0]);
        }
        if (levelFinish.isLevelComplete == false && gameOver.isGameOver == true)
        {
            switchMusictoGameplayMusic(audio[1]);
        }
    }
    public void switchMusictoGameplayMusic(AudioClip GPM)
    {
        backgroundAudio.Stop();
        backgroundAudio.clip = GPM;
        backgroundAudio.Play();
    }
}
