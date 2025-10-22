using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    internal class Input
    {
        //Load list of available Keyboard buttons
        private static Hashtable keyTable = new Hashtable();

        //Perform a check to see if a particular button is pressed.
        public static bool KeyPressed(Keys key)
        {
            return keyTable[key] == null ? false : (bool)keyTable[key];
        }

        //Detect if a keyboard button is pressed
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
