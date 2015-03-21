using UnityEngine;
using System.Collections;

public class Util {

	public static void Lookat(Transform subject, Transform target) {
		Vector3 diff = target.position - subject.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		subject.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}
	/// <summary>
	/// Causes the subject to look towards the target. This function will only move a fraction
	/// for each call.
	/// </summary>
	/// <returns><c>true</c>, if the new angle is within 10 degrees of the target, <c>false</c> otherwise.</returns>
	/// <param name="subject">Subject.</param>
	/// <param name="target">Target.</param>
	public static bool LookTowards(Transform subject, Transform target) {
		Vector3 diff = target.position - subject.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.Euler(0f, 0f, rot_z - 90);

		subject.rotation = Quaternion.Lerp (subject.rotation, q, 0.1f);
		return q.eulerAngles.z - subject.eulerAngles.z < 10.0f;
	}
}
