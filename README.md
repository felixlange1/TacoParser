# Taco Parser 🌮📍  

A C# console application that parses a CSV file of Taco Bell locations and calculates the two locations that are geographically the furthest apart.

---

## 🧰 Features

- Parses latitude, longitude, and name from a CSV file.
- Uses geographic coordinates to calculate the distance between locations.
- Logs parsing steps and error handling via a custom logger.
- Includes **unit tests** using xUnit to ensure parsing accuracy.

---

## 🗂️ Technologies Used

- C# (.NET Core Console App)
- [GeoCoordinatePortable](https://www.nuget.org/packages/GeoCoordinatePortable/)
- xUnit for unit testing
- File I/O & LINQ
- Object-Oriented Programming principles

---

## 🚀 How It Works

1. The app reads all lines from `TacoBell-US-AL.csv`.
2. Each line is parsed into a location object (`ITrackable`) using the `TacoParser`.
3. It calculates the distance between every pair of locations.
4. It identifies and prints the two Taco Bell locations that are the furthest apart.

---

## 📄 Sample CSV Line

34.073638,-84.677017,Taco Bell Acwort...


Each line contains:
- **Latitude** (e.g., `34.073638`)
- **Longitude** (e.g., `-84.677017`)
- **Location name** (e.g., `Taco Bell Acwort...`)

---

## 📦 Project Structure

TacoParser/
├── Program.cs # Main application logic
├── TacoParser.cs # Parses CSV lines into TacoBell objects
├── TacoBell.cs # Implements ITrackable
├── Point.cs # Holds coordinates
├── TacoLogger.cs # Basic console logger
├── ITrackable.cs # Interface for locations
└── TacoBell-US-AL.csv # Input data


---

## 🧪 Unit Testing

Unit tests are written using **xUnit** in the `TacoParserTests` class to verify:
- The parser returns a non-null object.
- Latitude and longitude are parsed correctly.

### Sample Test

```csharp
[Theory]
[InlineData("34.073638,-84.677017,Taco Bell Acwort...", -84.677017)]
public void ShouldParseLongitude(string line, double expected)
{
    var parser = new TacoParser();
    var result = parser.Parse(line);
    Assert.Equal(expected, result.Location.Longitude);
}
```


---

## ▶️ Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed

### Run the App

```bash
git clone https://github.com/your-username/TacoParser.git
cd TacoParser
dotnet run
```

---

### Run Tests

```bash
cd TacoParser.Test
dotnet test
```

## 📋 Output Example

```The two TacoBells furthest apart are: Taco Bell Huntsville, Taco Bell Mobile
Their coordinates are: 34.730369, -86.586104, 30.695366, -88.039894
The distance is: 301.54 kilometers or 187.34 miles.
```


## 📝 License

This project is licensed under the [MIT License](LICENSE), originally provided by [TrueCoders](https://truecoders.io).