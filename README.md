# Iron Dome System Simulation

## Overview
This project implements a sophisticated missile trajectory simulation system, designed to model and analyze ballistic missile paths with high precision. The system incorporates advanced mathematical models for various flight phases, geographic calculations, and real-time trajectory analysis.

## Core Components

### Missile Flight Physics
- **Powered Flight Phase**: Implementation of thrust-driven initial launch phase
- **Ballistic Flight Phase**: Mathematical modeling of unpowered flight trajectories
- **Geographic Calculations**: Real-world coordinate system integration
- **Real-time Position Tracking**: 3D position monitoring (X, Y, Z coordinates)

### Mathematical Models
The system implements complex mathematical formulas for:
- Trajectory calculations in 3D space
- Atmospheric effects consideration
- Geographic coordinate transformations
- Velocity and acceleration vectors
- Flight phase transitions

### Key Features
- **Advanced Missile Configuration**:
  - Configurable initial acceleration
  - Adjustable launch parameters
  - Geographic positioning (Latitude/Longitude)
  - Custom flight characteristics
- **Real-time Simulation**:
  - Live trajectory updates
  - Flight phase monitoring
  - Position tracking
  - Time-based calculations
- **Modular Architecture**:
  - Separate flight phase calculations
  - Extensible design patterns
  - Clean separation of concerns

## Technical Architecture

### Project Structure
```
IromDomeSystem/
├── Program.cs                        # Application entry point
├── MissileSimulation.cs             # Core simulation controller
├── Mathematical formulas/           # Mathematical computation modules
│   ├── MissileCalculation.cs       # Main calculation engine
│   ├── PoweredFlight.cs            # Powered phase calculations
│   ├── BallisticFlight.cs          # Ballistic phase calculations
│   ├── GeographicFlightCalculation.cs # Geographic transformations
│   ├── MathematicalFormulas.cs     # Core mathematical functions
│   ├── Print.cs                    # Output formatting
│   ├── FlightSnapshot.cs           # Flight state management
│   └── IFlightPhase.cs            # Flight phase interface
└── Missile/                        # Missile configuration
    └── Missile.cs                  # Missile properties and builder
```

### Design Patterns
- **Builder Pattern**: Flexible missile configuration
- **Strategy Pattern**: Interchangeable flight phases
- **Interface Segregation**: Clean separation of flight phase calculations
- **Dependency Injection**: Modular component design

## Technical Requirements
- **.NET Framework**: .NET Core SDK 6.0 or higher
- **Development Environment**: 
  - Visual Studio 2019/2022
  - Windows 10/11
- **Required NuGet Packages**: 
  - System.Threading
  - System.Math.Numerics (for complex calculations)

## Setup and Installation

### Development Setup
1. Clone the repository:
```bash
git clone https://github.com/yourusername/IromDomeSystem.git
cd IromDomeSystem
```

2. Open in Visual Studio:
```
IromDomeSystem.sln
```

3. Restore NuGet packages:
```bash
dotnet restore
```

4. Build the solution:
```bash
dotnet build
```

### Running the Simulation
1. Build and run the project in Visual Studio (F5)
2. Or via command line:
```bash
dotnet run
```

## Usage Example

```csharp
// Initialize missile with specific parameters
Missile missile = new Missile.Builder()
    .SetAcceleration(0)           // Initial acceleration
    .SetTimeAcceleration(5)       // Acceleration duration
    .SetLanunchAngle(45)          // Launch angle in degrees
    .SetGeographicAngle(50)       // Geographic orientation
    .SetLatitude(31.497642435306812)   // Launch position latitude
    .SetLongitude(34.447034780157175)  // Launch position longitude
    .Build();

// Run the simulation
MissileSimulation.Run(missile);
```

## Mathematical Models

The system implements several key mathematical models:
- Ballistic trajectory calculations
- Powered flight equations
- Geographic coordinate transformations
- Atmospheric resistance models
- Vector calculations in 3D space

## Contributing
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## Testing
- Unit tests for mathematical calculations
- Integration tests for flight phases
- System tests for full trajectory simulations

## License
This project is proprietary and confidential. All rights reserved.

## Authors and Acknowledgment
- Core Development Team
- Mathematical Models Contributors
- Testing Team

## Support and Contact
For technical support or inquiries:
- Open an issue in the repository
- Contact the development team
- Check documentation for common issues

## Project Status
Active development - Regular updates and improvements 