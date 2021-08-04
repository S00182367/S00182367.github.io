using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //allows other scrip to access Audio Manager
    public static AudioManager instance;

    public AudioSource[] soundEffects; //Create AudioSource array of sound effects

    public AudioSource bgm;
    public AudioSource levelEndMusic;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int soundToPlay)
    {
        //tell to stop if already playing
        soundEffects[soundToPlay].Stop();

        //change the pitch of the sound effect to reduce repitiveness
        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);

        //Tell the function the number to play from the array
        soundEffects[soundToPlay].Play();
    }
}
