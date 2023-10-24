using NUnit.Framework;
using UnityEngine;

// Andre

public class MusicTestScript
{
    AudioClip audioClip;
    
    [Test]
    public void TestMusicTrack1()
    {
        audioClip = Resources.Load<AudioClip>("Fiery_Greatsword");
        Assert.IsNotNull(audioClip);
    }

    [Test]
    public void TestMusicTrack2()
    {
        audioClip = Resources.Load<AudioClip>("Suspicious_tool_shop");
        Assert.IsNotNull(audioClip);        
    }

    [Test]
    public void TestMusicTrack3()
    {
        audioClip = Resources.Load<AudioClip>("Aged_Forest");
        Assert.IsNotNull(audioClip);
    }

    [Test]
    public void TestMusicTrack4()
    {
        audioClip = Resources.Load<AudioClip>("Feel_the_wind");
        Assert.IsNotNull(audioClip);
    }
}
