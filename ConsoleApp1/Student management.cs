using System;
using System.Runtime.InteropServices;


namespace StudentManagement
{
   
         enum state
        { 
        None,
        CheckStudent,
        AddStudent,
        DeleteStudent,
        FindStudent,
        ChangeStudent,
        Exit
        };


    class Interaction
    {
      
            public static bool ContinueOrNot()
        {
            Console.WriteLine("\nPress 1 to Continue\nPress others to goback");
            if(Console.ReadLine()=="1")
            { return true; }
            else
            { return false; }

        } 
        public static void Wait()
        {
            Console.WriteLine("按回车键继续...");
            Console.ReadLine();
        }

    }
    class Student
    {
        public string name;
        public int score;
        public bool occupied;
        public Student()
        {
            name = "Sorry,we can't find the student you are searching for";
            score = 0;
            occupied = false;

        }
        public Student(string n,int s)
        {
            name = n;
            score = s;
            occupied = true;
        }
    
    }

static class StudentList
    {
        public static state states = state.CheckStudent;
        public static StudentNode head = new StudentNode();
        public static int ShowMenu()
        {
            Console.WriteLine("Hello!Welcome to our student management system!\nPress 1 to check students\nPress 2 to add student\nPress 3 to delete student" +
                "\nPress 4 to find student\nPress 5 to changeStudent\nPress 6 to exit");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static void CheckStudents()
        {
            int num = 1;
            StudentNode temp = head;
            if(temp.nextOne == null)
            {
                Console.WriteLine("You have no student yet,continue by adding new students");
                return;
            }
            while(temp.nextOne != null)
            {
                Console.WriteLine(num+".");
                PrintStudent(temp.nextOne);
                temp = temp.nextOne;
                num++;
            }
        }
        public static StudentNode FindStudent(string name)
        {
     
                StudentNode temp = head;
                while(temp.nextOne != null)
                {
                    if(temp.nextOne.thisOne.name==name)
                    {
                        return temp.nextOne;
                    }
                    temp = temp.nextOne;
                }
                return null; 
        }
        public static void PrintStudent(StudentNode n)
        {
            Console.WriteLine("Name:"+n.thisOne.name+"\nScore:"+n.thisOne.score+"\n\n");
        }
        public static void AddStudent(string name,int score)
        {
  
            
                StudentNode temp = head;
                while (temp.nextOne != null)
                {
                    temp = temp.nextOne;
                }
                temp.nextOne = new StudentNode(name, score);

                
        }
        public static void InsertStudent(string name ,int score,string targetName )
        {
 
          
                StudentNode temp = head;
                while (temp.nextOne != null)
                {
                    if(temp.nextOne.thisOne.name==targetName)
                    {
                        StudentNode temp1 = temp.nextOne.nextOne;
                        temp.nextOne.nextOne = new StudentNode(name, score);
                        temp.nextOne.nextOne.nextOne = temp1;
                        break;
                    }
                    temp=temp.nextOne;
                }

        }
        public static void DeleteStudent(string targetName)
        {

          
            
                StudentNode temp = head;
                while (temp.nextOne != null)
                {
                    if (temp.nextOne.thisOne.name == targetName)
                    {
                        temp.nextOne = temp.nextOne.nextOne;
                    break;
                    }
                    temp = temp.nextOne;
                }
           
        }
        public static void ChangeStudent(string targetName)
        {
            string tempName;
            int tempScore;
            StudentNode tempStudent = FindStudent(targetName);
            if (tempStudent == null)
            {
                Console.WriteLine($"Didn't find the student:{targetName}");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Please enter the changed name:");
            tempName = Console.ReadLine();
            Console.WriteLine("Please enter the changed score:");
            tempScore = Convert.ToInt32(Console.ReadLine());
            tempStudent.thisOne.name = tempName;
            tempStudent.thisOne.score = tempScore;
            Console.WriteLine("Done!\n\n");
            Console.ReadLine();
        }

    }
    class StudentNode
    {
        public Student thisOne;
        public StudentNode nextOne;
        public StudentNode() 
        {
        this.thisOne=new Student();
        }
        public StudentNode(string name,int score)
        {
            this.thisOne = new Student(name, score);
        }

    }











    internal class Program
    {

        public static void Main(string[] args)
        {
            while(StudentList.states!=state.Exit)
            {

                Console.Clear();
                StudentList.states = (state)Convert.ToInt32(StudentList.ShowMenu());
                Console.Clear();
                switch(StudentList.states)
                {
                    case state.CheckStudent:
                        StudentList.CheckStudents();
                        Interaction.Wait();
                        Console.Clear();
                        break;

                    case state.AddStudent:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Adding student...\n\nName:");
                            string temp = Console.ReadLine();
                            Console.WriteLine("Score:");
                            int temp1 = Convert.ToInt32(Console.ReadLine());
                            StudentList.AddStudent(temp, temp1);
                            Console.Clear();
                            Console.WriteLine("Done!");
                        }
                        while (Interaction.ContinueOrNot() == true);
                        break;
                    case state.DeleteStudent:
                        do
                        {
                            Console.Clear();
                            StudentList.CheckStudents();
                            if(StudentList.head.nextOne == null)
                            {
                                Interaction.Wait();
                                break;
                            }
                            Console.WriteLine("Which one do you want to delete?(Please enter the name.)");
                            string s_temp= Console.ReadLine();
                            StudentNode temp=StudentList.FindStudent(s_temp);
                            if(temp!=null)
                            {
                                StudentList.DeleteStudent(s_temp);
                                Console.Clear();
                                Console.WriteLine("Done!\n");
                            }
                            else
                            {
                                Console.WriteLine("Sorry,we can't find the student you want to delete.\n");
                            }
                        }
                        while(Interaction.ContinueOrNot() == true);
                        break;
                    case state.FindStudent:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Searching...\nPlease enter the name:");
                            string s_temp = Console.ReadLine();
                            StudentNode temp = StudentList.FindStudent(s_temp);
                            if (temp != null)
                            {
                                Console.Clear();
                                Console.WriteLine("Found student:");
                                StudentList.PrintStudent(temp);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Can't find the student that named:\n"+$"{s_temp}");
                            }
                        }
                        while (Interaction.ContinueOrNot() == true);
                        break;
                    case state.ChangeStudent:
                        string tempName;
                        StudentList.CheckStudents();
                        Console.WriteLine("Which one do you want to change?(Please enter the name.)");
                        tempName = Console.ReadLine();
                        StudentList.ChangeStudent(tempName);
                        break;
                    default:
                        StudentList.states = state.Exit;
                        break;
                        
                        
                }
            }
        }
    }
}

