# StockApp - ASP.NET Core MVC Stock Trading Application

## ✨ Overview

StockApp is a real-time stock trading web application built using **ASP.NET Core MVC**. It allows users to:

* Browse popular stocks (via **Finnhub API**)
* View company profiles & live price quotes
* Place **Buy** and **Sell** orders
* View their order history
* Export trades as **PDF reports** using Rotativa

The app follows a clean layered architecture: Controllers → Services → Repositories, with proper separation of concerns.

---

## 🚀 Features

* ✔ Explore top 25 stocks or all stocks
* ✔ View stock quotes and company profile
* ✔ Create Buy/Sell orders
* ✔ List historical orders
* ✔ Export orders to PDF (using Rotativa)
* ✔ Validations and error handling via ModelState
* ✔ Options pattern for configuration binding

---

## 🔧 Technologies Used

| Layer             | Technologies                       |
| ----------------- | ---------------------------------- |
| Backend Framework | ASP.NET Core MVC                   |
| Data Access       | Entity Framework Core + SQL Server |
| API Integration   | HttpClient (Finnhub API)           |
| Configuration     | Options pattern                    |
| PDF Generator     | Rotativa.AspNetCore (wkhtmltopdf)  |
| Design Pattern    | Repository + Dependency Injection  |

---

## 🗂️ Project Structure

```
StockApp/
├── FinnhubStockApp/         # MVC Web App
│   ├── Controllers/         # StocksController, TradeController
│   ├── Models/              # ViewModels: Stock, Orders, StockTrade
│   ├── Views/               # Razor Views for MVC
│   ├── TradingOptions.cs    # App config model for top stocks
│   └── Program.cs           # App startup and service registration
│
├── Entities/                # EF Models: BuyOrder, SellOrder
├── Repositories/            # Implementation of Repos
├── RepositoryContracts/     # Repo Interfaces
├── Services/                # Business logic (StocksService, FinnhubService)
├── ServiceContracts/        # DTOs & Interfaces (IStocksService, IFinnhubService)
│   └── DTO/
│       ├── BuyOrderRequest.cs
│       ├── SellOrderRequest.cs
│       ├── BuyOrderResponse.cs
│       ├── SellOrderResponse.cs
│       └── IOrderResponse.cs
└── StockApp.sln             # Visual Studio solution file
```

---

## ⚙️ Configuration Setup

### 1. `appsettings.json`

```json
"FinnhubToken": "your_finnhub_api_token",
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=StockMarketDb;Trusted_Connection=True;"
}
```

### 2. Trading Options

`TradingOptions.cs` binds config using `Options pattern`:

```json
"TradingOptions": {
  "DefaultStockSymbol": "MSFT",
  "DefaultOrderQuantity": 5,
  "Top25PopularStocks": "MSFT,AAPL,GOOGL,..."
}
```

### 3. Registering Services - `Program.cs`

```csharp
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddTransient<IStocksService, StocksService>();
builder.Services.AddTransient<IFinnhubService, FinnhubService>();
builder.Services.AddDbContext<ApplicationDbContext>(...);
```

---

## 📆 Entity Definitions

### `BuyOrder` / `SellOrder`

Stored via EF Core in `ApplicationDbContext.cs`:

```csharp
public DbSet<BuyOrder> BuyOrders { get; set; }
public DbSet<SellOrder> SellOrders { get; set; }
```

Tables: `BuyOrders`, `SellOrders`

---

## 📖 Use Cases

### ✏️ TradeController

* `Index()` - Fetches stock quote + profile
* `BuyOrder(SellOrderRequest)` - Places a buy order
* `SellOrder(BuyOrderRequest)` - Places a sell order
* `Orders()` - Shows order history
* `OrdersPDF()` - Generates PDF of orders using Rotativa

### ⚖️ StocksController

* `Explore()` - Lists top 25 or all stocks based on query

---

## 📊 Services

### `StocksService`

* Create/Fetch orders from repository
* Validates & maps DTOs to Entities

### `FinnhubService`

* Calls repository methods to:

  * Get stock quote
  * Get company profile
  * Search stocks

---

## 🗲 Database & EF Core

* Tables are created using migrations

```bash
dotnet ef migrations add Initial

dotnet ef database update
```

---

## 🗒️ PDF Generation

* `Rotativa.AspNetCore` used in `OrdersPDF` action
* Converts Razor View to downloadable PDF:

```csharp
return new ViewAsPdf("OrdersPDF", orders)
{
    PageOrientation = Orientation.Landscape
};
```

---

## 📘 License

MIT License. Free for use.

---

## 🙌 Author

**Hrishikesh Korgaonkar** .NET Developer | Mumbai

---



