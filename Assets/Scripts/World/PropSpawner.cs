using UnityEngine;
using System.Collections.Generic;

public class PropSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 _bounds;

    [SerializeField]
    private List<GameObject> _propList = new List<GameObject>();

    private float _maxProps = 200;//maximum amount of props that will be instantiated

    private float _maxClusters = 3;
    private float _currentClusterAmount = 0;

    private GameObject _treeCluster;
    private Vector2 _clusterBounds;

    private float _minClusterWidth = 5;
    private float _maxClusterWidth = 15;
    private float _minClusterHeight = 5;
    private float _maxClusterHeight = 15;

    //private float _minDis = 1; //minimal distance between props/propclusters
    //private float _maxDis = 10; //maximal distance ^

    void Start()
    {
        CreateTreeCluster();
        PlaceProps();
    }

    //work in progress
    void PlaceProps()
    {
        for (int i = 0; i < _maxProps; i++)
        {
            //TO DO
            //minimal distance between props

            //new position every loop iteration
            float randomPosX = Random.Range(-_bounds.x, _bounds.x);
            float randomPosY = Random.Range(-_bounds.y, _bounds.y);

            //random gameobject every iteration
            GameObject randomProp = _propList[Random.Range(0, _propList.Count)];

            Instantiate(randomProp, new Vector3(randomPosX, randomPosY, 0), Quaternion.identity);
        }
    }

    void CreateTreeCluster()
    {
        for (int i = 0; i < _maxClusters; i++)
        {
            _clusterBounds = new Vector2(
            Random.Range(_minClusterWidth, _maxClusterWidth),
            Random.Range(_minClusterHeight, _maxClusterHeight)
            );


            _treeCluster = new GameObject();
            for (int x = 0; x < _clusterBounds.x; x++)
            {
                for (int y = 0; y < _clusterBounds.y; y++)
                {
                    //offset of the tree position so that it won't be squareshaped clusters
                    float offsetX = (y % 2 == 0 ? Random.Range(.4f, .8f) : 0f);
                    float offsetY = (x % 2 == 0 ? Random.Range(.4f, .8f) : 0f);

                    GameObject treeClone = (GameObject)Instantiate(_propList[8], new Vector3(x + offsetX, y + offsetY, 0), Quaternion.identity);
                    treeClone.transform.parent = _treeCluster.transform;
                }
            }

            //random treeCluster position
        }
    }
}
