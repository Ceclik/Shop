using System;
using Interfaces;
using Services.HumanServices;
using UnityEngine;

namespace Components.HumanComponents
{
    public class HumanPathWalker : MonoBehaviour
    {
        [SerializeField] private Transform pathParent;
        [SerializeField] private float humanWalkSpeed;
        [SerializeField] private float humanRotationSpeed;
        [Space(10)] [SerializeField] private bool debugGoBack;
        private Transform[] _points;
        private int _currentPointIndex;
        private bool _isPathComplete;

        private bool _isGoingForward = true;
        private bool _isGoingBackward;
        
        private IHumanPathWalker _walker;

        public delegate void HandleCompletedPath();
        public event HandleCompletedPath OnHumanCameToTable;
        public event HandleCompletedPath OnHumanGoAway;

        private void Start()
        {
            _walker = new HumanPathWalkerService();
            _points = new Transform[pathParent.childCount];
            for (int i = 0; i < pathParent.childCount; i++)
                _points[i] = pathParent.GetChild(i);
        }

        private void FixedUpdate()
        {
            if (_isGoingForward && !_isGoingBackward)
            {
                _walker.GoForward(ref _isPathComplete, _points, ref _currentPointIndex, humanWalkSpeed,
                    humanRotationSpeed,
                    transform, ref debugGoBack);
            }
            else
            {
                _walker.GoBackward(ref _isPathComplete, _points, ref _currentPointIndex, humanWalkSpeed,
                    humanRotationSpeed,
                    transform, ref debugGoBack);
            }

            if (_isPathComplete)
            {
                if (_isGoingForward)
                    OnHumanCameToTable?.Invoke();
                else
                {
                    OnHumanGoAway?.Invoke();
                    GameObject beerPack;

                    beerPack = GameObject.Find("BeerPackParent(Clone)");
                    Destroy(beerPack);
                    
                    ChangeDirection();
                }

                if(debugGoBack)
                {
                    debugGoBack = false;
                    ChangeDirection();
                }
                
                
            }

            if (_isPathComplete && debugGoBack)
            {
                debugGoBack = false;
                ChangeDirection();
            }
        }

        public void ChangeDirection()
        {
            if (_isPathComplete && _isGoingForward && !_isGoingBackward)
            {
                _isPathComplete = false;
                _currentPointIndex--;
                _isGoingForward = false;
                _isGoingBackward = true;
            }

            if (_isPathComplete && !_isGoingForward && _isGoingBackward)
            {
                _isPathComplete = false;
                _currentPointIndex = 0;
                _isGoingForward = true;
                _isGoingBackward = false;
            }
            
            Debug.Log($"Current point index: {_currentPointIndex}");
        }
    }
}