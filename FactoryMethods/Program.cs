using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new Log4NetLoggerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }

    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new AcLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class AcLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AcLogger...");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger...");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!!!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
