using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaGarbageCollection
{
    class Calculator : IDisposable
    {
        private bool disposed = false;

        public Calculator()
        {
            Console.WriteLine("Calculator being created");
        }

        ~Calculator()
        {
            Console.WriteLine("Calculator being finalized");
            Dispose();
        }

        public void Dispose()
        {
            lock (this)
            {
                if (!disposed)
                    Console.WriteLine("Calculator being disposed");

                disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public int Divide(int first, int second)
        {
            return first / second;
        }
    }
}
