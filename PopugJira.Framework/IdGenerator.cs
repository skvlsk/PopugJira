using MongoDB.Bson;

namespace PopugJira.Framework
{
    public static class IdGenerator
    {
        public static string GetNewId() => ObjectId.GenerateNewId().ToString();
    }
}