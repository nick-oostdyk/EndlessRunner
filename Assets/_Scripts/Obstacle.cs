using UnityEngine;

public class Obstacle : MonoBehaviour
{
	private float _speed = 10f;

	public void Start()
	{
		var rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = 0f;
		rb.velocity = Vector3.down * _speed;
	}

	public void Update()
	{
		if (transform.position.y < -12f)
			Destroy(gameObject);
	}
}
