using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLoader : MonoBehaviour
{
    

    public List<GameObject> alliesPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> getWave(int level) {
        return enemiesPrefabs;
    }

        public GameObject getMain() {
        return alliesPrefabs[0];
    }
}
