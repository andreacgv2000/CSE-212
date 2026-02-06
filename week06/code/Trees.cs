public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Insert middle elements recursively to build a balanced BST.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: stop when range is invalid
        if (first > last)
            return;

        // Find the middle index
        int mid = (first + last) / 2;

        // Insert the middle value
        bst.Insert(sortedNumbers[mid]);

        // Insert left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Insert right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
