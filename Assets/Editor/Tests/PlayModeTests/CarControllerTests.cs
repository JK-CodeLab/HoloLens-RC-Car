//using System;
//using System.Collections;
//using NUnit.Framework;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.TestTools;
//using UnityEngine.UI;
//using Object = UnityEngine.Object;
//using Slider = MixedReality.Toolkit.UX.Slider;

///// <summary>
///// This module contains the tests for the CarController class
///// </summary>
//namespace Editor.Tests.PlayModeTests
//{
//    /// <summary>
//    /// This class contains tests for the CarController class
//    /// </summary>
//    public class CarControllerTests
//    {
//        private GameObject _object;
//        private CarController _carController;
//        //private GameObject _remote = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/UI/Remote.prefab");
//        private GameObject _remote;

//        /// <summary>
//        /// This method sets up the tests by creating a car object and adding a CarController to it
//        /// </summary>
//        public IEnumerator ssssss()
//        {
//            _remote = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/UI/Remote.prefab");
//            //_object = GameObject.CreatePrimitive(PrimitiveType.Cube);
//            //var vSlider = _remote.GetComponentsInChildren<Slider>()[0];
//            //var hSlider = _remote.GetComponentsInChildren<Slider>()[1];

//            //// Create VerticalSlider
//            //var verticalSliderGO = new GameObject("VerticalSlider");
//            //var verticalSlider = verticalSliderGO.AddComponent<Slider>();

//            //// Create HorizontalSlider
//            //var horizontalSliderGO = new GameObject("HorizontalSlider");
//            //var horizontalSlider = horizontalSliderGO.AddComponent<Slider>();


//            _object = GameObject.CreatePrimitive(PrimitiveType.Cube);
//            //var verticalSliderGO = new GameObject("VerticalSlider");
//            var verticalSliderGO = _remote.GetComponentsInChildren<Slider>()[0].gameObject;
//            //var horizontalSliderGO = new GameObject("HorizontalSlider");
//            var horizontalSliderGO = _remote.GetComponentsInChildren<Slider>()[1].gameObject;
//            //verticalSliderGO.AddComponent<Slider>();
//            //horizontalSliderGO.AddComponent<Slider>();



//            //_object.AddComponent<Slider>();
//            //_object.AddComponent<Slider>();
//            //_object.GetComponentsInChildren<Slider>()[0].name = "VerticalSlider";
//            //_object.GetComponentsInChildren<Slider>()[1].name = "HorizontalSlider";

//            _object.AddComponent<Rigidbody>();
//            _carController = _object.AddComponent<CarController>();
//            _carController.VerticalSlider = verticalSliderGO.GetComponent<Slider>();
//            _carController.HorizontalSlider = horizontalSliderGO.GetComponent<Slider>();

//            var visual = new GameObject("Visual");
//            visual.transform.parent = _object.transform;

//            var wheels = new GameObject("Wheels");
//            wheels.transform.parent = visual.transform;

//            var wheelColliders = new GameObject("WheelColliders");
//            wheelColliders.transform.parent = wheels.transform;

//            var wheelTransforms = new GameObject("WheelMeshes");
//            wheelTransforms.transform.parent = wheels.transform;

//            var names = new string[] { "FrontLeft", "FrontRight", "RearLeft", "RearRight" };
//            foreach (var name in names)
//            {
//                var wheelCollider = new GameObject(name + "WheelCollider");
//                wheelCollider.transform.parent = wheelColliders.transform;
//                wheelCollider.AddComponent<WheelCollider>();

//                var wheelMesh = new GameObject(name + "WheelMesh");
//                wheelMesh.transform.parent = wheelTransforms.transform;
//            }

//            _carController.frontLeftWheelCollider = wheelColliders.transform.Find("FrontLeftWheelCollider").GetComponent<WheelCollider>();
//            _carController.frontRightWheelCollider = wheelColliders.transform.Find("FrontRightWheelCollider").GetComponent<WheelCollider>();
//            _carController.rearLeftWheelCollider = wheelColliders.transform.Find("RearLeftWheelCollider").GetComponent<WheelCollider>();
//            _carController.rearRightWheelCollider = wheelColliders.transform.Find("RearRightWheelCollider").GetComponent<WheelCollider>();

//            _carController.frontLeftWheelTransform = wheelTransforms.transform.Find("FrontLeftWheelMesh");
//            _carController.frontRightWheelTransform = wheelTransforms.transform.Find("FrontRightWheelMesh");
//            _carController.rearLeftWheelTransform = wheelTransforms.transform.Find("RearLeftWheelMesh");
//            _carController.rearRightWheelTransform = wheelTransforms.transform.Find("RearRightWheelMesh");

//            yield return new WaitForSeconds(4);
//        }

//        /// <summary>
//        /// This method resets the sliders to their default values
//        /// </summary>
//        [TearDown]
//        public void TearDown()
//        {
//            GameObject.DestroyImmediate(_object);
//        }

//        /// <summary>
//        /// This method tests the cars forward movement and asserts that the car has moved forward when the slider is set to 1
//        /// </summary>
//        /// <returns></returns>
//        [UnityTest]
//        public IEnumerator TestCarMovementForward()
//        {
//            ssssss();
//            Debug.Log(_object);

//            _carController.VerticalSlider.Value = 1;
//            yield return new WaitForSeconds(1);
//            Assert.IsTrue(_object.transform.position.z > 0);
//        }

//        /// <summary>
//        /// This method tests the cars backward movement and asserts that the car has moved backward when the slider is set to -0.5
//        /// </summary>
//        /// <returns></returns>
//        [UnityTest]
//        public IEnumerator TestCarMovementBackward()
//        {
//            ssssss();
//            Debug.Log(_object);
//            _object.GetComponent<Rigidbody>().useGravity = false;
//            _carController.VerticalSlider.Value = -0.5f;
//            yield return new WaitForSeconds(1);
//            Assert.IsTrue(_object.transform.position.z < 0);

//        }

//        /// <summary>
//        /// This method tests the cars right rotation and asserts that the car has rotated right when the slider is set to 1
//        /// </summary>
//        /// <returns></returns>
//        [UnityTest]
//        public IEnumerator TestCarRotationRight()
//        {
//            ssssss();
//            Debug.Log(_object);
//            _carController.HorizontalSlider.Value = 1;
//            yield return new WaitForSeconds(1);
//            Assert.IsTrue(_object.transform.rotation.y > 0);
//        }

//        /// <summary>
//        /// This method tests the cars left rotation and asserts that the car has rotated left when the slider is set to -0.5
//        /// </summary>
//        /// <returns></returns>
//        [UnityTest]
//        public IEnumerator TestCarRotationLeft()
//        {
//            ssssss();
//            Debug.Log(_object);
//            _carController.HorizontalSlider.Value = -0.5f;
//            yield return new WaitForSeconds(1);
//            Assert.IsTrue(_object.transform.rotation.y < 0);
//        }

//        /// <summary>
//        /// This method tests the cars gravity and asserts that the car is constantly falling.
//        /// </summary>
//        /// <returns></returns>
//        [UnityTest]
//        public IEnumerator TestCarZGravity()
//        {
//            yield return new WaitForSeconds(1);
//            Assert.IsTrue(_object.transform.position.y < 0);
//            _object.GetComponent<Rigidbody>().useGravity = false;
//        }
//    }
//}