using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
    public Dictionary<string, int> earthCounters;
    public int x, z;
    private GridScript grid;
    public GameObject unit;

    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        earthCounters = new Dictionary<string, int>();
        earthCounters.Add("influence", 0);
        grid = this.transform.parent.GetComponent<GridScript>();
        GameObject cb = Instantiate(cube, transform.position, Quaternion.identity, transform) as GameObject;
        cb.GetComponent<Click>().canvas = FindObjectOfType<GameEngine>().GetComponent<GameEngine>().canvas;
    }

    public void spawnUnit(GameObject unitPrefab) {
        //UnityEngine.Debug.Log("grid element size: " + unitPrefab.GetComponent<UnitBase>().afterEffects.Count);
        this.unit = unitPrefab;
        this.unit.transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z);
        this.unit.transform.SetParent(this.transform);
        //UnityEngine.Debug.Log("grid element unit size: " + unit.GetComponent<UnitBase>().afterEffects.Count);
    }


    // Update is called once per frame
    void Update()
    {
        if (unit != null){
            //UnityEngine.Debug.Log("update count: " + unit.GetComponent<UnitBase>().afterEffects.Count);
        }
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

    public GameObject getByXZ(int bx, int bz) {
        //UnityEngine.Debug.Log("Get " + (x+bx) + ", " + (z+bz));
        List<List<GameObject>> temp = this.transform.parent.GetComponent<GridScript>().GridElements;
        if (z+bz < temp.Count && z+bz >= 0) {
            if (x+bx < temp[z+bz].Count && x+bx >= 0) {
                return this.transform.parent.GetComponent<GridScript>().GridElements[z+bz][x+bx];
            }
        } 
        return null;
    }
}
