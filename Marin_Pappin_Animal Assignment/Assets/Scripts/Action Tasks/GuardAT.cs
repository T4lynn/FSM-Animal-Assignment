using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class GuardAT : ActionTask {

		public GameObject guardIcon;
		public Vector3 offset = Vector3.one;
		public Transform guardTransform;

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
			guardIcon.SetActive(true);
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            guardIcon.transform.position = agent.transform.position + offset;
			navAgent.SetDestination(guardTransform.position);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			if (guardIcon != null)
			{
				guardIcon.SetActive(false);
			}

            }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}