using System.Collections.Generic;
using UnityEngine;

namespace YUART.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject plane;
        [SerializeField] private int countOfPlanesToSpawn;
        
        private void Awake()
        {
            var startRowPoints = SpawnStartRowOfPlanes(new Vector3());

            var directionForSpawner = new Vector3(10, 0, 0);
            
            while (startRowPoints.Count > 0)
            {
                SpawnRowOfPlanes(startRowPoints.Pop(), directionForSpawner);
            }
        }

        private Stack<Vector3> SpawnStartRowOfPlanes(Vector3 startPoint)
        {
            var points = new Stack<Vector3>();
            var directionForRow = new Vector3(0, 0, 10);
            
            for (var i = 0; i < countOfPlanesToSpawn; i++)
            {
                Instantiate(plane, startPoint, Quaternion.identity);

                points.Push(startPoint);
                
                startPoint += directionForRow;
            }

            return points;
        }

        private void SpawnRowOfPlanes(Vector3 startPoint, Vector3 direction)
        {
            for (var i = 0; i < countOfPlanesToSpawn; i++)
            {
                startPoint += direction;
                
                Instantiate(plane, startPoint, Quaternion.identity);
            }
        }
    }
}
