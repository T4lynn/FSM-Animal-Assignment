using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		public GameObject wanderSpot1;
		public GameObject wanderSpot2;
		public GameObject wanderSpot3;

		public GameObject wanderIcon;

		float timer;

        NavMeshAgent navAgent;

        Vector3 iconOffset = new Vector3(1, 1, 1);
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
			timer = 4;
			wanderIcon.SetActive(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			wanderIcon.transform.position = agent.transform.position + iconOffset;

			timer += Time.deltaTime;

			if (timer > 4)
			{
				float selection = Random.Range(0, 4);
				

				if (selection == 0)
				{
					navAgent.SetDestination(wanderSpot1.transform.position);
				}
				else if (selection == 1)
				{
					navAgent.SetDestination(wanderSpot2.transform.position);
				} else if (selection == 2)
				{
                    navAgent.SetDestination(wanderSpot3.transform.position);
                } else { return; }

				timer = 0;
                }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			wanderIcon.SetActive(false);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}