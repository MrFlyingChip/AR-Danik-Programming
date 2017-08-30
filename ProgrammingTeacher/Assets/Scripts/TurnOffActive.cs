using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffActive : MonoBehaviour {

	public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
