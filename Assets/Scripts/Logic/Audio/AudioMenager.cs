using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{
    public AudioSource _bgMusic;
    public AudioSource _enemySpawn;
    public AudioSource _buildingSpawn;

    private AudioSource bgMusic;

    
    AudioSource spawn;
    AudioSource attack;
    AudioSource dead;


    ArrayList basicEnemySounds;

    public AudioMenager()
    {

    }

    public void initAudio(string unitType)
    {
        switch (unitType){
            case "enemy":
                enemy();
                break;
            case "building":
                building();
                break;
            case "menu":
                menu();
                break;
            default:
                //UnityEngine.Debug.LogWarning("INIT AUDIO Z DUPY ARGUMENT: " + unitType);
                break;
        }
    }

    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void enemy()
    {
        spawn = Instantiate(_enemySpawn);
    }

    void building()
    {
        spawn = Instantiate(_buildingSpawn, new Vector3(-9999999, 0, 0), Quaternion.identity);
        spawn.Play();
    }

    void menu()
    {
        bgMusic = Instantiate(_bgMusic);
        bgMusic.volume = 1F;
        bgMusic.Play();
        
    }

    public void playSpawn()
    {
        spawn.Play();
    }

    public void playAttack()
    {
        attack.Play();
    }

    public void playDead()
    {
        dead.Play();
    }

}
