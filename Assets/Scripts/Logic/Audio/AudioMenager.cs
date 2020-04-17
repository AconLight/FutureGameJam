using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{
    public AudioSource _bgMusic;
    //public GameObject bgMusicPrefab;
    private AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic = Instantiate(_bgMusic, new Vector3(0, 0, 0), Quaternion.identity);
        //bgMusic.GetComponent<AudioSource>().Play();
        bgMusic.volume = 0.5F;
        bgMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
