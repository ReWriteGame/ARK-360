using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public void loadNextLevelWrapper(float delayTime = 0)
    {
        StartCoroutine(loadNextLevelCor(delayTime));
    }

    public void reStartLevelWrapper(float delayTime = 0)
    {
        StartCoroutine(reStartLevelCor(delayTime));
    }

    public void loadLevelWrapper(int numLevel = 1, float delayTime = 0)
    {
        StartCoroutine(loadLevelCor(numLevel, delayTime));
    }

    private IEnumerator loadNextLevelCor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        int numberLvL = SceneManager.GetActiveScene().buildIndex;// получаем номер уровня
        if (numberLvL < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(++numberLvL);// загрузка след уровня номер можно посмотреть через shift + ctrl + b

        yield break;
    }


    private IEnumerator reStartLevelCor(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        yield break;
    }


    private IEnumerator loadLevelCor(int numLevel, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (numLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(numLevel);

        yield break;
    }
}
