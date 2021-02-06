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

            Teacher arif = new Teacher(mediator); 
            Student orhan = new Student(mediator);
            Student ishak = new Student(mediator);

            orhan.Name = "Orhan";
            ishak.Name = "İshak";

            mediator.Teacher = arif;
            mediator.Students = new List<Student>{ orhan, ishak };

            arif.SendImageUrl("slide1.jpg");
            Console.WriteLine("-----------------");
            ishak.SendQuestion("Is it true ?", ishak);
            Console.WriteLine("-----------------");
            arif.SendAnswer("Yes, this is true", ishak);

            Console.ReadLine();
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
            
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0}, {1}",student.Name,question);
        }

        public void SendAnswer(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}", student.Name,answer);
            Mediator.SendAnswer(answer,student);
        }

        public void SendImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.SendImage(url);
        }
    }

    class Student : CourseMember
    {
        public String Name { get; set; }

        public Student(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveImage(string url)
        {
           Console.WriteLine("{0} received image : {1}",Name,url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer {0}", answer,Name);
        }

        public void SendQuestion(string question, Student student)
        {
            Console.WriteLine("Send question from {0}, {1}",student.Name,question);
            Mediator.SendQuestion(question,student);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void SendImage(string url)
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

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            this.Mediator = mediator;
        }
    }
}
