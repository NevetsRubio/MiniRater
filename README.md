# MiniRater
A simplified rating engine and quote API.

## Pojects Included in this repo

### MiniRater.API
Single Controller with a single endpoint for a POST (`/Rate/Get-Total-Premium`).

#### Accepts a payload like:
```
{
    revenue: [Double],
    state: [string],
    business: [string]
}
```
Based on the information provided for this project, there are only some valid strings that can be provided for State/Business, at least for the moment.

| State |
|-------|
| "OH"  |
| "FL"  |
| "TX"  |

| Business     |
|--------------|
| "Architect"  |
| "Plumber"    |
| "Programmer" |

#### Returns response like:
```
{
    Premium: [Double]
}
```

### MiniRater.BL
- A few Dtos (Date Transfer Object)
  - BusinessFactorDto
  - PremiumRequestDto
  - PremiumResponseDto
  - StateFactorDto
  
> I am considering to change this to be just a `FactorDto` with an additional prop for tracking the type (`FactorType`) of factor (Business, State, Hazard). That way I can get rid of `BusinessFactorDto`, `StateFactorDto`, remove the consant `HazardFactor` from _Resources.cs_, and make this program more scalable for future types of Factors. If I can make time for adding a DB, I will most likely do this.

`RateService` is implementing the definition(s) in `IRateService`. There is only one public function that the service has.

> There is an internal function, which I was planning on writing a unit test for but I will need to figure out how to write tests for internal functions. Which I may not get to.

> Currently using a switch statement for this but would ideally have these details stored in a db and queried for. This is a rough idea of what I had in mind for a better (more realistic) implementation.
> ```csharp
>  public async Task<PremiumResponseDto> GetTotalPremium(PremiumRequestDto premiumRequestDto)
>  {
>   // ...
>   FactorDto businessFactor = _context.Factors
>     .Where(factor => factor.FactorType == Resources.BusinessTypeString && factor.FactorName == premiumRequestDto.Business).FirstOrDefault();
>     
>   if (businessFactor == null)
>   {
>     throw new Exception(Resources.CouldNotFindBusinessError);
>   }
>  
>   // ...
>  }
> ```
> Which this would definitely require more things to be added in _Resources.cs_ and the actual EF Core setup, of course.

`Resources.cs` is for constants that may be reused later.
> Will need to add error messages later when I go back to refactor.
### MiniRater.BL.Tests
Project dedicated for tests. As of right now I only have a single unit test, which only runs a theory of the example provided in the instructions.
> There is a common naming scheme for tests, which I will look into later.
> I will add tests for expected failures, which means that I will need to add some more validations in the RateService when I refactor.

## Running and Testing
- Clone the Repo
- Open the project with Visual Studio
- Run MiniRater.API
- I would suggest using the Swagger UI to test different payloads.
  - http://localhost:5000/swagger/index.html

## What I would do next
Based on some of the information provided, I am thinking of adding a DB for storing the different values for different state and business values. Would make it easier for managing later for when more states and businesses need to be added, and much cleaning in the business logic.

For a more detailed description of what I would have done to improve this, please refer to the blockquotes in this _README.md_. I originally started writing the the blockquotes to remind myself what I plan on doing later so it may be worded funny in some places. But it should give a good idea of what I had in mind for this.


## Deliverables Checklist
- [X] API written in .NET Core
- [X] API accepts `POST` and returns data per above requirements
- [X] Repo README has instructions for running and testing the API
- [X] Repo README has information about what you'd do next, per above requirements
