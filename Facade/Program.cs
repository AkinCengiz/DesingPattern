using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class Logging :ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching 
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize 
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validation : IValidate 
    {
        public void Validated()
        {
            Console.WriteLine("Validated...");
        }
    }

    internal interface IValidate
    {
        void Validated();
    }

    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concernsFacade;

        public CustomerManager()
        {
            _concernsFacade = new CrossCuttongConcernsFacade();
        }

        public void Save()
        {
            _concernsFacade.Authorized.CheckUser();
            _concernsFacade.Caching.Cache();
            _concernsFacade.Logging.Log();
            _concernsFacade.Validation.Validated();
            Console.WriteLine("Saved...");
        }
    }

    class CrossCuttongConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorized;
        public IValidate Validation;

        public CrossCuttongConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorized = new Authorize();
            Validation = new Validation();
        }
    }
}
