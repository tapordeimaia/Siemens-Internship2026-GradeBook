# Siemens Internship 2026 - .NET Developer Trainee Assignment

**Author:** Maia Tapordei

## Overview
This repository contains the completed technical assessment for the .NET Developer Trainee position at Siemens. The original ASP.NET Core 8 Web API project has been fully refactored, upgraded, and enhanced to meet all assignment requirements.

## Tasks Completed

### 1. Framework Upgrade
* Successfully upgraded the project target framework from **.NET 8** to **.NET 10**.

### 2. SOLID Principles & Code Review
* Refactored the codebase to adhere to SOLID principles (specifically addressing SRP and DIP violations).
* Renamed domain models from `Item` to `Grade` to better reflect the GradeBook context.
* *A detailed breakdown of all identified violations and applied fixes can be found in the [`SOLID_Violations.md`](./SOLID_Violations.md) file.*

### 3. Service Layer Implementation
* Introduced a dedicated `GradeService` to encapsulate business logic.
* Implemented a filter endpoint (`/api/grade/passing/{n}`) that retrieves the top *N* grades meeting the criteria:
  * The grade is active.
  * The grade is a passing grade (value >= 5).

### 4. Repository Refactoring
* Replaced the hardcoded in-memory data source with a dynamic implementation.
* Utilized `HttpClient` via Dependency Injection to fetch live JSON data from the provided external GitHub Gist endpoint.
* Handled JSON deserialization mapping to correctly parse the remote data structure.
