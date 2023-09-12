using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Player target;
    void Start()
    {
        target = FindObjectOfType<Player>();
        if (target is null)
        {
            Debug.LogError("No target was assigned to the camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null) 
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 4, -10);
        }
    }
}
