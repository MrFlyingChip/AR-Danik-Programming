using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffEnabled : MonoBehaviour {

	public void TurnOff()
    {
        GetComponent<Button>().interactable = false;
    }
}
