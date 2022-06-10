using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour
{
    [SerializeField] RubiksCube rubiksCube;

    int nbMixMoves = 40;
    bool mixing = false;
    bool resolving = false;

    int[] mixOrder = new int[40];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mixing)
        {
            Time.timeScale = 3;
            Mix();
        }
        else if (resolving)
        {
            Time.timeScale = 3;
            Resolve();
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    float mixTimer = 0.0f;
    int nbMix = 0;
    void Mix()
    {
        if (nbMix < nbMixMoves)
        {
            mixTimer += Time.deltaTime;

            if (mixTimer > 0.5f)
            {
                int moveIndex = Random.Range(0, 13);
                mixOrder[nbMix] = moveIndex;

                switch (moveIndex)
                {
                    case 1:
                        rubiksCube.SetRotateF(true);
                        break;
                    case 2:
                        rubiksCube.SetRotateF(false);
                        break;
                    case 3:
                        rubiksCube.SetRotateB(true);
                        break;
                    case 4:
                        rubiksCube.SetRotateB(false);
                        break;
                    case 5:
                        rubiksCube.SetRotateR(true);
                        break;
                    case 6:
                        rubiksCube.SetRotateR(false);
                        break;
                    case 7:
                        rubiksCube.SetRotateL(true);
                        break;
                    case 8:
                        rubiksCube.SetRotateL(false);
                        break;
                    case 9:
                        rubiksCube.SetRotateU(true);
                        break;
                    case 10:
                        rubiksCube.SetRotateU(false);
                        break;
                    case 11:
                        rubiksCube.SetRotateD(true);
                        break;
                    case 12:
                        rubiksCube.SetRotateD(false);
                        break;
                }

                nbMix++;
                mixTimer = 0.0f;
            }
        }
        else
        {
            mixing = false;
            Debug.Log("Mix end");
        }
    }

    void Resolve()
    {
        if (nbMix > 0)
        {
            mixTimer += Time.deltaTime;

            if (mixTimer > 0.5f)
            {
                switch (mixOrder[nbMix - 1])
                {
                    case 1:
                        rubiksCube.SetRotateF(false);
                        break;
                    case 2:
                        rubiksCube.SetRotateF(true);
                        break;
                    case 3:
                        rubiksCube.SetRotateB(false);
                        break;
                    case 4:
                        rubiksCube.SetRotateB(true);
                        break;
                    case 5:
                        rubiksCube.SetRotateR(false);
                        break;
                    case 6:
                        rubiksCube.SetRotateR(true);
                        break;
                    case 7:
                        rubiksCube.SetRotateL(false);
                        break;
                    case 8:
                        rubiksCube.SetRotateL(true);
                        break;
                    case 9:
                        rubiksCube.SetRotateU(false);
                        break;
                    case 10:
                        rubiksCube.SetRotateU(true);
                        break;
                    case 11:
                        rubiksCube.SetRotateD(false);
                        break;
                    case 12:
                        rubiksCube.SetRotateD(true);
                        break;
                }

                nbMix--;
                mixTimer = 0.0f;
            }
        }
        else
        {
            resolving = false;
            Debug.Log("Solve end");
        }
    }

    public void StartMix()
    {
        mixing = true;
    }

    public void StartSolve()
    {
        resolving = true;
    }
}
