using System;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
    public Boolean isPlaceholder = false;
    public Material defaultMaterial;
    public Dictionary<string, int> earthCounters;
    public int x, z;
    [HideInInspector]
    public int gCost, hCost, fCost;
    [HideInInspector]
    public GridElement cameFromNode;
    public GridScript grid {get;private set;}
    public GameObject unit;
    public GameObject cube;
    // Start is called before the first frame update

    // Animation garbage variables
    private static float step = 0.05f;
    private bool isGoingUp;
    private float maxYPosition;
    private float scale = 0;

    public void up(int i) {
        maxYPosition = 0.15f*i;
        isGoingUp = true;
    }

    public void down() {
        isGoingUp = false;
    }

    public GameObject cb;
    private float defY = -0.85f;
    void Start()
    {
        //defY = transform.position.y-0.85f;
        earthCounters = new Dictionary<string, int>();
        earthCounters.Add("influence", 0);
        grid = this.transform.parent.GetComponent<GridScript>();
        cb = Instantiate(cube, new Vector3(transform.position.x, defY, transform.position.z), Quaternion.identity, transform) as GameObject;
        cb.GetComponent<Click>().canvas = FindObjectOfType<GameEngine>().GetComponent<GameEngine>().canvas;
        cb.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
    }

    public void spawnUnit(GameObject unitPrefab) {
        scale = 0;
        //UnityEngine.Debug.Log("grid element size: " + unitPrefab.GetComponent<UnitBase>().afterEffects.Count);
        this.unit = unitPrefab;
        this.unit.transform.localScale = new Vector3(scale,scale,scale);
        this.unit.transform.position = new Vector3(transform.position.x - 0.1f,transform.position.y, transform.position.z + 0.1f);
        this.unit.transform.SetParent(this.transform);
        unitPrefab.GetComponent<UnitBase>().audioMenager.GetComponent<AudioMenager>().playSpawn();
        //UnityEngine.Debug.Log("grid element unit size: " + unit.GetComponent<UnitBase>().afterEffects.Count);
    }


    // Update is called once per frame
    void Update()
    {
        if (unit != null){
            //UnityEngine.Debug.Log("update count: " + unit.GetComponent<UnitBase>().afterEffects.Count);
        }

        if(isGoingUp) {
            if(transform.position.y <= maxYPosition)
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + maxYPosition * step , transform.position.z);
            }
        }
        else
        {
            if(transform.position.y >=0)
            {
                 transform.position = new Vector3(transform.position.x,transform.position.y - maxYPosition * step , transform.position.z);
            }
        }
        if (this.unit != null && scale <= 1) {
            scale += step;
            this.unit.transform.localScale = new Vector3(scale,2*scale,scale);
        }
        if (this.unit && isAttacking) {
            scale += attackAnimV*0.1f;
            attackAnimV -= 0.1f;
            
            if (scale <= 1 && attackAnimV < 0) {
                scale = 1;
                isAttacking = false;
            }

            this.unit.transform.localScale = new Vector3(scale,2*scale,scale);
        }

        if (this.unit && isGettingDamage) {
            gettingDamageAnimP += gettingDamageAnimV*0.1f;
            gettingDamageAnimV -= 0.1f;
            
            if (gettingDamageAnimP <= 0 && gettingDamageAnimV < 0) {
                gettingDamageAnimP = 0;
                isGettingDamage = false;
            }

            transform.position = new Vector3(transform.position.x, gettingDamageAnimP, transform.position.z);

        }


    }

    Boolean isAttacking = false;
    float attackAnimV = 0;
    public void attack() {
        isAttacking = true;
        attackAnimV = 0.5f;
    }

    Boolean isGettingDamage = false;
    float gettingDamageAnimV = 0;
    float gettingDamageAnimP = 0;
    public void getDamage(int value) {
        isGettingDamage = true;
        gettingDamageAnimV = 0.5f*value;
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
    public GameObject getAbsoluteXZ(int x, int z)
    {
        List<List<GameObject>> temp = this.transform.parent.GetComponent<GridScript>().GridElements;
        if (z < temp.Count && z >= 0) {
            if (x < temp[z].Count && x >= 0) {
                return this.transform.parent.GetComponent<GridScript>().GridElements[z][x];
            }
        } 
        return null;
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
    public GridElement isPassable()
    {
        if(unit != null)
        {
            return null;
        }else
        {
            return this;
        }
    }
}
