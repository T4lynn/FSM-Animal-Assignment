using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ProphesizeAT : ActionTask {

		public GameObject prophesizeIcon;
		Vector3 iconOffset = Vector3.one;

		public GameObject whisperSounds;
		public Vector3 bedpos = new(1.42f, 0.6f, 12.2f);

		GameObject whisperSoundholder;
		GameObject prophesizeIconHolder;
		

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			prophesizeIconHolder =  GameObject.Instantiate(prophesizeIcon, bedpos + iconOffset, Camera.main.transform.rotation);
			whisperSoundholder = GameObject.Instantiate(whisperSounds, iconOffset, Quaternion.identity) ;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			prophesizeIcon.transform.position = agent.transform.position + iconOffset;
			 
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
			GameObject.Destroy(prophesizeIconHolder);
			GameObject.Destroy(whisperSoundholder);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}