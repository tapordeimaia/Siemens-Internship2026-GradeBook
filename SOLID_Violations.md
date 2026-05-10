\# SOLID Violations \& Code Review



\## 1. Single Responsibility Principle (SRP) Violation

\* \*\*Where:\*\* `Controllers/ItemController.cs` (Lines 16-25 \& throughout)

\* \*\*Why:\*\* The controller is taking on too many responsibilities. It handles HTTP requests/responses, performs direct logging to the console (`Console.WriteLine`), and contains business logic (calculating `TotalCount` and `AverageValue`). A controller should only handle routing and delegating work.

\* \*\*Fix:\*\* 1. Renamed all `Item` references to `Grade` for domain accuracy.

&#x20; 2. Extracted the business logic (statistics calculation) into a dedicated Service Layer (`GradeService`).

&#x20; 3. Replaced `Console.WriteLine` with the built-in .NET `ILogger` interface injected via Dependency Injection.



\## 2. Open/Closed Principle (OCP) / Dependency Inversion Principle (DIP) Violation

\* \*\*Where:\*\* `Repositories/ItemRepository.cs`

\* \*\*Why:\*\* The repository hardcodes an in-memory list (`\_items`). If the data source changes (which it does in this assignment), the class has to be modified. It relies on concrete internal data rather than an abstraction for fetching data.

\* \*\*Fix:\*\* Refactored the repository to rely on `HttpClient` to fetch data from an external API, making the system extensible to external data sources without modifying the core domain logic.

