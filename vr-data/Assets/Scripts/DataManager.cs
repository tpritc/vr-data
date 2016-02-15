﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

    public string dataFile;
    public GeometryInformation geoInfo;
    public GameObject dataPointPrefab;

	void Start () {
        List<Dictionary<string, object>> dataSet = CSVReader.Read(dataFile);
        int completed = 0;
        int inBounds = 0;

        //foreach (var dataItem in dataSet)
        for (int i = 119100; i < 120100; i++)
        {
            Dictionary<string, object> dataItem = dataSet[i];
            float lat = (float)dataItem["Latitude"];
            float lon = (float)dataItem["Longitude"];

            if (geoInfo.IsCoordinateInRange(lat, lon))
            {
                print(lat + ", " + lon);
                Vector3 position = geoInfo.GetPositionForCoordinate(lat, lon);
                print(position);
                GameObject newDataPoint = Instantiate(dataPointPrefab, position, Quaternion.identity) as GameObject;
                newDataPoint.transform.parent = transform;
                newDataPoint.name = "Data Point (" + lat + ", " + lon + ")";
                inBounds++;
            }
            completed++;
        }
        print("Processed: " + completed.ToString());
        print("Shown:     " + inBounds.ToString());
	}
	

}
