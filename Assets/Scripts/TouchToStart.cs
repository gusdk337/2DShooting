using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchToStart : MonoBehaviour
{

	Text flashingText;

	// Use this for initialization
	void Start()
	{
		flashingText = GetComponent<Text>();
		StartCoroutine(BlinkText());
	}

	public IEnumerator BlinkText()
	{
		while (true)
		{
			flashingText.text = "";
			yield return new WaitForSeconds(.7f);
			flashingText.text = "touch to Start";
			yield return new WaitForSeconds(.7f);
		}
	}
}