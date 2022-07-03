using InventryManager.Service.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.Service.Helpers
{
    public static class ExtensionHelpers
    {
        public static object ConvertToObject(this string str)
        {
            try
            {
                return str != null ? JsonConvert.DeserializeObject(str) : default(object);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // ignored
            }

            return default(object);
        }

        public static T ConvertToModel<T>(this string obj)
        {
            try
            {
                return obj != null ? JsonConvert.DeserializeObject<T>(obj) : default(T);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // ignored
            }

            return default(T);
        }

        public static string ToJsonString(this object obj)
        {
            return obj != null ? JsonConvert.SerializeObject(obj) : string.Empty;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(this object obj)
        {
            if (obj == null)
                return null;
            byte[] result;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                result = ms.ToArray();
            }
            return result;
        }

        // Convert a byte array to an Object
        public static T ByteArrayToObject<T>(this byte[] arrBytes)
        {
            if (arrBytes == null)
                return default(T);
            T obj;
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                obj = (T)binForm.Deserialize(memStream);
            }
            return obj;
        }

        public static TimeSpan GetTimeSpan(this ExpirationType expiration)
        {
            switch (expiration)
            {
                case ExpirationType.OneMinute:
                    return TimeSpan.FromMinutes(1);
                case ExpirationType.FiveMinutes:
                    return TimeSpan.FromMinutes(5);
                case ExpirationType.TenMinutes:
                    return TimeSpan.FromMinutes(10);
                case ExpirationType.TwentyMinutes:
                    return TimeSpan.FromMinutes(20);
                case ExpirationType.ThirtyMinutes:
                    return TimeSpan.FromMinutes(30);
                case ExpirationType.OneHour:
                    return TimeSpan.FromHours(1);
                case ExpirationType.TwoHours:
                    return TimeSpan.FromHours(2);
                case ExpirationType.FourHours:
                    return TimeSpan.FromHours(4);
                case ExpirationType.SixHours:
                    return TimeSpan.FromHours(6);
                case ExpirationType.TwelveHours:
                    return TimeSpan.FromHours(12);
                case ExpirationType.OneDay:
                    return TimeSpan.FromDays(1);
                case ExpirationType.TwoDays:
                    return TimeSpan.FromDays(2);
                case ExpirationType.OneWeek:
                    return TimeSpan.FromDays(7);
                case ExpirationType.TwoWeeks:
                    return TimeSpan.FromDays(14);
                case ExpirationType.OneMonth:
                    return TimeSpan.FromDays(30);
                case ExpirationType.TwoMonths:
                    return TimeSpan.FromDays(60);
            }
            return TimeSpan.FromSeconds(-1);
        }

        public static string ToCommaSeperatedString(this List<int> list)
        {
            if (list == null || list.Count < 1)
            {
                return null;
            }
            return string.Join(",", list.Select(item => item.ToString()).ToArray());
        }
    }
}
