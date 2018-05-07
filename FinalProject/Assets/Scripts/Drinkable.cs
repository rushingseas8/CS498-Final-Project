﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drinkable : MonoBehaviour {
	private float drinkDistance = 0.175f;
	private GameObject eyeCenter;

	// Use this for initialization
	void Start () {
		eyeCenter = GameObject.Find ("CenterEyeAnchor");
	}

	// Update is called once per frame
	void Update () {
		if ((this.gameObject.transform.position - eyeCenter.transform.position).magnitude < drinkDistance) {
			// Are we a full water bottle?
			if (this.gameObject.name.Contains ("WaterBottleFull")) {
				// Are we being grabbed right now? (Check both kinds)
				if ((this.gameObject.GetComponent<OVRGrabbable> () != null && this.gameObject.GetComponent<OVRGrabbable> ().isGrabbed) ||
				    (this.gameObject.GetComponent<SpringGrabbable> () != null && this.gameObject.GetComponent<SpringGrabbable> ().isGrabbed)) {
					Vector3 pos = gameObject.transform.position;
					Quaternion rot = gameObject.transform.rotation;



					GameObject emptyBottle = GameObject.Instantiate<GameObject> (Resources.Load<GameObject> ("Prefabs/WaterBottleEmpty"));
					emptyBottle.transform.position = pos;
					emptyBottle.transform.rotation = rot;

					GameObject.Destroy (this.gameObject);
				}
			}
		}
	}
}