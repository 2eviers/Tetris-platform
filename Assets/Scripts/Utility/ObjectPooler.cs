using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CarLabSimulation.Core
{
    /// <summary>
    /// Object Pooler pattern
    /// </summary>
    public class ObjectPooler : MonoBehaviour
    {
        #region SerializeFields

        /// <summary>Prefab to pool</summary>
        [SerializeField]
        private GameObject _prefab;

        /// <summary>Number of object to instantiate</summary>
        [SerializeField]
        private int _bufferSize;

        #endregion SerializeFields

        #region Fields

        /// <summary>Name of the objectPooler</summary>
        private string _name;

        /// <summary>buffer where are stored the instances of the prefab</summary>
        private List<GameObject> _buffer = new List<GameObject> { };

        #endregion Fields

        #region Properties

        /// <summary>Static dictionary to find the objectPooler by name</summary>
        static public Dictionary<string, ObjectPooler> ObjectPoolers = new Dictionary<string, ObjectPooler>();

        #endregion Properties

        #region Unity Callbacks

        /// <summary>
        /// Instantiates and fills the buffer with instances of the prefab.
        /// </summary>
        private void Awake()
        {
            _name = _prefab.name;
            if (ObjectPoolers.ContainsKey(_name))
            {
                Debug.LogError("ObjectPooler already exist");
                Destroy(this);
            }
            else
                ObjectPoolers.Add(_name, this);

            GameObject dynamicObjects;
            if (!(dynamicObjects = GameObject.Find("DynamicObjects")))
            {
                dynamicObjects = new GameObject();
                dynamicObjects.name = "DynamicObjects";
            }

            for (int i = 0; i < _bufferSize; i++)
            {
                GameObject objectInstance = Instantiate(_prefab);
                objectInstance.SetActive(false);
                objectInstance.name = _name;
                objectInstance.transform.SetParent(dynamicObjects.transform);
                _buffer.Add(objectInstance);
            }
        }

        /// <summary>
        /// Remove the object pooler from the dictionary when destroy
        /// </summary>
        private void OnDestroy()
        {
            ObjectPoolers.Remove(_name);
        }

        #endregion Unity Callbacks

        #region Public Methods

        /// <summary>
        /// If the buffer isn't empty, it returns an instance from the buffer, else it instantiates a GameObject from the prefab
        /// </summary>
        /// <returns>An instance of the prefab from the buffer</returns>
        public GameObject GetPooledObject()
        {
            GameObject objectInstance;
            if (_buffer.Count != 0)
            {
                objectInstance = _buffer.First();
                _buffer.Remove(objectInstance);
            }
            else
            {
                objectInstance = Instantiate(_prefab);
                objectInstance.name = _name;
            }
            objectInstance.SetActive(true);
            return objectInstance;
        }

        /// <summary>
        /// Send back the instance to the buffer.
        /// </summary>
        /// <param name="objectInstance"></param>
        public void Recycle(GameObject objectInstance)
        {
            if (objectInstance.name == _name)
            {
                objectInstance.SetActive(false);
                _buffer.Add(objectInstance);
            }
            else
                Debug.LogError("Object Pooler : " + _name + ", Wrong object");
        }

        #endregion Public Methods
    }
}