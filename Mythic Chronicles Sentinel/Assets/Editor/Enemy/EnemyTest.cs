using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//Naiyao

public class EnemyTest : MonoBehaviour
{
    GameObject enemyPrafab;

    [Test]
    public void EnemyTest1()
    {
         enemyPrafab = Resources.Load<GameObject>("Skeleton");
         Assert.IsNotNull(enemyPrafab);
    }

    [Test]
    public void EnemyTest2()
    {
        enemyPrafab = Resources.Load<GameObject>("Slime");
        Assert.IsNotNull(enemyPrafab);
    }
}
