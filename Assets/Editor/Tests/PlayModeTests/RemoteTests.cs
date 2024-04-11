using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Slider = MixedReality.Toolkit.UX.Slider;


/// <summary>
/// This module contains the tests for the Remote object
/// </summary>
namespace Editor.Tests.PlayModeTests
{
    /// <summary>
    /// This class contains tests for the Remote object
    /// </summary>
    public class RemoteTests
    {
        private SliderScript _sliderScript;
        private readonly GameObject _remote = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/UI/Remote.prefab");
        private Slider _verticalSlider;
        private Slider _horizontalSlider;

        /// <summary>
        /// This method sets up the tests by creating a remote object from the prefab and adding a SliderScript to it
        /// </summary>
        [SetUp]
        public void Setup()
        {
            //_remote = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Remote.prefab");
        }

        /// <summary>
        /// This method asserts that all sliders in the remote have a default value of 0
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator TestSliderDefaultValueIs0()
        {
            foreach (var slider in _remote.GetComponentsInChildren<Slider>())
            {
                Assert.IsTrue(slider.Value == 0);
            }
            yield return null;
        }

        /// <summary>
        /// This method asserts that all sliders in the remote have a max value of 1
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator TestSliderMaxValueIs1()
        {
            foreach (var slider in _remote.GetComponentsInChildren<Slider>())
            {
                Assert.IsTrue(Math.Abs(slider.MaxValue - 1f) < 0.01f);
            }
            yield return null;
        }

        /// <summary>
        /// This method asserts that all sliders in the remote have a min value of -1
        /// </summary>
        /// <returns></returns>
        [UnityTest]
        public IEnumerator TestSliderMinValueIsNegative1()
        {
            foreach (var slider in _remote.GetComponentsInChildren<Slider>())
            {
                Assert.IsTrue(Math.Abs(slider.MinValue + 1f) < 0.01f);
            }
            yield return null;
        }
    }
}