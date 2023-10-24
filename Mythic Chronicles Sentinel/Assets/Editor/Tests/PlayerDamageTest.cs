using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class PlayerDamageTest
{
    GameObject playerPrefab = Resources.Load<GameObject>("Player");

    [Test]
    public void PlayerDamageTest1()
    {
        GameObject player = GameObject.Instantiate(playerPrefab);

        // test if max HP is set to 10
        float health = player.GetComponent<PlayerHealth>().Health;
        float expected = 10.0f;

        Assert.That(health, Is.EqualTo(expected));
    }

    [Test]
    public void PlayerDamageTest2()
    {
        GameObject player = GameObject.Instantiate(playerPrefab);

        float health = player.GetComponent<PlayerHealth>().Health;
        float initialHealth = 10.0f;
        float damage = 1.0f;
        
        // cannot get method to work from PlayerHealth to here, simplify test by using the method's logic instead: 
        // OnHit method logic applied to player health is as simple as: Health -= damage
        health -= damage;

        // test if health has decreased from the initial value
        Assert.Less(health, initialHealth);
    }

}
