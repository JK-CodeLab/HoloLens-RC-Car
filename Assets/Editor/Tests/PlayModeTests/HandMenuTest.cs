using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using MixedReality.Toolkit.UX;

namespace Editor.Tests.PlayModeTests
{
    public class HandMenuTest
    {
        private readonly GameObject _handMenu = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/UI/HandMenu.prefab");
        private GameObject _carGameObject;

        [SetUp]
        public void Setup()
        {
            _handMenu.AddComponent<DialogPool>();
            _handMenu.AddComponent<HandMenuScript>();
            GameObject carGameObject = new GameObject("RaceCar_Blue");
            carGameObject.AddComponent<Rigidbody>();
            _carGameObject = carGameObject;
        }

        [UnityTest]
        public IEnumerator TestHandMenuHasDialogPool()
        {
            var dialogPool = _handMenu.GetComponent<DialogPool>();
            Assert.IsNotNull(dialogPool);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHandMenuHasCarGameObject()
        {
            var carGameObject = _handMenu.transform.Find("RaceCar_Blue").gameObject;
            Assert.IsNotNull(carGameObject);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHandMenuHasCarRigidBody()
        {
            var carRigidBody = _handMenu.transform.Find("RaceCar_Blue").gameObject.GetComponent<Rigidbody>();
            Assert.IsNotNull(carRigidBody);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHandMenuHasCarGameObjectInactive()
        {
            var carGameObject = _handMenu.transform.Find("RaceCar_Blue").gameObject;
            Assert.IsFalse(carGameObject.activeSelf);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHandMenuResetCar()
        {
            var handMenuScript = _handMenu.GetComponent<HandMenuScript>();
            handMenuScript.ResetCar();
            Assert.IsTrue(_carGameObject.activeSelf);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHandMenuCreateExitDialog()
        {
            var handMenuScript = _handMenu.GetComponent<HandMenuScript>();
            handMenuScript.CreateExitDialog();
            var dialogPool = _handMenu.GetComponent<DialogPool>();
            Assert.IsNotNull(dialogPool);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestHandMenuCreateRemapRoomDialog()
        {
            var handMenuScript = _handMenu.GetComponent<HandMenuScript>();
            handMenuScript.CreateRemapRoomDialog();
            var dialogPool = _handMenu.GetComponent<DialogPool>();
            Assert.IsNotNull(dialogPool);
            yield return null;
        }
    }

}

