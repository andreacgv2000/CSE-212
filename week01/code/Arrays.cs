using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function creates an array of multiples of a given number.
    /// For example: MultiplesOf(3, 5) -> {3, 6, 9, 12, 15}
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create an array with the size equal to "length".
        // 2. Use a loop to calculate each multiple.
        // 3. Store each multiple in the array.
        // 4. Return the completed array.

        // Step 1: Create the array that will store the multiples
        double[] result = new double[length];

        // Step 2: Loop through the array
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple.
            // We use (i + 1) because multiples start at 1 * number
            result[i] = number * (i + 1);
        }

        // Step 4: Return the array with all multiples
        return result;
    }

    /// <summary>
    /// Rotates the list to the right by the given amount.
    /// The original list is modified directly.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Find the size of the list.
        // 2. Adjust the rotation amount using modulo.
        // 3. If the amount is 0, no rotation is needed.
        // 4. Split the list into two parts.
        // 5. Move the last part to the front of the list.

        // Step 1: Get the number of elements in the list
        int count = data.Count;

        // Step 2: Use modulo to handle full rotations
        amount = amount % count;

        // Step 3: If no rotation is needed, exit the function
        if (amount == 0)
        {
            return;
        }

        // Step 4: Calculate where the split should happen
        int splitIndex = count - amount;

        // Step 5: Get the elements that will move to the front
        List<int> endPart = data.GetRange(splitIndex, amount);

        // Step 6: Remove those elements from the end
        data.RemoveRange(splitIndex, amount);

        // Step 7: Insert them at the beginning of the list
        data.InsertRange(0, endPart);
    }
}
