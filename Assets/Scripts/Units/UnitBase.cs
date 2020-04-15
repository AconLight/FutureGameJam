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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int x, int z) {
        GameObject gridElement = this.transform.parent.GetComponent<GridElement>().getByXZ(x, z);
        if (gridElement != null && gridElement.GetComponent<GridElement>().unit == null) {
            this.transform.SetParent(gridElement.transform);
            gridElement.GetComponent<GridElement>().unit = this.gameObject;
            // TODO animation goes brrrrrr
        }
    }
}
