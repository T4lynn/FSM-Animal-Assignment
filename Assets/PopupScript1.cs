using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript1 : MonoBehaviour
{
    public GameObject popup; 
    public GameObject locationObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = locationObject.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(popup, position, Quaternion.identity);
        }
    }
}
