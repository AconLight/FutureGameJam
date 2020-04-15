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
        UnityEngine.Debug.Log("elo");
        this.unit = Instantiate (unitPrefab, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
