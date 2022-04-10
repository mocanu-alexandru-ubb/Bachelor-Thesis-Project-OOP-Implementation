using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateGround : MonoBehaviour
{
    public GameObject emptyTile;
    public GameObject terrain;

    public int rows;
    public int cols;

    public bool createTerrain = false;
    public bool deleteTerrain = false;

    private void Awake()
    {
    }

    private void Update()
    {
        if (createTerrain)
        {
            createTerrain = false;
            Transform terrainTransform = terrain.transform;
            for (int i = 0; i < rows; i++)
            {
                terrainTransform.position += Vector3.forward;
                for (int j = 0; j < cols; j++)
                {
                    Instantiate(emptyTile, terrainTransform, true);
                    terrainTransform.position += Vector3.right;
                }
                terrainTransform.position = new Vector3(0, terrainTransform.position.y, terrainTransform.position.z);
                Debug.Log(terrainTransform.position);
            }
        }
        if (deleteTerrain)
        {
            deleteTerrain = false;
            DestroyImmediate(terrain);
            terrain = new GameObject("Terrain");
            terrain.transform.SetParent(transform);
            terrain.transform.position = new Vector3();
        }
    }
}
