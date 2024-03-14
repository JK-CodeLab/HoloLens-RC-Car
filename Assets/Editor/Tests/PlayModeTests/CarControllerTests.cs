// using System;
// using System.Collections;
// using NUnit.Framework;
// using UnityEditor;
// using UnityEngine;
// using UnityEngine.TestTools;
// using UnityEngine.UI;
// using Object = UnityEngine.Object;
// using Slider = MixedReality.Toolkit.UX.Slider;
//
// /// <summary>
// /// This module contains the tests for the CarController class
// /// </summary>
// namespace Editor.Tests.PlayModeTests
// {
//     /// <summary>
//     /// This class contains tests for the CarController class
//     /// </summary>
//     public class CarControllerTests
//     {
//         private GameObject _object;
//         private CarController _carController;
//         private GameObject _remote = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Remote.prefab");
//
//         /// <summary>
//         /// This method sets up the tests by creating a car object and adding a CarController to it
//         /// </summary>
//         [SetUp]
//         public void Setup()
//         {
//             _object = GameObject.CreatePrimitive(PrimitiveType.Cube);
//             _carController = _object.AddComponent<CarController>();
//             _carController.carRigidBody = _object;
//             if (_carController != null)
//             {
//                 _carController.VerticalSlider = _remote.GetComponentsInChildren<Slider>()[0];
//                 _carController.HorizontalSlider = _remote.GetComponentsInChildren<Slider>()[1];
//                 _carController.Start();
//             }
//         }
//         
//         /// <summary>
//         /// This method resets the sliders to their default values
//         /// </summary>
//         [TearDown]
//         public void TearDown()
//         {
//             foreach (var slider in _remote.GetComponentsInChildren<Slider>())
//             {
//                 slider.Value = 0;
//             }
//         }
//         
//         /// <summary>
//         /// This method tests the cars forward movement and asserts that the car has moved forward when the slider is set to 1
//         /// </summary>
//         /// <returns></returns>
//         [UnityTest]
//         public IEnumerator TestCarMovementForward()
//         {
//             _carController.VerticalSlider.Value = 1;
//             yield return new WaitForSeconds(1);
//             Assert.IsTrue(_object.transform.position.z > 0);
//         }
//         
//         /// <summary>
//         /// This method tests the cars backward movement and asserts that the car has moved backward when the slider is set to -0.5
//         /// </summary>
//         /// <returns></returns>
//         [UnityTest]
//         public IEnumerator TestCarMovementBackward()
//         {
//             _carController.VerticalSlider.Value = -0.5f;
//             yield return new WaitForSeconds(1);
//             Assert.IsTrue(_object.transform.position.z < 0);
//             
//         }
//         
//         /// <summary>
//         /// This method tests the cars right rotation and asserts that the car has rotated right when the slider is set to 1
//         /// </summary>
//         /// <returns></returns>
//         [UnityTest]
//         public IEnumerator TestCarRotationRight()
//         {
//             _carController.HorizontalSlider.Value = 1;
//             yield return new WaitForSeconds(1);
//             Assert.IsTrue(_object.transform.rotation.y > 0);
//         }
//         
//         /// <summary>
//         /// This method tests the cars left rotation and asserts that the car has rotated left when the slider is set to -0.5
//         /// </summary>
//         /// <returns></returns>
//         [UnityTest]
//         public IEnumerator TestCarRotationLeft()
//         {
//             _carController.HorizontalSlider.Value = -0.5f;
//             yield return new WaitForSeconds(1);
//             Assert.IsTrue(_object.transform.rotation.y < 0);
//         }
//         
//         /// <summary>
//         /// This method tests the cars gravity and asserts that the car is constantly falling.
//         /// </summary>
//         /// <returns></returns>
//         [UnityTest]
//         public IEnumerator TestCarGravity()
//         {
//             yield return new WaitForSeconds(1);
//             Assert.IsTrue(_object.transform.position.y < 0);
//         }
//     }
// }