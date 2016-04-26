using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {

	public Text m_Text;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		string text = "Stats:\r\n";
		text += "Desired Speed: " + playerController.getDesiredSpeed ().ToString ("0.0") + " knots\r\n";
		text += "Current Speed: " + playerController.getCurrentSpeed ().ToString ("0.0") + " knots\r\n";

		m_Text.text = text;
	}
}
