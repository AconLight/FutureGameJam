using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{

    public GameObject bgMusicPrefab;
    private GameObject bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic = Instantiate(bgMusicPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        bgMusic.GetComponent<AudioSource>().Play((ulong)0.2);

        //bgMusic.Play(0.5);
       // audio.clip = otherClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
