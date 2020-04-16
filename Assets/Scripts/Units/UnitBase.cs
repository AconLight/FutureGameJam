using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{   [Range(1,10)]
    public int maxHP;
    private int currentHP;
    [Range(1,10)]
    public int basicIniative;
    private int currentIniative;
    public List<InfluenceZoneBase> influenceZones;

    public GameObject animation;

    // Start is called before the first frame update
    public void Start()
    {
        Instantiate (animation, new Vector3(transform.position.x,transform.position.y, transform.position.z) , Quaternion.identity, this.transform);
    }

    // Update is called once per frame
    int mx = 0;
    int mz = 0;
    float time = 0, time2 = 0;
    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;
        mx = (int)(Math.Sin(time)*1.2);
        mz = (int)(Math.Cos(time)*1.2);
        if (time2 > Math.PI/2) {
            time2 -= (float) Math.PI/2;
            //UnityEngine.Debug.Log(mx + ", " + mz);
            //Move(mx, mz);
        }
    }

    public void Move(int x, int z) {
        //UnityEngine.Debug.Log("Move");
        GameObject gridElement = this.transform.parent.GetComponent<GridElement>().getByXZ(x, z);
        if (gridElement != null && gridElement.GetComponent<GridElement>().unit == null) {
            GridElement oldGridElement = this.transform.parent.gameObject.GetComponent<GridElement>();
            this.transform.SetParent(gridElement.transform);
            gridElement.GetComponent<GridElement>().unit = this.gameObject;
            this.transform.position = gridElement.transform.position;
            oldGridElement.unit = null;
            // TODO animation goes brrrrrr

            //UnityEngine.Debug.Log("Move Done");
        } else {
            UnityEngine.Debug.Log("dupa");
        }

    }
}
