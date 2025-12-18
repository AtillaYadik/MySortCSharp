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
        public static Int64[] SortAndRemoveDuplicates(int[] numbers)
        {
            if (numbers == null) throw new ArgumentNullException(nameof(numbers));
        if (numbers.Length == 0) return Array.Empty<int>();

        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            int v = numbers[i];
            if (v < min) min = v;
            if (v > max) max = v;
        }

        long rangeLong = (long)max - min + 1;
        if (rangeLong > int.MaxValue)
            throw new InvalidOperationException($"Range too large: {rangeLong}.");

        int range = (int)rangeLong;
        var present = new bool[range];

        for (int i = 0; i < numbers.Length; i++)
        {
            present[numbers[i] - min] = true;
        }

        // Count uniques
        int count = 0;
        for (int i = 0; i < range; i++)
        {
            if (present[i]) count++;
        }

        // Fill output
        var output = new int[count];
        int idx = 0;
        for (int i = 0; i < range; i++)
        {
            if (present[i]) output[idx++] = i + min;
        }

        return output;
    }
}
