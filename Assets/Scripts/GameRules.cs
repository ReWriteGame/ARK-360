using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    [SerializeField] private LifeBar lifeBar;
    [SerializeField] private GameObject blocks;
    [SerializeField] private LevelController levelController;
   

    // Update is called once per frame
    void Update()
    {
        if (lifeBar.NumberOfLife == 0)
            levelController.reStartLevelWrapper();
        
        if (blocks.transform.childCount == 0)// если блоков не осталось
            levelController.loadNextLevelWrapper();
    }
}
