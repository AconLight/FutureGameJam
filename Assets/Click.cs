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

    void OnMouseDown()
    {
        CardPlaceContent rc = canvas.GetComponentInChildren<CardPlaceContent>();
        if (rc.unit != null && rc.gridElement.GetComponent<GridElement>().isPlaceholder) {
            rc.unit.transform.SetParent(rc.cardContent.transform);
            rc.unit.transform.position = new Vector3(-999999, 0, 0);
            rc.unit = null;
            rc.gridElement.GetComponent<GridElement>().unit = null;
            rc.gridElement.GetComponent<GridElement>().isPlaceholder = false;
        }
        if (rc.gridElement == transform.parent.gameObject) {
            rc.gridElement = null;
            rc.transform.position = new Vector3(-9999, rc.transform.position.y, rc.transform.position.z);
        }
        else {
            Debug.Log("chose grid elem");
            rc.gridElement = transform.parent.gameObject;
            rc.SetByGridElement(transform.parent.gameObject);
            rc.transform.position = new Vector3(200, rc.transform.position.y, rc.transform.position.z);
        }
    }
}
