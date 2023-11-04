using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{   public static AudioManager Instance {  get; private set; }
    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null) { 
        Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Mas hay de un AudioManager en escena");
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReproducirSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
