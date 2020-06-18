using HtmlAgilityPack;

namespace logic
{
    public static class HtmlHelper
    {
        public static string RemoveHtmlTags(string inputHtml)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(inputHtml);
            return htmlDoc.DocumentNode.InnerText;
        }
    }
}
