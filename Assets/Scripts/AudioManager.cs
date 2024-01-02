using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        DontDestroyOnLoad(transform.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
