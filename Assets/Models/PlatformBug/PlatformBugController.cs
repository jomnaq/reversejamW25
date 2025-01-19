using UnityEngine;

public class PlatformBugController : MonoBehaviour {
	[SerializeField] PlatformBug platformBug;
	[SerializeField] float moveDistance = 10f;

	Vector3 moveDir = Vector3.forward;

	void Update(){
		if(platformBug.AtTarget){
			platformBug.MoveTo(
				platformBug.transform.position + moveDir * moveDistance
			);

			moveDir = -moveDir;
		}
	}
}