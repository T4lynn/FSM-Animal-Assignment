using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ProphesizeAT : ActionTask {

		public GameObject prophesizeIcon;
		Vector3 iconOffset = Vector3.one;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			prophesizeIcon.SetActive(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			prophesizeIcon.transform.position = agent.transform.position + iconOffset;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			prophesizeIcon.SetActive(false);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}