using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.UIElements;
using UnityEngine.AI;
using NodeCanvas.Tasks.Actions;
public class PopupScript1 : MonoBehaviour
{
    public Blackboard wyrmBlackboard;

    public GameObject popup;
    public GameObject SleepState;
    public GameObject wanderState;
    public GameObject huntState;
    public GameObject locationObject;


    private GameObject currentIcon;
    private GameObject previousIcon;
    public Transform bedPos;

    Vector3 position;
    Vector3 offset = new Vector3 (0, 2, 0);

    bool createdCurrentIcon = false;
    // Start is called before the first frame update
    void Start()
    {
       //wyrmBlackboard = GetComponent<Blackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        int state = wyrmBlackboard.GetVariableValue<int>("currentState");
       // Debug.Log(state);

        switch (state)
        {
            case 0:
               
                //Destroy(previousIcon);

                //SpawnIconFollow(wanderState);
                //createdCurrentIcon = false;
                break;
            case 1:
              
                //Destroy(previousIcon);
                
                //SpawnIconAtLocation(SleepState);
                break ;

                
        }
 
    }
    private void SpawnIconAtLocation(GameObject stateIcon)
    {
        if (!createdCurrentIcon)
        {
            position = locationObject.transform.position;


            if (position.x > bedPos.position.x - 0.5 && position.z > bedPos.position.z - 0.5)
            {
               currentIcon =  Instantiate(stateIcon, position + offset, Camera.main.transform.rotation);
                Debug.Log("Sleeping");

                createdCurrentIcon = true;
            }
        } else if (createdCurrentIcon)
        {
            currentIcon = previousIcon;
        }
    }
    private void SpawnIconFollow(GameObject stateIcon)
    {
        
            position = locationObject.transform.position;


            currentIcon = Instantiate(stateIcon, position + offset, Camera.main.transform.rotation);
            Destroy(currentIcon);
        
    }
}
