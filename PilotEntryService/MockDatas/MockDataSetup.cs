//using Moq;
//using PilotEntryService.Models.Entities;
//using PilotEntryService.Repositories.Interfaces;

//namespace PilotEntryService.MockDatas
//{
//    // Mock Data Setup
//    public class MockDataSetup
//    {
//        public static Mock<ITripLogRepository> GetMockTripLogRepository()
//        {
//            var mockRepo = new Mock<ITripLogRepository>();

//            var tripLogs = new List<TripLog>
//        {
//            new TripLog
//            {
//                Id = 1,
//                FlightNumber = "AB123",
//                AircraftRegistration = "N12345",
//                PilotId = "P001",
//                DepartureTime = DateTime.UtcNow.AddHours(-5),
//                ArrivalTime = DateTime.UtcNow,
//                DepartureAirport = "JFK",
//                DestinationAirport = "LAX",
//                Remarks = "Smooth flight",
//                DeAntiIcingData = new De_Anti_IcingData
//                {
//                    Id = 1,
//                    FluidType = (int)FluideType.Type1,
//                    MixtureRatio = "50/50",
//                    Time = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(-4))
//                },
//                FuelData = new FuelData
//                {
//                    Id = 1,
//                    ParkingFuel = 1000,
//                    RevisedParkingFuel = 950,
//                    PlannedUplift = 500,
//                    ActualUplift = 480,
//                    FuelOnBoard = 1500,
//                    UpliftInLiters = 600
//                },
//                Inspection = new Inspection
//                {
//                    Id = 1,
//                    PreFlightInspectionCompleted = true,
//                    PostFlightInspectionCompleted = true
//                }
//            },
//            new TripLog
//            {
//                Id = 2,
//                FlightNumber = "CD456",
//                AircraftRegistration = "N54321",
//                PilotId = "P002",
//                DepartureTime = DateTime.UtcNow.AddHours(-8),
//                ArrivalTime = DateTime.UtcNow.AddHours(-3),
//                DepartureAirport = "ORD",
//                DestinationAirport = "ATL",
//                Remarks = "Turbulence en route",
//                DeAntiIcingData = new De_Anti_IcingData
//                {
//                    Id = 2,
//                    FluidType = (int)FluideType.Type2,
//                    MixtureRatio = "60/40",
//                    Time = TimeOnly.FromDateTime(DateTime.UtcNow.AddHours(-7))
//                },
//                FuelData = new FuelData
//                {
//                    Id = 2,
//                    ParkingFuel = 1200,
//                    RevisedParkingFuel = 1150,
//                    PlannedUplift = 600,
//                    ActualUplift = 580,
//                    FuelOnBoard = 1700,
//                    UpliftInLiters = 720
//                },
//                Inspection = new Inspection
//                {
//                    Id = 2,
//                    PreFlightInspectionCompleted = true,
//                    PostFlightInspectionCompleted = false
//                }
//            }
//        };

//            mockRepo.Setup(repo => repo.GetAllTripLogsAsync()).ReturnsAsync(tripLogs);
//            mockRepo.Setup(repo => repo.GetTripLogByIdAsync(It.IsAny<int>()))
//                .ReturnsAsync((int id) => tripLogs.FirstOrDefault(t => t.Id == id));
//            mockRepo.Setup(repo => repo.AddTripLogAsync(It.IsAny<TripLog>()))
//                .Callback<TripLog>(tripLog => tripLogs.Add(tripLog));
//            mockRepo.Setup(repo => repo.UpdateTripLogAsync(It.IsAny<TripLog>()))
//                .Callback<TripLog>(tripLog =>
//                {
//                    var existingTripLog = tripLogs.FirstOrDefault(t => t.Id == tripLog.Id);
//                    if (existingTripLog != null)
//                    {
//                        tripLogs.Remove(existingTripLog);
//                        tripLogs.Add(tripLog);
//                    }
//                });
//            mockRepo.Setup(repo => repo.DeleteTripLogAsync(It.IsAny<int>()))
//                .Callback<int>(id =>
//                {
//                    var tripLog = tripLogs.FirstOrDefault(t => t.Id == id);
//                    if (tripLog != null)
//                    {
//                        tripLogs.Remove(tripLog);
//                    }
//                });

//            return mockRepo;
//        }
//    }

//}
