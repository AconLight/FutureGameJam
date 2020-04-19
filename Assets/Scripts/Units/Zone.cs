using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone
{
    public static int size = 5;
    public int[,] zoneValues = new int[size,size];

    public Zone() {
        for(int x = 0; x < size; x++) {
            for(int z = 0; z < size; z++) {
                zoneValues[z,x] = 0;
            } 
        }
    }

    public static Zone frame(int radius) {
        Zone zone = new Zone();
        for(int x = 0; x < radius*2+1; x++) {
            for(int z = 0; z < radius*2+1; z++) {
                zone.zoneValues[z+(size-1)/2-radius,x+(size-1)/2-radius] = 1;
            } 
        } 
        zone.zoneValues[(size-1)/2, (size-1)/2] = 0;
        return zone;
    }

    public static Zone one() {
        Zone zone = new Zone();
        for(int x = 0; x < size; x++) {
            for(int z = 0; z < size; z++) {
                zone.zoneValues[z,x] = 0;
            } 
        }
        zone.zoneValues[(size-1)/2, (size-1)/2] = 1;
        //Debug.Log((size-1)/2);
        return zone;
    }
}
