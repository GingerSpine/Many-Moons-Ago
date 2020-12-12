using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidGenerator
{
    private float _ctrX, _ctrY, _aveRadius, _irregularity, _spikeyness;
    private int _numVerts;
    public AsteroidGenerator(float ctrX, float ctrY, float aveRadius, float irregularity, float spikeyness, int numVerts)
    {
        _ctrX = ctrX;
        _ctrY = ctrY;
        _aveRadius = aveRadius;
        _irregularity = irregularity;
        _spikeyness = spikeyness;
        _numVerts = numVerts;
    }

    public GameObject generate(float x, float y, float z = 0.0f, float scaleX = 1f, float scaleY = 0.5f)
    {
        GameObject newAsteroid = new GameObject();
        newAsteroid.name = "Asteroid";

        var points = generatePolygon();
        generateMesh(newAsteroid, points);
        generatePolygonCollider2D(newAsteroid, points);
        generatePlatformEffector2D(newAsteroid);

        newAsteroid.transform.position = new Vector3(x, y, z);
        newAsteroid.transform.localScale = new Vector3(scaleX, scaleY, 1f);

        return newAsteroid;
    }
    private void generatePlatformEffector2D(GameObject asteroid)
    {
        var platformEffector2D = asteroid.AddComponent<PlatformEffector2D> ();
        platformEffector2D.surfaceArc = 160;
        platformEffector2D.useOneWay = true;
    }
    private void generatePolygonCollider2D(GameObject asteroid, Vector2[] points)
    {
        var polygonCollider2D = asteroid.AddComponent<PolygonCollider2D>();
        polygonCollider2D.points = points;
        polygonCollider2D.usedByEffector = true;
    }
    private void generateMesh(GameObject asteroid, Vector2[] points)
    {
        var vertices3D = System.Array.ConvertAll<Vector2, Vector3>(points, v => v);

        // Use the triangulator to get indices for creating triangles
        var triangulator = new Triangulator(points);
        var indices = triangulator.Triangulate();

        // Generate a color for each vertex
        var colors = Enumerable.Range(0, vertices3D.Length)
            .Select(i => Random.ColorHSV())
            .ToArray();

        // Create the mesh
        var mesh = new Mesh
        {
            vertices = vertices3D,
            triangles = indices,
            colors = colors,
        };

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Set up game object with mesh;
        var meshRenderer = asteroid.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));

        var filter = asteroid.AddComponent<MeshFilter>();
        filter.mesh = mesh;
    }
    public Vector2[] generatePolygon()
    {
        /*Start with the centre of the polygon at ctrX, ctrY, 
    then creates the polygon by sampling points on a circle around the centre.
    Randon noise is added by varying the angular spacing between sequential points,
    and by varying the radial distance of each point from the centre.

    Params:
        ctrX, ctrY - coordinates of the "centre" of the polygon
    aveRadius - in px, the average radius of this polygon, this roughly controls how large the polygon is, really only useful for order of magnitude.
    irregularity - [0, 1] indicating how much variance there is in the angular spacing of vertices. [0, 1] will map to[0, 2pi / numberOfVerts]
    spikeyness - [0, 1] indicating how much variance there is in each vertex from the circle of radius aveRadius. [0, 1] will map to[0, aveRadius]
    numVerts - self - explanatory

    Returns a list of vertices, in CCW order.
    */

        _irregularity = clip(_irregularity, 0f, 1.0f) * 2.0f * Mathf.PI / _numVerts;
        _spikeyness = clip(_spikeyness, 0f, 1.0f) * _aveRadius;

        // generate n angle steps
        List<float> angleSteps = new List<float>();
        float lower = (2 * Mathf.PI / _numVerts) - _irregularity;
        float upper = (2 * Mathf.PI / _numVerts) + _irregularity;
        float sum = 0f;
        for (int i = 0; i < _numVerts; i++)
        {
            float tmp = Random.Range(lower, upper);
            angleSteps.Add(tmp);
            sum = sum + tmp;
        }

        // normalize the steps so that point 0 and point n+1 are the same
        float k = sum / (2 * Mathf.PI);
        for (int i = 0; i < _numVerts; i++)
        { angleSteps[i] = angleSteps[i] / k; }

        // now generate the points
        Vector2[] points = new Vector2[_numVerts];
        float angle = Random.Range(0f, 2.0f * Mathf.PI);
        for (int i = 0; i < _numVerts; i++)
        {
            float r_i = clip(GenerateNormalRandom(_aveRadius, _spikeyness, 0f, 10f), 0f, 2.0f * _aveRadius);
            float x = _ctrX + r_i * Mathf.Cos(angle);
            float y = _ctrY + r_i * Mathf.Sin(angle);
            points[i] = new Vector2(x, y);

            angle = angle + angleSteps[i];
        }

        return points;
    }

    private float clip(float x, float min, float max)
    {
        if (min > max) { return x; }
        else
        {
            if (x < min) { return min; }
            else
            {
                if (x > max) { return max; }
                else { return x; }
            }
        }
    }

    private static float GenerateNormalRandom(float mean, float sigma, float min, float max)
    {
        float rand1 = Random.Range(0.0f, 1.0f);
        float rand2 = Random.Range(0.0f, 1.0f);

        float n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);

        float generatedNumber = Mathf.FloorToInt(mean + sigma * n);

        generatedNumber = Mathf.Clamp(generatedNumber, min, max);

        return generatedNumber;
    }
}
