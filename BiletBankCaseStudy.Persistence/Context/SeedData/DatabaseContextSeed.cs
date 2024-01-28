using BiletBankCaseStudy.Core.Security.Enums;
using BiletBankCaseStudy.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;

namespace BiletBankCaseStudy.Persistence.Context.SeedData
{
    public class DatabaseContextSeed
    {
        public async Task SeedAsync(DatabaseContext context, IWebHostEnvironment env, ILogger<DatabaseContextSeed> logger)
        {
            var policy = Policy.Handle<SqlException>()
                .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timespan, retry, ctx) =>
                {
                    logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message");
                }
            );

            await policy.ExecuteAsync(() => ProcessSeeding(context));
        }

        private async Task ProcessSeeding(DatabaseContext context)
        {
            if (!context.AirlineCompanies.Any())
            {
                await context.AirlineCompanies.AddRangeAsync(GetAirlineCompanySeedData());

                await context.SaveChangesAsync();
            }

            if (!context.Airports.Any())
            {
                await context.Airports.AddRangeAsync(GetAirportSeedData());

                await context.SaveChangesAsync();

                if (!context.Flights.Any())
                {
                    var airports = context.Airports.ToList();
                    var airlineCompanes = context.AirlineCompanies.ToList();

                    await context.Flights.AddRangeAsync(GetFlightSeedData(airports, airlineCompanes));

                    await context.SaveChangesAsync();

                    if (!context.FlightPrices.Any())
                    {
                        var flights = context.Flights.ToList();

                        await context.FlightPrices.AddRangeAsync(GetFlightListSeedData(flights));

                        await context.SaveChangesAsync();
                    }
                }

            }
        }

        private IEnumerable<FlightPrice> GetFlightListSeedData(IEnumerable<Flight> flights)
        {
            var flightPrices = new List<FlightPrice>();

            Random random = new Random();
            double minPrice = 540.45;
            double maxPrice = 2790.36;

            foreach (var item in flights)
            {
                flightPrices.Add(new FlightPrice
                {
                    Features = "Rahat Koltuk.",
                    LuggageWeight = 15,
                    PriceType = FligtPriceType.Eco,
                    Price = minPrice + (random.NextDouble() * (maxPrice - minPrice)),
                    FlightId = item.Id,
                    Status = (byte)GlobalStatus.Active,
                    CreatedDate = DateTime.UtcNow
                }) ;

                flightPrices.Add(new FlightPrice
                {
                    Features = "Rahat Koltuk.",
                    LuggageWeight = 20,
                    PriceType = FligtPriceType.Extrafly,
                    Price = minPrice + (random.NextDouble() * (maxPrice - minPrice)),
                    FlightId = item.Id,
                    Status = (byte)GlobalStatus.Active,
                    CreatedDate = DateTime.UtcNow
                });

                flightPrices.Add(new FlightPrice
                {
                    Features = "Rahat Koltuk.",
                    LuggageWeight = 25,
                    PriceType = FligtPriceType.Primefly,
                    Price = minPrice + (random.NextDouble() * (maxPrice - minPrice)),
                    FlightId = item.Id,
                    Status = (byte)GlobalStatus.Active,
                    CreatedDate = DateTime.UtcNow
                });

                flightPrices.Add(new FlightPrice
                {
                    Features = "Rahat Koltuk.",
                    LuggageWeight = 30,
                    PriceType = FligtPriceType.Businessfly,
                    Price = minPrice + (random.NextDouble() * (maxPrice - minPrice)),
                    FlightId = item.Id,
                    Status = (byte)GlobalStatus.Active,
                    CreatedDate = DateTime.UtcNow
                });
            }

            return flightPrices;
        }
        private IEnumerable<AirlineCompany> GetAirlineCompanySeedData()
        {
            var airlineCompanies = new List<AirlineCompany>()
            {
                new AirlineCompany { Name = "Turkish Airlines", Status = (byte)GlobalStatus.Active },
                new AirlineCompany { Name = "Emirates" , Status =(byte) GlobalStatus.Active},
                new AirlineCompany { Name = "Delta Air Lines",Status = (byte)GlobalStatus.Active },
                new AirlineCompany { Name = "Lufthansa" , Status =(byte) GlobalStatus.Active},
                new AirlineCompany { Name = "Qatar Airways",Status = (byte)GlobalStatus.Active },
                new AirlineCompany { Name = "British Airways",Status = (byte)GlobalStatus.Active },
                new AirlineCompany { Name = "Air France",Status = (byte)GlobalStatus.Active },
                new AirlineCompany { Name = "American Airlines" ,Status = (byte)GlobalStatus.Active},
                new AirlineCompany { Name = "Etihad Airways",Status = (byte)GlobalStatus.Active },
                new AirlineCompany {Name = "Singapore Airlines",Status = (byte)GlobalStatus.Active },
            };

            return airlineCompanies;
        }
        private IEnumerable<Flight> GetFlightSeedData(IEnumerable<Airport> airports, IEnumerable<AirlineCompany> airlineCompanies)
        {
            var flightList = new List<Flight>();
            Random random = new Random();

            for (int i = 0; i < 80; i++)
            {
                Airport randomDataOne = GetRandomItem(airports, random);
                Airport randomDataTwo = GetRandomItem(airports, random);
                AirlineCompany airlineCompany = GetRandomItem(airlineCompanies, random);

                for (int j = 0; j < 4; j++)
                {
                    var flight = new Flight()
                    {
                        AirlineCompanyId = airlineCompany.Id,
                        DepartureAirportId = randomDataOne.Id,
                        ArrivalAirportId = randomDataTwo.Id,
                        TotalHours = random.Next(1, 30),
                        DepartureDate = GetRandomDate(random, DateTime.UtcNow),
                        //ReturnDate = GetRandomDate(random, DateTime.UtcNow, random.Next(1, 3)),
                        CreatedDate = DateTime.UtcNow,
                        Status = (byte)GlobalStatus.Active
                    };

                    flightList.Add(flight);
                }

                //flightList.Add(new Flight()
                //{
                //    AirlineCompanyId = airlineCompany.Id,
                //    LuggageWeight = random.Next(12, 30),
                //    DepartureAirportId = randomDataTwo.Id,
                //    ArrivalAirportId = randomDataOne.Id,
                //    TotalHours = random.Next(1, 30),
                //    DepartureDate = GetRandomDate(random, departureFlight.DepartureDate),
                //    CreatedDate = DateTime.UtcNow,
                //    Status = (byte)GlobalStatus.Active
                //});
            }

            return flightList;
        }
        private static T GetRandomItem<T>(IEnumerable<T> sourceList, Random random)
        {
            List<T> shuffledList = sourceList.OrderBy(x => random.Next()).ToList();

            T randomItem = shuffledList.FirstOrDefault();

            return randomItem;
        }
        private static DateTime GetRandomDate(Random random, DateTime startDate, int? departureAddDay = null)
        {
            int randomDay = random.Next(1, 5);
            DateTime randomDate = startDate.AddDays(randomDay);

            if (departureAddDay.HasValue)
                randomDate.AddDays(departureAddDay.Value);

            return randomDate;
        }
        private IEnumerable<Airport> GetAirportSeedData()
        {
            var airportList = new List<Airport>();

            var json = File.ReadAllText("D:\\Windows\\source\\repos\\BiletBankCaseStudy\\BiletBankCaseStudy.Persistence\\Context\\SeedData\\AirportList.json");

            List<AirportFromJson> airportsFromJson = JsonConvert.DeserializeObject<List<AirportFromJson>>(json);

            var list = new List<Airport>();

            foreach (var airport in airportsFromJson)
            {
                list.Add(new()
                {
                    Name = airport.name,
                    City = airport.city,
                    Country = airport.country,
                    IATA_CODE = airport.iata_code,
                    LATITUDE = airport._geoloc.lat.ToString(),
                    LONGITUDE = airport._geoloc.lng.ToString(),
                    Status = (byte)GlobalStatus.Active,
                    CreatedDate = DateTime.UtcNow
                });
            }

            return list;
        }
        private class Geoloc
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        private class AirportFromJson
        {
            public string name { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string iata_code { get; set; }
            public Geoloc _geoloc { get; set; }
            public int links_count { get; set; }
            public string objectID { get; set; }
        }
    }
}
