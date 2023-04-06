using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AlterableTests
{
    [Test]
    [TestCase(0)]
    [TestCase(100)]
    [TestCase(-100)]
    public void CreateAlterableWithBasicParameters(int valueToTest)
    {
        // Arrange / Act
        Alterable<int> a = new Alterable<int>(valueToTest);

        // Assert
        Assert.IsNotNull(a);
    }

    [Test]
    public void AddWrongParameterToAlterable()
    {
        // Arrange
        Alterable<int> a = new Alterable<int>(0);

        // Act / Assert
        Assert.Throws<AssertionException>(() => {

            a.AddTransformator(null, 100);

        });
    }

    [Test]
    public void RemoveNothing()
    {
        // Arrange
        Alterable<int> a = new(0);

        // Act
        a.RemoveTransformator(null);

        // Assert

    }

    [Test]
    public void DoubleRemove()
    {
        // Arrange
        Alterable<int> a = new(0);
        var ticket = a.AddTransformator(i => i * 10, 10);

        // Act
        a.RemoveTransformator(ticket);
        a.RemoveTransformator(ticket);

        // Assert

    }


    [Test]
    public void AlterableProcess()
    {
        // Arrange
        Alterable<int> a = new Alterable<int>(10);
        a.AddTransformator(i => i * 10, 10);

        // Act
        var result = a.CalculateValue();

        // Assert
        Assert.That(result, Is.EqualTo(100));
    }

    [Test]
    public void AlterableProcessWithTwoPasses()
    {
        // Arrange
        Alterable<int> a = new Alterable<int>(10);
        a.AddTransformator(i => i + 10, 20);
        a.AddTransformator(i => i * 10, 10);

        // Seed ===>10 =====> 20
        // 10 ===> 100 ===> 110

        // Act
        var result = a.CalculateValue();

        // Assert
        Assert.That(result, Is.EqualTo(110));
    }


    [Test]
    public void AlterableProcessWithThreePassesThenRemoveOneTransformator()
    {
        // Arrange
        Alterable<int> a = new Alterable<int>(10);
        var t1 = a.AddTransformator(i => i + 10, 10);
        var t2 = a.AddTransformator(i => 12, 30);
        var t3 = a.AddTransformator(i => i * 10, 20);

        // 10 ====> +10 =====> *10 =====> 12
        // 12

        Assert.That(a.CalculateValue(), Is.EqualTo(12));

        a.RemoveTransformator(t2);

        // 10 ====> +10 =====> *10 
        // 200

        Assert.That(a.CalculateValue(), Is.EqualTo(200));

    }

}
