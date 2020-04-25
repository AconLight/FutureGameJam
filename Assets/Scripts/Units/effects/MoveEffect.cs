using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : Effect
{
    public MoveEffect(UnitBase unitBase, Zone zone, GameObject materialHolder): base(unitBase, zone, materialHolder) {
        name = "Move";
        description = "Moves a unit toward its enemies";
    }

    protected override void computeOne(GridElement gridElement, int value) {
        //UnityEngine.Debug.Log("move: try");
        if (value != 1) return;
        //UnityEngine.Debug.Log("move: compute");
        Debug.Log("move compute one");
        GameObject temp = gridElement.getAbsoluteXZ(0,0);
        GridElement goalPos = isGridElement(temp);
        int x;
        int z;
        if(goalPos){
            var move = Astar(gridElement, goalPos);
            x = move[0];
            z = move[1];
        }else{
            x = 0;
            z = 0;
        }
        
        // TODO A* for x,z
        GameObject gridElementObject = gridElement.getByXZ(x, z);//Względne
        if (gridElementObject != null && gridElementObject.GetComponent<GridElement>().unit == null) {
            GridElement oldGridElement = unitBase.transform.parent.gameObject.GetComponent<GridElement>();
            unitBase.transform.SetParent(gridElementObject.transform);
            gridElementObject.GetComponent<GridElement>().unit = unitBase.gameObject;
            unitBase.transform.position = gridElementObject.transform.position;
            oldGridElement.unit = null;
            // TODO animation goes brrrrrr
        } else {
            //UnityEngine.Debug.Log("dupa");
        }
    }

    protected override void performOne(GridElement gridElement, int value) {

    }

    private GridElement isGridElement(GameObject obj){
        if(obj.GetComponent<GridElement>())
        {
            return obj.GetComponent<GridElement>();
        }else
        {
            return null;
        }
        
    }
    private int[] Astar(GridElement startPos, GridElement endPos)
    {
        List<GridElement> openedList = new List<GridElement> {startPos};
        List<GridElement> closedList = new List<GridElement>();
        var grid = startPos.grid.GridElements;

        foreach (var z in grid)
        {
            foreach(var x in z)
            {
                GridElement pathNode = isGridElement(x);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }
        startPos.gCost = 0;
        startPos.hCost = ManhattanDistance(startPos, endPos);
        startPos.CalculateFCost();

        while (openedList.Count > 0)
        {
            GridElement currentGridElement = GetLowestFCost(openedList);
            if (currentGridElement == endPos)
            {
                return CalcPath(endPos, startPos);
            }
            openedList.Remove(currentGridElement);
            closedList.Add(currentGridElement);

            foreach(var Node in getNeighbours(currentGridElement))
            {
                if(closedList.Contains(Node)) continue;

                int tempGCost = currentGridElement.gCost + ManhattanDistance(currentGridElement, Node);
                if(tempGCost < Node.gCost)
                {
                    Node.cameFromNode = currentGridElement;
                    Node.gCost = tempGCost;
                    Node.hCost = ManhattanDistance(Node, endPos);
                    Node.CalculateFCost();
                    if(!openedList.Contains(Node))
                    {
                        openedList.Add(Node);
                    }
                }
            }
        }
        return null;
    }
    private int ManhattanDistance(GridElement startNode, GridElement endNode)
    {
        int xDist = Mathf.Abs(startNode.x - endNode.x);
        int zDist = Mathf.Abs(startNode.z - endNode.z);
        return xDist + zDist;
    }
    private GridElement GetLowestFCost(List<GridElement> nodeList)
    {
        GridElement lcn = nodeList[0];
        foreach(var node in nodeList)
        {
            if(node.fCost < lcn.fCost)
            {
                lcn = node;
            }
        }
        return lcn;
    }
    private int[] CalcPath(GridElement endNode, GridElement startNode)
    {
        List<GridElement> path = new List<GridElement>();
        path.Add(endNode);
        GridElement currElem = endNode;
        while (currElem.cameFromNode != null)
        {
            path.Add(currElem.cameFromNode);
            currElem = currElem.cameFromNode;
        }
        path.Reverse();
        int [] move = {Mathf.Abs(startNode.x - path[0].x), Mathf.Abs(startNode.z - path[0].z)};
        return move;
    }
    private List<GridElement> getNeighbours(GridElement node)
    {
        List<GridElement> nList = new List<GridElement>();
        nList.Add(isGridElement(node.getDown()));
        nList.Add(isGridElement(node.getUp()));
        nList.Add(isGridElement(node.getLeft()));
        nList.Add(isGridElement(node.getRight()));
        nList.RemoveAll(Node => Node == null);
        return nList;

    }
}
