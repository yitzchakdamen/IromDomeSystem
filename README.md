# Iron Dome System - מערכת כיפת ברזל

## סקירה כללית - Overview
מערכת סימולציה מתקדמת לחישוב ומעקב אחר מסלולי טילים, המיועדת לשימוש במערכת כיפת ברזל. המערכת מספקת חישובים מדויקים של מסלולי טיסה, נקודות יירוט, ומיקומים גיאוגרפיים בזמן אמת.

This advanced simulation system calculates and tracks missile trajectories for the Iron Dome defense system. The system provides precise calculations of flight paths, interception points, and real-time geographic locations.

## ארכיטקטורת המערכת - System Architecture

### מבנה הפרויקט - Project Structure
```
IromDomeSystem/
├── Program.cs                        # נקודת כניסה לתוכנית
├── MissileSimulation.cs             # בקר סימולציה ראשי
├── Mathematical formulas/           # מודולי חישוב מתמטיים
│   ├── MissileCalculation.cs       # מנוע החישובים הראשי
│   ├── PoweredFlight.cs            # חישובי שלב הטיסה המונעת
│   ├── BallisticFlight.cs          # חישובי שלב הטיסה הבליסטית
│   ├── GeographicFlightCalculation.cs # המרות קואורדינטות גיאוגרפיות
│   ├── MathematicalFormulas.cs     # פונקציות מתמטיות בסיסיות
│   ├── Print.cs                    # עיצוב פלט
│   ├── FlightSnapshot.cs           # ניהול מצב טיסה
│   └── IFlightPhase.cs            # ממשק שלבי טיסה
└── Missile/                        # הגדרות טיל
    └── Missile.cs                  # מאפייני טיל ובנייה
```

### רכיבים עיקריים - Main Components

#### 1. MissileCalculation - חישובי טיל
- חישוב מסלול טיסה מלא
- מעקב אחר מיקום בזמן אמת
- חיזוי נקודת פגיעה
- המרת קואורדינטות גיאוגרפיות

#### 2. Flight Phases - שלבי טיסה
##### Powered Flight - טיסה מונעת
- חישוב תאוצה ראשונית
- מעקב אחר מהירות וכיוון
- חישוב זמן שלב ההאצה

##### Ballistic Flight - טיסה בליסטית
- חישוב מסלול בליסטי
- התחשבות בכוח הכבידה
- חיזוי מסלול ונקודת נחיתה

#### 3. Geographic Calculations - חישובים גיאוגרפיים
- המרה בין קואורדינטות קרטזיות לגיאוגרפיות
- חישוב מרחקים גיאוגרפיים
- מעקב אחר מיקום בזמן אמת

## מודלים מתמטיים - Mathematical Models

### חישובי מסלול - Trajectory Calculations
```math
x(t) = x₀ + v₀ₓt + ½at²   // מיקום אופקי
y(t) = y₀ + v₀ᵧt - ½gt²   // מיקום אנכי
v(t) = √(vₓ² + vᵧ²)       // מהירות כוללת
θ(t) = tan⁻¹(vᵧ/vₓ)       // זווית תנועה
```

### המרות גיאוגרפיות - Geographic Conversions
- חישובי מרחק על פני כדור הארץ
- המרת קואורדינטות גיאוגרפיות
- התחשבות בעקמומיות כדור הארץ

## דרישות טכניות - Technical Requirements

### דרישות מערכת - System Requirements
- **מערכת הפעלה**: Windows 10/11
- **.NET Framework**: .NET Core SDK 6.0 ומעלה
- **זיכרון**: מינימום 8GB RAM
- **מעבד**: Intel Core i5 ומעלה

### תלויות תוכנה - Software Dependencies
```xml
<dependencies>
    <dependency>
        <groupId>System.Threading.Tasks</groupId>
        <version>6.0.0</version>
    </dependency>
    <dependency>
        <groupId>System.Math.Numerics</groupId>
        <version>6.0.0</version>
    </dependency>
</dependencies>
```

## התקנה והפעלה - Setup and Installation

### התקנת הפרויקט - Project Setup
```bash
# Clone the repository
git clone https://github.com/yourusername/IromDomeSystem.git

# Navigate to project directory
cd IromDomeSystem

# Restore dependencies
dotnet restore

# Build the project
dotnet build
```

### הפעלת הסימולציה - Running the Simulation
```csharp
// יצירת אובייקט טיל עם פרמטרים ספציפיים
var missile = new Missile.Builder()
    .SetAcceleration(30.0)          // תאוצה התחלתית
    .SetTimeAcceleration(5.0)       // זמן האצה
    .SetLanunchAngle(45.0)          // זווית שיגור
    .SetGeographicAngle(50.0)       // כיוון גיאוגרפי
    .SetLatitude(31.497642435306812)  // קו רוחב
    .SetLongitude(34.447034780157175) // קו אורך
    .Build();

// הפעלת החישובים
var missileCalc = new MissileCalculation();
await missileCalc.CalculateMissile(missile);

// הרצת סימולציה בזמן אמת
for (double time = 0; time <= impactTime; time += 0.1)
{
    missileCalc.run(time);
    await Task.Delay(100); // עיכוב להדמיית זמן אמת
}
```

## פלט המערכת - System Output

### נתוני טיסה בזמן אמת - Real-time Flight Data
- מיקום נוכחי (X, Y)
- רכיבי מהירות (Vx, Vy)
- מהירות כוללת
- זווית תנועה
- קואורדינטות גיאוגרפיות
- מידע על נקודת פגיעה צפויה

### דוגמת פלט - Sample Output
```
Flight Status:
Position: X=1234.56m, Y=567.89m
Velocity: Vx=100.0m/s, Vy=-20.0m/s
Total Velocity: 102.0m/s
Angle: -11.3°

Geographic Location:
Latitude: 31.4976°N
Longitude: 34.4470°E
Location: Sderot, Israel

Impact Prediction:
Time to Impact: 15.3s
Impact Coordinates: 31.5012°N, 34.4523°E
```

## פיתוח ותחזוקה - Development and Maintenance

### תבניות עיצוב - Design Patterns
- **Builder Pattern**: בניית אובייקטי טיל
- **Strategy Pattern**: ניהול שלבי טיסה
- **Observer Pattern**: מעקב אחר שינויי מצב
- **Dependency Injection**: הזרקת תלויות

### בדיקות - Testing
- בדיקות יחידה למודלים מתמטיים
- בדיקות אינטגרציה לשלבי טיסה
- בדיקות מערכת לסימולציה מלאה

### ביצועים - Performance
- אופטימיזציה לחישובים מתמטיים
- ניהול זיכרון יעיל
- תמיכה בחישובים מקביליים

## תיעוד API - API Documentation

### MissileCalculation Class
```csharp
public class MissileCalculation
{
    // חישוב מסלול טיל
    public async Task CalculateMissile(Missile missile);
    
    // הרצת סימולציה בנקודת זמן
    public void run(double time);
    
    // חישוב זמן פגיעה
    public double? ImpactTime(IFlightPhase phase, double timeAcceleration);
}
```

### Missile Builder
```csharp
public class Missile
{
    public class Builder
    {
        public Builder SetAcceleration(double acceleration);
        public Builder SetTimeAcceleration(double time);
        public Builder SetLanunchAngle(double angle);
        public Builder SetGeographicAngle(double angle);
        public Builder SetLatitude(double latitude);
        public Builder SetLongitude(double longitude);
        public Missile Build();
    }
}
```

## אבטחה ובטיחות - Security and Safety

### אבטחת מידע - Data Security
- הצפנת נתונים רגישים
- בקרת גישה למערכת
- תיעוד פעולות משתמשים

### בטיחות מערכת - System Safety
- בדיקות תקינות קלט
- טיפול בשגיאות
- גיבוי נתונים

## תמיכה ועזרה - Support and Help

### פתרון בעיות נפוצות - Common Issues
- בעיות התקנה
- שגיאות חישוב
- בעיות ביצועים

### יצירת קשר - Contact
- פתיחת issue במערכת
- פנייה לצוות הפיתוח
- תיעוד טכני מפורט

## סטטוס פרויקט - Project Status
- בפיתוח פעיל
- עדכונים שוטפים
- שיפורים מתמשכים

## רישיון - License
כל הזכויות שמורות © 2024