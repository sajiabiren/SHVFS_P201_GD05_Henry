using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HackManC1
{
    public class GenericExample : MonoBehaviour
    {
        private void Start()
        {
            var pairOfNumbers = new Pair<int, string>() {First = 13, Second = "Ash"};
            Debug.Log($"First: { pairOfNumbers.First }, Secound: {pairOfNumbers.Second}");

            var listOfNumbers = new List<int>() {1, 2, 3, 4};
            var listOfNames = new List<string>() {"Chris", "Henry", "Rina", "Shawn"};
            PrintTheItems(listOfNames);
            PrintTheItems(listOfNumbers);

            var newClass = Produce<Single>();
            newClass.Foo();
        }

        private void PrintTheItems<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Debug.Log(item);
            }
        }

        private T Produce<T>() where T : Single, new()
        {
            T returnValue = new T();
            // returnValue = Foo();
            return returnValue;
        }
    }

    public class Pair<T, U>
    {
        public T First;
        public U Second;
        
        public void Foo()
        {
            Debug.Log("fofofoffo");
        }
    }
    
    public class Single
    {
        public void Foo()
        {
            Debug.Log("fofofoffo");
        }
    }
}

