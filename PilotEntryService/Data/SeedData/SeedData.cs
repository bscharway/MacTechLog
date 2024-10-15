//using PilotEntryService.Models.Entities;

//namespace PilotEntryService.Data.SeedData
//{
//    public static class SeedData
//    {
//        public static void Initialize(PilotEntryContext context)
//        {
//            // Ensure database is created
//            context.Database.EnsureCreated();

//            if (!context.TripLogs.Any())
//            {
//                context.TripLogs.AddRange(
//                    new TripLog
//                    {
//                        FlightNumber = "AB123",
//                        AircraftRegistration = "N12345",
//                        PilotId = "P001",
//                        DepartureTime = DateTime.UtcNow.AddHours(-5),
//                        ArrivalTime = DateTime.UtcNow,
//                        DepartureAirport = "JFK",
//                        DestinationAirport = "LAX",
//                        Remarks = "Smooth flight",
//                        DeAntiIcingData = new De_Anti_IcingData
//                        {
//                            FluidType = (int)FluideType.Type1,
//                            MixtureRatio = "50/50",
//                            Time = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(-4))
//                        },
//                        FuelData = new FuelData
//                        {
//                            ParkingFuel = 1000,
//                            RevisedParkingFuel = 950,
//                            PlannedUplift = 500,
//                            ActualUplift = 480,
//                            FuelOnBoard = 1500,
//                            UpliftInLiters = 600
//                        },
//                        Inspection = new Inspection
//                        {
//                            PreFlightInspectionCompleted = true,
//                            PostFlightInspectionCompleted = true
//                        }
//                    }
//                // Add more TripLog instances as needed.
//                );

//                context.SaveChanges();
//            }
//        }
//    }


//}
