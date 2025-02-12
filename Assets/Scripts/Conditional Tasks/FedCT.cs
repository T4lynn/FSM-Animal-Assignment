using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FedCT : ConditionTask {
		public BBParameter<bool> fed;

		public float timer = 0;
		public float timesUp = 5;
		public float timeStart = 0;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (fed.value == false)
			{
				if (timer >= timesUp)
				{
					timer = timeStart;
					return true;
				} else
				{
					timer += Time.deltaTime;
					return false; 
				}
			} else
			{
				return false;
			}
		}
	}
}