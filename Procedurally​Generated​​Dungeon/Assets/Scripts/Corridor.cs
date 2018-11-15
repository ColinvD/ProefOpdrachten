using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{

    private float corridorMinWidth = 8f;
    private float corridorMinHeight = 8f;
    private float corridorMaxWidth = 15f;
    private float corridorMaxHeight = 15f;
    private float gateWidth = 3f;

    private float corridorWidth;
    private float corridorHeight;

    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private GameObject wall;

    private GameObject corridorParent;
    private GameObject floorCorridor;
    private Dictionary<side, List<GameObject>> walls = new Dictionary<side, List<GameObject>>();
    private enum side { Right, Down, Left, Up };

    // Use this for initialization
    void Start()
    {
        corridorParent = new GameObject();
        corridorParent.name = "corridor";
        walls.Add(side.Right, new List<GameObject>());
        walls.Add(side.Down, new List<GameObject>());
        walls.Add(side.Left, new List<GameObject>());
        walls.Add(side.Up, new List<GameObject>());
        corridorWidth = Mathf.Round(Random.Range(corridorMinWidth, corridorMaxWidth) * 100f) / 100f;
        corridorHeight = Mathf.Round(Random.Range(corridorMinHeight, corridorMaxHeight) * 100f) / 100f;
        Spawncorridor();

        side chosenSide = RandomSide();
        SpawnGateWalls(RandomGatePosition(chosenSide), chosenSide);
    }

    private void Spawncorridor()
    {
        GameObject corridorFloor = Instantiate(floor);

        corridorFloor.transform.SetParent(corridorParent.transform);
        corridorFloor.transform.localScale = new Vector3(corridorWidth / 10, 1, corridorHeight / 10);
        floorCorridor = corridorFloor;

        SpawnWall(corridorWidth / 2 + 0.5f, 0, 1, corridorHeight + 2, side.Right);
        SpawnWall(0, -corridorHeight / 2 - 0.5f, corridorWidth, 1, side.Down);
        SpawnWall(-corridorWidth / 2 - 0.5f, 0, 1, corridorHeight + 2, side.Left);
        SpawnWall(0, corridorHeight / 2 + 0.5f, corridorWidth, 1, side.Up);

    }

    private void SpawnGateWalls(float gatePos, side wallNumber)
    {
        float scaleX1 = 1;
        float scaleX2 = 1;
        float scaleZ1 = 1;
        float scaleZ2 = 1;
        float posX = 1;
        float posX1 = 1;
        float posZ = 1;
        float posZ1 = 1;

        if (wallNumber == side.Right || wallNumber == side.Left)
        {
            scaleX1 = 1;
            scaleX2 = 1;
            scaleZ1 = corridorHeight - gateWidth - gatePos + 1;
            scaleZ2 = gatePos + 1;
            posZ = -(corridorHeight - scaleZ1 + 2) / 2;
            posZ1 = (corridorHeight - scaleZ2 + 2) / 2;
            if (wallNumber == side.Right)
            {
                posX = posX1 = corridorWidth / 2 + 0.5f;
            }
            else
            {
                posX = posX1 = -corridorWidth / 2 - 0.5f;
            }
        }
        else
        {
            scaleX1 = corridorWidth - gateWidth - gatePos + 1;
            scaleX2 = gatePos + 1;
            scaleZ1 = 1;
            scaleZ2 = 1;
            posX = -(corridorWidth - scaleX1 + 2) / 2;
            posX1 = (corridorWidth - scaleX2 + 2) / 2;
            if (wallNumber == side.Up)
            {
                posZ = posZ1 = corridorHeight / 2 + 0.5f;
            }
            else
            {
                posZ = posZ1 = -corridorHeight / 2 - 0.5f;
            }
        }

        RemoveWall(wallNumber);

        SpawnWall(posX, posZ, scaleX1, scaleZ1, wallNumber);
        SpawnWall(posX1, posZ1, scaleX2, scaleZ2, wallNumber);
    }

    private void RemoveWall(side side)
    {
        if (walls.ContainsKey(side))
        {
            GameObject temp = walls[side][0];
            walls[side].Remove(walls[side][0]);
            Destroy(temp);
        }
    }

    private void SpawnWall(float xPos, float zPos, float xScale, float zScale, side side)
    {
        if (walls.ContainsKey(side))
        {
            GameObject wallcorridor = Instantiate(wall);
            wallcorridor.transform.SetParent(corridorParent.transform);
            wallcorridor.transform.localScale = new Vector3(xScale, wallcorridor.transform.localScale.y, zScale);
            wallcorridor.transform.localPosition = new Vector3(xPos, wallcorridor.transform.position.y, zPos);

            walls[side].Add(wallcorridor);
        }
    }

    private float RandomGatePosition(side side)
    {
        float gatePos = side == side.Left || side == side.Right ? Random.Range(0, corridorHeight - gateWidth) : Random.Range(0, corridorWidth - gateWidth);
        return gatePos;
    }

    private side RandomSide()
    {
        return (side)Random.Range(0, 3);
    }
}
