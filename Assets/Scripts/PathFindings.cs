using UnityEngine;

public class PathFindings : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] wayPoints;
    int wayPointIndex = 0;

    void Start()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWaypoints();
        transform.position = waveConfig.GetStartingWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wayPointIndex < wayPoints.Length)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float moveSpeed = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
            if (transform.position == targetPosition) wayPointIndex++;
        }
        else Destroy(gameObject);
    }
}
