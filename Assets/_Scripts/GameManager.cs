using TMPro;

using UnityEngine;

public class GameManager : MonoBehaviour
{
	private float _timeSinceGameStart;

	[Header("User Interface")]
	[SerializeField] private TextMeshProUGUI _timeText;
	[SerializeField] private TextMeshProUGUI _scoreText;

	[SerializeField] float _obstacleSpawnDelay = 2f;
	float _obstacleSpawnOffset;
	[SerializeField] float _coinSpawnDelay = 1f;
	private GameObject _obstaclePrefab;
	private GameObject _coinPrefab;

	float _lastObsSpawnTime;
	float _lastCoinSpawnTime;

	public int Score;

	public void Start()
	{
		_timeSinceGameStart = 0f;
		_lastCoinSpawnTime = 0f;
		_obstacleSpawnOffset = 0;
		Score = 0;

		_lastObsSpawnTime = Time.time;
		_obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
		_coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");
	}

	public void Update()
	{
		_spawnObstacle();
		_spawnCoin();
		_updateUI();
	}

	private void _updateUI()
	{
		_timeSinceGameStart += Time.deltaTime;
		int time = Mathf.RoundToInt(_timeSinceGameStart);
		var minutes = time / 60;
		var seconds = time % 60;
		_timeText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
		var scoreFromTime = Mathf.RoundToInt(_timeSinceGameStart * 10);
		_scoreText.text = (Score + scoreFromTime).ToString();
	}

	private void _spawnObstacle()
	{
		if (Time.time - _lastObsSpawnTime < _obstacleSpawnDelay + _obstacleSpawnOffset) return;
		_lastObsSpawnTime = Time.time;
		_obstacleSpawnOffset = Random.Range(0f, 1f);

		int lane = Random.Range(-1, 2);
		var spawnPos = new Vector3(lane * 2f, 12f, 0f);
		Instantiate(_obstaclePrefab, spawnPos, Quaternion.identity, transform);

		int lane2 = -1;
		switch (Random.Range(0, 5))
		{
			case 0:
				do
					lane2 = Random.Range(-1, 2);
				while (lane2 == lane);
				spawnPos = new Vector3(lane2 * 2f, 14.5f, 0f);
				Instantiate(_obstaclePrefab, spawnPos, Quaternion.identity, transform);
				break;

			case 1:
				spawnPos = new Vector3(lane * 2f, 15.5f, 0f);
				Instantiate(_obstaclePrefab, spawnPos, Quaternion.identity, transform);
				break;

			default: break;
		}
	}

	private void _spawnCoin()
	{
		if (Time.time - _lastCoinSpawnTime < _coinSpawnDelay) return;
		_lastCoinSpawnTime = Time.time;
		if (Random.Range(0, 3) != 0) return;

		int lane = Random.Range(-1, 2);
		var spawnPos = new Vector3(lane * 2f, 12f, 0f);
		Instantiate(_coinPrefab, spawnPos, Quaternion.identity, transform);
	}
}