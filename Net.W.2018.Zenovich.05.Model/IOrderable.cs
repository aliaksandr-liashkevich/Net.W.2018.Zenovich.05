using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.W._2018.Zenovich._05.Model
{
    public interface IOrderable
    {
        bool OrderBy(int comparerableResult);
    }
}
