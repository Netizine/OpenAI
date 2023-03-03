//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Formats.Asn1;
//using System.Linq;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Text.Json;
//using System.Threading.Tasks;
//using OpenAI.Mock.Models.Requests;
//using Org.BouncyCastle.Utilities;
//using System.Xml.Linq;

//namespace OpenAI.Mock.Converters {

//    public class RoleConverter : JsonConverter {
//        private readonly Type[] _types;

//        public KeysJsonConverter(params Type[] types) {
//            _types = types;
//        }

//        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
//            JToken t = JToken.FromObject(value);

//            if (t.Type != JTokenType.Object) {
//                t.WriteTo(writer);
//            }
//            else {
//                JObject o = (JObject)t;
//                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

//                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

//                o.WriteTo(writer);
//            }
//        }

//        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
//            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
//        }

//        public override bool CanRead {
//            get { return false; }
//        }

//        public override bool CanConvert(Type objectType) {
//            return _types.Any(t => t == objectType);
//        }
//    }

//    //public static class JsonRoles
//    //{
//    //    public class RoleConverter : JsonConverter {
//    //        public override bool CanConvert(Type t) => t == typeof(ChatRoles) || t == typeof(ChatRoles?);

//    //        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer) {
//    //            if (reader.TokenType == JsonToken.Null) return null;
//    //            var value = serializer.Deserialize<string>(reader);
//    //            switch (value) {
//    //                case "system":
//    //                    return ChatRoles.System;
//    //                case "user":
//    //                    return ChatRoles.User;
//    //            }
//    //            throw new Exception("Cannot unmarshal type Role");
//    //        }

//    //        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer) {
//    //            if (untypedValue == null) {
//    //                serializer.Serialize(writer, null);
//    //                return;
//    //            }
//    //            var value = (ChatRoles)untypedValue;
//    //            switch (value) {
//    //                case ChatRoles.System:
//    //                    serializer.Serialize(writer, "system");
//    //                    return;
//    //                case ChatRoles.User:
//    //                    serializer.Serialize(writer, "user");
//    //                    return;
//    //            }
//    //            throw new Exception("Cannot marshal type Role");
//    //        }

//    //        public static readonly RoleConverter Singleton = new RoleConverter();
//    //    }
//    //}
//}
