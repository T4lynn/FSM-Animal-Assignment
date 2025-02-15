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
    public GameObject locationObject;
    private GameObject snoozeIcon;
    public Transform bedPos;

    Vector3 position;
    Vector3 offset = new Vector3 (0, 2, 0);

    bool createdSnooze = false;
    // Start is called before the first frame update
    void Start()
    {
       //wyrmBlackboard = GetComponent<Blackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        int state = wyrmBlackboard.GetVariableValue<int>("currentState");
        Debug.Log(state);


        if (state == 1)
        {
            SpawnIcon();
        }


       if (  state == 0)
        {
            Debug.Log("swapped states");
            Destroy(snoozeIcon);
            createdSnooze = false; 
        }
    }
    private void SpawnIcon()
    {
        if (!createdSnooze)
        {
            position = locationObject.transform.position;


            if (position.x > bedPos.position.x - 1 && position.z > bedPos.position.z - 1)
            {
               snoozeIcon =  Instantiate(SleepState, position + offset, Camera.main.transform.rotation);
                Debug.Log("Sleeping");

                createdSnooze = true;
            }
        }
    }
}
