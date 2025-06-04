namespace IromDomeSystem
{
    class GeographicFlightCalculation
    {
        double GeographicAngle, launchLongitude, launchLatitude;


        public GeographicFlightCalculation(double geographicAngle, double longitude, double latitude)
        {
            GeographicAngle = Calculate.DegreesToRadians(geographicAngle);
            launchLongitude = longitude;
            launchLatitude = latitude;
        }

        public (double Longitude, double Latitude) CalculatLongitudeLatitude(double distance)
        {
            double lat1 = Calculate.DegreesToRadians(launchLatitude);
            double lon1 = Calculate.DegreesToRadians(launchLongitude);


            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(distance / Calculate.EarthRadius) +
                                    Math.Cos(lat1) * Math.Sin(distance / Calculate.EarthRadius) * Math.Cos(GeographicAngle));

            double lon2 = lon1 + Math.Atan2(Math.Sin(GeographicAngle) * Math.Sin(distance / Calculate.EarthRadius) * Math.Cos(lat1),
                                            Math.Cos(distance / Calculate.EarthRadius) - Math.Sin(lat1) * Math.Sin(lat2));

            return (Calculate.RadiansToDegrees(lat2), Calculate.RadiansToDegrees(lon2));
        }

    }

}