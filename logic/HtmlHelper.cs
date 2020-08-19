using HtmlAgilityPack;

namespace logic
{
    public static class HtmlHelper
    {
        public static string RemoveHtmlTags(string inputHtml)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(inputHtml);
            var plainText = htmlDoc.DocumentNode.InnerText;
            return plainText.Replace("&nbsp", string.Empty);
        }
    }
}
