using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;


namespace NodeCanvas.Tasks.Actions {

	public class SleepAT : ActionTask {

		NavMeshAgent navAgent;
		public BBParameter<Transform> bedTran;
		Vector3 bedPos;
		public BBParameter<int> state;
		private bool createdIcon;
		public GameObject Icon;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			bedPos = bedTran.value.position;
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			state.value = 1;
			navAgent.SetDestination(bedPos);
			createdIcon = false;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!createdIcon)
			{
				Vector3 position = agent.transform.position;
                if (position.x > bedPos.x - 0.5 && position.z > bedPos.z - 0.5)
				{
                  Icon.SetActive(true);
					createdIcon = true;
                }

            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			state.value = 0;
			Icon.SetActive(false);
			createdIcon = false ;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}