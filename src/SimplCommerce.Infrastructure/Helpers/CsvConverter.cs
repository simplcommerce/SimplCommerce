using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SimplCommerce.Infrastructure.Helpers
{
    public static class CsvConverter
    {
        public static IList<T> ReadCsvStream<T>(Stream stream, bool skipFirstLine = true, string csvDelimiter = ",") where T : new()
        {
            var records = new List<T>();
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(csvDelimiter.ToCharArray());
                    if (skipFirstLine)
                    {
                        skipFirstLine = false;
                    }
                    else
                    {
                        var item = new T();
                        var properties = item.GetType().GetProperties();
                        for (int i = 0; i < values.Length; i++)
                        {
                            properties[i].SetValue(item, Convert.ChangeType(values[i], properties[i].PropertyType, CultureInfo.CurrentCulture), null);
                        }

                        records.Add(item);
                    }
                }
            }

            return records;
        }

        public static string ExportCsv<T>(IList<T> data, bool includeHeader = true, string csvDelimiter = ",")
        {
            var type = data.GetType();
            Type itemType;

            if (type.GetGenericArguments().Length > 0)
            {
                itemType = type.GetGenericArguments()[0];
            }
            else
            {
                itemType = type.GetElementType();
            }

            using (var stringWriter = new StringWriter())
            {
                if (includeHeader)
                {
                    stringWriter.WriteLine(
                        string.Join<string>(
                            csvDelimiter, itemType.GetProperties().Select(x => x.Name)
                        )
                    );
                }

                foreach (var obj in data)
                {
                    var vals = obj.GetType().GetProperties().Select(pi => new
                    {
                        Value = pi.GetValue(obj, null)
                    }
                    );

                    string line = string.Empty;
                    foreach (var val in vals)
                    {
                        if (val.Value != null)
                        {
                            var escapeVal = val.Value.ToString();
                            // Check if the value contans a comma and place it in quotes if so
                            if (escapeVal.Contains(",", StringComparison.OrdinalIgnoreCase))
                            {
                                escapeVal = string.Concat("\"", escapeVal, "\"");
                            }

                            // Replace any \r or \n special characters from a new line with a space
                            if (escapeVal.Contains("\r", StringComparison.OrdinalIgnoreCase))
                            {
                                escapeVal = escapeVal.Replace("\r", " ", StringComparison.OrdinalIgnoreCase);
                            }

                            if (escapeVal.Contains("\n", StringComparison.OrdinalIgnoreCase))
                            {
                                escapeVal = escapeVal.Replace("\n", " ", StringComparison.OrdinalIgnoreCase);
                            }

                            line = string.Concat(line, escapeVal, csvDelimiter);
                        }
                        else
                        {
                            line = string.Concat(line, string.Empty, csvDelimiter);
                        }
                    }

                    stringWriter.WriteLine(line.TrimEnd(csvDelimiter.ToCharArray()));
                }

                return stringWriter.ToString();
            }
        }
    }
}
