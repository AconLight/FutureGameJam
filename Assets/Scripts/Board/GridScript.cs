using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject gridElementPrefab;
    public static int size = 10;

    public int spawnSpotX = 0, spawnSpotZ = 0;
    public int mainSpotX = 0, mainSpotZ = size-1;
    public List<List<GameObject>> GridElements;
    public GameObject unitPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GridElements = new List<List<GameObject>>();
        for (int z = -size/2; z < size/2; z++) {
            List<GameObject> temp = new List<GameObject>();
            for (int x = -size/2; x < size/2; x++) {
                GameObject go = Instantiate (gridElementPrefab, new Vector3(transform.position.x + x,transform.position.y, transform.position.z + z) , Quaternion.identity, this.transform);
                go.GetComponent<GridElement>().x = x+size/2;
                go.GetComponent<GridElement>().z = z+size/2;
                temp.Add(go);
            }
            GridElements.Add(temp);
        }
    }

    public Boolean spawnEnemy(GameObject enemy) {
        if (GridElements[spawnSpotZ][spawnSpotX].GetComponent<GridElement>().unit == null) {
            GridElements[spawnSpotZ][spawnSpotX].GetComponent<GridElement>().spawnUnit(enemy);
            enemy.GetComponent<UnitBase>().audioMenager.GetComponent<AudioMenager>().playSpawn();
            return true;
        }
        return false;
    }

    public Boolean spawnMain(GameObject main) {
        //Debug.Log("grid script size: " + main.GetComponent<UnitBase>().afterEffects.Count);
        if (GridElements[mainSpotZ][mainSpotX].GetComponent<GridElement>().unit == null) {
            GridElements[mainSpotZ][mainSpotX].GetComponent<GridElement>().spawnUnit(main);
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
