using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
    public int x, z;
    private GridScript grid;
    public GameObject unit;
    // Start is called before the first frame update
    void Start()
    {
        grid = this.transform.parent.GetComponent<GridScript>();
    }

    public void spawnUnit(GameObject unitPrefab) {
        this.unit = Instantiate (unitPrefab, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getLeft() {
        List<List<GameObject>> temp = this.transform.parent.GetComponent<GridScript>().GridElements;
        if (x-1 >= 0) return this.transform.parent.GetComponent<GridScript>().GridElements[z][x-1];
        else return null;
    }

    public GameObject getRight() {
        List<List<GameObject>> temp = this.transform.parent.GetComponent<GridScript>().GridElements;
        if (x+1 < temp[z].Count) return this.transform.parent.GetComponent<GridScript>().GridElements[z][x+1];
        else return null;
    }

    public GameObject getDown() {
        List<List<GameObject>> temp = this.transform.parent.GetComponent<GridScript>().GridElements;
        if (z-1 >= 0) return this.transform.parent.GetComponent<GridScript>().GridElements[z-1][x];
        else return null;
    }

    public GameObject getUp() {
        List<List<GameObject>> temp = this.transform.parent.GetComponent<GridScript>().GridElements;
        if (z+1 < temp.Count) return this.transform.parent.GetComponent<GridScript>().GridElements[z+1][x];
        else return null;
    }
}
