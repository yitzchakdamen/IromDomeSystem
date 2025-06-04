# Iron Dome System Simulation

## Overview
This project is a simulation system for missile trajectory calculations and interception scenarios, implemented in C#. It provides a mathematical model for missile behavior, taking into account various physical parameters and geographical coordinates.

## Features
- Missile trajectory calculation
- Configurable missile parameters:
  - Acceleration
  - Launch angle
  - Geographic angle
  - GPS coordinates (Latitude/Longitude)
- Real-time simulation capabilities
- Mathematical modeling of missile physics

## Project Structure
```
IromDomeSystem/
├── Program.cs              # Main entry point
├── MissileSimulation.cs    # Simulation logic
├── Mathematical formulas/  # Mathematical calculations and formulas
└── Missile/               # Missile-related components
```

## Requirements
- .NET Core SDK
- Windows Operating System
- Visual Studio (recommended) or any C# compatible IDE

## Getting Started
1. Clone the repository:
```bash
git clone https://github.com/yourusername/IromDomeSystem.git
```

2. Open the solution in Visual Studio:
- Double click on `IromDomeSystem.sln` or
- Open Visual Studio and select `File > Open > Project/Solution`

3. Build and run the project:
- Press F5 to build and run
- Or use `dotnet run` from the command line

## Usage
The system allows you to configure missile parameters through the builder pattern:

```csharp
Missile missile = new Missile.Builder()
    .SetAcceleration(0)
    .SetTimeAcceleration(5)
    .SetLanunchAngle(45)
    .SetGeographicAngle(50)
    .SetLatitude(31.497642435306812)
    .SetLongitude(34.447034780157175)
    .Build();
```

## Contributing
Contributions are welcome! Please feel free to submit a Pull Request.

## License
This project is proprietary and confidential. All rights reserved.

## Contact
For any questions or concerns, please open an issue in the repository. 