using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ingameSource;
    public AudioClip background;
    public AudioClip ingamebg;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
        musicSource.clip = background;
        ingameSource.clip = ingamebg;
        musicSource.Play();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            musicSource.Stop();
        }
    }
}
