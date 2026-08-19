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
      public static int[] AtillaNoDuplicateSorting(int[] arr)
    {
        if (arr == null || arr.Length == 0) return Array.Empty<int>();

        // In C#, the array is already typed as int[], so there's no need
        // for a runtime "is it an integer" check like in JS (where numbers
        // can be floats). If your input might come in as double[] or object[],
        // let me know and I can add that validation back in.

        int min = int.MaxValue;
        int max = int.MinValue;

        foreach (var v in arr)
        {
            if (v < min) min = v;
            if (v > max) max = v;
        }

        long k = (long)max - min + 1;

        // Bail out to normal sort if range is too big relative to n
        if (k > arr.Length * 10L)
        {
            return arr.Distinct().OrderBy(x => x).ToArray();
        }

        // Use nullable int as a stand-in for JS's "undefined" sentinel
        var buckets = new int?[k];

        foreach (var v in arr)
        {
            long idx = (long)v - min;
            buckets[idx] = v; // dedupe
        }

        var result = new List<int>();
        for (long i = 0; i < k; i++)
        {
            if (buckets[i].HasValue)
            {
                result.Add(buckets[i].Value);
            }
        }

        return result.ToArray();
    }
    }
}
