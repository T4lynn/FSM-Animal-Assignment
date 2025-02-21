using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class flickerAT : ActionTask {
		public GameObject prophesizeIcon;
		public GameObject prophesizeIconHolder;
		Vector3 iconOffset = Vector3.one;
        public Vector3 bedpos = new(1.42f, 0.6f, 12.2f);

        float timer;

		public Material wyrmMat;
		Color wyrmColor;

		Color flickerColor = new Color(1, 1, 1, 0.5f);
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			wyrmColor = wyrmMat.color;
			timer = 2;
			prophesizeIconHolder = GameObject.Instantiate(prophesizeIcon, bedpos + iconOffset, Camera.main.transform.rotation);

            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer += timer + Time.deltaTime;
			if (timer > 2)
			{
                wyrmMat.SetColor("_Color", flickerColor);
				timer = 0;
            } else
			{
				wyrmMat.SetColor("_Color", wyrmColor);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			GameObject.Destroy(prophesizeIconHolder);
			wyrmMat.SetColor("_Color", wyrmColor);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}