﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject gridElementPrefab;
    public int size = 10;
    List<List<GameObject>> GridElements;
    public GameObject unitPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GridElements = new List<List<GameObject>>();
        for (int z = -size/2; z < size/2; z++) {
            List<GameObject> temp = new List<GameObject>();
            for (int x = -size/2; x < size/2; x++) {
                GameObject go = Instantiate (gridElementPrefab, new Vector3(transform.position.x + x,transform.position.y, transform.position.z + z) , Quaternion.identity, this.transform);
                go.GetComponent<GridElement>().x = x;
                go.GetComponent<GridElement>().z = z;
                temp.Add(go);
            }
            GridElements.Add(temp);
        }
        GridElements[size/2][size/2].GetComponent<GridElement>().spawnUnit(unitPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
