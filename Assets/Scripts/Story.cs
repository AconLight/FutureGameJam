using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{

    public TextAsset part0, part1, part2, part3, part4;
    private TextAsset part;
    private List<TextAsset> parts;

    // Start is called before the first frame update
    void Start()
    {
        parts = new List<TextAsset>();
        parts.Add(part0);
        parts.Add(part1);
        parts.Add(part2);
        parts.Add(part3);
        parts.Add(part4);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dispalyPart(int n)
    {
        part = Instantiate(parts[n]);

        Text title = gameObject.GetComponentsInChildren<Text>()[0];
        title.text = "Episode " + n;

        Text description = gameObject.GetComponentsInChildren<Text>()[1];
        description.text = part.text;
        
    }

}
