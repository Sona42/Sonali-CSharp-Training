using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListManager
{
    public class Program
    {
        /// <summary>
        ///  This launches a simple ToDo List Managing application
        ///  where user can add, remove and view the items in a todo list
        /// </summary>
        public static void Main(string[] args)
        {
            var todolist = new ToDoList();
            todolist.AppRun();
        }            
    }
}
