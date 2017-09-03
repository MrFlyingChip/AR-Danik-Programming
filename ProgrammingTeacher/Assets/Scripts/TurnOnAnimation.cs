using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnAnimation : MonoBehaviour {

	public void TurnOn()
    {
        GetComponent<Animator>().SetBool("Ready", true);
    }

    public void TurnOff()
    {
        GetComponent<Animator>().SetBool("Ready", false);
    }
}
