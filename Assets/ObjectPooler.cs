using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_object;
    public int object_num = 50;
    public List<GameObject> object_list;
    private float minX = -10f, maxX = 10f, minZ = -10f, maxZ = 10f, minY = 0.5f, maxY = 15f;
    // Start is called before the first frame update
    void Start()
    {
        object_list = new List<GameObject>();
        for (int i = 0; i < object_num; i++)
        {
            GameObject temp = Instantiate(prefab_object);
            float xPos = Random.Range(minX, maxX);
            float yPos = Random.Range(minY, maxY);
            float zPos = Random.Range(minZ, maxZ);
            temp.transform.position = new Vector3(xPos, yPos, zPos);
            object_list.Add(temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
