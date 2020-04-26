using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject gridElementPrefab;
    public static int size = 6;

    public int[] spawnSpotX = new int[3] {0, size-1, size-1}, spawnSpotZ = new int[3] {0, 0, size-1};
    public int mainSpotX = 0, mainSpotZ = size-1;
    public List<List<GameObject>> GridElements;
    public GameObject unitPrefab;

    float scale = 0.45f;
    // Start is called before the first frame update
    void Start()
    {
        GridElements = new List<List<GameObject>>();
        for (int z = -size/2; z < size/2; z++) {
            List<GameObject> temp = new List<GameObject>();
            for (int x = -size/2; x < size/2; x++) {
                GameObject go = Instantiate (gridElementPrefab, new Vector3(transform.position.x + x*scale + 2,transform.position.y, transform.position.z + z*scale -1) , Quaternion.identity, this.transform);
                go.GetComponent<GridElement>().x = x+size/2;
                go.GetComponent<GridElement>().z = z+size/2;
                temp.Add(go);
            }
            GridElements.Add(temp);
        }
    }

    public Boolean spawnEnemy(GameObject enemy, int spawnId) {
        if (GridElements[spawnSpotZ[spawnId]][spawnSpotX[spawnId]].GetComponent<GridElement>().unit == null) {
            GridElements[spawnSpotZ[spawnId]][spawnSpotX[spawnId]].GetComponent<GridElement>().spawnUnit(enemy);
            enemy.GetComponent<UnitBase>().audioMenager.GetComponent<AudioMenager>().playSpawn();
            return true;
        }
        return false;
    }

    public Boolean spawnMain(GameObject main) {
        Debug.Log("mainSpotX: " + mainSpotX + ", " + mainSpotZ);
        if (GridElements[mainSpotZ][mainSpotX].GetComponent<GridElement>().unit == null) {
            GridElements[mainSpotZ][mainSpotX].GetComponent<GridElement>().spawnUnit(main);
            return true;
        }
        return false;
    }

    public void clear() {
        for (int z = -size/2; z < size/2; z++) {
            List<GameObject> temp = new List<GameObject>();
            for (int x = -size/2; x < size/2; x++) {
                if (GridElements[z+size/2][x+size/2].GetComponent<GridElement>().unit) {
                    GridElements[z+size/2][x+size/2].GetComponent<GridElement>().unit.GetComponent<UnitBase>().destroyMe();
                    GridElements[z+size/2][x+size/2].GetComponent<GridElement>().unit = null;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
