
namespace QuadroStride
{
    public static class UT_TagHandler
    {
        public static string Spot = "Spot";
        public static string GunBot = "GunBot";

        public static string OpponentTag(string tag)
        {
            return tag == UT_TagHandler.Spot ? UT_TagHandler.GunBot : UT_TagHandler.Spot;
        }

        public static bool IsAgentTag(string tag)
        {
            return tag.Equals(Spot) || tag.Equals(GunBot);
        }
    }
}