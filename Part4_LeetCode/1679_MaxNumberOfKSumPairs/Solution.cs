public int MaxOperations(int[] nums, int k)
{
    var dict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if(!dict.ContainsKey(nums[i]))
        {
            dict.Add(nums[i], 1);
        }
        else
        {
            dict[nums[i]]++;
        }
    }

    int count = 0;
    
    // key is num and value its frequency
    foreach (var kv in dict)
    {
        int num = kv.Key;
        int complement = k - num;
        if (!dict.ContainsKey(complement)!)
        {
            continue;
        }

        if (num < complement)
        {
            count += Math.Min(dict[num], dict[complement]);
        }
        else if (num == complement)
        {
            count += (int)Math.Floor(dict[num] / 2.0);
        }
        dict.Remove(complement);
    }
    
    return count;
}