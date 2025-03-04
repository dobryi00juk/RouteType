// See https://aka.ms/new-console-template for more information

Sort(new[] {2, 0, 1});
Console.WriteLine("Hello, World!");
return;
 
void Sort(int[] nums)
{
    Span<int> temp = stackalloc int[nums.Length];

    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] < nums[i + 1])
        {
            var a = nums[i];
            (nums[i], nums[i + 1]) = (nums[i + 1], a);
        }

        Console.WriteLine(nums[i]);
    }
}