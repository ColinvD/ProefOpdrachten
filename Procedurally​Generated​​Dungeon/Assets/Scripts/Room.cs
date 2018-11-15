using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    private float roomMinWidth = 8f;
    private float roomMinHeight = 8f;
    private float roomMaxWidth = 15f;
    private float roomMaxHeight = 15f;
    private float gateWidth = 3f;

    private float roomWidth;
    private float roomHeight;

    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private GameObject wall;

    private GameObject roomParent;
    private GameObject floorRoom;
    private Dictionary<side, List<GameObject>> walls = new Dictionary<side, List<GameObject>>();
    private enum side {Right, Down, Left, Up};

    // Use this for initialization
    void Start () {
        roomParent = new GameObject();
        roomParent.name = "Room";
        walls.Add(side.Right, new List<GameObject>());
        walls.Add(side.Down, new List<GameObject>());
        walls.Add(side.Left, new List<GameObject>());
        walls.Add(side.Up, new List<GameObject>());
        roomWidth = Mathf.Round(Random.Range(roomMinWidth, roomMaxWidth) * 100f) / 100f;
        roomHeight = Mathf.Round(Random.Range(roomMinHeight, roomMaxHeight) * 100f) / 100f;
        SpawnRoom();

        side chosenSide = RandomSide();
        SpawnGateWalls(RandomGatePosition(chosenSide), chosenSide);
    }
	
	private void SpawnRoom()
    {
        GameObject roomFloor = Instantiate(floor);
        
        roomFloor.transform.SetParent(roomParent.transform);
        roomFloor.transform.localScale = new Vector3(roomWidth / 10, 1, roomHeight / 10);
        floorRoom = roomFloor;

        SpawnWall(roomWidth / 2 + 0.5f, 0, 1, roomHeight + 2, side.Right);
        SpawnWall(0, -roomHeight / 2 - 0.5f, roomWidth, 1, side.Down);
        SpawnWall(-roomWidth / 2 - 0.5f, 0, 1, roomHeight + 2, side.Left);
        SpawnWall(0, roomHeight / 2 + 0.5f, roomWidth, 1, side.Up);

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

        if(wallNumber == side.Right || wallNumber == side.Left)
        {
            scaleX1 = 1;
            scaleX2 = 1;
            scaleZ1 = roomHeight - gateWidth - gatePos + 1;
            scaleZ2 = gatePos + 1;
            posZ = -(roomHeight - scaleZ1 + 2) / 2;
            posZ1 = (roomHeight - scaleZ2 + 2) / 2;
            if (wallNumber == side.Right)
            {
                posX = posX1 = roomWidth / 2 + 0.5f;
            }
            else
            {
                posX = posX1 = -roomWidth / 2 - 0.5f;
            }
        } else
        {
            scaleX1 = roomWidth - gateWidth - gatePos + 1;
            scaleX2 = gatePos + 1;
            scaleZ1 = 1;
            scaleZ2 = 1;
            posX = -(roomWidth - scaleX1 + 2) / 2;
            posX1 = (roomWidth - scaleX2 + 2) / 2;
            if (wallNumber == side.Up)
            {
                posZ = posZ1 = roomHeight / 2 + 0.5f;
            }
            else
            {
                posZ = posZ1 = -roomHeight / 2 - 0.5f;
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
            GameObject wallRoom = Instantiate(wall);
            wallRoom.transform.SetParent(roomParent.transform);
            wallRoom.transform.localScale = new Vector3(xScale, wallRoom.transform.localScale.y, zScale);
            wallRoom.transform.localPosition = new Vector3(xPos, wallRoom.transform.position.y, zPos);

            walls[side].Add(wallRoom);
        }
    }

    private float RandomGatePosition(side side)
    {
        float gatePos = side == side.Left || side == side.Right ? Random.Range(0, roomHeight - gateWidth) : Random.Range(0, roomWidth - gateWidth);
        return gatePos;
    }

    private side RandomSide()
    {
        return (side)Random.Range(0, 3);
    }
}
