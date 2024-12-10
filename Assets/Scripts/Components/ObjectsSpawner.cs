using System;
using UnityEngine;

namespace Components
{
    public class ObjectsSpawner : MonoBehaviour
    {
        [Header("Items prefabs")]
        [SerializeField] private GameObject jackPrefab;
        [SerializeField] private GameObject beerPrefab;
        [SerializeField] private GameObject cheesePrefab;
        [SerializeField] private GameObject applePrefab;

        [Space(10)] [Header("Spawn points parents")] [SerializeField]
        private Transform jackPointsParent;
        [SerializeField] private Transform beerPointsParent;
        [SerializeField] private Transform cheesePointsParent;
        [SerializeField] private Transform applePointsParent;
        [Space(5)] [SerializeField] private Transform interactingObjectsParent;

        private Transform[] _jackSpawnPoints;
        private Transform[] _beerSpawnPoints;
        private Transform[] _cheeseSpawnPoints;
        private Transform[] _appleSpawnPoints;

        private void Start()
        {
            _jackSpawnPoints = new Transform[jackPointsParent.childCount];
            _beerSpawnPoints = new Transform[beerPointsParent.childCount];
            _cheeseSpawnPoints = new Transform[cheesePointsParent.childCount];
            _appleSpawnPoints = new Transform[applePointsParent.childCount];

            for (int i = 0; i < _jackSpawnPoints.Length; i++)
                _jackSpawnPoints[i] = jackPointsParent.GetChild(i);
            
            for (int i = 0; i < _beerSpawnPoints.Length; i++)
                _beerSpawnPoints[i] = beerPointsParent.GetChild(i);
            
            for (int i = 0; i < _cheeseSpawnPoints.Length; i++)
                _cheeseSpawnPoints[i] = cheesePointsParent.GetChild(i);
            
            for (int i = 0; i < _appleSpawnPoints.Length; i++)
                _appleSpawnPoints[i] = applePointsParent.GetChild(i);
            
            RespawnObjects();
        }

        public void RespawnObjects()
        {
            foreach (var jackSpawnPoint in _jackSpawnPoints)
            {
                var jackSpawnPointObj = jackSpawnPoint.GetComponent<SpawnPoint>();
                if (jackSpawnPointObj.SpawnedObject == null)
                {
                    jackSpawnPointObj.SpawnedObject = Instantiate(jackPrefab,
                        jackSpawnPoint.position, jackSpawnPoint.rotation, interactingObjectsParent);
                    jackSpawnPointObj.SpawnedObject.name = "Jack";
                }
            }
            
            foreach (var beerSpawnPoint in _beerSpawnPoints)
            {
                var beerSpawnPointObj = beerSpawnPoint.GetComponent<SpawnPoint>();
                if (beerSpawnPointObj.SpawnedObject == null)
                {
                    beerSpawnPointObj.SpawnedObject = Instantiate(beerPrefab,
                        beerSpawnPoint.position, beerSpawnPoint.rotation, interactingObjectsParent);
                    beerSpawnPointObj.SpawnedObject.name = "Beer";
                }
            }
            
            foreach (var cheeseSpawnPoint in _cheeseSpawnPoints)
            {
                var cheeseSpawnPointObj = cheeseSpawnPoint.GetComponent<SpawnPoint>();
                if (cheeseSpawnPointObj.SpawnedObject == null)
                {
                    cheeseSpawnPointObj.SpawnedObject = Instantiate(cheesePrefab,
                        cheeseSpawnPoint.position, cheeseSpawnPoint.rotation, interactingObjectsParent);
                    cheeseSpawnPointObj.SpawnedObject.name = "Cheese";
                }
            }
            
            foreach (var appleSpawnPoint in _appleSpawnPoints)
            {
                var appleSpawnPointObj = appleSpawnPoint.GetComponent<SpawnPoint>();
                if (appleSpawnPointObj.SpawnedObject == null)
                {
                    appleSpawnPointObj.SpawnedObject = Instantiate(applePrefab,
                        appleSpawnPoint.position, appleSpawnPoint.rotation, interactingObjectsParent);
                    appleSpawnPointObj.SpawnedObject.name = "Apple";
                }
            }
        }
    }
}