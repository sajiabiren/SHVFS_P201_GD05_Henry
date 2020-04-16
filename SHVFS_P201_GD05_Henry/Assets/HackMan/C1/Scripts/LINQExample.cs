using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace HackManC1
{
    public class LINQExample : MonoBehaviour
    {
        void Start()
        {
            var Chris = new Student() {Name = "Chris", Age = 22, IQ = 218, Courses = new List<string>() {"Pro-Gamer"}};

            
            var students = new List<Student>
            {
                new Student() {Name = "Chris", Age = 22, IQ = 218, Courses = new List<string>() {"Pro-Gamer"}},
                new Student() {Name = "Shawn", Age = 21, IQ = 2, Courses = new List<string>() {"Pro-Gamer, Elaine-Holder"},},
                new Student() {Name = "Elaine", Age = 12, IQ = 2000, Courses = new List<string>() {"Chris-Holder"},},
                new Student() {Name = "Rina", Age = 12, IQ = 80, Courses = new List<string>() {"Chris-Holder"},},
                new Student() {Name = "Henry", Age = 12, IQ = 50, Courses = new List<string>() {"Chris-Holder"},},
                Chris,
            };
            
            var students2 = new List<Student>
            {
                new Student() {Name = "Chris2", Age = 22, IQ = 218, Courses = new List<string>() {"Pro-Gamer"}},
                new Student() {Name = "Shawn2", Age = 21, IQ = 2, Courses = new List<string>() {"Pro-Gamer, Elaine-Holder"},},
                new Student() {Name = "Elaine2", Age = 12, IQ = 2000, Courses = new List<string>() {"Chris-Holder"},},
            };

            var enemies = new List<Enemy>()
            {
                new Enemy(){Name = "E1", HP = 100},
                new Enemy(){Name = "E2", HP = 0},
                new Enemy(){Name = "E3", HP = 10},
                new Enemy(){Name = "E4", HP = 1},
            };

            //var smartStudents = new List<Student>();
            //
            //foreach (var student in students)
            //{
            //   if (student.IQ > 100)
            //    {
            //        smartStudents.Add(student.Name);
            //    }
            //}

            // => lambda
            var smartStudentsSmartestFirst = students.Where(s => s.IQ > 100).OrderByDescending(s => s.IQ);
            var studentNames = students.Select(s => s.Name);
            var studentCourses = students.Select(s => s.Courses).ToList();
            var studentCoursesMany = students.SelectMany(s => s.Courses).ToList();
            var areOurstudentsSmart = students.All(s => s.IQ > 100);
            var areWeHaveChris = students.Contains(Chris);
            // var averageIQ = students.Average(s => s.IQ);
            var allStudents = students.Concat(students2);
            var distinctStudents = students.Distinct();
            var skipTheFirstTwo = students.Skip(2); // Take(2)
            var startWhenWeGetADummy = students.OrderByDescending(s => s.IQ).SkipWhile(s => s.IQ > 100);
            var takeWhenWeGetADummy = students.OrderByDescending(s => s.IQ).TakeWhile(s => s.IQ > 100);
            
            // foreach (var smartStudent in smartStudentsSmartestFirst)
            // {
            //     Debug.Log(smartStudent.Name);
            // }
            //
            // foreach (var studentName in studentNames)
            // {
            //     Debug.Log(studentName);
            // }
            //
            // foreach (var studentCourseLists in studentCourses)
            // {
            //     foreach (var studentCourseList in studentCourseLists)
            //     {
            //         Debug.Log(studentCourseList);
            //     }
            // }
            //
            // foreach (var studentCourseList in studentCoursesMany)
            // {
            //     Debug.Log(studentCourseList);
            // }
            //
            // Debug.Log(areOurstudentsSmart);
            //
            // Debug.Log(areWeHaveChris);
            //
            // foreach (var studentsName in allStudents)
            // {
            //     Debug.Log(studentsName.Name);
            // }

            // foreach (var destinctStudent in distinctStudents)
            // {
            //     Debug.Log(destinctStudent.Name);
            // }

            foreach (var student in students)
            {
                Debug.Log(student.Name);
            }
            
            foreach (var student in startWhenWeGetADummy)
            {
                Debug.Log(student.Name);
            }
            
            foreach (var student in takeWhenWeGetADummy)
            {
                Debug.Log(student.Name);
            }
        }
    }

    public struct Student
    {
        public string Name;
        public int Age;
        public int IQ;
        public List<string> Courses;
    }

    public class Enemy
    {
        public string Name;
        public int HP;
    }
}