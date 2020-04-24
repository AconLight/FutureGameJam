using System.Collections.Generic;
using UnityEngine;


public class AudioMenager : MonoBehaviour
{
    public AudioSource _bgMusic;

    public AudioSource _enemySpawn;
    public AudioSource _enemyAttack1;
    public AudioSource _enemyAttack2;

    public AudioSource _buildingSpawn;
    public AudioSource _buildingAttack1;
    public AudioSource _buildingAttack2;
    public AudioSource _buildingAttack3;
    

    private AudioSource bgMusic;
    private AudioSource spawn;
    private List<AudioSource> attack; 

    AudioSource dead;


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
        attack = new List<AudioSource>();
        attack.Add(Instantiate(_enemyAttack2));
        attack.Add(Instantiate(_enemyAttack1));
    }

    void building()
    {
        spawn = Instantiate(_buildingSpawn);
        attack = new List<AudioSource>();
        attack.Add(Instantiate(_buildingAttack1));
        attack.Add(Instantiate(_buildingAttack2));
        attack.Add(Instantiate(_buildingAttack3));
    }

    void menu()
    {
        bgMusic = Instantiate(_bgMusic);
        bgMusic.volume = 0.2F;
        bgMusic.Play();
        
    }

    public void playSpawn()
    {
        spawn.Play();
    }

    public void playAttack()
    {
        int jebacTenRandom = Random.Range(0, attack.Count);
        attack[jebacTenRandom].Play();

    }

    public void playDead()
    {
        dead.Play();
    }

}
