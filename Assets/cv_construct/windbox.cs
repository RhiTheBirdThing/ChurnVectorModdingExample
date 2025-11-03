using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[RequireComponent(typeof(Collider))]
public class Windbox : MonoBehaviour {
    public Vector3 PushVector = new Vector3(0,1,0);
    private void OnValidate() {
        Collider col = GetComponent<Collider>();
        if (col != null && !col.isTrigger) {
            Debug.LogWarning($"{name}: Windbox collider should be set as a Trigger!", this);
        }
    }
	private void OnTriggerStay(Collider other) {
		Rigidbody Object = other.attachedRigidbody;
		if (Object != null) {
			Object.AddForce(10*PushVector, ForceMode.Acceleration);
			//Debug.Log($"Pushing {other.name}");
		}
	}
}

namespace Editor
{
	[CustomEditor(typeof(Windbox))]

	public class DrawGizmo : UnityEditor.Editor
	{
		private static float f(float x) {
			return (float)((x/(x+1))/2);
		}
		private void OnSceneGUI() {
			Windbox wb = (Windbox)target;
			
			EditorGUI.BeginChangeCheck();
			Vector3 newDir = Handles.PositionHandle(
				wb.transform.position + wb.PushVector,
				Quaternion.identity
			);
			if (EditorGUI.EndChangeCheck()) {
				Undo.RecordObject(wb, "Changed Push Vector.");
				wb.PushVector = newDir - wb.transform.position;
			}
			Handles.color = Color.HSVToRGB(
				(float).5-f(wb.PushVector.magnitude),
				1,
				1
			);
			Vector3 tpos = wb.transform.position + wb.PushVector;
			Handles.ArrowHandleCap(0,wb.transform.position, wb.transform.rotation * Quaternion.LookRotation(wb.PushVector), wb.PushVector.magnitude*(float)0.877194, EventType.Repaint);
		}
	}
}