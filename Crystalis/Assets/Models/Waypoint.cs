﻿using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
    public Waypoint next;

    void Start() {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
