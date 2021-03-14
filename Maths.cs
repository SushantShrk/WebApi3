using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Maths: IMaths
    {
        public int addition(int a, int b)
        {
            return a + b;
        }
    }

    public interface IMaths
    {
        public int addition(int a, int b);
    }
}
