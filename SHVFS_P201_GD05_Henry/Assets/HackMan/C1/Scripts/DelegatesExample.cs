using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace HackManC1
{
    public class DelegatesExample: MonoBehaviour
    {
        private delegate void MeDelegate();
        private delegate bool MeDelegatInt(int n);
        // Delegate is a ref of a object and method
        private Action myAction;

        private void Awake()
        {
            MeDelegate meDelegate0 = Foo;
            meDelegate0 += Goo;
            meDelegate0 += Foo;
            meDelegate0 += Foo;
            meDelegate0 -= Foo;
            // meDelegate = (MeDelegate)Delegate.Combine(meDelegate, (MeDelegate)Goo);
            // meDelegate = (MeDelegate)Foo + Goo
            foreach (var del in meDelegate0.GetInvocationList())
            {
                Debug.Log($"Target:{del.Target}, method:{del.Method}");
            }
            
            Action<string> myAction = new Action<string>(MyActionMethod);
            Func<int, bool> myFunc = new Func<int, bool>(MyFuncMethod);
            myAction("Ahahaha");
            Debug.Log(myFunc(4));
        }

        private void Start()
        {
            MeDelegate meDelegate = new MeDelegate(Goo);
            MeDelegate meDelegate1 = Goo;
            meDelegate();
            meDelegate1();
            // meDelegate.Invoke();
            
            Debug.Log($"Target: {meDelegate.Target}, Mehthod: {meDelegate.Method.ToString()}");


            
            var numbers = new List<int>() {1, 2, 11, 55, 4};
            var result = GetAllTheNumbersLessThanCheck(10, numbers);
            var result1 = GetAllTheNumbersLessThanFive(numbers);
            var result2 = GetAllTheNumbersGeaterThanThirty(numbers);
            foreach (var i in result)
            {
                Debug.Log(i);
            }
            foreach (var i in result1)
            {
                Debug.Log(i);
            }
            foreach (var i in result2)
            {
                Debug.Log(i);
            }
            
            var result3 = RunNumbersThroughTheGauntlet(numbers, LessThanFive);
            // var result4 = RunNumbersThroughTheGauntlet(numbers, bool LessThanTen (int n){ return n < 10; });
            var result4 = RunNumbersThroughTheGauntlet(numbers, n => n < 5);
            result3.ForEach(n => Debug.Log(n));
            result4.ForEach(n => Debug.Log($"result4: {n}"));
        }

        static bool LessThanFive(int n) { return n < 5; }
        static bool LessThanCheck(int n) { return n < 10; }
        static bool GreaterThanThirty(int n) { return n > 30; }

        private List<int> RunNumbersThroughTheGauntlet(List<int> numbers, MeDelegatInt gauntlet)
        {
            return numbers.Where(n => gauntlet(n)).ToList();

            var tempNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (gauntlet(number)) 
                    // if(number < 5)
                    // if(LesssThanFive(number)
                {
                    tempNumbers.Add(number);
                }
            }
        }

        private IEnumerable<int> GetAllTheNumbersLessThanCheck(int checkedNumber, List<int> numbers)
        {
            return numbers.Where(n => n < checkedNumber).ToList();
        }
        
        private IEnumerable<int> GetAllTheNumbersLessThanFive(List<int> numbers)
        {
            return numbers.Where(n => n < 5).ToList();
        }
        
        private IEnumerable<int> GetAllTheNumbersGeaterThanThirty(List<int> numbers)
        {
            return numbers.Where(n => n > 30).ToList();
        }

        private void Goo()
        {
            Debug.Log(111111);
        }

        private static void Foo()
        {
            
        }

        private void MyActionMethod(string myString)
        {
            Debug.Log(myString);
        }

        private bool MyFuncMethod(int number)
        {
            bool isItLessThanFive = false;
            
            if (number < 5)
            {
                isItLessThanFive = true;
            }

            return isItLessThanFive;
        }
    }
}