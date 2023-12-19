using UnityEngine;

public class Coin : MonoBehaviour
{
	private float _speed = 10f;

	public void Start()
	{
		var rb = gameObject.AddComponent<Rigidbody2D>();
		rb.gravityScale = 0f;
		rb.velocity = Vector3.down * _speed;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Player>() == null) Destroy(gameObject);

		FindObjectOfType<GameManager>().Score += 50;
		Destroy(gameObject);
	}
}
