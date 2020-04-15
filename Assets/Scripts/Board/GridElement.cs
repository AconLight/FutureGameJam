using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
    public int x, z;
    private Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = this.transform.parent.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
