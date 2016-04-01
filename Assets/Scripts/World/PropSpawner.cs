using UnityEngine;
using System.Collections.Generic;

public class PropSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 _bounds;

    [SerializeField]
    private List<GameObject> _propList = new List<GameObject>();

    private float _maxProps = 200;

    private float _maxClusters = 3;
    
    private GameObject _treeCluster;
    private Vector2 _clusterBounds;

    private float _minClusterWidth = 5;
    private float _maxClusterWidth = 15;
    private float _minClusterHeight = 5;
    private float _maxClusterHeight = 15;

    private float _minDistance = 3; //minimal distance between props/propclusters
    private List<Vector3> _propPositions = new List<Vector3>();

    void Start()
    {
        //CreateTreeCluster();
        PlaceProps();
    }

    //work in progress
    void PlaceProps()
    {
        for (int i = 0; i < _maxProps; i++)
        {
            Vector3 randomPos;
            
            while (true)
            {
                //create random position
                randomPos = new Vector3(
                Random.Range(-_bounds.x, _bounds.x),
                Random.Range(-_bounds.y, _bounds.y),
                0);

                bool succeed = true;

                //loop through all positions
                foreach(Vector3 other in _propPositions)
                {
                    //check distance between 'other' and new position
                    if(Vector3.Distance(other, randomPos) < _minDistance)
                    {
                        succeed = false;

                        //stops it from looking further
                        break;
                    }
                }

                //stops it from creating new position
                if (succeed)
                    break;
            }
            //instantiating prop and adding position to 'other'
            GameObject randomProp = (GameObject)Instantiate(_propList[Random.Range(0, _propList.Count)], randomPos, Quaternion.identity);
            _propPositions.Add(randomProp.transform.position);
        }
    }

    void CreateTreeCluster()
    {
        //no more than 3 clusters
        for (int i = 0; i < _maxClusters; i++)
        {
            _clusterBounds = new Vector2(
            Random.Range(_minClusterWidth, _maxClusterWidth),
            Random.Range(_minClusterHeight, _maxClusterHeight)
            );

            _treeCluster = new GameObject();

            //creating a cluster of trees
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
        }
    }
}
