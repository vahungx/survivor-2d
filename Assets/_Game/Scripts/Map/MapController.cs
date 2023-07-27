using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrianChunks;

    public GameObject player;
    public float checkerRadius;
    private Vector3 noTerrainPosition;
    private Vector3 lastChunkPoint;
    public LayerMask terrainMask;
    [SerializeField] private Transform right, left, up, down, leftUp, leftDown, rightUp, rightDown;
    private PlayerMovement playerMovement;

    public GameObject currentChunk;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
    }

    private void ChunkChecker()
    {
        if (!currentChunk) { return; }
        lastChunkPoint = currentChunk.transform.position;
        if (playerMovement.moveDirection.x > 0 && playerMovement.moveDirection.y == 0) //Right
        {
            if (!Physics2D.OverlapCircle(player.transform.position + right.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + right.position;                
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x < 0 && playerMovement.moveDirection.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(player.transform.position + left.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + left.position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x == 0 && playerMovement.moveDirection.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(player.transform.position + up.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + up.position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x == 0 && playerMovement.moveDirection.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(player.transform.position + down.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + down.position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x > 0 && playerMovement.moveDirection.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(player.transform.position + rightUp.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + rightUp.position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x > 0 && playerMovement.moveDirection.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(player.transform.position + rightDown.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + rightDown.position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x < 0 && playerMovement.moveDirection.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(player.transform.position + leftUp.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + leftUp.position;
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDirection.x < 0 && playerMovement.moveDirection.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(player.transform.position + leftDown.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + leftDown.position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int random = UnityEngine.Random.Range(0, terrianChunks.Count);
        Instantiate(terrianChunks[random], noTerrainPosition, Quaternion.identity);
    }
}
