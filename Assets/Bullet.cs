using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_small_object;
    public float speed = 8f;
    private ObjectPooler pooler;
    private List<GameObject> object_list;
    private int small_object_num = 10;
    private Vector3 cube_position;
    private float minX , maxX, minZ, maxZ, minY, maxY;
    private float speed_fall = 5f;
    // Start is called before the first frame update
    void Start()
    {
        pooler = (ObjectPooler)FindObjectOfType(typeof(ObjectPooler));
        object_list = pooler.object_list;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += transform.forward * speed * Time.deltaTime;
       for(int i = 0; i < object_list.Count; i++)
        {
           if(object_list[i].gameObject != null)
            {
                GameObject cube = object_list[i];
                if (Vector3.Distance(transform.position, cube.transform.position) < 0.5f)
                {
                    
                    cube_position = cube.transform.position;
                    Destroy(cube);
                    Destroy(this);
                    this.gameObject.SetActive(false);
                    List<GameObject> small_object_list = GenerateSmallObject();
                    //Fall(small_object_list);
                    
                }
            }
        }

    }

    List<GameObject> GenerateSmallObject()
    {
        List<GameObject> result = new List<GameObject>();
        minX = cube_position.x - 0.25f;
        maxX = cube_position.x + 0.25f;
        minY = cube_position.y - 0.25f;
        maxY = cube_position.y + 0.25f;
        minZ = cube_position.z - 0.25f;
        maxZ = cube_position.z + 0.25f;
        for (int i = 0; i < small_object_num; i++)
        {
            GameObject temp = Instantiate(prefab_small_object);
            float xPos = Random.Range(minX, maxX);
            float yPos = Random.Range(minY, maxY);
            float zPos = Random.Range(minZ, maxZ);
            temp.transform.position = new Vector3(xPos, yPos, zPos);
            result.Add(temp);
        }
        return result;
    }

    void Fall(List<GameObject> list)
    {
        foreach(GameObject ob in list)
        {
            while (true)
            {
                ob.transform.position = new Vector3(ob.transform.position.x, ob.transform.position.y - speed_fall, ob.transform.position.z);
                if (ob.transform.position.y < 0.1f)
                {
                    Destroy(ob);
                    break;
                }
            }
        }
    }

    void Destroy_Small_Objects(List<GameObject> list)
    {

    }
}
