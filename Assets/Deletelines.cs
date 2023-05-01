using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deletelines : MonoBehaviour
{
    public void OnClick()
	{
		FindObjectOfType<LineGenerator>().DeleteLines();
	}
}
