using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ingameSource;
    public AudioClip background;
    public AudioClip ingamebg;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        ingameSource.clip = ingamebg;
        musicSource.Play();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
