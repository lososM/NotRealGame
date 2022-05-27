using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flashlight2D : MonoBehaviour
{

    [SerializeField] bool _active;
    [Range(1, 360)]
    [SerializeField] float _angle;
    [SerializeField] float _distance;
    [SerializeField] Vector3 _direction;
    [SerializeField] int _startRayCount;
    [SerializeField] bool _isSphere;
    [SerializeField] bool _noRays;
    private int _rayCount;

    [SerializeField] MeshFilter _meshFilter;
    [SerializeField] Vector3 _offset;
    private Mesh _mesh;
    private Vector3[] _vertices;
    private int[] _triangles;


    private void Awake()
    {
       
    }
    void Start()
    {
        MakeMesh();
    }

    void Update()
    {
        if (!_active) return;
        _vertices[0] = transform.position - _meshFilter.transform.position + _offset;
        var ray_direction = transform.rotation * _direction;
        ray_direction.z = 0;
        ray_direction.Normalize();
        ray_direction = Quaternion.Euler(new Vector3(0, 0, -_angle / 2)) * ray_direction;
        var anglePerRay = _angle / _rayCount;

        //make ray points
        for (int i = 1; i < _rayCount; i++)
        {
            ray_direction = Quaternion.Euler(new Vector3(0, 0, anglePerRay)) * ray_direction;
            Ray ray = new Ray(transform.position - _meshFilter.transform.position, ray_direction);
            _vertices[i] = ray.GetPoint(_distance);

            
            var hits = Physics2D.RaycastAll(transform.position, ray_direction, _distance);
            foreach (var item_hit in hits.OrderBy(h => h.distance))
            {
                if (!ExecuteLightMethods.LastHits.Contains(item_hit.transform)) ExecuteLightMethods.LastHits.Add(item_hit.transform);

                if (_noRays) continue;
                if (item_hit.transform.tag != TagHandler.TRANSPARENT)
                {
                    _vertices[i] = (Vector3)item_hit.point - _meshFilter.transform.position + _offset;
                    break;
                }

            }
            
        }

        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;

    }
   /* private void OnDrawGizmos()
    {
        if (_vertices == null) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], .2f);
        }
    }*/
    private void MakeMesh()
    {
        _rayCount = _startRayCount;
        _mesh = new Mesh();
        _vertices = new Vector3[_rayCount];
        if (_isSphere)
            _triangles = new int[((_rayCount - 2) * 3) + 3];
        else
            _triangles = new int[(_rayCount - 2) * 3];


        for (int i = 0, trG = 0; i < _rayCount - 2; i++, trG += 3)
        {
            _triangles[trG] = i + 2;
            _triangles[trG + 1] = i + 1;
            _triangles[trG + 2] = 0;
        }
        if (_isSphere)
        {
            _triangles[_triangles.Length - 3] = 1;
            _triangles[_triangles.Length - 2] = _triangles[_triangles.Length - 6];
            _triangles[_triangles.Length - 1] = 0;
        }
        UpdateStatus();
    }
    public void RemakeMesh()
    {
        return;
        MakeMesh();
    }
    public void SetStatus(bool status)
    {
        _active = status;
        UpdateStatus();
       
    }

    private void UpdateStatus()
    {
        if (_active)
            _meshFilter.mesh = _mesh;
        else
        {
            _meshFilter.mesh = null;
      }
            
    }
}
