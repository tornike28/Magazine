using Application.IService;
using Application.Service;
using ConsoleApp2.Application.Service;
using Domain.Models;
using Shared;
using System;

namespace Application
{
    class Program 
    {
        static void Main(string[] args)
        {
            ConsoleHelper consoleHelper = new ConsoleHelper();
            consoleHelper.Execute();
        }
    }
}
