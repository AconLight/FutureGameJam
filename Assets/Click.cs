using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Transform cube;

    void OnMouseDown()
    {
        CardPlaceContent rc = canvas.GetComponentInChildren<CardPlaceContent>();
        if (rc.unit != null && rc.gridElement != null && rc.gridElement.GetComponent<GridElement>().isPlaceholder) {
            rc.unit.transform.SetParent(rc.cardContent.transform);
            rc.unit.transform.position = new Vector3(-999999, 0, 0);
            rc.unit = null;
            rc.gridElement.GetComponent<GridElement>().unit = null;
            rc.gridElement.GetComponent<GridElement>().isPlaceholder = false;
            cube = rc.gridElement.transform.GetChild(0);
            if(cube != null) cube.transform.localPosition = new Vector3(0,-1.7f,0);
            
        }
        if (rc.gridElement == transform.parent.gameObject) {
            if(cube != null) cube.transform.localPosition = new Vector3(0,-1.7f,0);
            rc.gridElement = null;
            rc.transform.position = new Vector3(-9999, rc.transform.position.y, rc.transform.position.z);
        }
        else {
            Debug.Log("chose grid elem");
            

            if(rc.gridElement != null) cube = rc.gridElement.transform.GetChild(0);
            if(cube != null) cube.transform.localPosition = new Vector3(0,-1.7f,0);
            rc.gridElement = transform.parent.gameObject;
            rc.influence.text = "Influence: " + rc.gridElement.GetComponent<GridElement>().earthCounters["influence"];
            cube = rc.gridElement.transform.GetChild(0);
            if(cube != null) cube.transform.localPosition = new Vector3(0,-1.65f,0);
            rc.SetByGridElement(transform.parent.gameObject);
            rc.transform.position = new Vector3(250, rc.transform.position.y, rc.transform.position.z);
            rc.GetComponent<CardPlaceContent>().resetUnitStats();
        }
    }
}
