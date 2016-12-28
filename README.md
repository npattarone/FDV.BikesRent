## Summary

This small class library contains the base model for a basic Bikes Rent. The business rules are:

1. Rental by hour, charging $5 per hour
2. Rental by day, charging $20 a day
3. Rental by week, changing $60 a week
4. Family Rental, is a promotion that can include from 3 to 5 Rentals (of any type) with a discount of 30% of the total price

## General Design

I decided to use Strategy Pattern to model 2 types of strategy to calculate total price for every rent. I choose **CommonRent**, that includes Rental by Hour, by Week and by Day; and **FamilyRent** that has a collection of CommonRent. Due that price calculation for any CommonRent has no particular specification, only price * [amount_of_time] I decided to use a basic Enum type to categorize them.
But for FamilyRent, there is a collection of CommonRent so I need to loop through it and calculate each individual set of price * [amount_of_time], so I need a different Strategy verb.

As Strategy Pattern sugest, there is an abstract class that contains all methods that are going to be different, depeding on which element is going to use it. In this case, there are 2: CalculateTotal() and a AddRent(). Due that I needed to define an equal base structure for this abstract class, I decided to use a collection of Rents that will contain only one Rent in the CommonRent case, and over 3 and under 5 CommonRents for FamilyRent case.

I use a Rent class to define basic properties for a Rent, such as Time, Price and RentType.

## Tests

Tests were written to cover happy and alternative paths. The have a coverage of %. By running [Code Coverage Tool from Visual Studio](https://msdn.microsoft.com/en-us/library/dd537628.aspx) you can check it on your own.

The basic modeling structure was "originated" by writing the first Tests with TDD. By describing the basic rules needed to be covered by the code, the first classes and properties appeared. But, it's well known that and excesive use of TDD causes you to lose sight of the overall design of the modeling model.

To run them, this [site](https://www.visualstudio.com/en-us/docs/test/developer-testing/getting-started/getting-started-with-developer-testing#run-unit-tests-with-test-explorer) provides a good step-by-step procedure.
