using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{
    public AudioSource _bgMusic;
    private AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic = Instantiate(_bgMusic, new Vector3(0, 0, 0), Quaternion.identity);
        bgMusic.volume = 0F;
        bgMusic.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
