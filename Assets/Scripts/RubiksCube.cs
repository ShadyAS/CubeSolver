using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubiksCube : MonoBehaviour
{
    [SerializeField] List<Face> faces = new List<Face>();
    //public float speedRotation = 1.0f;

    //float rotationTimer = 0.0f;
    //float rotationBySeconds = 90.0f;

    bool rotateF = false;
    bool rotateB = false;
    bool rotateR = false;
    bool rotateL = false;
    bool rotateU = false;
    bool rotateD = false;
    bool clockwise = true;

    private void Start()
    {
        //rotationTimer = speedRotation;
        //rotationBySeconds = 90.0f / speedRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateF)
        {
            RotateF();
        }
        else if (rotateB)
        {
            RotateB();
        }
        else if(rotateR)
        {
            RotateR();
        }
        else if(rotateL)
        {
            RotateL();
        }
        else if(rotateU)
        {
            RotateU();
        }
        else if(rotateD)
        {
            RotateD();
        }
    }

    int frames = 0;

    void RotateF()
    {
        Vector3 axis = -Vector3.forward;

        if (!clockwise)
        {
            axis = Vector3.forward;
        }

        for (int i = 0; i < 8; i++)
        {
            faces[0].Nodes[i].Cube.transform.RotateAround(faces[0].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);
        }
        faces[0].Pivot.Cube.transform.RotateAround(faces[0].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        frames += 1;

        if (frames == 9)
        {
            rotateF = false;
            frames = 0;

            UpdateFaces();
        }

        //rotationTimer -= Time.deltaTime;
        //if (rotationTimer < 0.0f)
        //{
        //    rotateF = false;
        //    rotationTimer = speedRotation;

        //    UpdateFaces();
        //}
    }

    void RotateB()
    {
        Vector3 axis = Vector3.forward;

        if (!clockwise)
        {
            axis = -Vector3.forward;
        }

        for (int i = 0; i < 8; i++)
        {
            faces[1].Nodes[i].Cube.transform.RotateAround(faces[1].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        }
        faces[1].Pivot.Cube.transform.RotateAround(faces[1].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        frames += 1;

        if (frames == 9)
        {
            rotateB = false;
            frames = 0;

            UpdateFaces();
        }

        //rotationTimer -= Time.deltaTime;
        //if (rotationTimer < 0.0f)
        //{
        //    rotateB = false;
        //    rotationTimer = speedRotation;

        //    UpdateFaces();
        //}
    }

    void RotateR()
    {
        Vector3 axis = Vector3.right;

        if (!clockwise)
        {
            axis = -Vector3.right;
        }

        for (int i = 0; i < 8; i++)
        {
            faces[2].Nodes[i].Cube.transform.RotateAround(faces[2].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        }
        faces[2].Pivot.Cube.transform.RotateAround(faces[2].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        frames += 1;

        if (frames == 9)
        {
            rotateR = false;
            frames = 0;

            UpdateFaces();
        }

        //rotationTimer -= Time.deltaTime;
        //if (rotationTimer < 0.0f)
        //{
        //    rotateR = false;
        //    rotationTimer = speedRotation;

        //    UpdateFaces();
        //}
    }

    void RotateL()
    {
        Vector3 axis = -Vector3.right;

        if (!clockwise)
        {
            axis = Vector3.right;
        }

        for (int i = 0; i < 8; i++)
        {
            faces[3].Nodes[i].Cube.transform.RotateAround(faces[3].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        }
        faces[3].Pivot.Cube.transform.RotateAround(faces[3].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        frames += 1;

        if (frames == 9)
        {
            rotateL = false;
            frames = 0;

            UpdateFaces();
        }

        //rotationTimer -= Time.deltaTime;
        //if (rotationTimer < 0.0f)
        //{
        //    rotateL = false;
        //    rotationTimer = speedRotation;

        //    UpdateFaces();
        //}
    }

    void RotateU()
    {
        Vector3 axis = Vector3.up;

        if (!clockwise)
        {
            axis = -Vector3.up;
        }

        for (int i = 0; i < 8; i++)
        {
            faces[4].Nodes[i].Cube.transform.RotateAround(faces[4].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        }
        faces[4].Pivot.Cube.transform.RotateAround(faces[4].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        frames += 1;

        if (frames == 9)
        {
            rotateU = false;
            frames = 0;

            UpdateFaces();
        }

        //rotationTimer -= Time.deltaTime;
        //if (rotationTimer < 0.0f)
        //{
        //    rotateU = false;
        //    rotationTimer = speedRotation;

        //    UpdateFaces();
        //}
    }

    void RotateD()
    {
        Vector3 axis = -Vector3.up;

        if (!clockwise)
        {
            axis = Vector3.up;
        }

        for (int i = 0; i < 8; i++)
        {
            faces[5].Nodes[i].Cube.transform.RotateAround(faces[5].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        }
        faces[5].Pivot.Cube.transform.RotateAround(faces[5].Pivot.transform.position, axis, 10.0f/*rotationBySeconds * Time.deltaTime*/);

        frames += 1;

        if (frames == 9)
        {
            rotateD = false;
            frames = 0;

            UpdateFaces();
        }

        //rotationTimer -= Time.deltaTime;
        //if (rotationTimer < 0.0f)
        //{
        //    rotateD = false;
        //    rotationTimer = speedRotation;

        //    UpdateFaces();
        //}
    }

    public void SetRotateF(bool _clockwise)
    {
        clockwise = _clockwise;
        rotateF = true;
    }

    public void SetRotateB(bool _clockwise)
    {
        clockwise = _clockwise;
        rotateB = true;
    }

    public void SetRotateR(bool _clockwise)
    {
        clockwise = _clockwise;
        rotateR = true;
    }

    public void SetRotateL(bool _clockwise)
    {
        clockwise = _clockwise;
        rotateL = true;
    }

    public void SetRotateU(bool _clockwise)
    {
        clockwise = _clockwise;
        rotateU = true;
    }

    public void SetRotateD(bool _clockwise)
    {
        clockwise = _clockwise;
        rotateD = true;
    }

    void UpdateFaces()
    {
        for (int i = 0; i < faces.Count; i++)
        {
            faces[i].UpdatesNodes();
        }
    }
}
