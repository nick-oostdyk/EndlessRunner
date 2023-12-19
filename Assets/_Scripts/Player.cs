using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
	private int _currLane;

	// Start is called before the first frame update
	void Start()
	{
		_currLane = 0;
	}

	// Update is called once per frame
	void Update()
	{
		_handleInput();
		_handleAnim();
	}

	private void _handleInput()
	{
		if (Input.GetKeyDown(KeyCode.A)) _changeLane(-1);
		if (Input.GetKeyDown(KeyCode.D)) _changeLane(1);
	}

	private void _changeLane(int offset)
	{
		if (_currLane == -1 && offset < 0) return;
		if (_currLane == 1 && offset > 0) return;

		_currLane += offset;
	}

	private void _handleAnim()
	{
		var pos = transform.position;
		pos.x = _currLane * 2f;
		transform.position = pos;
	}
}
