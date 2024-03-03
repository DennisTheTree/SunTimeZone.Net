using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunTimeZone.Common.Enums;

namespace SunTimeZone.Common
{
    internal static class CoordinateParser
    {
        private readonly static string DecimalDegreeRegex = @"(-?[0-9]{1,2}.[0-9]{0,5}),?\s(-?[0-9]{1,2}.[0-9]{0,5})";

        private readonly static string DecimalDegreeSecondsRegex = @"(([0-9]{1,2})(º|\s)\s?([0-9]{1,2}(.[0-9]{1,2})?)('|\s)\s?([0-9]{1,2}(.[0-9]{1,2})?)(""|\s)\s?(N|S|n|s))\s(([0-9]{1,2})(º|\s)\s?([0-9]{1,2}(.[0-9]{1,2})?)('|\s)\s?([0-9]{1,2}(.[0-9]{1,2})?)(""|\s)\s?(W|E|w|e))";

        private readonly static string DegreeMinuteSecondsRegex = @"(([0-9]{1,2})\s([0-9]{1,2}.[0-9]{0,4})),?\s?(([0-9]{1,2})\s([0-9]{1,2}.[0-9]{0,4}))";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="coordinateFormat"></param>
        /// <returns></returns>
        internal static double ParseLongitude(string coordinates, CoordinateFormat coordinateFormat)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(coordinates);
            if(coordinateFormat == CoordinateFormat.None){
                return 0;
            }

            double longitude = 0;
            bool success = false;

            success = coordinateFormat switch
            {
                CoordinateFormat.DD => ParseDecimalDegreesCoordinates(coordinates, out longitude, out _),
                CoordinateFormat.DDS => ParseDecimalDegreeSecondsCoordinates(coordinates, out longitude, out _),
                CoordinateFormat.DMS => ParseDegreeMinuteSecondsCoordinates(coordinates, out longitude, out _),
                _ => false,
            };

            if(success == false){
                throw new InvalidOperationException($"The given coordinates {coordinates} are unable to be parsed for the given format {coordinateFormat}");
            }

            ArgumentOutOfRangeException.ThrowIfLessThan(longitude, -180);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(longitude, 180);

            return longitude;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="coordinateFormat"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        internal static bool TryParseLongitude(string coordinates, CoordinateFormat coordinateFormat, out double longitude)
        {
            longitude = 0;
            bool success = false;

            if(string.IsNullOrEmpty(coordinates)){
                return success;
            }

            success = coordinateFormat switch
            {
                CoordinateFormat.DD => ParseDecimalDegreesCoordinates(coordinates, out longitude, out _),
                CoordinateFormat.DDS => ParseDecimalDegreeSecondsCoordinates(coordinates, out longitude, out _),
                CoordinateFormat.DMS => ParseDegreeMinuteSecondsCoordinates(coordinates, out longitude, out _),
                _ => false,
            };
            if (longitude < -180 || longitude > 180){
                return false;
            }
            return success;
        }

        private static bool ParseDecimalDegreesCoordinates (string coordinate, out double latitude, out double longitude)
        {
            latitude = 0;
            longitude = 0;
            return false;
        }

        private static bool ParseDecimalDegreeSecondsCoordinates (string coordinate, out double latitude, out double longitude)
        {
            latitude = 0;
            longitude = 0;
            return false;
        }

        private static bool ParseDegreeMinuteSecondsCoordinates (string coordinate, out double latitude, out double longitude)
        {
            latitude = 0;
            longitude = 0;
            return false;
        }
        
    }
}