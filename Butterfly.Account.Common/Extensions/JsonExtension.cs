using Newtonsoft.Json;

namespace Butterfly.Account.Common.Extensions;

    /// <summary>
    /// JsonExtension class is a extension for case such as Serializing and Deserializing Data
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// Deserialize is an extension method for string which deserialize the string into a specified Template Type
        /// </summary>
        /// <typeparam name="T">A generic type for deserializing the string value</typeparam>
        /// <param name="value">The value is the data which is going to be Deserialized</param>
        /// <returns>A template type of object deserialized</returns>
        public static T Deserialize<T>(this string value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        /// <summary>
        /// Serialize method is an extension for specified generic type which serializes the generic specified type into a string i.e. json value
        /// </summary>
        /// <typeparam name="T">Specified template type which is going to be serialized</typeparam>
        /// <param name="value">Value is the data which is going to be serialized</param>
        /// <returns>A string value of the serialized Template Type</returns>
        public static string Serialize<T>(this T value) where T : class
        {
            return JsonConvert.SerializeObject(value);
        }
    }