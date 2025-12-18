using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    public static class AtillaSort
    {
       public static Int64[] SortAndRemoveDuplicates(int[] data)
        {
            var tmp1 = new int[10000];
           
            for (var i = 0; i < data.Length; i++)
            {
                int currentVal = data[i];
                tmp1[currentVal] = currentVal;
            }

            var tmp2 = new List<Int64>();

            tmp2.Add(tmp1[0]);
            for (var i = 1; i < tmp1.Length; ++i)
            {
                var tmp = tmp1[i];
                if (tmp > 0)
                    tmp2.Add(tmp) ;
            }

            return tmp2.ToArray<Int64>();

        }
    }
}
