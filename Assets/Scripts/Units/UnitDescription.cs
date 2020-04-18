using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDescription
{
    string cardDescription;
    string cardName;

    public UnitDescription()
    {
        //lul
    }

    public void setCardDescription(string name, string description)
    {
        cardName = name;
        cardDescription = description;
    }

    public void setCardDescription(string description)
    {
        cardDescription = description;
    }

    public void setCardName(string name)
    {
        cardName = name;
    }

}
