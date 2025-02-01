public class Solution
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        var output = solution.RemoveElement(new int[] { 3, 2, 2, 3 }, 3);
        Console.WriteLine(output.ToString());
    }

    public int RemoveElement(int[] lineOfPeople, int disallowedShirtColor) // using an analogy of a nightclub with a bouncer
                                                                           // to remove elements from an array in-place
                                                                           // with a bouncer(pointer) removing people (int) from the line(int[]) based on shirt color(int val)
                                                                           // where the int value represents shirt color
    {
        // k represents the number of people allowed in the club (the next available spot inside)
        int nextAvailableSpot = 0;

        // Initial state:
        //
        // Line of people: [10, 20, 30, 40, 30, 50]  (disallowedShirtColor = 30)
        //                   ^
        //                   |
        //             nextAvailableSpot (0)
        // Club: []

        // The bouncer checks each person in the line
        for (int bouncer = 0; bouncer < lineOfPeople.Length; bouncer++)
        {
            // If the current person's shirt is not the disallowed color
            if (lineOfPeople[bouncer] != disallowedShirtColor)
            {
                // Let this person into the club (place them at the next available spot)
                lineOfPeople[nextAvailableSpot] = lineOfPeople[bouncer];

                //   Example (first iteration, person with shirt '10' is allowed):
                //
                //   Line: [10, 20, 30, 40, 30, 50]
                //           ^                  ^
                //           |                  |
                //       bouncer (0)      nextAvailableSpot (0)
                //   Club: []
                //
                //   After allowing the person in:
                //
                //   Line: [10, 20, 30, 40, 30, 50]
                //           ^                  ^
                //           |                  |
                //       bouncer (0)      nextAvailableSpot (1) <--- nextAvailableSpot moves up
                //   Club: [10]

                // Move the next available spot forward
                nextAvailableSpot++;
            }
            //  If the person's shirt is the disallowed color, they are skipped:
            //
            //   Example (third iteration, person with shirt '30' is skipped):
            //
            //   Line: [10, 20, 30, 40, 30, 50]
            //                ^
            //                |
            //            bouncer (2)
            //   Club: [10, 20]
            //          ^
            //          |
            //    nextAvailableSpot (2) <--- nextAvailableSpot does NOT move
        }

        // Final state (after the bouncer has checked everyone):
        //
        //   Line: [10, 20, 40, 50, 30, 50]
        //                          ^
        //                          |
        //                     bouncer (6)
        //   Club: [10, 20, 40, 50]
        //                   ^
        //                   |
        //           nextAvailableSpot (4)

        // The number of people allowed in the club is the new logical size of the array
        return nextAvailableSpot;
    }
}
