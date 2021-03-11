using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "Sefa";
            mediator.Teacher = teacher;
            Student sefa = new Student(mediator);
            sefa.Name = "Sefa";
            mediator.Students.Add(sefa);

            Student irem = new Student(mediator);
            irem.Name = "irem";
            mediator.Students.Add(irem);

            mediator.Students = new List<Student> { irem };



            sefa.SendNewImageUrl("slide1.jpg");
            Console.ReadLine();
        }

    }

    abstract class CourseMember
    {

        private Mediator Mediator;
        protected  CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }

    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from{0},{1}", student.Name, question);
        }
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
        }


    }
    class Student : CourseMember
    {
        public Student (Mediator mediator): base(mediator)
        {

        }
        public string  Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("Student received image : {0}", url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("Student recevied answer {0}", answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student>  Students{ get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}
