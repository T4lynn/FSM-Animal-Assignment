using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;



namespace NodeCanvas.Tasks.Actions {

	public class BickerAT : ActionTask {
		public GameObject bickerIcon;
		Vector3 iconOffset = Vector3.one;

		public GameObject fightingSounds;
		 GameObject fightingSoundsHolder;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			bickerIcon.SetActive(true);
			fightingSoundsHolder = GameObject.Instantiate(fightingSounds, Vector3.zero, Quaternion.identity);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			bickerIcon.transform.position = agent.transform.position + iconOffset;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			if (bickerIcon != null) { 
			bickerIcon.SetActive(false);
		}
			GameObject.Destroy(fightingSoundsHolder);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}