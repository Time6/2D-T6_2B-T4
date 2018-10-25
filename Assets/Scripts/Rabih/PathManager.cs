using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathManager : MonoBehaviour {


    public ContactFilter2D playerMask;


    public GameObject[] koalaPunkPath;
    public BoxCollider2D koalaPunkRoom;
    public bool koalaPunkStarted;

    public GameObject ratoEscamoso;

	// Update is called once per frame

    void FixedUpdate()
    {
        KoalaCheck();
        KoalaPunk();

        PathCleaner();

    }
    #region Checking NPC's
    void KoalaCheck()
    {
        if (Singleton.GetInstance.playerScript.talking == true)
        {
            if (koalaPunkRoom.IsTouching(playerMask))
            {
                if (!koalaPunkStarted)
                {
                    koalaPunkStarted = true;
                }

            }
        }
    }
    #endregion Checking NPC's

    #region NPC's Path
    void KoalaPunk()
    {
        //Vendo qual "Quest" ele está resolvendo
        if (koalaPunkStarted)
        {

            //vendo se ele passou pelo caminho certo
            if (koalaPunkPath[0] == Singleton.GetInstance.playerScript.roomsPassedTrough[0])
            {
                if (koalaPunkPath[1] == Singleton.GetInstance.playerScript.roomsPassedTrough[1])
                {
                    if (koalaPunkPath[2] == Singleton.GetInstance.playerScript.roomsPassedTrough[2])
                    {
                        if (koalaPunkPath[3] == Singleton.GetInstance.playerScript.roomsPassedTrough[3])

                        {
                            //agora tendo passado , aparecerá o NPC seguinte

                            ratoEscamoso.SetActive(true);




                        }
                    }
                }
            }

        }
    }
    #endregion NPC's Path

    void PathCleaner()
    {
        if (Singleton.GetInstance.playerScript.roomsPassedTrough[3] != null)
        {
            Singleton.GetInstance.playerScript.roomsPassedTrough[0] = null;
            Singleton.GetInstance.playerScript.roomsPassedTrough[1] = null;
            Singleton.GetInstance.playerScript.roomsPassedTrough[2] = null;
            Singleton.GetInstance.playerScript.roomsPassedTrough[3] = null;
            Singleton.GetInstance.playerScript.actualRoom = 0;

            koalaPunkStarted = false;
        }


    }
}
