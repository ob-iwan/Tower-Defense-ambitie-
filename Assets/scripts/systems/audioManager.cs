
using UnityEngine;
using System;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{

    //use: FindObjectOfType<audioManager>().Play("name of sound");
    //to play a sound from any script

    public sound[] sounds;

    public static audioManager instance;

    void Awake()
    {
        //checks and deletes audioManager if it has more than one in the scene
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //keeps the audio manager alive even if switching scene
        DontDestroyOnLoad(gameObject);

        //check for all sounds put in sound[] and put the right values
        foreach (sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
        //looks for the sound asked to play then plays it
        sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
}
