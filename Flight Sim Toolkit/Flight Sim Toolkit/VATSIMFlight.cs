﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Flight_Sim_Toolkit;
//
//    var vatsimFlight = VatsimFlight.FromJson(jsonString);

using System.Net;
using System.Windows.Forms;

namespace Flight_Sim_Toolkit
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using J = Newtonsoft.Json.JsonPropertyAttribute;
    using R = Newtonsoft.Json.Required;
    using N = Newtonsoft.Json.NullValueHandling;

    public partial class VatsimFlight
    {
        [J("role")] public string Role { get; set; }
        [J("callsign")] public string Callsign { get; set; }
        [J("cid")] [JsonConverter(typeof(ParseStringConverter))] public long Cid { get; set; }
        [J("name")] public string Name { get; set; }
        [J("rating")] public string Rating { get; set; }
        [J("aircraft")] public string Aircraft { get; set; }
        [J("flight_type")] public string FlightType { get; set; }
        [J("origin")] public string Origin { get; set; }
        [J("route")] public string Route { get; set; }
        [J("destination")] public string Destination { get; set; }
        [J("altitude")] [JsonConverter(typeof(ParseStringConverter))] public long Altitude { get; set; }
        [J("groundspeed")] [JsonConverter(typeof(ParseStringConverter))] public long Groundspeed { get; set; }
        [J("heading")] [JsonConverter(typeof(ParseStringConverter))] public long Heading { get; set; }
        [J("remarks")] public string Remarks { get; set; }
        [J("planned_altitude")] public string PlannedAltitude { get; set; }
        [J("transponder")] [JsonConverter(typeof(ParseStringConverter))] public long Transponder { get; set; }
        [J("qnh_in")] public string QnhIn { get; set; }
        [J("qnh_mb")] [JsonConverter(typeof(ParseStringConverter))] public long QnhMb { get; set; }
        [J("gcmap")] public Uri Gcmap { get; set; }
        [J("latitude")] public string Latitude { get; set; }
        [J("longitude")] public string Longitude { get; set; }
        [J("latitude_humanized")] public string LatitudeHumanized { get; set; }
        [J("longitude_humanized")] public string LongitudeHumanized { get; set; }
        [J("logon")] public string Logon { get; set; }
        [J("online_since")] public DateTimeOffset OnlineSince { get; set; }
    }

    public partial class VatsimFlight
    {
        public static List<VatsimFlight> FromJson(string json) => JsonConvert.DeserializeObject<List<VatsimFlight>>(json, Flight_Sim_Toolkit.Converter.Settings);

        public static VatsimFlight FromCallsign(string callsign)
        {
            var jsonFlightInfo = "";

            using (var wc = new WebClient())
            {
                try
                {
                    jsonFlightInfo = wc.DownloadString($"http://api.vateud.net/online/callsign/{callsign}.json");
                }
                catch (Exception e)
                {
                    throw new VATSIMDownloadFailureException("Failed to fetch flight info from VATSIM: " + e.Message, e);
                }

                if (jsonFlightInfo == "[]")
                {
                    throw new InactiveCallsignException("Callsign not active on VATSIM!\n\nIt can take up to 2 minutes from filing your flight plan and connecting to being able to fetch your status.");
                }

            }
            return FromJson(jsonFlightInfo)[0];
        }
    }

    public static class Serialize
    {
        public static string ToJson(this List<VatsimFlight> self) => JsonConvert.SerializeObject(self, Flight_Sim_Toolkit.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    public class InactiveCallsignException : Exception
    {
        public InactiveCallsignException()
        {

        }

        public InactiveCallsignException(string message) : base(message)
        {

        }

        public InactiveCallsignException(string message, Exception inner) : base(message, inner)
        {

        }
    }

    public class VATSIMDownloadFailureException : Exception
    {
        public VATSIMDownloadFailureException()
        {

        }

        public VATSIMDownloadFailureException(string message) : base(message)
        {

        }

        public VATSIMDownloadFailureException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}