using UnityEngine;

public static class RandomExtensions
{
    public static Vector3 RandomVector3(float minRange, float maxRange)
    {
        Vector3 resultVector = Vector3.zero;

        resultVector.x = Random.Range(minRange, maxRange);
        resultVector.y = Random.Range(minRange, maxRange);
        resultVector.z = Random.Range(minRange, maxRange);

        return resultVector;
    }

    public static Vector3 RandomVector3(float xMinRange, float xMaxRange, float yMinRange, float yMaxRange, float zMinRange, float zMaxRange)
    {
        Vector3 resultVector = Vector3.zero;

        resultVector.x = Random.Range(xMinRange, xMaxRange);
        resultVector.y = Random.Range(yMinRange, yMaxRange);
        resultVector.z = Random.Range(zMinRange, zMaxRange);

        return resultVector;
    }
}
