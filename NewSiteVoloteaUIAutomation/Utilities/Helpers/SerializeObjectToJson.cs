namespace VoloteaUIAutomation.Utilities.Helpers
{
    public static class SerializeObjectToJson
    {
        public static string SerializeToJson(object data)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(data);
        }
    }
}
