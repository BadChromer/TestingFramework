namespace Framework.Utilities
{
    public class Logger
    {
        public static void ElementIsClicked(string elementName)
        {
            Console.WriteLine($"{elementName} was clicked");
        }

        public static void ElementIsDisplayed(string elementName)
        {
            Console.WriteLine(elementName);
        }

        public static void PageIsLoaded(string pageName)
        {
            Console.WriteLine($"{pageName} was loaded");
        }

        public static void AttributeIsGiven(string elementName, string attributeName)
        {
            Console.WriteLine($"Getting {attributeName} from {elementName}");
        }
    }
}