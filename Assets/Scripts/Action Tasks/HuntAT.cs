using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class HuntAT : ActionTask {

		public GameObject huntIcon;
		Vector3 iconOffset = Vector3.one;

		public GameObject huntSpot1;
		public GameObject huntSpot2;
		public GameObject huntSpot3;

		public GameObject food;

		float timer;

		NavMeshAgent navAgent;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			huntIcon.SetActive(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            huntIcon.transform.position = agent.transform.position + iconOffset;

            timer += Time.deltaTime;

            if (timer > 4)
            {
                float selection = Random.Range(0, 4);


                if (selection == 0)
                {
                    navAgent.SetDestination(huntSpot1.transform.position);
                }
                else if (selection == 1)
                {
                    navAgent.SetDestination(huntSpot2.transform.position);
                }
                else if (selection == 2)
                {
                    navAgent.SetDestination(huntSpot3.transform.position);
                }
                else { return; }

                timer = 0;
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			huntIcon?.SetActive(false);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}