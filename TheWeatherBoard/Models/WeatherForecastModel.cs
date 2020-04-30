using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWeatherBoard.Models
{
  public  class WeatherForecastModel
    {
        public WeatherForecastModel()
        {
            this.List = new List[1];
        }
       
        public long Cod { get; set; }

       
        public long Message { get; set; }

     
        public long Cnt { get; set; }

       
        public List[] List { get; set; }

     
        public City City { get; set; }
    }

    public partial class City
    {
      
        public long Id { get; set; }

    
        public string Name { get; set; }

        public Coord Coord { get; set; }

       
        public string Country { get; set; }

        public long Population { get; set; }

    
        public long Timezone { get; set; }

      
        public long Sunrise { get; set; }

     
        public long Sunset { get; set; }
    }

    public partial class Coord
    {
        
        public double Lat { get; set; }

        
        public double Lon { get; set; }
    }

    public partial class List
    {
      
        public long Dt { get; set; }

      
        public MainClass Main { get; set; }

      
        public Weather[] Weather { get; set; }

    
        public Clouds Clouds { get; set; }

    
        public Wind Wind { get; set; }

        
        public Rain Rain { get; set; }


        public Sys Sys { get; set; }


        public DateTimeOffset DtTxt { get; set; }
    }

    public partial class Clouds
    {
       
        public long All { get; set; }
    }

    public partial class MainClass
    {
       
        public double Temp { get; set; }

     
        public double FeelsLike { get; set; }


        public double TempMin { get; set; }


        public double TempMax { get; set; }


        public long Pressure { get; set; }

        public long SeaLevel { get; set; }

        public long GrndLevel { get; set; }


        public long Humidity { get; set; }

 
        public double TempKf { get; set; }
    }

    public partial class Rain
    {
       
        public double The3H { get; set; }
    }

    public partial class Sys
    {
       
        public Pod Pod { get; set; }
    }

    public partial class Weather
    {
       
        public long Id { get; set; }

        public MainEnum Main { get; set; }

 
        public string Description { get; set; }

     
        public string Icon { get; set; }
    }

    public partial class Wind
    {
 
        public double Speed { get; set; }

     
        public long Deg { get; set; }
    }

    public enum Pod { D, N };

    public enum MainEnum { Clear, Clouds, Rain };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PodConverter.Singleton,
                MainEnumConverter.Singleton,
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

    internal class PodConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Pod) || t == typeof(Pod?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "d":
                    return Pod.D;
                case "n":
                    return Pod.N;
            }
            throw new Exception("Cannot unmarshal type Pod");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Pod)untypedValue;
            switch (value)
            {
                case Pod.D:
                    serializer.Serialize(writer, "d");
                    return;
                case Pod.N:
                    serializer.Serialize(writer, "n");
                    return;
            }
            throw new Exception("Cannot marshal type Pod");
        }

        public static readonly PodConverter Singleton = new PodConverter();
    }

    internal class MainEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MainEnum) || t == typeof(MainEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear":
                    return MainEnum.Clear;
                case "Clouds":
                    return MainEnum.Clouds;
                case "Rain":
                    return MainEnum.Rain;
            }
            throw new Exception("Cannot unmarshal type MainEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MainEnum)untypedValue;
            switch (value)
            {
                case MainEnum.Clear:
                    serializer.Serialize(writer, "Clear");
                    return;
                case MainEnum.Clouds:
                    serializer.Serialize(writer, "Clouds");
                    return;
                case MainEnum.Rain:
                    serializer.Serialize(writer, "Rain");
                    return;
            }
            throw new Exception("Cannot marshal type MainEnum");
        }

        public static readonly MainEnumConverter Singleton = new MainEnumConverter();
    }
}
