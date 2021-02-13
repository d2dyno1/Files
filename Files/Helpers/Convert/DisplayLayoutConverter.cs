using Files.Views;
using System;
using static Files.Constants.Browser;

namespace Files.Helpers.Convert
{
    public static class DisplayLayoutConverter
    {
        public static DisplayPageType Convert(Type pageType)
        {
            if (pageType == typeof(YourHome))
            {
                return DisplayPageType.HomePage;
            }
            else if (pageType == typeof(GenericFileBrowser))
            {
                return DisplayPageType.GenericFileBrowser;
            }
            else if (pageType == typeof(GridViewBrowser))
            {
                return DisplayPageType.GridViewBrowser;
            }

            return DisplayPageType.None;
        }

        public static Type Convert(DisplayPageType displayPageType)
        {
            if (displayPageType == DisplayPageType.HomePage)
            {
                return typeof(YourHome);
            }
            else if (displayPageType == DisplayPageType.GenericFileBrowser)
            {
                return typeof(GenericFileBrowser);
            }
            else if (displayPageType == DisplayPageType.GridViewBrowser)
            {
                return typeof(GridViewBrowser);
            }

            return null;
        }
    }
}
