using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SurfaceMeshRenderer : MonoBehaviour
{
    [SerializeField] private GameObject _meshObjectPrefab;
    [SerializeField] private float _meshWidth = 0.05f;
    [SerializeField] private float _maxDistance = 10f;
    
    private Mesh _surfaceMesh;
    private List<Vector3> _vertices = new List<Vector3>();
    private List<int> _triangles = new List<int>();
    private MeshFilter _meshFilter;

    private void Start()
    {
        GameObject surfaceMeshObject = Instantiate(_meshObjectPrefab, Vector3.zero, Quaternion.identity);
        _meshFilter = surfaceMeshObject.GetComponent<MeshFilter>();
        _surfaceMesh = new Mesh();
        _meshFilter.mesh = _surfaceMesh;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            Vector3 hitPoint = hit.point;

            AddSurfacePoint(hitPoint);
            UpdateMesh();
        }
    }

    private void AddSurfacePoint(Vector3 point)
    {
        _vertices.Add(point);
        
        if(_vertices.Count >= 3)
        {
            int lastIndex = _vertices.Count - 1;
            _triangles.Add(lastIndex - 2);
            _triangles.Add(lastIndex - 1);
            _triangles.Add(lastIndex);
        }
    }
}
