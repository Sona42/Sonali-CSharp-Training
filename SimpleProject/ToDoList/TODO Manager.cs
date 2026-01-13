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
        ///  This runs a simple ToDo List Managing application
        /// </summary>
        public static void Main(string[] args)
        {
            var todolist = new ToDoList();
            todolist.AppRun();
        }            
    }
}
